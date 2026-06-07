using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Loyalty.RedeemReward;

public sealed record RedeemRewardRequest(
    Guid CompanyId,
    Guid CustomerId,
    Guid RewardId,
    Guid? OrderId);

public sealed record RedeemRewardResult(
    Guid RedemptionId,
    string RedemptionCode,
    Guid LoyaltyTransactionId,
    int Points,
    int PointBalance,
    RewardRedemptionState State);
