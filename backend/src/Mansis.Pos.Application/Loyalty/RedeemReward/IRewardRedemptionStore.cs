using Mansis.Pos.Domain.Entities;

namespace Mansis.Pos.Application.Loyalty.RedeemReward;

public interface IRewardRedemptionStore
{
    Task<RewardRedemptionSnapshot?> LoadSnapshotAsync(
        Guid companyId,
        Guid customerId,
        Guid rewardId,
        CancellationToken cancellationToken);

    Task AddRedemptionAsync(RewardRedemptionGraph graph, CancellationToken cancellationToken);
}

public sealed record RewardRedemptionSnapshot(
    LoyaltyAccount LoyaltyAccount,
    Reward Reward);

public sealed record RewardRedemptionGraph(
    RewardRedemption Redemption,
    LoyaltyPointTransaction LoyaltyTransaction,
    LoyaltyAccount LoyaltyAccountToUpdate);
