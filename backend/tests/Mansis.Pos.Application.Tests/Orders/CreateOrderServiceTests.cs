using FluentValidation;
using Mansis.Pos.Application.Loyalty;
using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Orders;

public sealed class CreateOrderServiceTests
{
    private static readonly Guid CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    private static readonly Guid PosId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    private static readonly Guid UserId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    private static readonly Guid CustomerId = Guid.Parse("44444444-4444-4444-4444-444444444444");
    private static readonly Guid ProductId = Guid.Parse("55555555-5555-5555-5555-555555555555");
    private static readonly Guid StoreId = Guid.Parse("66666666-6666-6666-6666-666666666666");

    [Fact]
    public async Task CreateAsync_WithValidOrder_PersistsFullLedgerGraph()
    {
        var store = FakeOrderCreationStore.Ready();
        var service = CreateService(store);

        var result = await service.CreateAsync(ValidRequest());

        Assert.True(result.IsSuccess);
        var value = Assert.IsType<OrderResult>(result.Value);
        Assert.False(value.Existing);
        Assert.Equal(20m, value.Total);
        Assert.Equal(PaymentSummary.Cash, value.PaymentSummary);
        Assert.NotNull(store.SavedGraph);
        Assert.Single(store.SavedGraph.OrderProducts);
        Assert.Single(store.SavedGraph.OrderPayments);
        Assert.Single(store.SavedGraph.StockMovements);
        Assert.Single(store.SavedGraph.WalletTransactions);
        Assert.Single(store.SavedGraph.LoyaltyPointTransactions);
        Assert.Equal(8, store.SavedGraph.StoreProductsToUpdate[0].Quantity);
        Assert.Equal(80m, store.SavedGraph.WalletAccountToUpdate!.Balance);
        Assert.Equal(20, store.SavedGraph.LoyaltyAccountToUpdate!.PointBalance);
        Assert.Equal(20, store.SavedGraph.LoyaltyAccountToUpdate!.LifetimePoints);
    }

    [Fact]
    public async Task CreateAsync_WithEarnRuleAndTierMultiplier_AppliesConfiguredPoints()
    {
        var tier = new LoyaltyTier
        {
            Id = Guid.NewGuid(),
            CompanyId = CompanyId,
            Name = "Gold",
            MinimumPoints = 0,
            EarnMultiplier = 2m,
            Active = true
        };
        var store = FakeOrderCreationStore.Ready(
            earnRules:
            [
                new EarnRule
                {
                    Id = Guid.NewGuid(),
                    CompanyId = CompanyId,
                    Name = "Ten per point",
                    AmountPerPoint = 10m,
                    MinimumOrderTotal = 20m,
                    Scope = EarnRuleScope.All,
                    ExpiryDays = 30,
                    Active = true
                }
            ],
            loyaltyTiers: [tier],
            loyaltyTierId: tier.Id);
        var service = CreateService(store);

        var result = await service.CreateAsync(ValidRequest());

        Assert.True(result.IsSuccess);
        Assert.Single(store.SavedGraph!.LoyaltyPointTransactions);
        Assert.Equal(4, store.SavedGraph.LoyaltyPointTransactions[0].Points);
        Assert.NotNull(store.SavedGraph.LoyaltyPointTransactions[0].ExpiresAt);
        Assert.Equal(4, store.SavedGraph.LoyaltyAccountToUpdate!.PointBalance);
        Assert.Equal(4, store.SavedGraph.LoyaltyAccountToUpdate!.LifetimePoints);
    }

    [Fact]
    public async Task CreateAsync_WithRepeatedIdempotencyKey_ReturnsExistingOrderWithoutDuplicateGraph()
    {
        var existing = new Order
        {
            Id = Guid.NewGuid(),
            CompanyId = CompanyId,
            IdempotencyKey = "idem-001",
            Total = 42m,
            PaymentSummary = PaymentSummary.Mixed
        };
        var store = FakeOrderCreationStore.Ready(existing);
        var service = CreateService(store);

        var result = await service.CreateAsync(ValidRequest());

        Assert.True(result.IsSuccess);
        var value = Assert.IsType<OrderResult>(result.Value);
        Assert.True(value.Existing);
        Assert.Equal(existing.Id, value.OrderId);
        Assert.Null(store.SavedGraph);
    }

    [Fact]
    public async Task CreateAsync_WithInsufficientStock_FailsWithoutPersisting()
    {
        var store = FakeOrderCreationStore.Ready(stockQuantity: 1);
        var service = CreateService(store);

        var result = await service.CreateAsync(ValidRequest());

        Assert.False(result.IsSuccess);
        Assert.Equal("Insufficient stock.", result.Error);
        Assert.Null(store.SavedGraph);
    }

    [Fact]
    public async Task CreateAsync_WithInsufficientWalletBalance_FailsWithoutPersisting()
    {
        var store = FakeOrderCreationStore.Ready(walletBalance: 5m);
        var service = CreateService(store);

        var result = await service.CreateAsync(ValidRequest());

        Assert.False(result.IsSuccess);
        Assert.Equal("Insufficient wallet balance.", result.Error);
        Assert.Null(store.SavedGraph);
    }

    private static CreateOrderService CreateService(IOrderCreationStore store)
    {
        IValidator<CreateOrderRequest> validator = new CreateOrderValidator();
        return new CreateOrderService(validator, store, new LoyaltyEarnCalculator());
    }

    private static CreateOrderRequest ValidRequest()
    {
        return new CreateOrderRequest(
            CompanyId,
            PosId,
            UserId,
            CustomerId,
            ShippingType.Self,
            DateTimeOffset.UtcNow,
            "idem-001",
            [new CreateOrderLine(ProductId, 2, 10m)],
            [new CreateOrderPayment(PaymentType.Cash, 20m)]);
    }

    private sealed class FakeOrderCreationStore(
        Order? existingOrder,
        int stockQuantity,
        decimal walletBalance,
        IReadOnlyList<EarnRule> earnRules,
        IReadOnlyList<LoyaltyTier> loyaltyTiers,
        Guid? loyaltyTierId)
        : IOrderCreationStore
    {
        public OrderCreationGraph? SavedGraph { get; private set; }

        public static FakeOrderCreationStore Ready(
            Order? existingOrder = null,
            int stockQuantity = 10,
            decimal walletBalance = 100m,
            IReadOnlyList<EarnRule>? earnRules = null,
            IReadOnlyList<LoyaltyTier>? loyaltyTiers = null,
            Guid? loyaltyTierId = null)
        {
            earnRules ??=
            [
                new EarnRule
                {
                    Id = Guid.NewGuid(),
                    CompanyId = CompanyId,
                    Name = "Default",
                    AmountPerPoint = 1m,
                    Scope = EarnRuleScope.All,
                    Active = true
                }
            ];

            return new FakeOrderCreationStore(
                existingOrder,
                stockQuantity,
                walletBalance,
                earnRules,
                loyaltyTiers ?? [],
                loyaltyTierId);
        }

        public Task<Order?> FindByIdempotencyKeyAsync(
            Guid companyId,
            string idempotencyKey,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(existingOrder);
        }

        public Task<OrderCreationSnapshot> LoadSnapshotAsync(
            Guid companyId,
            Guid posId,
            Guid? customerId,
            IReadOnlyCollection<Guid> productIds,
            CancellationToken cancellationToken)
        {
            var snapshot = new OrderCreationSnapshot(
                StoreId,
                Guid.NewGuid(),
                new Dictionary<Guid, ProductStockSnapshot>
                {
                    [ProductId] = new ProductStockSnapshot(ProductId, Guid.NewGuid(), Stocktaking: true, stockQuantity)
                },
                new WalletAccount
                {
                    Id = Guid.NewGuid(),
                    CompanyId = CompanyId,
                    CustomerId = CustomerId,
                    Currency = "TRY",
                    Balance = walletBalance
                },
                new LoyaltyAccount
                {
                    Id = Guid.NewGuid(),
                    CompanyId = CompanyId,
                    CustomerId = CustomerId,
                    LoyaltyTierId = loyaltyTierId,
                    PointBalance = 0
                },
                earnRules,
                loyaltyTiers);

            return Task.FromResult(snapshot);
        }

        public Task AddOrderGraphAsync(OrderCreationGraph graph, CancellationToken cancellationToken)
        {
            SavedGraph = graph;
            return Task.CompletedTask;
        }
    }
}
