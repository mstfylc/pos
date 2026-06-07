using FluentValidation;
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
        return new CreateOrderService(validator, store);
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

    private sealed class FakeOrderCreationStore(Order? existingOrder, int stockQuantity, decimal walletBalance)
        : IOrderCreationStore
    {
        public OrderCreationGraph? SavedGraph { get; private set; }

        public static FakeOrderCreationStore Ready(
            Order? existingOrder = null,
            int stockQuantity = 10,
            decimal walletBalance = 100m)
        {
            return new FakeOrderCreationStore(existingOrder, stockQuantity, walletBalance);
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
                new Dictionary<Guid, ProductStockSnapshot>
                {
                    [ProductId] = new ProductStockSnapshot(ProductId, Stocktaking: true, stockQuantity)
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
                    PointBalance = 0
                });

            return Task.FromResult(snapshot);
        }

        public Task AddOrderGraphAsync(OrderCreationGraph graph, CancellationToken cancellationToken)
        {
            SavedGraph = graph;
            return Task.CompletedTask;
        }
    }
}
