using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Core;

public sealed record ProductDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    Guid CategoryId,
    decimal? PurchasePrice,
    decimal? SalePrice,
    string? Barcode,
    string? StockCode,
    ProductUnitType ProductUnitType,
    TaxType TaxType,
    bool Stocktaking,
    string? Image,
    bool StoreProduct,
    bool PosProduct,
    bool EntryProduct,
    bool FavoriteProduct,
    int SortOrder,
    string? Description,
    bool Main,
    Guid? ParentId,
    bool Active);

public sealed record ProductWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    Guid CategoryId,
    decimal? PurchasePrice,
    decimal? SalePrice,
    string? Barcode,
    string? StockCode,
    ProductUnitType ProductUnitType,
    TaxType TaxType,
    bool Stocktaking,
    string? Image,
    bool StoreProduct,
    bool PosProduct,
    bool EntryProduct,
    bool FavoriteProduct,
    int SortOrder,
    string? Description,
    bool Main,
    Guid? ParentId);

public sealed record PosProductDto(Guid Id, Guid CompanyId, Guid PosId, Guid ProductId, decimal? PurchasePrice, decimal? SalePrice);
public sealed record PosProductWriteDto(Guid CompanyId, Guid UserId, Guid PosId, Guid ProductId, decimal? PurchasePrice, decimal? SalePrice);

// TODO: ProductSubProduct combo/recipe DTOs are intentionally out of scope until recipe requirements are defined.

public sealed record CategoryDto(Guid Id, Guid CompanyId, string Name, int SortOrder, bool Active);
public sealed record CategoryWriteDto(Guid CompanyId, Guid UserId, string Name, int SortOrder, Guid CategoryColorId, Guid CategoryShapeId);
public sealed record CategoryColorDto(Guid Id, Guid CompanyId, string Name, string Content, bool Active);
public sealed record CategoryShapeDto(Guid Id, Guid CompanyId, string Name, string Content, bool Active);

public sealed record CustomerDto(Guid Id, Guid CompanyId, string Name, string Surname, string Username, string? Phone, string? Mail, decimal Balance, bool Active);

public sealed record CustomerDetailDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    string Surname,
    string Username,
    string? Phone,
    string? Mail,
    decimal Balance,
    bool Active,
    IReadOnlyList<AddressDto> Addresses,
    WalletAccountDto? Wallet,
    LoyaltyAccountDto? Loyalty);

public sealed record CustomerWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    string Surname,
    string Username,
    string? Phone,
    string? Mail,
    Guid RoleId,
    IReadOnlyList<AddressWriteDto>? Addresses = null);

public sealed record AddressDto(
    Guid Id,
    AddressType AddressType,
    string? AddressHeader,
    Guid CityId,
    Guid TownId,
    string? District,
    string? MobilePhone,
    string? BusinessPhone,
    string? Description);

public sealed record AddressWriteDto(
    Guid? Id,
    AddressType AddressType,
    string? AddressHeader,
    Guid CityId,
    Guid TownId,
    string? District,
    string? MobilePhone,
    string? BusinessPhone,
    string? Description);

public sealed record WalletAccountDto(Guid Id, Guid CompanyId, Guid CustomerId, string Currency, decimal Balance);
public sealed record LoyaltyAccountDto(Guid Id, Guid CompanyId, Guid CustomerId, Guid? LoyaltyTierId, int PointBalance, int LifetimePoints);
public sealed record CustomerWalletAdjustmentRequest(Guid CompanyId, Guid UserId, decimal Amount, LedgerDirection Direction, string Reason);
public sealed record CustomerLoyaltyAdjustmentRequest(Guid CompanyId, Guid UserId, int Points, LedgerDirection Direction, string Reason);
public sealed record WalletAdjustmentDto(WalletAccountDto Account, Guid TransactionId);
public sealed record LoyaltyAdjustmentDto(LoyaltyAccountDto Account, Guid TransactionId);

public sealed record UserDto(
    Guid Id,
    Guid CompanyId,
    string FirstName,
    string LastName,
    string Username,
    string? Phone,
    string? Mail,
    Guid RoleId,
    Guid? CardId,
    string? Pin,
    bool MustChangePassword,
    bool Active,
    IReadOnlyList<Guid> BranchIds,
    IReadOnlyList<Guid> PosIds,
    IReadOnlyList<Guid> StoreIds);

public sealed record UserWriteDto(
    Guid CompanyId,
    Guid UserId,
    string FirstName,
    string LastName,
    string Username,
    string? Phone,
    string? Mail,
    Guid RoleId,
    Guid? CardId,
    string? Pin,
    string? Password,
    bool MustChangePassword,
    IReadOnlyList<Guid> BranchIds,
    IReadOnlyList<Guid> PosIds,
    IReadOnlyList<Guid> StoreIds);

public sealed record RoleDto(Guid Id, Guid CompanyId, string Name, bool Active, IReadOnlyList<Guid> PermissionIds);
public sealed record RoleWriteDto(Guid CompanyId, Guid UserId, string Name);
public sealed record PermissionDto(Guid Id, string Name, string? DisplayName, PermissionType PermissionType);
public sealed record RolePermissionWriteDto(Guid CompanyId, Guid UserId, IReadOnlyList<Guid> PermissionIds);

public sealed record AssignmentDto(
    Guid Id,
    Guid UserId,
    Guid CompanyId,
    AssignmentTableType AssignmentTableType,
    IReadOnlyList<AssignmentRecordDto> Records);

public sealed record AssignmentRecordDto(Guid RecordId, string RecordName);
public sealed record AssignmentWriteDto(Guid CompanyId, Guid UserId, AssignmentTableType AssignmentTableType, IReadOnlyList<Guid> RecordIds);

public sealed record OrderListDto(
    Guid Id,
    Guid CompanyId,
    Guid PosId,
    Guid? CustomerId,
    DateTimeOffset OrderTime,
    decimal SubTotal,
    decimal TaxTotal,
    decimal? TotalDiscount,
    decimal Total,
    OrderState OrderState,
    PaymentSummary PaymentSummary,
    string? Description,
    Guid? AddressId);

public sealed record StoreDto(Guid Id, Guid CompanyId, string Name, Guid? BranchId, bool Active);
public sealed record StoreWriteDto(Guid CompanyId, Guid UserId, string Name, Guid? BranchId);
public sealed record BranchDto(Guid Id, Guid CompanyId, string Name, string? Address, string? Phone, EntryTrackingMode EntryTrackingMode, bool Active);

public sealed record PosDto(Guid Id, Guid CompanyId, string Name, Guid BranchId, Guid StoreId, bool Active);
public sealed record PosWriteDto(Guid CompanyId, Guid UserId, string Name, Guid BranchId, Guid StoreId);

public sealed record DiscountDto(
    Guid Id,
    Guid CompanyId,
    string? Description,
    decimal Amount,
    decimal MaxDiscountAmount,
    decimal? MonthlyLimit,
    DateTimeOffset? ExpireDate,
    DiscountType DiscountType,
    DiscountCategory DiscountCategory,
    int SortOrder,
    bool Active,
    IReadOnlyList<Guid> BranchIds,
    IReadOnlyList<Guid> PosIds,
    IReadOnlyList<Guid> UserIds);

public sealed record DiscountWriteDto(
    Guid CompanyId,
    Guid UserId,
    string? Description,
    decimal Amount,
    decimal MaxDiscountAmount,
    decimal? MonthlyLimit,
    DateTimeOffset? ExpireDate,
    DiscountType DiscountType,
    DiscountCategory DiscountCategory,
    int SortOrder,
    IReadOnlyList<Guid> BranchIds,
    IReadOnlyList<Guid> PosIds,
    IReadOnlyList<Guid> UserIds);

public sealed record CampaignDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    string? Description,
    CampaignType CampaignType,
    string RuleJson,
    int Priority,
    decimal? MaxTotalDiscount,
    Guid? TargetTierId,
    DateTimeOffset? StartsAt,
    DateTimeOffset? EndsAt,
    bool Active);

public sealed record CampaignWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    string? Description,
    CampaignType CampaignType,
    string RuleJson,
    int Priority,
    decimal? MaxTotalDiscount,
    Guid? TargetTierId,
    DateTimeOffset? StartsAt,
    DateTimeOffset? EndsAt,
    bool Active);

public sealed record EarnRuleDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    decimal PointsPerCurrency,
    decimal MinOrder,
    int? ExpiryDays,
    EarnRuleScope Scope,
    Guid? BranchId,
    Guid? CategoryId,
    DateTimeOffset? StartsAt,
    DateTimeOffset? EndsAt,
    bool Active);

public sealed record EarnRuleWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    decimal PointsPerCurrency,
    decimal MinOrder,
    int? ExpiryDays,
    EarnRuleScope Scope,
    Guid? BranchId,
    Guid? CategoryId,
    DateTimeOffset? StartsAt,
    DateTimeOffset? EndsAt,
    bool Active);

public sealed record LoyaltyTierDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    int MinPoints,
    decimal PointMultiplier,
    string? Benefits,
    bool Active);

public sealed record LoyaltyTierWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    int MinPoints,
    decimal PointMultiplier,
    string? Benefits,
    bool Active);

public sealed record RewardDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    int PointCost,
    RewardType RewardType,
    decimal? DiscountAmount,
    string? Image,
    Guid? ProductId,
    bool Active);

public sealed record RewardWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    int PointCost,
    RewardType RewardType,
    decimal? DiscountAmount,
    string? Image,
    Guid? ProductId,
    bool Active);

public sealed record StampCardDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    int RequiredStamps,
    Guid? RewardId,
    DateTimeOffset? StartsAt,
    DateTimeOffset? EndsAt,
    bool Active);

public sealed record StampCardWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    int RequiredStamps,
    Guid? RewardId,
    DateTimeOffset? StartsAt,
    DateTimeOffset? EndsAt,
    bool Active);

public sealed record SupplierDto(
    Guid Id,
    Guid CompanyId,
    string Name,
    string? AuthorizedPerson,
    string? Address,
    string? Phone,
    string? Mail,
    string? TaxOffice,
    string? TaxNo,
    bool? TaxFree,
    MoneyUnitType? MoneyUnitType,
    int? Maturity,
    decimal? OpeningBalance,
    bool Active);

public sealed record SupplierWriteDto(
    Guid CompanyId,
    Guid UserId,
    string Name,
    string? AuthorizedPerson,
    string? Address,
    string? Phone,
    string? Mail,
    string? TaxOffice,
    string? TaxNo,
    bool? TaxFree,
    MoneyUnitType? MoneyUnitType,
    int? Maturity,
    decimal? OpeningBalance);

public sealed record PurchaseDto(
    Guid Id,
    Guid CompanyId,
    DateTimeOffset? PurchaseTime,
    string? Invoice,
    decimal Total,
    bool PaymentCompleted,
    bool Received,
    Guid? PayerId,
    Guid? ReceiverId,
    Guid SupplierId,
    Guid StoreId,
    IReadOnlyList<PurchaseLineDto> Lines);

public sealed record PurchaseLineDto(Guid Id, Guid ProductId, int Quantity, decimal Price, decimal Total, int? Discount, int? Tax);
public sealed record PurchaseLineWriteDto(Guid ProductId, int Quantity, decimal Price, int? Discount, int? Tax);

public sealed record PurchaseWriteDto(
    Guid CompanyId,
    Guid UserId,
    DateTimeOffset? PurchaseTime,
    string? Invoice,
    bool PaymentCompleted,
    bool Received,
    Guid? PayerId,
    Guid? ReceiverId,
    Guid SupplierId,
    Guid StoreId,
    IReadOnlyList<PurchaseLineWriteDto> Lines);
