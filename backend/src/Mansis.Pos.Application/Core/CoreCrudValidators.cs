using FluentValidation;
using System.Text.Json;

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
