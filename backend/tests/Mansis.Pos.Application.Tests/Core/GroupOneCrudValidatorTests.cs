using Mansis.Pos.Application.Core;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Core;

public sealed class GroupOneCrudValidatorTests
{
    [Fact]
    public void UserWriteValidator_accepts_admin_user_payload_with_assignments()
    {
        var validator = new UserWriteValidator();
        var request = ValidUser();

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void UserWriteValidator_rejects_missing_identity_and_short_password()
    {
        var validator = new UserWriteValidator();
        var request = ValidUser() with
        {
            Username = string.Empty,
            RoleId = Guid.Empty,
            Password = "short"
        };

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(UserWriteDto.Username));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(UserWriteDto.RoleId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(UserWriteDto.Password));
    }

    [Fact]
    public void RolePermissionWriteValidator_accepts_empty_matrix_for_role_reset()
    {
        var validator = new RolePermissionWriteValidator();
        var request = new RolePermissionWriteDto(Guid.NewGuid(), Guid.NewGuid(), []);

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void AssignmentWriteValidator_requires_tenant_user_and_records_collection()
    {
        var validator = new AssignmentWriteValidator();
        var request = new AssignmentWriteDto(Guid.Empty, Guid.Empty, AssignmentTableType.Branch, null!);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(AssignmentWriteDto.CompanyId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(AssignmentWriteDto.UserId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(AssignmentWriteDto.RecordIds));
    }

    [Fact]
    public void DiscountWriteValidator_accepts_scope_payload_with_monthly_limit()
    {
        var validator = new DiscountWriteValidator();
        var request = ValidDiscount();

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void DiscountWriteValidator_rejects_negative_monthly_limit()
    {
        var validator = new DiscountWriteValidator();
        var request = ValidDiscount() with { MonthlyLimit = -1m };

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(DiscountWriteDto.MonthlyLimit));
    }

    [Fact]
    public void CampaignWriteValidator_accepts_json_object_rule()
    {
        var validator = new CampaignWriteValidator();
        var request = ValidCampaign();

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void CampaignWriteValidator_rejects_invalid_rule_and_reversed_dates()
    {
        var validator = new CampaignWriteValidator();
        var request = ValidCampaign() with
        {
            RuleJson = "[1,2,3]",
            StartsAt = DateTimeOffset.UtcNow.AddDays(1),
            EndsAt = DateTimeOffset.UtcNow
        };

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CampaignWriteDto.RuleJson));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CampaignWriteDto.EndsAt));
    }

    private static UserWriteDto ValidUser() => new(
        CompanyId: Guid.NewGuid(),
        UserId: Guid.NewGuid(),
        FirstName: "Ada",
        LastName: "Lovelace",
        Username: "ada",
        Phone: "5550000000",
        Mail: "ada@example.com",
        RoleId: Guid.NewGuid(),
        CardId: null,
        Pin: "1234",
        Password: "ChangeMe123!",
        MustChangePassword: true,
        BranchIds: [Guid.NewGuid()],
        PosIds: [Guid.NewGuid()],
        StoreIds: [Guid.NewGuid()]);

    private static DiscountWriteDto ValidDiscount() => new(
        CompanyId: Guid.NewGuid(),
        UserId: Guid.NewGuid(),
        Description: "Branch discount",
        Amount: 10m,
        MaxDiscountAmount: 50m,
        MonthlyLimit: 250m,
        ExpireDate: DateTimeOffset.UtcNow.AddMonths(1),
        DiscountType: DiscountType.Percentage,
        DiscountCategory: DiscountCategory.Branch,
        SortOrder: 1,
        BranchIds: [Guid.NewGuid()],
        PosIds: [],
        UserIds: []);

    private static CampaignWriteDto ValidCampaign() => new(
        CompanyId: Guid.NewGuid(),
        UserId: Guid.NewGuid(),
        Name: "Gold bonus",
        Description: null,
        CampaignType: CampaignType.ExtraPoints,
        RuleJson: """{"multiplier":2}""",
        Priority: 10,
        MaxTotalDiscount: 100m,
        TargetTierId: null,
        StartsAt: DateTimeOffset.UtcNow,
        EndsAt: DateTimeOffset.UtcNow.AddDays(7),
        Active: true);
}
