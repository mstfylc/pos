using System.Security.Cryptography;
using FluentValidation;
using Mansis.Pos.Application.Common;
using Mansis.Pos.Application.Loyalty;
using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Pos;

public sealed class PosService(
    IPosStore store,
    IValidator<IssueCustomerCardTokenRequest> issueTokenValidator,
    IValidator<IdentifyCustomerRequest> identifyCustomerValidator,
    IValidator<LoyaltyPreviewRequest> loyaltyPreviewValidator,
    LoyaltyEarnCalculator loyaltyEarnCalculator,
    CampaignEvaluator campaignEvaluator)
{
    public Task<PosProductCatalogResponse?> GetCatalogAsync(Guid companyId, Guid posId, CancellationToken cancellationToken = default) =>
        store.GetCatalogAsync(companyId, posId, cancellationToken);

    public async Task<Result<CustomerCardTokenResponse>> IssueCustomerCardTokenAsync(
        IssueCustomerCardTokenRequest request,
        CancellationToken cancellationToken = default)
    {
        var validation = await issueTokenValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            return Result<CustomerCardTokenResponse>.Failure(validation.Errors[0].ErrorMessage);
        }

        var customer = await store.GetCustomerAsync(request.CompanyId, request.CustomerId, cancellationToken);
        if (customer is null)
        {
            return Result<CustomerCardTokenResponse>.Failure("Customer not found.");
        }

        var now = DateTimeOffset.UtcNow;
        var tokenValue = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32))
            .Replace("+", string.Empty, StringComparison.Ordinal)
            .Replace("/", string.Empty, StringComparison.Ordinal)
            .Replace("=", string.Empty, StringComparison.Ordinal);
        var expiresAt = now.AddSeconds(request.ExpiresInSeconds);
        var token = new CustomerCardToken
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            CustomerId = request.CustomerId,
            TokenHash = HashToken(tokenValue),
            ExpiresAt = expiresAt,
            State = TokenState.Active
        };

        await store.AddCustomerCardTokenAsync(token, cancellationToken);
        return Result<CustomerCardTokenResponse>.Success(new CustomerCardTokenResponse(request.CustomerId, tokenValue, expiresAt));
    }

    public async Task<Result<IdentifiedCustomerDto>> IdentifyCustomerAsync(
        IdentifyCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        var validation = await identifyCustomerValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            return Result<IdentifiedCustomerDto>.Failure(validation.Errors[0].ErrorMessage);
        }

        var token = !string.IsNullOrWhiteSpace(request.Token) ? request.Token : request.CardNumber!;
        var consume = !string.IsNullOrWhiteSpace(request.Token);
        var customer = await store.IdentifyCustomerByTokenAsync(request.CompanyId, HashToken(token), consume, cancellationToken);
        return customer is null
            ? Result<IdentifiedCustomerDto>.Failure("Customer token not found or expired.")
            : Result<IdentifiedCustomerDto>.Success(customer);
    }

    public async Task<Result<LoyaltyPreviewResponse>> PreviewLoyaltyAsync(
        LoyaltyPreviewRequest request,
        CancellationToken cancellationToken = default)
    {
        var validation = await loyaltyPreviewValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            return Result<LoyaltyPreviewResponse>.Failure(validation.Errors[0].ErrorMessage);
        }

        var productIds = request.Lines.Select(line => line.ProductId).Distinct().ToArray();
        var snapshot = await store.LoadLoyaltyPreviewSnapshotAsync(
            request.CompanyId,
            request.PosId,
            request.CustomerId,
            productIds,
            cancellationToken);
        if (snapshot is null || snapshot.LoyaltyAccount is null)
        {
            return Result<LoyaltyPreviewResponse>.Failure("Customer loyalty account not found.");
        }

        foreach (var line in request.Lines)
        {
            if (!snapshot.Products.ContainsKey(line.ProductId))
            {
                return Result<LoyaltyPreviewResponse>.Failure("Product not found.");
            }
        }

        var grossTotal = request.Lines.Sum(line => line.UnitPrice * line.Quantity + line.TaxAmount);
        var campaignEvaluation = campaignEvaluator.Evaluate(snapshot, grossTotal, DateTimeOffset.UtcNow);
        var finalTotal = grossTotal - campaignEvaluation.DiscountAmount;
        var earnResult = loyaltyEarnCalculator.Calculate(
            snapshot,
            request.Lines.Select(line => new CreateOrderLine(line.ProductId, line.Quantity, line.UnitPrice, line.TaxAmount)).ToArray(),
            finalTotal,
            DateTimeOffset.UtcNow);
        var rewards = await store.ListAvailableRewardsAsync(request.CompanyId, snapshot.LoyaltyAccount.PointBalance, cancellationToken);

        return Result<LoyaltyPreviewResponse>.Success(new LoyaltyPreviewResponse(
            grossTotal,
            campaignEvaluation.DiscountAmount,
            finalTotal,
            earnResult.Points,
            earnResult.ExpiresAt,
            campaignEvaluation.ExtraPoints,
            campaignEvaluation.AppliedCampaignNames,
            rewards.Select(reward => new AvailableRewardDto(
                reward.Id,
                reward.Name,
                reward.RequiredPoints,
                reward.RewardType,
                reward.DiscountAmount,
                reward.ProductId)).ToArray()));
    }

    private static string HashToken(string token)
    {
        var bytes = SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(token.Trim()));
        return Convert.ToHexString(bytes);
    }
}
