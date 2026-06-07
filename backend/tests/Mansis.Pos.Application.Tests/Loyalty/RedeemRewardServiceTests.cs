using FluentValidation;
using Mansis.Pos.Application.Loyalty.RedeemReward;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Loyalty;

public sealed class RedeemRewardServiceTests
{
    private static readonly Guid CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    private static readonly Guid CustomerId = Guid.Parse("44444444-4444-4444-4444-444444444444");
    private static readonly Guid RewardId = Guid.Parse("55555555-5555-5555-5555-555555555555");

    [Fact]
    public async Task RedeemAsync_WithEnoughPoints_WritesRedemptionAndLedgerDebit()
    {
        var store = FakeRewardRedemptionStore.Ready(pointBalance: 50, requiredPoints: 25);
        var service = CreateService(store);

        var result = await service.RedeemAsync(new RedeemRewardRequest(CompanyId, CustomerId, RewardId, OrderId: null));

        Assert.True(result.IsSuccess);
        Assert.NotNull(store.SavedGraph);
        Assert.Equal(25, store.SavedGraph.Redemption.Points);
        Assert.Equal(RewardRedemptionState.Approved, store.SavedGraph.Redemption.State);
        Assert.StartsWith("RW-", store.SavedGraph.Redemption.RedemptionCode);
        Assert.Equal(LoyaltyPointTransactionType.Redeem, store.SavedGraph.LoyaltyTransaction.TransactionType);
        Assert.Equal(-25, store.SavedGraph.LoyaltyTransaction.Points);
        Assert.Equal(25, store.SavedGraph.LoyaltyAccountToUpdate.PointBalance);
    }

    [Fact]
    public async Task RedeemAsync_WithInsufficientPoints_FailsWithoutPersisting()
    {
        var store = FakeRewardRedemptionStore.Ready(pointBalance: 10, requiredPoints: 25);
        var service = CreateService(store);

        var result = await service.RedeemAsync(new RedeemRewardRequest(CompanyId, CustomerId, RewardId, OrderId: null));

        Assert.False(result.IsSuccess);
        Assert.Equal("Insufficient loyalty points.", result.Error);
        Assert.Null(store.SavedGraph);
    }

    private static RedeemRewardService CreateService(IRewardRedemptionStore store)
    {
        IValidator<RedeemRewardRequest> validator = new RedeemRewardValidator();
        return new RedeemRewardService(validator, store);
    }

    private sealed class FakeRewardRedemptionStore(RewardRedemptionSnapshot snapshot) : IRewardRedemptionStore
    {
        public RewardRedemptionGraph? SavedGraph { get; private set; }

        public static FakeRewardRedemptionStore Ready(int pointBalance, int requiredPoints)
        {
            return new FakeRewardRedemptionStore(new RewardRedemptionSnapshot(
                new LoyaltyAccount
                {
                    Id = Guid.NewGuid(),
                    CompanyId = CompanyId,
                    CustomerId = CustomerId,
                    PointBalance = pointBalance,
                    LifetimePoints = pointBalance
                },
                new Reward
                {
                    Id = RewardId,
                    CompanyId = CompanyId,
                    Name = "Free drink",
                    RequiredPoints = requiredPoints,
                    RewardType = RewardType.DiscountAmount,
                    Active = true
                }));
        }

        public Task<RewardRedemptionSnapshot?> LoadSnapshotAsync(
            Guid companyId,
            Guid customerId,
            Guid rewardId,
            CancellationToken cancellationToken)
        {
            return Task.FromResult<RewardRedemptionSnapshot?>(snapshot);
        }

        public Task AddRedemptionAsync(RewardRedemptionGraph graph, CancellationToken cancellationToken)
        {
            SavedGraph = graph;
            return Task.CompletedTask;
        }
    }
}
