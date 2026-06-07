namespace Mansis.Pos.Application.Core;

public sealed class CoreCrudService(ICoreCrudStore store)
{
    public Task<PagedResult<ProductDto>> ListProductsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListProductsAsync(companyId, query, cancellationToken);
    public async Task<IReadOnlyList<ProductDto>> ListProductsAsync(Guid companyId, CancellationToken cancellationToken) =>
        (await store.ListProductsAsync(companyId, new ListQuery(PageSize: 500), cancellationToken)).Items;
    public Task<ProductDto?> CreateProductAsync(ProductWriteDto request, CancellationToken cancellationToken) => store.CreateProductAsync(request, cancellationToken);
    public Task<ProductDto?> UpdateProductAsync(Guid id, ProductWriteDto request, CancellationToken cancellationToken) => store.UpdateProductAsync(id, request, cancellationToken);
    public Task<bool> DeactivateProductAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateProductAsync(companyId, id, userId, cancellationToken);
    public Task<PosProductDto?> CreatePosProductAsync(PosProductWriteDto request, CancellationToken cancellationToken) => store.CreatePosProductAsync(request, cancellationToken);
    public Task<PosProductDto?> UpdatePosProductAsync(Guid id, PosProductWriteDto request, CancellationToken cancellationToken) => store.UpdatePosProductAsync(id, request, cancellationToken);
    public Task<IReadOnlyList<PosProductDto>> ListPosProductsForProductAsync(Guid companyId, Guid productId, CancellationToken cancellationToken) => store.ListPosProductsForProductAsync(companyId, productId, cancellationToken);

    public Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync(Guid companyId, CancellationToken cancellationToken) => store.ListCategoriesAsync(companyId, cancellationToken);
    public Task<CategoryDto?> CreateCategoryAsync(CategoryWriteDto request, CancellationToken cancellationToken) => store.CreateCategoryAsync(request, cancellationToken);
    public Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryWriteDto request, CancellationToken cancellationToken) => store.UpdateCategoryAsync(id, request, cancellationToken);
    public Task<bool> DeactivateCategoryAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateCategoryAsync(companyId, id, userId, cancellationToken);

    public Task<PagedResult<CustomerDto>> ListCustomersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListCustomersAsync(companyId, query, cancellationToken);
    public async Task<IReadOnlyList<CustomerDto>> ListCustomersAsync(Guid companyId, CancellationToken cancellationToken) =>
        (await store.ListCustomersAsync(companyId, new ListQuery(PageSize: 500), cancellationToken)).Items;
    public Task<CustomerDetailDto?> GetCustomerAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetCustomerAsync(companyId, id, cancellationToken);
    public Task<CustomerDto?> CreateCustomerAsync(CustomerWriteDto request, CancellationToken cancellationToken) => store.CreateCustomerAsync(request, cancellationToken);
    public Task<CustomerDto?> UpdateCustomerAsync(Guid id, CustomerWriteDto request, CancellationToken cancellationToken) => store.UpdateCustomerAsync(id, request, cancellationToken);
    public Task<bool> DeactivateCustomerAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateCustomerAsync(companyId, id, userId, cancellationToken);
    public Task<WalletAdjustmentDto?> AdjustCustomerWalletAsync(Guid customerId, CustomerWalletAdjustmentRequest request, CancellationToken cancellationToken) => store.AdjustCustomerWalletAsync(customerId, request, cancellationToken);
    public Task<LoyaltyAdjustmentDto?> AdjustCustomerLoyaltyAsync(Guid customerId, CustomerLoyaltyAdjustmentRequest request, CancellationToken cancellationToken) => store.AdjustCustomerLoyaltyAsync(customerId, request, cancellationToken);

    public Task<PagedResult<UserDto>> ListUsersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListUsersAsync(companyId, query, cancellationToken);
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

    public Task<PagedResult<OrderListDto>> ListOrdersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListOrdersAsync(companyId, query, cancellationToken);
    public async Task<IReadOnlyList<OrderListDto>> ListOrdersAsync(Guid companyId, CancellationToken cancellationToken) =>
        (await store.ListOrdersAsync(companyId, new ListQuery(PageSize: 500), cancellationToken)).Items;

    public Task<IReadOnlyList<StoreDto>> ListStoresAsync(Guid companyId, CancellationToken cancellationToken) => store.ListStoresAsync(companyId, cancellationToken);
    public Task<StoreDto?> CreateStoreAsync(StoreWriteDto request, CancellationToken cancellationToken) => store.CreateStoreAsync(request, cancellationToken);
    public Task<StoreDto?> UpdateStoreAsync(Guid id, StoreWriteDto request, CancellationToken cancellationToken) => store.UpdateStoreAsync(id, request, cancellationToken);
    public Task<bool> DeactivateStoreAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateStoreAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<PosDto>> ListPosAsync(Guid companyId, CancellationToken cancellationToken) => store.ListPosAsync(companyId, cancellationToken);
    public Task<PosDto?> CreatePosAsync(PosWriteDto request, CancellationToken cancellationToken) => store.CreatePosAsync(request, cancellationToken);
    public Task<PosDto?> UpdatePosAsync(Guid id, PosWriteDto request, CancellationToken cancellationToken) => store.UpdatePosAsync(id, request, cancellationToken);
    public Task<bool> DeactivatePosAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivatePosAsync(companyId, id, userId, cancellationToken);

    public Task<PagedResult<DiscountDto>> ListDiscountsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListDiscountsAsync(companyId, query, cancellationToken);
    public async Task<IReadOnlyList<DiscountDto>> ListDiscountsAsync(Guid companyId, CancellationToken cancellationToken) =>
        (await store.ListDiscountsAsync(companyId, new ListQuery(PageSize: 500), cancellationToken)).Items;
    public Task<DiscountDto?> GetDiscountAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetDiscountAsync(companyId, id, cancellationToken);
    public Task<DiscountDto?> CreateDiscountAsync(DiscountWriteDto request, CancellationToken cancellationToken) => store.CreateDiscountAsync(request, cancellationToken);
    public Task<DiscountDto?> UpdateDiscountAsync(Guid id, DiscountWriteDto request, CancellationToken cancellationToken) => store.UpdateDiscountAsync(id, request, cancellationToken);
    public Task<bool> DeactivateDiscountAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateDiscountAsync(companyId, id, userId, cancellationToken);
    public Task<PagedResult<CampaignDto>> ListCampaignsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListCampaignsAsync(companyId, query, cancellationToken);
    public Task<CampaignDto?> GetCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetCampaignAsync(companyId, id, cancellationToken);
    public Task<CampaignDto?> CreateCampaignAsync(CampaignWriteDto request, CancellationToken cancellationToken) => store.CreateCampaignAsync(request, cancellationToken);
    public Task<CampaignDto?> UpdateCampaignAsync(Guid id, CampaignWriteDto request, CancellationToken cancellationToken) => store.UpdateCampaignAsync(id, request, cancellationToken);
    public Task<bool> DeleteCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeleteCampaignAsync(companyId, id, cancellationToken);

    public Task<PagedResult<EarnRuleDto>> ListEarnRulesAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListEarnRulesAsync(companyId, query, cancellationToken);
    public Task<EarnRuleDto?> GetEarnRuleAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetEarnRuleAsync(companyId, id, cancellationToken);
    public Task<EarnRuleDto?> CreateEarnRuleAsync(EarnRuleWriteDto request, CancellationToken cancellationToken) => store.CreateEarnRuleAsync(request, cancellationToken);
    public Task<EarnRuleDto?> UpdateEarnRuleAsync(Guid id, EarnRuleWriteDto request, CancellationToken cancellationToken) => store.UpdateEarnRuleAsync(id, request, cancellationToken);
    public Task<bool> DeleteEarnRuleAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeleteEarnRuleAsync(companyId, id, cancellationToken);

    public Task<PagedResult<LoyaltyTierDto>> ListLoyaltyTiersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListLoyaltyTiersAsync(companyId, query, cancellationToken);
    public Task<LoyaltyTierDto?> GetLoyaltyTierAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetLoyaltyTierAsync(companyId, id, cancellationToken);
    public Task<LoyaltyTierDto?> CreateLoyaltyTierAsync(LoyaltyTierWriteDto request, CancellationToken cancellationToken) => store.CreateLoyaltyTierAsync(request, cancellationToken);
    public Task<LoyaltyTierDto?> UpdateLoyaltyTierAsync(Guid id, LoyaltyTierWriteDto request, CancellationToken cancellationToken) => store.UpdateLoyaltyTierAsync(id, request, cancellationToken);
    public Task<bool> DeleteLoyaltyTierAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeleteLoyaltyTierAsync(companyId, id, cancellationToken);

    public Task<PagedResult<RewardDto>> ListRewardsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListRewardsAsync(companyId, query, cancellationToken);
    public Task<RewardDto?> GetRewardAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetRewardAsync(companyId, id, cancellationToken);
    public Task<RewardDto?> CreateRewardAsync(RewardWriteDto request, CancellationToken cancellationToken) => store.CreateRewardAsync(request, cancellationToken);
    public Task<RewardDto?> UpdateRewardAsync(Guid id, RewardWriteDto request, CancellationToken cancellationToken) => store.UpdateRewardAsync(id, request, cancellationToken);
    public Task<bool> DeleteRewardAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeleteRewardAsync(companyId, id, cancellationToken);

    public Task<PagedResult<StampCardDto>> ListStampCardsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListStampCardsAsync(companyId, query, cancellationToken);
    public Task<StampCardDto?> GetStampCardAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetStampCardAsync(companyId, id, cancellationToken);
    public Task<StampCardDto?> CreateStampCardAsync(StampCardWriteDto request, CancellationToken cancellationToken) => store.CreateStampCardAsync(request, cancellationToken);
    public Task<StampCardDto?> UpdateStampCardAsync(Guid id, StampCardWriteDto request, CancellationToken cancellationToken) => store.UpdateStampCardAsync(id, request, cancellationToken);
    public Task<bool> DeleteStampCardAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeleteStampCardAsync(companyId, id, cancellationToken);

    public Task<PagedResult<SupplierDto>> ListSuppliersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListSuppliersAsync(companyId, query, cancellationToken);
    public Task<SupplierDto?> GetSupplierAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetSupplierAsync(companyId, id, cancellationToken);
    public Task<SupplierDto?> CreateSupplierAsync(SupplierWriteDto request, CancellationToken cancellationToken) => store.CreateSupplierAsync(request, cancellationToken);
    public Task<SupplierDto?> UpdateSupplierAsync(Guid id, SupplierWriteDto request, CancellationToken cancellationToken) => store.UpdateSupplierAsync(id, request, cancellationToken);
    public Task<bool> DeactivateSupplierAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateSupplierAsync(companyId, id, userId, cancellationToken);

    public Task<PagedResult<PurchaseDto>> ListPurchasesAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken) => store.ListPurchasesAsync(companyId, query, cancellationToken);
    public Task<PurchaseDto?> GetPurchaseAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.GetPurchaseAsync(companyId, id, cancellationToken);
    public Task<PurchaseDto?> CreatePurchaseAsync(PurchaseWriteDto request, CancellationToken cancellationToken) => store.CreatePurchaseAsync(request, cancellationToken);
    public Task<PurchaseDto?> UpdatePurchaseAsync(Guid id, PurchaseWriteDto request, CancellationToken cancellationToken) => store.UpdatePurchaseAsync(id, request, cancellationToken);
    public Task<bool> DeletePurchaseAsync(Guid companyId, Guid id, CancellationToken cancellationToken) => store.DeletePurchaseAsync(companyId, id, cancellationToken);
}
