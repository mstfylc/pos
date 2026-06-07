using Mansis.Pos.Application.Core;
using Mansis.Pos.Application.Stock;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Core;

public sealed class GroupTwoCrudValidatorTests
{
    [Fact]
    public void EarnRuleWriteValidator_requires_scope_target_for_branch_rule()
    {
        var validator = new EarnRuleWriteValidator();
        var request = ValidEarnRule() with { Scope = EarnRuleScope.Branch, BranchId = null };

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(EarnRuleWriteDto.BranchId));
    }

    [Fact]
    public void LoyaltyTierWriteValidator_accepts_upgrade_only_admin_payload()
    {
        var validator = new LoyaltyTierWriteValidator();
        var request = new LoyaltyTierWriteDto(Guid.NewGuid(), Guid.NewGuid(), "Gold", 1000, 1.5m, "Free coffee", true);

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void RewardWriteValidator_requires_product_for_free_product_reward()
    {
        var validator = new RewardWriteValidator();
        var request = new RewardWriteDto(Guid.NewGuid(), Guid.NewGuid(), "Free product", 100, RewardType.FreeProduct, null, null, null, true);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(RewardWriteDto.ProductId));
    }

    [Fact]
    public void DestroyStockValidator_requires_reason()
    {
        var validator = new DestroyStockValidator();
        var request = new DestroyStockRequest(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 1, string.Empty);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(DestroyStockRequest.Reason));
    }

    [Fact]
    public void CreateTransferValidator_rejects_same_source_and_target()
    {
        var validator = new CreateTransferValidator();
        var storeId = Guid.NewGuid();
        var request = new CreateTransferRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            storeId,
            storeId,
            [new TransferLineWriteDto(Guid.NewGuid(), 1, ProductUnitType.Adet, null)]);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateTransferRequest.TargetStoreId));
    }

    private static EarnRuleWriteDto ValidEarnRule() => new(
        CompanyId: Guid.NewGuid(),
        UserId: Guid.NewGuid(),
        Name: "Default earn",
        PointsPerCurrency: 0.1m,
        MinOrder: 10m,
        ExpiryDays: 30,
        Scope: EarnRuleScope.All,
        BranchId: null,
        CategoryId: null,
        StartsAt: DateTimeOffset.UtcNow,
        EndsAt: DateTimeOffset.UtcNow.AddDays(10),
        Active: true);
}
