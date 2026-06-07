using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Application.Pos;
using Mansis.Pos.Application.Loyalty;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Pos;

public sealed class PosServiceTests
{
    private static readonly Guid CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    private static readonly Guid PosId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    private static readonly Guid CustomerId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    private static readonly Guid ProductId = Guid.Parse("44444444-4444-4444-4444-444444444444");
    private static readonly Guid RewardId = Guid.Parse("55555555-5555-5555-5555-555555555555");

    [Fact]
    public async Task IdentifyCustomerAsync_WithToken_ConsumesQrToken()
    {
        var customer = new IdentifiedCustomerDto(CustomerId, "Ada", "Lovelace", "555", "ada@example.test", 25m, 40, 100, null, null);
        var store = new FakePosStore { IdentifiedCustomer = customer };
        var service = CreateService(store);

        var result = await service.IdentifyCustomerAsync(new IdentifyCustomerRequest(CompanyId, "qr-token", null));

        Assert.True(result.IsSuccess);
        Assert.Equal(CustomerId, result.Value!.CustomerId);
        Assert.True(store.LastIdentifyConsume);
    }

    [Fact]
    public async Task PreviewLoyaltyAsync_WithEligibleCart_ReturnsEarnPointsCampaignsAndRewards()
    {
        var store = new FakePosStore
        {
            PreviewSnapshot = new OrderCreationSnapshot(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new Dictionary<Guid, ProductStockSnapshot>
                {
                    [ProductId] = new(ProductId, Guid.NewGuid(), true, false, 10)
                },
                new Dictionary<Guid, DiscountSnapshot>(),
                new WalletAccount { CompanyId = CompanyId, CustomerId = CustomerId, Balance = 0m },
                new LoyaltyAccount { CompanyId = CompanyId, CustomerId = CustomerId, PointBalance = 60, LifetimePoints = 60 },
                [
                    new EarnRule
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = CompanyId,
                        Name = "Ten per point",
                        AmountPerPoint = 10m,
                        MinimumOrderTotal = 20m,
                        Scope = EarnRuleScope.All,
                        Active = true
                    }
                ],
                [],
                [
                    new Campaign
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = CompanyId,
                        Name = "Five off",
                        CampaignType = CampaignType.DiscountAmount,
                        RuleJson = """{"minOrderTotal":20,"discountAmount":5}""",
                        Priority = 10,
                        Active = true
                    },
                    new Campaign
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = CompanyId,
                        Name = "Bonus points",
                        CampaignType = CampaignType.ExtraPoints,
                        RuleJson = """{"minOrderTotal":20,"extraPoints":7}""",
                        Priority = 10,
                        Active = true
                    }
                ]),
            Rewards =
            [
                new Reward
                {
                    Id = RewardId,
                    CompanyId = CompanyId,
                    Name = "Coffee reward",
                    RequiredPoints = 50,
                    RewardType = RewardType.DiscountAmount,
                    DiscountAmount = 10m,
                    Active = true
                }
            ]
        };
        var service = CreateService(store);

        var result = await service.PreviewLoyaltyAsync(new LoyaltyPreviewRequest(
            CompanyId,
            PosId,
            CustomerId,
            [new LoyaltyPreviewLine(ProductId, 2, 20m)]));

        Assert.True(result.IsSuccess);
        Assert.Equal(40m, result.Value!.GrossTotal);
        Assert.Equal(5m, result.Value.CampaignDiscount);
        Assert.Equal(35m, result.Value.FinalTotal);
        Assert.Equal(3, result.Value.EarnPoints);
        Assert.Equal(7, result.Value.CampaignExtraPoints);
        Assert.Equal(["Five off", "Bonus points"], result.Value.AppliedCampaigns);
        var reward = Assert.Single(result.Value.AvailableRewards);
        Assert.Equal(RewardId, reward.RewardId);
    }

    private static PosService CreateService(FakePosStore store)
    {
        return new PosService(
            store,
            new IssueCustomerCardTokenValidator(),
            new IdentifyCustomerValidator(),
            new LoyaltyPreviewValidator(),
            new LoyaltyEarnCalculator(),
            new CampaignEvaluator());
    }

    private sealed class FakePosStore : IPosStore
    {
        public IdentifiedCustomerDto? IdentifiedCustomer { get; init; }
        public bool? LastIdentifyConsume { get; private set; }
        public OrderCreationSnapshot? PreviewSnapshot { get; init; }
        public IReadOnlyList<Reward> Rewards { get; init; } = [];

        public Task<PosProductCatalogResponse?> GetCatalogAsync(Guid companyId, Guid posId, CancellationToken cancellationToken)
        {
            return Task.FromResult<PosProductCatalogResponse?>(new PosProductCatalogResponse([]));
        }

        public Task<Customer?> GetCustomerAsync(Guid companyId, Guid customerId, CancellationToken cancellationToken)
        {
            return Task.FromResult<Customer?>(new Customer { Id = customerId, CompanyId = companyId });
        }

        public Task AddCustomerCardTokenAsync(CustomerCardToken token, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<IdentifiedCustomerDto?> IdentifyCustomerByTokenAsync(Guid companyId, string token, bool consume, CancellationToken cancellationToken)
        {
            LastIdentifyConsume = consume;
            return Task.FromResult(IdentifiedCustomer);
        }

        public Task<OrderCreationSnapshot?> LoadLoyaltyPreviewSnapshotAsync(
            Guid companyId,
            Guid posId,
            Guid customerId,
            IReadOnlyCollection<Guid> productIds,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(PreviewSnapshot);
        }

        public Task<IReadOnlyList<Reward>> ListAvailableRewardsAsync(Guid companyId, int pointBalance, CancellationToken cancellationToken)
        {
            return Task.FromResult(Rewards);
        }
    }
}
