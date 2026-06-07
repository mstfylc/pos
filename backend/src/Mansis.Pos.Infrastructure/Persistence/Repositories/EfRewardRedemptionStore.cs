using Mansis.Pos.Application.Loyalty.RedeemReward;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfRewardRedemptionStore(PosDbContext dbContext) : IRewardRedemptionStore
{
    public async Task<RewardRedemptionSnapshot?> LoadSnapshotAsync(
        Guid companyId,
        Guid customerId,
        Guid rewardId,
        CancellationToken cancellationToken)
    {
        var loyaltyAccount = await dbContext.LoyaltyAccounts
            .FirstOrDefaultAsync(
                account => account.CompanyId == companyId && account.CustomerId == customerId,
                cancellationToken);

        var reward = await dbContext.Rewards
            .AsNoTracking()
            .FirstOrDefaultAsync(
                item => item.CompanyId == companyId && item.Id == rewardId,
                cancellationToken);

        return loyaltyAccount is null || reward is null
            ? null
            : new RewardRedemptionSnapshot(loyaltyAccount, reward);
    }

    public async Task AddRedemptionAsync(RewardRedemptionGraph graph, CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        dbContext.RewardRedemptions.Add(graph.Redemption);
        dbContext.LoyaltyPointTransactions.Add(graph.LoyaltyTransaction);
        dbContext.LoyaltyAccounts.Update(graph.LoyaltyAccountToUpdate);

        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
