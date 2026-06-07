using System.Text.Json;
using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Loyalty;

public sealed class CampaignEvaluator
{
    public CampaignEvaluationResult Evaluate(
        OrderCreationSnapshot snapshot,
        decimal orderTotal,
        DateTimeOffset now)
    {
        if (snapshot.Campaigns.Count == 0)
        {
            return CampaignEvaluationResult.None;
        }

        var currentTierId = snapshot.LoyaltyAccount?.LoyaltyTierId;
        var eligibleCampaigns = snapshot.Campaigns
            .Where(campaign => IsEligible(campaign, currentTierId, orderTotal, now))
            .GroupBy(campaign => campaign.CampaignType)
            .Select(group => group
                .OrderByDescending(campaign => campaign.Priority)
                .ThenBy(campaign => campaign.Id)
                .First())
            .ToArray();

        var extraPoints = 0;
        var discountAmount = 0m;
        decimal? maxTotalDiscount = null;
        var descriptions = new List<string>();
        foreach (var campaign in eligibleCampaigns)
        {
            var rule = ParseRule(campaign.RuleJson);
            if (campaign.CampaignType == CampaignType.ExtraPoints && rule.ExtraPoints > 0)
            {
                extraPoints += rule.ExtraPoints;
                descriptions.Add(campaign.Name);
            }

            if (campaign.CampaignType == CampaignType.DiscountAmount && rule.DiscountAmount > 0m)
            {
                discountAmount += rule.DiscountAmount;
                maxTotalDiscount = campaign.MaxTotalDiscount.HasValue
                    ? Math.Min(maxTotalDiscount ?? campaign.MaxTotalDiscount.Value, campaign.MaxTotalDiscount.Value)
                    : maxTotalDiscount;
                descriptions.Add(campaign.Name);
            }
        }

        var cappedDiscount = Math.Min(discountAmount, maxTotalDiscount ?? discountAmount);
        return new CampaignEvaluationResult(extraPoints, Math.Min(cappedDiscount, orderTotal), descriptions);
    }

    private static bool IsEligible(
        Campaign campaign,
        Guid? currentTierId,
        decimal orderTotal,
        DateTimeOffset now)
    {
        if (!campaign.Active)
        {
            return false;
        }

        if (campaign.StartsAt.HasValue && campaign.StartsAt.Value > now)
        {
            return false;
        }

        if (campaign.EndsAt.HasValue && campaign.EndsAt.Value < now)
        {
            return false;
        }

        if (campaign.TargetTierId.HasValue && campaign.TargetTierId != currentTierId)
        {
            return false;
        }

        var rule = ParseRule(campaign.RuleJson);
        return orderTotal >= rule.MinOrderTotal;
    }

    private static CampaignRule ParseRule(string? json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return CampaignRule.Empty;
        }

        try
        {
            return JsonSerializer.Deserialize<CampaignRule>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web))
                ?? CampaignRule.Empty;
        }
        catch (JsonException)
        {
            return CampaignRule.Empty;
        }
    }
}

public sealed record CampaignEvaluationResult(
    int ExtraPoints,
    decimal DiscountAmount,
    IReadOnlyList<string> AppliedCampaignNames)
{
    public static CampaignEvaluationResult None { get; } = new(0, 0m, []);
}

public sealed record CampaignRule(decimal MinOrderTotal = 0m, int ExtraPoints = 0, decimal DiscountAmount = 0m)
{
    public static CampaignRule Empty { get; } = new();
}
