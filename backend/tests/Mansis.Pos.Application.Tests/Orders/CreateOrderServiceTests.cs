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
    private static readonly Guid DiscountId = Guid.Parse("77777777-7777-7777-7777-777777777777");

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
    public async Task CreateAsync_WhenLifetimePointsCrossTierThreshold_UpgradesTier()
    {
        var silver = new LoyaltyTier
        {
            Id = Guid.NewGuid(),
            CompanyId = CompanyId,
            Name = "Silver",
            MinimumPoints = 10,
            EarnMultiplier = 1m,
            Active = true
        };
        var store = FakeOrderCreationStore.Ready(
            loyaltyLifetimePoints: 0,
            loyaltyTiers: [silver]);
        var service = CreateService(store);

        var result = await service.CreateAsync(ValidRequest());

        Assert.True(result.IsSuccess);
        Assert.Equal(silver.Id, store.SavedGraph!.LoyaltyAccountToUpdate!.LoyaltyTierId);
        Assert.Equal("Tier upgraded to Silver", store.SavedGraph.LoyaltyPointTransactions[0].Description);
    }

    [Fact]
    public async Task CreateAsync_WithEligibleCampaign_AppliesDiscountAndExtraPoints()
    {
        var store = FakeOrderCreationStore.Ready(
            campaigns:
            [
                new Campaign
                {
                    Id = Guid.NewGuid(),
                    CompanyId = CompanyId,
                    Name = "Five off",
                    CampaignType = CampaignType.DiscountAmount,
                    RuleJson = """{"minOrderTotal":20,"discountAmount":5}""",
                    Active = true
                },
                new Campaign
                {
                    Id = Guid.NewGuid(),
                    CompanyId = CompanyId,
                    Name = "Bonus points",
                    CampaignType = CampaignType.ExtraPoints,
                    RuleJson = """{"minOrderTotal":20,"extraPoints":7}""",
                    Active = true
                }
            ]);
        var service = CreateService(store);
        var request = new CreateOrderRequest(
            CompanyId,
            PosId,
            UserId,
            CustomerId,
            ShippingType.Self,
            DateTimeOffset.UtcNow,
            "idem-campaign",
            false,
            [new CreateOrderLine(ProductId, 2, 10m)],
            [new CreateOrderPayment(PaymentType.Cash, 15m)],
            []);

        var result = await service.CreateAsync(request);

        Assert.True(result.IsSuccess);
        Assert.Equal(15m, store.SavedGraph!.Order.Total);
        Assert.Equal(5m, store.SavedGraph.Order.TotalDiscount);
        Assert.Equal(2, store.SavedGraph.LoyaltyPointTransactions.Count);
        Assert.Contains(store.SavedGraph.LoyaltyPointTransactions, transaction => transaction.Points == 7);
        Assert.Equal(22, store.SavedGraph.LoyaltyAccountToUpdate!.PointBalance);
    }

    [Fact]
    public async Task CreateAsync_WithConflictingSameTypeCampaigns_AppliesHighestPriorityPerTypeAndDiscountCap()
    {
        var store = FakeOrderCreationStore.Ready(
            campaigns:
            [
                new Campaign
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    CompanyId = CompanyId,
                    Name = "Low priority discount",
                    CampaignType = CampaignType.DiscountAmount,
                    RuleJson = """{"minOrderTotal":20,"discountAmount":8}""",
                    Priority = 1,
                    Active = true
                },
                new Campaign
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    CompanyId = CompanyId,
                    Name = "High priority discount",
                    CampaignType = CampaignType.DiscountAmount,
                    RuleJson = """{"minOrderTotal":20,"discountAmount":12}""",
                    Priority = 10,
                    MaxTotalDiscount = 7m,
                    Active = true
                },
                new Campaign
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    CompanyId = CompanyId,
                    Name = "Low priority points",
                    CampaignType = CampaignType.ExtraPoints,
                    RuleJson = """{"minOrderTotal":20,"extraPoints":3}""",
                    Priority = 1,
                    Active = true
                },
                new Campaign
                {
                    Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    CompanyId = CompanyId,
                    Name = "High priority points",
                    CampaignType = CampaignType.ExtraPoints,
                    RuleJson = """{"minOrderTotal":20,"extraPoints":9}""",
                    Priority = 10,
                    Active = true
                }
            ]);
        var service = CreateService(store);
        var request = new CreateOrderRequest(
            CompanyId,
            PosId,
            UserId,
            CustomerId,
            ShippingType.Self,
            DateTimeOffset.UtcNow,
            "idem-campaign-conflict",
            false,
            [new CreateOrderLine(ProductId, 2, 10m)],
            [new CreateOrderPayment(PaymentType.Cash, 13m)],
            []);

        var result = await service.CreateAsync(request);

        Assert.True(result.IsSuccess);
        Assert.Equal(13m, store.SavedGraph!.Order.Total);
        Assert.Equal(7m, store.SavedGraph.Order.TotalDiscount);
        Assert.Equal(2, store.SavedGraph.LoyaltyPointTransactions.Count);
        Assert.Contains(store.SavedGraph.LoyaltyPointTransactions, transaction => transaction.Points == 9);
        Assert.DoesNotContain(store.SavedGraph.LoyaltyPointTransactions, transaction => transaction.Points == 3);
        Assert.Equal(22, store.SavedGraph.LoyaltyAccountToUpdate!.PointBalance);
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
    public async Task CreateAsync_WithOfflineOrder_SkipsStockQuantityCheck()
    {
        var store = FakeOrderCreationStore.Ready(stockQuantity: 1);
        var service = CreateService(store);
        var request = ValidRequest() with { OfflineOrder = true };

        var result = await service.CreateAsync(request);

        Assert.True(result.IsSuccess);
        Assert.True(store.SavedGraph!.Order.OfflineOrder);
    }

    [Fact]
    public async Task CreateAsync_WithManualDiscount_PersistsDiscountRows()
    {
        var store = FakeOrderCreationStore.Ready(
            discounts:
            [
                new DiscountSnapshot(
                    DiscountId,
                    MaxDiscountAmount: 100m,
                    UsedThisMonth: 0m,
                    AppliesToAll: true,
                    AppliesToBranch: false,
                    AppliesToPos: false,
                    AppliesToUser: false)
            ]);
        var service = CreateService(store);
        var request = ValidRequest() with
        {
            Discounts = [new CreateOrderDiscount(DiscountId, UserId, 5m)],
            Payments = [new CreateOrderPayment(PaymentType.Cash, 15m)]
        };

        var result = await service.CreateAsync(request);

        Assert.True(result.IsSuccess);
        Assert.Equal(15m, store.SavedGraph!.Order.Total);
        Assert.Equal(5m, store.SavedGraph.Order.TotalDiscount);
        Assert.Single(store.SavedGraph.OrderDiscounts);
        Assert.Single(store.SavedGraph.DiscountUsageLogs);
        Assert.Equal(DiscountId, store.SavedGraph.DiscountUsageLogs[0].DiscountId);
    }

    [Fact]
    public async Task CreateAsync_WithManualDiscountOverMonthlyLimit_FailsWithoutPersisting()
    {
        var store = FakeOrderCreationStore.Ready(
            discounts:
            [
                new DiscountSnapshot(
                    DiscountId,
                    MaxDiscountAmount: 10m,
                    UsedThisMonth: 9m,
                    AppliesToAll: true,
                    AppliesToBranch: false,
                    AppliesToPos: false,
                    AppliesToUser: false)
            ]);
        var service = CreateService(store);
        var request = ValidRequest() with
        {
            Discounts = [new CreateOrderDiscount(DiscountId, UserId, 5m)],
            Payments = [new CreateOrderPayment(PaymentType.Cash, 15m)]
        };

        var result = await service.CreateAsync(request);

        Assert.False(result.IsSuccess);
        Assert.Equal("Discount monthly limit exceeded.", result.Error);
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
        return new CreateOrderService(validator, store, new LoyaltyEarnCalculator(), new CampaignEvaluator());
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
            false,
            [new CreateOrderLine(ProductId, 2, 10m)],
            [new CreateOrderPayment(PaymentType.Cash, 20m)],
            []);
    }

    private sealed class FakeOrderCreationStore(
        Order? existingOrder,
        int stockQuantity,
        decimal walletBalance,
        IReadOnlyList<EarnRule> earnRules,
        IReadOnlyList<LoyaltyTier> loyaltyTiers,
        Guid? loyaltyTierId,
        int loyaltyLifetimePoints,
        IReadOnlyList<Campaign> campaigns,
        IReadOnlyDictionary<Guid, DiscountSnapshot> discounts)
        : IOrderCreationStore
    {
        public OrderCreationGraph? SavedGraph { get; private set; }

        public static FakeOrderCreationStore Ready(
            Order? existingOrder = null,
            int stockQuantity = 10,
            decimal walletBalance = 100m,
            IReadOnlyList<EarnRule>? earnRules = null,
            IReadOnlyList<LoyaltyTier>? loyaltyTiers = null,
            Guid? loyaltyTierId = null,
            int loyaltyLifetimePoints = 0,
            IReadOnlyList<Campaign>? campaigns = null,
            IReadOnlyList<DiscountSnapshot>? discounts = null)
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
                loyaltyTierId,
                loyaltyLifetimePoints,
                campaigns ?? [],
                (discounts ?? []).ToDictionary(discount => discount.DiscountId));
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
            Guid userId,
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
                discounts,
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
                    PointBalance = 0,
                    LifetimePoints = loyaltyLifetimePoints
                },
                earnRules,
                loyaltyTiers,
                campaigns);

            return Task.FromResult(snapshot);
        }

        public Task AddOrderGraphAsync(OrderCreationGraph graph, CancellationToken cancellationToken)
        {
            SavedGraph = graph;
            return Task.CompletedTask;
        }
    }
}
