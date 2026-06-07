using FluentValidation;
using System.Text.Json;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Core;

public sealed class ProductWriteValidator : AbstractValidator<ProductWriteDto>
{
    public ProductWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.CategoryId).NotEmpty();
        RuleFor(request => request.ProductUnitType).IsInEnum();
        RuleFor(request => request.TaxType).IsInEnum();
    }
}

public sealed class PosProductWriteValidator : AbstractValidator<PosProductWriteDto>
{
    public PosProductWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.PosId).NotEmpty();
        RuleFor(request => request.ProductId).NotEmpty();
    }
}

public sealed class UserWriteValidator : AbstractValidator<UserWriteDto>
{
    public UserWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.FirstName).NotEmpty();
        RuleFor(request => request.LastName).NotEmpty();
        RuleFor(request => request.Username).NotEmpty();
        RuleFor(request => request.RoleId).NotEmpty();
        RuleFor(request => request.Password)
            .MinimumLength(8)
            .When(request => !string.IsNullOrWhiteSpace(request.Password));
        RuleFor(request => request.BranchIds).NotNull();
        RuleFor(request => request.PosIds).NotNull();
        RuleFor(request => request.StoreIds).NotNull();
    }
}

public sealed class RoleWriteValidator : AbstractValidator<RoleWriteDto>
{
    public RoleWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
    }
}

public sealed class RolePermissionWriteValidator : AbstractValidator<RolePermissionWriteDto>
{
    public RolePermissionWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.PermissionIds).NotNull();
    }
}

public sealed class AssignmentWriteValidator : AbstractValidator<AssignmentWriteDto>
{
    public AssignmentWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.AssignmentTableType).IsInEnum();
        RuleFor(request => request.RecordIds).NotNull();
    }
}

public sealed class DiscountWriteValidator : AbstractValidator<DiscountWriteDto>
{
    public DiscountWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Amount).GreaterThanOrEqualTo(0);
        RuleFor(request => request.MaxDiscountAmount).GreaterThanOrEqualTo(0);
        RuleFor(request => request.MonthlyLimit).GreaterThanOrEqualTo(0).When(request => request.MonthlyLimit.HasValue);
        RuleFor(request => request.DiscountType).IsInEnum();
        RuleFor(request => request.DiscountCategory).IsInEnum();
        RuleFor(request => request.BranchIds).NotNull();
        RuleFor(request => request.PosIds).NotNull();
        RuleFor(request => request.UserIds).NotNull();
    }
}

public sealed class CampaignWriteValidator : AbstractValidator<CampaignWriteDto>
{
    public CampaignWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.CampaignType).IsInEnum();
        RuleFor(request => request.RuleJson).NotEmpty().Must(BeJsonObject).WithMessage("RuleJson must be a JSON object.");
        RuleFor(request => request.MaxTotalDiscount).GreaterThanOrEqualTo(0).When(request => request.MaxTotalDiscount.HasValue);
        RuleFor(request => request.EndsAt)
            .GreaterThanOrEqualTo(request => request.StartsAt)
            .When(request => request.StartsAt.HasValue && request.EndsAt.HasValue);
    }

    private static bool BeJsonObject(string ruleJson)
    {
        try
        {
            using var document = JsonDocument.Parse(ruleJson);
            return document.RootElement.ValueKind == JsonValueKind.Object;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}

public sealed class EarnRuleWriteValidator : AbstractValidator<EarnRuleWriteDto>
{
    public EarnRuleWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.PointsPerCurrency).GreaterThan(0);
        RuleFor(request => request.MinOrder).GreaterThanOrEqualTo(0);
        RuleFor(request => request.ExpiryDays).GreaterThan(0).When(request => request.ExpiryDays.HasValue);
        RuleFor(request => request.Scope).IsInEnum();
        RuleFor(request => request.BranchId).NotEmpty().When(request => request.Scope == EarnRuleScope.Branch);
        RuleFor(request => request.CategoryId).NotEmpty().When(request => request.Scope == EarnRuleScope.Category);
        RuleFor(request => request.EndsAt)
            .GreaterThanOrEqualTo(request => request.StartsAt)
            .When(request => request.StartsAt.HasValue && request.EndsAt.HasValue);
    }
}

public sealed class LoyaltyTierWriteValidator : AbstractValidator<LoyaltyTierWriteDto>
{
    public LoyaltyTierWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.MinPoints).GreaterThanOrEqualTo(0);
        RuleFor(request => request.PointMultiplier).GreaterThan(0);
    }
}

public sealed class RewardWriteValidator : AbstractValidator<RewardWriteDto>
{
    public RewardWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.PointCost).GreaterThan(0);
        RuleFor(request => request.RewardType).IsInEnum();
        RuleFor(request => request.DiscountAmount).GreaterThan(0).When(request => request.DiscountAmount.HasValue);
        RuleFor(request => request.ProductId).NotEmpty().When(request => request.RewardType == RewardType.FreeProduct);
    }
}

public sealed class StampCardWriteValidator : AbstractValidator<StampCardWriteDto>
{
    public StampCardWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.RequiredStamps).GreaterThan(0);
        RuleFor(request => request.EndsAt)
            .GreaterThanOrEqualTo(request => request.StartsAt)
            .When(request => request.StartsAt.HasValue && request.EndsAt.HasValue);
    }
}

public sealed class CustomerWriteValidator : AbstractValidator<CustomerWriteDto>
{
    public CustomerWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.Surname).NotEmpty();
        RuleFor(request => request.Username).NotEmpty();
        RuleFor(request => request.RoleId).NotEmpty();
        RuleForEach(request => request.Addresses).ChildRules(address =>
        {
            address.RuleFor(item => item.AddressType).IsInEnum();
            address.RuleFor(item => item.CityId).NotEmpty();
            address.RuleFor(item => item.TownId).NotEmpty();
        });
    }
}

public sealed class CustomerWalletAdjustmentValidator : AbstractValidator<CustomerWalletAdjustmentRequest>
{
    public CustomerWalletAdjustmentValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Amount).GreaterThan(0);
        RuleFor(request => request.Direction).IsInEnum();
        RuleFor(request => request.Reason).NotEmpty();
    }
}

public sealed class CustomerLoyaltyAdjustmentValidator : AbstractValidator<CustomerLoyaltyAdjustmentRequest>
{
    public CustomerLoyaltyAdjustmentValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Points).GreaterThan(0);
        RuleFor(request => request.Direction).IsInEnum();
        RuleFor(request => request.Reason).NotEmpty();
    }
}

public sealed class SupplierWriteValidator : AbstractValidator<SupplierWriteDto>
{
    public SupplierWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.MoneyUnitType).IsInEnum().When(request => request.MoneyUnitType.HasValue);
        RuleFor(request => request.Maturity).GreaterThanOrEqualTo(0).When(request => request.Maturity.HasValue);
    }
}

public sealed class PurchaseWriteValidator : AbstractValidator<PurchaseWriteDto>
{
    public PurchaseWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.SupplierId).NotEmpty();
        RuleFor(request => request.StoreId).NotEmpty();
        RuleFor(request => request.Lines).NotEmpty();
        RuleForEach(request => request.Lines).ChildRules(line =>
        {
            line.RuleFor(item => item.ProductId).NotEmpty();
            line.RuleFor(item => item.Quantity).GreaterThan(0);
            line.RuleFor(item => item.Price).GreaterThanOrEqualTo(0);
            line.RuleFor(item => item.Discount).GreaterThanOrEqualTo(0).When(item => item.Discount.HasValue);
            line.RuleFor(item => item.Tax).GreaterThanOrEqualTo(0).When(item => item.Tax.HasValue);
        });
    }
}
