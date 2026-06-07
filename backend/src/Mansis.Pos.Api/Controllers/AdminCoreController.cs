using FluentValidation;
using Mansis.Pos.Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[Route("api/v1/admin")]
[Tags("Admin")]
public sealed class AdminCoreController(
    CoreCrudService coreCrudService,
    IValidator<ProductWriteDto> productWriteValidator,
    IValidator<PosProductWriteDto> posProductWriteValidator,
    IValidator<CustomerWriteDto> customerWriteValidator,
    IValidator<CustomerWalletAdjustmentRequest> customerWalletAdjustmentValidator,
    IValidator<CustomerLoyaltyAdjustmentRequest> customerLoyaltyAdjustmentValidator,
    IValidator<UserWriteDto> userWriteValidator,
    IValidator<RoleWriteDto> roleWriteValidator,
    IValidator<RolePermissionWriteDto> rolePermissionWriteValidator,
    IValidator<AssignmentWriteDto> assignmentWriteValidator,
    IValidator<DiscountWriteDto> discountWriteValidator,
    IValidator<CampaignWriteDto> campaignWriteValidator,
    IValidator<EarnRuleWriteDto> earnRuleWriteValidator,
    IValidator<LoyaltyTierWriteDto> loyaltyTierWriteValidator,
    IValidator<RewardWriteDto> rewardWriteValidator,
    IValidator<StampCardWriteDto> stampCardWriteValidator,
    IValidator<SupplierWriteDto> supplierWriteValidator,
    IValidator<PurchaseWriteDto> purchaseWriteValidator) : ControllerBase
{
    [HttpGet("products")]
    public Task<PagedResult<ProductDto>> ListProductsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListProductsAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpPost("products")]
    public async Task<ActionResult<ProductDto>> CreateProductAsync([FromBody] ProductWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await productWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateProductAsync(request, cancellationToken));
    }

    [HttpPut("products/{id:guid}")]
    public async Task<ActionResult<ProductDto>> UpdateProductAsync(Guid id, [FromBody] ProductWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await productWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateProductAsync(id, request, cancellationToken));
    }

    [HttpDelete("products/{id:guid}")]
    public async Task<IActionResult> DeleteProductAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateProductAsync(companyId, id, userId, cancellationToken));

    [HttpPost("pos-products")]
    public async Task<ActionResult<PosProductDto>> CreatePosProductAsync([FromBody] PosProductWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await posProductWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreatePosProductAsync(request, cancellationToken));
    }

    [HttpPut("pos-products/{id:guid}")]
    public async Task<ActionResult<PosProductDto>> UpdatePosProductAsync(Guid id, [FromBody] PosProductWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await posProductWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdatePosProductAsync(id, request, cancellationToken));
    }

    [HttpGet("products/{productId:guid}/pos-products")]
    public Task<IReadOnlyList<PosProductDto>> ListProductPosOverridesAsync(Guid productId, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListPosProductsForProductAsync(companyId, productId, cancellationToken);

    [HttpGet("categories")]
    public Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListCategoriesAsync(companyId, cancellationToken);

    [HttpPost("categories")]
    public async Task<ActionResult<CategoryDto>> CreateCategoryAsync([FromBody] CategoryWriteDto request, CancellationToken cancellationToken) =>
        CreatedResult(await coreCrudService.CreateCategoryAsync(request, cancellationToken));

    [HttpPut("categories/{id:guid}")]
    public async Task<ActionResult<CategoryDto>> UpdateCategoryAsync(Guid id, [FromBody] CategoryWriteDto request, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.UpdateCategoryAsync(id, request, cancellationToken));

    [HttpDelete("categories/{id:guid}")]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateCategoryAsync(companyId, id, userId, cancellationToken));

    [HttpGet("customers")]
    public Task<PagedResult<CustomerDto>> ListCustomersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListCustomersAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("customers/{id:guid}")]
    public async Task<ActionResult<CustomerDetailDto>> GetCustomerAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetCustomerAsync(companyId, id, cancellationToken));

    [HttpPost("customers")]
    public async Task<ActionResult<CustomerDto>> CreateCustomerAsync([FromBody] CustomerWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await customerWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateCustomerAsync(request, cancellationToken));
    }

    [HttpPut("customers/{id:guid}")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomerAsync(Guid id, [FromBody] CustomerWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await customerWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateCustomerAsync(id, request, cancellationToken));
    }

    [HttpDelete("customers/{id:guid}")]
    public async Task<IActionResult> DeleteCustomerAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateCustomerAsync(companyId, id, userId, cancellationToken));

    [HttpPost("customers/{id:guid}/wallet-adjustments")]
    public async Task<ActionResult<WalletAdjustmentDto>> AdjustCustomerWalletAsync(Guid id, [FromBody] CustomerWalletAdjustmentRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await customerWalletAdjustmentValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.AdjustCustomerWalletAsync(id, request, cancellationToken));
    }

    [HttpPost("customers/{id:guid}/loyalty-adjustments")]
    public async Task<ActionResult<LoyaltyAdjustmentDto>> AdjustCustomerLoyaltyAsync(Guid id, [FromBody] CustomerLoyaltyAdjustmentRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await customerLoyaltyAdjustmentValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.AdjustCustomerLoyaltyAsync(id, request, cancellationToken));
    }

    [HttpGet("users")]
    public Task<PagedResult<UserDto>> ListUsersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListUsersAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("users/{id:guid}")]
    public async Task<ActionResult<UserDto>> GetUserAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetUserAsync(companyId, id, cancellationToken));

    [HttpPost("users")]
    public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] UserWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await userWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));
        if (string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                [nameof(UserWriteDto.Password)] = ["Password is required when creating a user."]
            }));
        }

        return CreatedResult(await coreCrudService.CreateUserAsync(request, cancellationToken));
    }

    [HttpPut("users/{id:guid}")]
    public async Task<ActionResult<UserDto>> UpdateUserAsync(Guid id, [FromBody] UserWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await userWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateUserAsync(id, request, cancellationToken));
    }

    [HttpDelete("users/{id:guid}")]
    public async Task<IActionResult> DeleteUserAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateUserAsync(companyId, id, userId, cancellationToken));

    [HttpGet("roles")]
    public Task<IReadOnlyList<RoleDto>> ListRolesAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListRolesAsync(companyId, cancellationToken);

    [HttpGet("roles/{id:guid}")]
    public async Task<ActionResult<RoleDto>> GetRoleAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetRoleAsync(companyId, id, cancellationToken));

    [HttpPost("roles")]
    public async Task<ActionResult<RoleDto>> CreateRoleAsync([FromBody] RoleWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await roleWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateRoleAsync(request, cancellationToken));
    }

    [HttpPut("roles/{id:guid}")]
    public async Task<ActionResult<RoleDto>> UpdateRoleAsync(Guid id, [FromBody] RoleWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await roleWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateRoleAsync(id, request, cancellationToken));
    }

    [HttpDelete("roles/{id:guid}")]
    public async Task<IActionResult> DeleteRoleAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateRoleAsync(companyId, id, userId, cancellationToken));

    [HttpGet("permissions")]
    public Task<IReadOnlyList<PermissionDto>> ListPermissionsAsync(CancellationToken cancellationToken) =>
        coreCrudService.ListPermissionsAsync(cancellationToken);

    [HttpPut("roles/{id:guid}/permissions")]
    public async Task<ActionResult<RoleDto>> UpdateRolePermissionsAsync(Guid id, [FromBody] RolePermissionWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await rolePermissionWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateRolePermissionsAsync(id, request, cancellationToken));
    }

    [HttpGet("assignments")]
    public Task<IReadOnlyList<AssignmentDto>> ListAssignmentsAsync([FromQuery] Guid companyId, [FromQuery] Guid? userId, CancellationToken cancellationToken) =>
        coreCrudService.ListAssignmentsAsync(companyId, userId, cancellationToken);

    [HttpGet("assignments/{id:guid}")]
    public async Task<ActionResult<AssignmentDto>> GetAssignmentAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetAssignmentAsync(companyId, id, cancellationToken));

    [HttpPost("assignments")]
    public async Task<ActionResult<AssignmentDto>> CreateAssignmentAsync([FromBody] AssignmentWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await assignmentWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateAssignmentAsync(request, cancellationToken));
    }

    [HttpPut("assignments/{id:guid}")]
    public async Task<ActionResult<AssignmentDto>> UpdateAssignmentAsync(Guid id, [FromBody] AssignmentWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await assignmentWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateAssignmentAsync(id, request, cancellationToken));
    }

    [HttpDelete("assignments/{id:guid}")]
    public async Task<IActionResult> DeleteAssignmentAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeleteAssignmentAsync(companyId, id, cancellationToken));

    [HttpGet("orders")]
    public Task<PagedResult<OrderListDto>> ListOrdersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListOrdersAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("stores")]
    public Task<IReadOnlyList<StoreDto>> ListStoresAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListStoresAsync(companyId, cancellationToken);

    [HttpPost("stores")]
    public async Task<ActionResult<StoreDto>> CreateStoreAsync([FromBody] StoreWriteDto request, CancellationToken cancellationToken) =>
        CreatedResult(await coreCrudService.CreateStoreAsync(request, cancellationToken));

    [HttpPut("stores/{id:guid}")]
    public async Task<ActionResult<StoreDto>> UpdateStoreAsync(Guid id, [FromBody] StoreWriteDto request, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.UpdateStoreAsync(id, request, cancellationToken));

    [HttpDelete("stores/{id:guid}")]
    public async Task<IActionResult> DeleteStoreAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateStoreAsync(companyId, id, userId, cancellationToken));

    [HttpGet("pos")]
    public Task<IReadOnlyList<PosDto>> ListPosAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListPosAsync(companyId, cancellationToken);

    [HttpPost("pos")]
    public async Task<ActionResult<PosDto>> CreatePosAsync([FromBody] PosWriteDto request, CancellationToken cancellationToken) =>
        CreatedResult(await coreCrudService.CreatePosAsync(request, cancellationToken));

    [HttpPut("pos/{id:guid}")]
    public async Task<ActionResult<PosDto>> UpdatePosAsync(Guid id, [FromBody] PosWriteDto request, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.UpdatePosAsync(id, request, cancellationToken));

    [HttpDelete("pos/{id:guid}")]
    public async Task<IActionResult> DeletePosAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivatePosAsync(companyId, id, userId, cancellationToken));

    [HttpGet("discounts")]
    public Task<PagedResult<DiscountDto>> ListDiscountsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListDiscountsAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("discounts/{id:guid}")]
    public async Task<ActionResult<DiscountDto>> GetDiscountAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetDiscountAsync(companyId, id, cancellationToken));

    [HttpPost("discounts")]
    public async Task<ActionResult<DiscountDto>> CreateDiscountAsync([FromBody] DiscountWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await discountWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateDiscountAsync(request, cancellationToken));
    }

    [HttpPut("discounts/{id:guid}")]
    public async Task<ActionResult<DiscountDto>> UpdateDiscountAsync(Guid id, [FromBody] DiscountWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await discountWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateDiscountAsync(id, request, cancellationToken));
    }

    [HttpDelete("discounts/{id:guid}")]
    public async Task<IActionResult> DeleteDiscountAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateDiscountAsync(companyId, id, userId, cancellationToken));

    [HttpGet("campaigns")]
    public Task<PagedResult<CampaignDto>> ListCampaignsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListCampaignsAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("campaigns/{id:guid}")]
    public async Task<ActionResult<CampaignDto>> GetCampaignAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetCampaignAsync(companyId, id, cancellationToken));

    [HttpPost("campaigns")]
    public async Task<ActionResult<CampaignDto>> CreateCampaignAsync([FromBody] CampaignWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await campaignWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateCampaignAsync(request, cancellationToken));
    }

    [HttpPut("campaigns/{id:guid}")]
    public async Task<ActionResult<CampaignDto>> UpdateCampaignAsync(Guid id, [FromBody] CampaignWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await campaignWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateCampaignAsync(id, request, cancellationToken));
    }

    [HttpDelete("campaigns/{id:guid}")]
    public async Task<IActionResult> DeleteCampaignAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeleteCampaignAsync(companyId, id, cancellationToken));

    [HttpGet("earn-rules")]
    public Task<PagedResult<EarnRuleDto>> ListEarnRulesAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListEarnRulesAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("earn-rules/{id:guid}")]
    public async Task<ActionResult<EarnRuleDto>> GetEarnRuleAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetEarnRuleAsync(companyId, id, cancellationToken));

    [HttpPost("earn-rules")]
    public async Task<ActionResult<EarnRuleDto>> CreateEarnRuleAsync([FromBody] EarnRuleWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await earnRuleWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateEarnRuleAsync(request, cancellationToken));
    }

    [HttpPut("earn-rules/{id:guid}")]
    public async Task<ActionResult<EarnRuleDto>> UpdateEarnRuleAsync(Guid id, [FromBody] EarnRuleWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await earnRuleWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateEarnRuleAsync(id, request, cancellationToken));
    }

    [HttpDelete("earn-rules/{id:guid}")]
    public async Task<IActionResult> DeleteEarnRuleAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeleteEarnRuleAsync(companyId, id, cancellationToken));

    [HttpGet("loyalty-tiers")]
    public Task<PagedResult<LoyaltyTierDto>> ListLoyaltyTiersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListLoyaltyTiersAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("loyalty-tiers/{id:guid}")]
    public async Task<ActionResult<LoyaltyTierDto>> GetLoyaltyTierAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetLoyaltyTierAsync(companyId, id, cancellationToken));

    [HttpPost("loyalty-tiers")]
    public async Task<ActionResult<LoyaltyTierDto>> CreateLoyaltyTierAsync([FromBody] LoyaltyTierWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await loyaltyTierWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateLoyaltyTierAsync(request, cancellationToken));
    }

    [HttpPut("loyalty-tiers/{id:guid}")]
    public async Task<ActionResult<LoyaltyTierDto>> UpdateLoyaltyTierAsync(Guid id, [FromBody] LoyaltyTierWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await loyaltyTierWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateLoyaltyTierAsync(id, request, cancellationToken));
    }

    [HttpDelete("loyalty-tiers/{id:guid}")]
    public async Task<IActionResult> DeleteLoyaltyTierAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeleteLoyaltyTierAsync(companyId, id, cancellationToken));

    [HttpGet("rewards")]
    public Task<PagedResult<RewardDto>> ListRewardsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListRewardsAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("rewards/{id:guid}")]
    public async Task<ActionResult<RewardDto>> GetRewardAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetRewardAsync(companyId, id, cancellationToken));

    [HttpPost("rewards")]
    public async Task<ActionResult<RewardDto>> CreateRewardAsync([FromBody] RewardWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await rewardWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateRewardAsync(request, cancellationToken));
    }

    [HttpPut("rewards/{id:guid}")]
    public async Task<ActionResult<RewardDto>> UpdateRewardAsync(Guid id, [FromBody] RewardWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await rewardWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateRewardAsync(id, request, cancellationToken));
    }

    [HttpDelete("rewards/{id:guid}")]
    public async Task<IActionResult> DeleteRewardAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeleteRewardAsync(companyId, id, cancellationToken));

    [HttpGet("stamp-cards")]
    public Task<PagedResult<StampCardDto>> ListStampCardsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListStampCardsAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("stamp-cards/{id:guid}")]
    public async Task<ActionResult<StampCardDto>> GetStampCardAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetStampCardAsync(companyId, id, cancellationToken));

    [HttpPost("stamp-cards")]
    public async Task<ActionResult<StampCardDto>> CreateStampCardAsync([FromBody] StampCardWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await stampCardWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateStampCardAsync(request, cancellationToken));
    }

    [HttpPut("stamp-cards/{id:guid}")]
    public async Task<ActionResult<StampCardDto>> UpdateStampCardAsync(Guid id, [FromBody] StampCardWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await stampCardWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateStampCardAsync(id, request, cancellationToken));
    }

    [HttpDelete("stamp-cards/{id:guid}")]
    public async Task<IActionResult> DeleteStampCardAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeleteStampCardAsync(companyId, id, cancellationToken));

    [HttpGet("suppliers")]
    public Task<PagedResult<SupplierDto>> ListSuppliersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListSuppliersAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("suppliers/{id:guid}")]
    public async Task<ActionResult<SupplierDto>> GetSupplierAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetSupplierAsync(companyId, id, cancellationToken));

    [HttpPost("suppliers")]
    public async Task<ActionResult<SupplierDto>> CreateSupplierAsync([FromBody] SupplierWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await supplierWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreateSupplierAsync(request, cancellationToken));
    }

    [HttpPut("suppliers/{id:guid}")]
    public async Task<ActionResult<SupplierDto>> UpdateSupplierAsync(Guid id, [FromBody] SupplierWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await supplierWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdateSupplierAsync(id, request, cancellationToken));
    }

    [HttpDelete("suppliers/{id:guid}")]
    public async Task<IActionResult> DeleteSupplierAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateSupplierAsync(companyId, id, userId, cancellationToken));

    [HttpGet("purchases")]
    public Task<PagedResult<PurchaseDto>> ListPurchasesAsync([FromQuery] Guid companyId, CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sort = null, [FromQuery] string? filter = null) =>
        coreCrudService.ListPurchasesAsync(companyId, Query(page, pageSize, sort, filter), cancellationToken);

    [HttpGet("purchases/{id:guid}")]
    public async Task<ActionResult<PurchaseDto>> GetPurchaseAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.GetPurchaseAsync(companyId, id, cancellationToken));

    [HttpPost("purchases")]
    public async Task<ActionResult<PurchaseDto>> CreatePurchaseAsync([FromBody] PurchaseWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await purchaseWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return CreatedResult(await coreCrudService.CreatePurchaseAsync(request, cancellationToken));
    }

    [HttpPut("purchases/{id:guid}")]
    public async Task<ActionResult<PurchaseDto>> UpdatePurchaseAsync(Guid id, [FromBody] PurchaseWriteDto request, CancellationToken cancellationToken)
    {
        var validationResult = await purchaseWriteValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid) return BadRequest(new ValidationProblemDetails(validationResult.ToDictionary()));

        return NullableResult(await coreCrudService.UpdatePurchaseAsync(id, request, cancellationToken));
    }

    [HttpDelete("purchases/{id:guid}")]
    public async Task<IActionResult> DeletePurchaseAsync(Guid id, [FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeletePurchaseAsync(companyId, id, cancellationToken));

    private ActionResult<T> CreatedResult<T>(T? value) => value is null ? BadRequest() : StatusCode(StatusCodes.Status201Created, value);
    private ActionResult<T> NullableResult<T>(T? value) => value is null ? NotFound() : Ok(value);
    private IActionResult BoolResult(bool value) => value ? NoContent() : NotFound();
    private static ListQuery Query(int page, int pageSize, string? sort, string? filter) => new(page, pageSize, sort, filter);
}
