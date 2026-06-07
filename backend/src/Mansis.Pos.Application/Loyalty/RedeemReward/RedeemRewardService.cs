using FluentValidation;
using Mansis.Pos.Application.Common;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Loyalty.RedeemReward;

public sealed class RedeemRewardService(
    IValidator<RedeemRewardRequest> validator,
    IRewardRedemptionStore store)
{
    public async Task<Result<RedeemRewardResult>> RedeemAsync(
        RedeemRewardRequest request,
        CancellationToken cancellationToken = default)
    {
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            return Result<RedeemRewardResult>.Failure(validation.Errors[0].ErrorMessage);
        }

        var snapshot = await store.LoadSnapshotAsync(
            request.CompanyId,
            request.CustomerId,
            request.RewardId,
            cancellationToken);

        if (snapshot is null)
        {
            return Result<RedeemRewardResult>.Failure("Reward or loyalty account not found.");
        }

        if (!snapshot.Reward.Active)
        {
            return Result<RedeemRewardResult>.Failure("Reward is not active.");
        }

        if (snapshot.LoyaltyAccount.PointBalance < snapshot.Reward.RequiredPoints)
        {
            return Result<RedeemRewardResult>.Failure("Insufficient loyalty points.");
        }

        var now = DateTimeOffset.UtcNow;
        var redemption = new RewardRedemption
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            CustomerId = request.CustomerId,
            RewardId = request.RewardId,
            OrderId = request.OrderId,
            Points = snapshot.Reward.RequiredPoints,
            RedemptionCode = CreateRedemptionCode(),
            State = RewardRedemptionState.Approved,
            RequestedAt = now
        };

        snapshot.LoyaltyAccount.PointBalance -= snapshot.Reward.RequiredPoints;
        var transaction = new LoyaltyPointTransaction
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            LoyaltyAccountId = snapshot.LoyaltyAccount.Id,
            OrderId = request.OrderId,
            TransactionType = LoyaltyPointTransactionType.Redeem,
            Points = -snapshot.Reward.RequiredPoints,
            State = LedgerEntryState.Posted,
            Description = $"Reward redemption {redemption.RedemptionCode}",
            OccurredAt = now
        };

        await store.AddRedemptionAsync(
            new RewardRedemptionGraph(redemption, transaction, snapshot.LoyaltyAccount),
            cancellationToken);

        return Result<RedeemRewardResult>.Success(new RedeemRewardResult(
            redemption.Id,
            redemption.RedemptionCode,
            transaction.Id,
            redemption.Points,
            snapshot.LoyaltyAccount.PointBalance,
            redemption.State));
    }

    private static string CreateRedemptionCode()
    {
        return "RW-" + Guid.NewGuid().ToString("N")[..10].ToUpperInvariant();
    }
}
