namespace Mansis.Pos.Application.Core;

public sealed class CoreCrudService(ICoreCrudStore store)
{
    public Task<IReadOnlyList<ProductDto>> ListProductsAsync(Guid companyId, CancellationToken cancellationToken) => store.ListProductsAsync(companyId, cancellationToken);
    public Task<ProductDto?> CreateProductAsync(ProductWriteDto request, CancellationToken cancellationToken) => store.CreateProductAsync(request, cancellationToken);
    public Task<ProductDto?> UpdateProductAsync(Guid id, ProductWriteDto request, CancellationToken cancellationToken) => store.UpdateProductAsync(id, request, cancellationToken);
    public Task<bool> DeactivateProductAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateProductAsync(companyId, id, userId, cancellationToken);
    public Task<PosProductDto?> CreatePosProductAsync(PosProductWriteDto request, CancellationToken cancellationToken) => store.CreatePosProductAsync(request, cancellationToken);
    public Task<PosProductDto?> UpdatePosProductAsync(Guid id, PosProductWriteDto request, CancellationToken cancellationToken) => store.UpdatePosProductAsync(id, request, cancellationToken);

    public Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync(Guid companyId, CancellationToken cancellationToken) => store.ListCategoriesAsync(companyId, cancellationToken);
    public Task<CategoryDto?> CreateCategoryAsync(CategoryWriteDto request, CancellationToken cancellationToken) => store.CreateCategoryAsync(request, cancellationToken);
    public Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryWriteDto request, CancellationToken cancellationToken) => store.UpdateCategoryAsync(id, request, cancellationToken);
    public Task<bool> DeactivateCategoryAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateCategoryAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<CustomerDto>> ListCustomersAsync(Guid companyId, CancellationToken cancellationToken) => store.ListCustomersAsync(companyId, cancellationToken);
    public Task<CustomerDto?> CreateCustomerAsync(CustomerWriteDto request, CancellationToken cancellationToken) => store.CreateCustomerAsync(request, cancellationToken);
    public Task<CustomerDto?> UpdateCustomerAsync(Guid id, CustomerWriteDto request, CancellationToken cancellationToken) => store.UpdateCustomerAsync(id, request, cancellationToken);
    public Task<bool> DeactivateCustomerAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateCustomerAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<UserDto>> ListUsersAsync(Guid companyId, CancellationToken cancellationToken) => store.ListUsersAsync(companyId, cancellationToken);
    public Task<UserDto?> GetUserAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetUserAsync(companyId, id, cancellationToken);
    public Task<UserDto?> CreateUserAsync(UserWriteDto request, CancellationToken cancellationToken) => store.CreateUserAsync(request, cancellationToken);
    public Task<UserDto?> UpdateUserAsync(Guid id, UserWriteDto request, CancellationToken cancellationToken) => store.UpdateUserAsync(id, request, cancellationToken);
    public Task<bool> DeactivateUserAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateUserAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<RoleDto>> ListRolesAsync(Guid companyId, CancellationToken cancellationToken) => store.ListRolesAsync(companyId, cancellationToken);
    public Task<RoleDto?> GetRoleAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetRoleAsync(companyId, id, cancellationToken);
    public Task<RoleDto?> CreateRoleAsync(RoleWriteDto request, CancellationToken cancellationToken) => store.CreateRoleAsync(request, cancellationToken);
    public Task<RoleDto?> UpdateRoleAsync(Guid id, RoleWriteDto request, CancellationToken cancellationToken) => store.UpdateRoleAsync(id, request, cancellationToken);
    public Task<bool> DeactivateRoleAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateRoleAsync(companyId, id, userId, cancellationToken);
    public Task<IReadOnlyList<PermissionDto>> ListPermissionsAsync(CancellationToken cancellationToken) => store.ListPermissionsAsync(cancellationToken);
    public Task<RoleDto?> UpdateRolePermissionsAsync(Guid roleId, RolePermissionWriteDto request, CancellationToken cancellationToken) => store.UpdateRolePermissionsAsync(roleId, request, cancellationToken);

    public Task<IReadOnlyList<AssignmentDto>> ListAssignmentsAsync(Guid companyId, Guid? userId, CancellationToken cancellationToken) => store.ListAssignmentsAsync(companyId, userId, cancellationToken);
    public Task<AssignmentDto?> GetAssignmentAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetAssignmentAsync(companyId, id, cancellationToken);
    public Task<AssignmentDto?> CreateAssignmentAsync(AssignmentWriteDto request, CancellationToken cancellationToken) => store.CreateAssignmentAsync(request, cancellationToken);
    public Task<AssignmentDto?> UpdateAssignmentAsync(Guid id, AssignmentWriteDto request, CancellationToken cancellationToken) => store.UpdateAssignmentAsync(id, request, cancellationToken);
    public Task<bool> DeleteAssignmentAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeleteAssignmentAsync(companyId, id, cancellationToken);

    public Task<IReadOnlyList<OrderListDto>> ListOrdersAsync(Guid companyId, CancellationToken cancellationToken) => store.ListOrdersAsync(companyId, cancellationToken);

    public Task<IReadOnlyList<StoreDto>> ListStoresAsync(Guid companyId, CancellationToken cancellationToken) => store.ListStoresAsync(companyId, cancellationToken);
    public Task<StoreDto?> CreateStoreAsync(StoreWriteDto request, CancellationToken cancellationToken) => store.CreateStoreAsync(request, cancellationToken);
    public Task<StoreDto?> UpdateStoreAsync(Guid id, StoreWriteDto request, CancellationToken cancellationToken) => store.UpdateStoreAsync(id, request, cancellationToken);
    public Task<bool> DeactivateStoreAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateStoreAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<PosDto>> ListPosAsync(Guid companyId, CancellationToken cancellationToken) => store.ListPosAsync(companyId, cancellationToken);
    public Task<PosDto?> CreatePosAsync(PosWriteDto request, CancellationToken cancellationToken) => store.CreatePosAsync(request, cancellationToken);
    public Task<PosDto?> UpdatePosAsync(Guid id, PosWriteDto request, CancellationToken cancellationToken) => store.UpdatePosAsync(id, request, cancellationToken);
    public Task<bool> DeactivatePosAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivatePosAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<DiscountDto>> ListDiscountsAsync(Guid companyId, CancellationToken cancellationToken) => store.ListDiscountsAsync(companyId, cancellationToken);
    public Task<DiscountDto?> GetDiscountAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetDiscountAsync(companyId, id, cancellationToken);
    public Task<DiscountDto?> CreateDiscountAsync(DiscountWriteDto request, CancellationToken cancellationToken) => store.CreateDiscountAsync(request, cancellationToken);
    public Task<DiscountDto?> UpdateDiscountAsync(Guid id, DiscountWriteDto request, CancellationToken cancellationToken) => store.UpdateDiscountAsync(id, request, cancellationToken);
    public Task<bool> DeactivateDiscountAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateDiscountAsync(companyId, id, userId, cancellationToken);
    public Task<IReadOnlyList<CampaignDto>> ListCampaignsAsync(Guid companyId, CancellationToken cancellationToken) => store.ListCampaignsAsync(companyId, cancellationToken);
    public Task<CampaignDto?> GetCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetCampaignAsync(companyId, id, cancellationToken);
    public Task<CampaignDto?> CreateCampaignAsync(CampaignWriteDto request, CancellationToken cancellationToken) => store.CreateCampaignAsync(request, cancellationToken);
    public Task<CampaignDto?> UpdateCampaignAsync(Guid id, CampaignWriteDto request, CancellationToken cancellationToken) => store.UpdateCampaignAsync(id, request, cancellationToken);
    public Task<bool> DeleteCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeleteCampaignAsync(companyId, id, cancellationToken);
}
