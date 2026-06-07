using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class LoyaltyTier : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MinimumPoints { get; set; }
    public decimal EarnMultiplier { get; set; } = 1m;
    public bool Active { get; set; } = true;
}

public sealed class EarnRule : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal AmountPerPoint { get; set; }
    public decimal MinimumOrderTotal { get; set; }
    public EarnRuleScope Scope { get; set; } = EarnRuleScope.All;
    public Guid? BranchId { get; set; }
    public Guid? CategoryId { get; set; }
    public int? ExpiryDays { get; set; }
    public DateTimeOffset? StartsAt { get; set; }
    public DateTimeOffset? EndsAt { get; set; }
    public bool Active { get; set; } = true;
    public Branch? Branch { get; set; }
    public Category? Category { get; set; }
}

public sealed class Reward : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RequiredPoints { get; set; }
    public RewardType RewardType { get; set; } = RewardType.DiscountAmount;
    public decimal? DiscountAmount { get; set; }
    public Guid? ProductId { get; set; }
    public bool Active { get; set; } = true;
    public Product? Product { get; set; }
}

public sealed class RewardRedemption : Entity, ICompanyScoped, IAppendOnly
{
    public Guid CompanyId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid RewardId { get; set; }
    public int Points { get; set; }
    public RewardRedemptionState State { get; set; }
    public string RedemptionCode { get; set; } = string.Empty;
    public Guid? OrderId { get; set; }
    public Guid? ReversalOfId { get; set; }
    public DateTimeOffset RequestedAt { get; set; }
    public Customer? Customer { get; set; }
    public Order? Order { get; set; }
    public Reward? Reward { get; set; }
    public RewardRedemption? ReversalOf { get; set; }
}

public sealed class Campaign : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public CampaignType CampaignType { get; set; } = CampaignType.ExtraPoints;
    public string RuleJson { get; set; } = "{}";
    public int Priority { get; set; }
    public Guid? TargetTierId { get; set; }
    public DateTimeOffset? StartsAt { get; set; }
    public DateTimeOffset? EndsAt { get; set; }
    public bool Active { get; set; } = true;
    public Company? Company { get; set; }
    public LoyaltyTier? TargetTier { get; set; }
}

public sealed class DeviceToken : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public Guid CustomerId { get; set; }
    public string TokenHash { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? RevokedAt { get; set; }
    public Customer? Customer { get; set; }
}

public sealed class CustomerCardToken : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public Guid CustomerId { get; set; }
    public string TokenHash { get; set; } = string.Empty;
    public DateTimeOffset ExpiresAt { get; set; }
    public TokenState State { get; set; }
    public Customer? Customer { get; set; }
}
