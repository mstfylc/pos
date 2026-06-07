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
    IValidator<UserWriteDto> userWriteValidator,
    IValidator<RoleWriteDto> roleWriteValidator,
    IValidator<RolePermissionWriteDto> rolePermissionWriteValidator,
    IValidator<AssignmentWriteDto> assignmentWriteValidator,
    IValidator<DiscountWriteDto> discountWriteValidator,
    IValidator<CampaignWriteDto> campaignWriteValidator) : ControllerBase
{
    [HttpGet("products")]
    public Task<IReadOnlyList<ProductDto>> ListProductsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListProductsAsync(companyId, cancellationToken);

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
    public Task<IReadOnlyList<CustomerDto>> ListCustomersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListCustomersAsync(companyId, cancellationToken);

    [HttpPost("customers")]
    public async Task<ActionResult<CustomerDto>> CreateCustomerAsync([FromBody] CustomerWriteDto request, CancellationToken cancellationToken) =>
        CreatedResult(await coreCrudService.CreateCustomerAsync(request, cancellationToken));

    [HttpPut("customers/{id:guid}")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomerAsync(Guid id, [FromBody] CustomerWriteDto request, CancellationToken cancellationToken) =>
        NullableResult(await coreCrudService.UpdateCustomerAsync(id, request, cancellationToken));

    [HttpDelete("customers/{id:guid}")]
    public async Task<IActionResult> DeleteCustomerAsync(Guid id, [FromQuery] Guid companyId, [FromQuery] Guid userId, CancellationToken cancellationToken) =>
        BoolResult(await coreCrudService.DeactivateCustomerAsync(companyId, id, userId, cancellationToken));

    [HttpGet("users")]
    public Task<IReadOnlyList<UserDto>> ListUsersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListUsersAsync(companyId, cancellationToken);

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
    public Task<IReadOnlyList<OrderListDto>> ListOrdersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListOrdersAsync(companyId, cancellationToken);

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
    public Task<IReadOnlyList<DiscountDto>> ListDiscountsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListDiscountsAsync(companyId, cancellationToken);

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
    public Task<IReadOnlyList<CampaignDto>> ListCampaignsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListCampaignsAsync(companyId, cancellationToken);

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

    private ActionResult<T> CreatedResult<T>(T? value) => value is null ? BadRequest() : StatusCode(StatusCodes.Status201Created, value);
    private ActionResult<T> NullableResult<T>(T? value) => value is null ? NotFound() : Ok(value);
    private IActionResult BoolResult(bool value) => value ? NoContent() : NotFound();
}
