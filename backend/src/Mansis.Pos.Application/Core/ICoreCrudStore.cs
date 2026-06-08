namespace Mansis.Pos.Application.Core;

public interface ICoreCrudStore
{
    Task<PagedResult<ProductDto>> ListProductsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<ProductDto?> CreateProductAsync(ProductWriteDto request, CancellationToken cancellationToken);
    Task<ProductDto?> UpdateProductAsync(Guid id, ProductWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateProductAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);
    Task<PosProductDto?> CreatePosProductAsync(PosProductWriteDto request, CancellationToken cancellationToken);
    Task<PosProductDto?> UpdatePosProductAsync(Guid id, PosProductWriteDto request, CancellationToken cancellationToken);
    Task<IReadOnlyList<PosProductDto>> ListPosProductsForProductAsync(Guid companyId, Guid productId, CancellationToken cancellationToken);

    Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync(Guid companyId, CancellationToken cancellationToken);
    Task<IReadOnlyList<CategoryColorDto>> ListCategoryColorsAsync(Guid companyId, CancellationToken cancellationToken);
    Task<IReadOnlyList<CategoryShapeDto>> ListCategoryShapesAsync(Guid companyId, CancellationToken cancellationToken);
    Task<CategoryDto?> CreateCategoryAsync(CategoryWriteDto request, CancellationToken cancellationToken);
    Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateCategoryAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<PagedResult<CustomerDto>> ListCustomersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<CustomerDetailDto?> GetCustomerAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<CustomerDto?> CreateCustomerAsync(CustomerWriteDto request, CancellationToken cancellationToken);
    Task<CustomerDto?> UpdateCustomerAsync(Guid id, CustomerWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateCustomerAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);
    Task<WalletAdjustmentDto?> AdjustCustomerWalletAsync(Guid customerId, CustomerWalletAdjustmentRequest request, CancellationToken cancellationToken);
    Task<LoyaltyAdjustmentDto?> AdjustCustomerLoyaltyAsync(Guid customerId, CustomerLoyaltyAdjustmentRequest request, CancellationToken cancellationToken);

    Task<PagedResult<UserDto>> ListUsersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<UserDto?> GetUserAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<UserDto?> CreateUserAsync(UserWriteDto request, CancellationToken cancellationToken);
    Task<UserDto?> UpdateUserAsync(Guid id, UserWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateUserAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<RoleDto>> ListRolesAsync(Guid companyId, CancellationToken cancellationToken);
    Task<RoleDto?> GetRoleAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<RoleDto?> CreateRoleAsync(RoleWriteDto request, CancellationToken cancellationToken);
    Task<RoleDto?> UpdateRoleAsync(Guid id, RoleWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateRoleAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);
    Task<IReadOnlyList<PermissionDto>> ListPermissionsAsync(CancellationToken cancellationToken);
    Task<RoleDto?> UpdateRolePermissionsAsync(Guid roleId, RolePermissionWriteDto request, CancellationToken cancellationToken);

    Task<IReadOnlyList<AssignmentDto>> ListAssignmentsAsync(Guid companyId, Guid? userId, CancellationToken cancellationToken);
    Task<AssignmentDto?> GetAssignmentAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<AssignmentDto?> CreateAssignmentAsync(AssignmentWriteDto request, CancellationToken cancellationToken);
    Task<AssignmentDto?> UpdateAssignmentAsync(Guid id, AssignmentWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeleteAssignmentAsync(Guid companyId, Guid id, CancellationToken cancellationToken);

    Task<PagedResult<OrderListDto>> ListOrdersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);

    Task<IReadOnlyList<BranchDto>> ListBranchesAsync(Guid companyId, CancellationToken cancellationToken);
    Task<IReadOnlyList<StoreDto>> ListStoresAsync(Guid companyId, CancellationToken cancellationToken);
    Task<StoreDto?> CreateStoreAsync(StoreWriteDto request, CancellationToken cancellationToken);
    Task<StoreDto?> UpdateStoreAsync(Guid id, StoreWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateStoreAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<PosDto>> ListPosAsync(Guid companyId, CancellationToken cancellationToken);
    Task<PosDto?> CreatePosAsync(PosWriteDto request, CancellationToken cancellationToken);
    Task<PosDto?> UpdatePosAsync(Guid id, PosWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivatePosAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<PagedResult<DiscountDto>> ListDiscountsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<DiscountDto?> GetDiscountAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<DiscountDto?> CreateDiscountAsync(DiscountWriteDto request, CancellationToken cancellationToken);
    Task<DiscountDto?> UpdateDiscountAsync(Guid id, DiscountWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateDiscountAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<PagedResult<CampaignDto>> ListCampaignsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<CampaignDto?> GetCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<CampaignDto?> CreateCampaignAsync(CampaignWriteDto request, CancellationToken cancellationToken);
    Task<CampaignDto?> UpdateCampaignAsync(Guid id, CampaignWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeleteCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken);

    Task<PagedResult<EarnRuleDto>> ListEarnRulesAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<EarnRuleDto?> GetEarnRuleAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<EarnRuleDto?> CreateEarnRuleAsync(EarnRuleWriteDto request, CancellationToken cancellationToken);
    Task<EarnRuleDto?> UpdateEarnRuleAsync(Guid id, EarnRuleWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeleteEarnRuleAsync(Guid companyId, Guid id, CancellationToken cancellationToken);

    Task<PagedResult<LoyaltyTierDto>> ListLoyaltyTiersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<LoyaltyTierDto?> GetLoyaltyTierAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<LoyaltyTierDto?> CreateLoyaltyTierAsync(LoyaltyTierWriteDto request, CancellationToken cancellationToken);
    Task<LoyaltyTierDto?> UpdateLoyaltyTierAsync(Guid id, LoyaltyTierWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeleteLoyaltyTierAsync(Guid companyId, Guid id, CancellationToken cancellationToken);

    Task<PagedResult<RewardDto>> ListRewardsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<RewardDto?> GetRewardAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<RewardDto?> CreateRewardAsync(RewardWriteDto request, CancellationToken cancellationToken);
    Task<RewardDto?> UpdateRewardAsync(Guid id, RewardWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeleteRewardAsync(Guid companyId, Guid id, CancellationToken cancellationToken);

    Task<PagedResult<StampCardDto>> ListStampCardsAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<StampCardDto?> GetStampCardAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<StampCardDto?> CreateStampCardAsync(StampCardWriteDto request, CancellationToken cancellationToken);
    Task<StampCardDto?> UpdateStampCardAsync(Guid id, StampCardWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeleteStampCardAsync(Guid companyId, Guid id, CancellationToken cancellationToken);

    Task<PagedResult<SupplierDto>> ListSuppliersAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<SupplierDto?> GetSupplierAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<SupplierDto?> CreateSupplierAsync(SupplierWriteDto request, CancellationToken cancellationToken);
    Task<SupplierDto?> UpdateSupplierAsync(Guid id, SupplierWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateSupplierAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<PagedResult<PurchaseDto>> ListPurchasesAsync(Guid companyId, ListQuery query, CancellationToken cancellationToken);
    Task<PurchaseDto?> GetPurchaseAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
    Task<PurchaseDto?> CreatePurchaseAsync(PurchaseWriteDto request, CancellationToken cancellationToken);
    Task<PurchaseDto?> UpdatePurchaseAsync(Guid id, PurchaseWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeletePurchaseAsync(Guid companyId, Guid id, CancellationToken cancellationToken);
}
