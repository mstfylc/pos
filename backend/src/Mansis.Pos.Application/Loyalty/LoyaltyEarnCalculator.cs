using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Loyalty;

public sealed class LoyaltyEarnCalculator
{
    public LoyaltyEarnResult Calculate(
        OrderCreationSnapshot snapshot,
        IReadOnlyList<CreateOrderLine> lines,
        decimal orderTotal,
        DateTimeOffset now)
    {
        if (snapshot.LoyaltyAccount is null)
        {
            return LoyaltyEarnResult.None;
        }

        var rule = snapshot.EarnRules
            .Where(candidate => IsEligible(candidate, snapshot, lines, orderTotal, now))
            .OrderByDescending(candidate => candidate.MinimumOrderTotal)
            .ThenBy(candidate => candidate.Id)
            .FirstOrDefault();

        if (rule is null || rule.AmountPerPoint <= 0m)
        {
            return LoyaltyEarnResult.None;
        }

        var currentTier = ResolveCurrentTier(snapshot.LoyaltyAccount, snapshot.LoyaltyTiers);
        var multiplier = currentTier?.EarnMultiplier > 0m ? currentTier.EarnMultiplier : 1m;
        var basePoints = Math.Floor(orderTotal / rule.AmountPerPoint);
        var points = (int)Math.Floor(basePoints * multiplier);

        if (points <= 0)
        {
            return LoyaltyEarnResult.None;
        }

        return new LoyaltyEarnResult(points, rule.ExpiryDays.HasValue ? now.AddDays(rule.ExpiryDays.Value) : null);
    }

    public LoyaltyTier? ResolveTierAfterEarn(LoyaltyAccount account, IReadOnlyList<LoyaltyTier> tiers, int earnedPoints)
    {
        var lifetimePoints = account.LifetimePoints + Math.Max(earnedPoints, 0);
        return tiers
            .Where(tier => tier.Active && tier.MinimumPoints <= lifetimePoints)
            .OrderByDescending(tier => tier.MinimumPoints)
            .ThenBy(tier => tier.Id)
            .FirstOrDefault();
    }

    private static LoyaltyTier? ResolveCurrentTier(LoyaltyAccount account, IReadOnlyList<LoyaltyTier> tiers)
    {
        if (account.LoyaltyTierId.HasValue)
        {
            var assignedTier = tiers.FirstOrDefault(tier => tier.Id == account.LoyaltyTierId.Value && tier.Active);
            if (assignedTier is not null)
            {
                return assignedTier;
            }
        }

        return tiers
            .Where(tier => tier.Active && tier.MinimumPoints <= account.LifetimePoints)
            .OrderByDescending(tier => tier.MinimumPoints)
            .ThenBy(tier => tier.Id)
            .FirstOrDefault();
    }

    private static bool IsEligible(
        EarnRule rule,
        OrderCreationSnapshot snapshot,
        IReadOnlyList<CreateOrderLine> lines,
        decimal orderTotal,
        DateTimeOffset now)
    {
        if (!rule.Active || orderTotal < rule.MinimumOrderTotal)
        {
            return false;
        }

        if (rule.StartsAt.HasValue && rule.StartsAt.Value > now)
        {
            return false;
        }

        if (rule.EndsAt.HasValue && rule.EndsAt.Value < now)
        {
            return false;
        }

        return rule.Scope switch
        {
            EarnRuleScope.All => true,
            EarnRuleScope.Branch => rule.BranchId == snapshot.BranchId,
            EarnRuleScope.Category => rule.CategoryId.HasValue
                && lines.Any(line =>
                    snapshot.Products.TryGetValue(line.ProductId, out var product)
                    && product.CategoryId == rule.CategoryId.Value),
            _ => false
        };
    }
}

public sealed record LoyaltyEarnResult(int Points, DateTimeOffset? ExpiresAt)
{
    public static LoyaltyEarnResult None { get; } = new(0, null);
}
