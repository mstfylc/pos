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

public sealed record CustomerDto(Guid Id, Guid CompanyId, string Name, string Surname, string Username, string? Phone, string? Mail, decimal Balance, bool Active);
public sealed record CustomerWriteDto(Guid CompanyId, Guid UserId, string Name, string Surname, string Username, string? Phone, string? Mail, Guid RoleId);

public sealed record OrderListDto(Guid Id, Guid CompanyId, Guid PosId, Guid? CustomerId, DateTimeOffset OrderTime, decimal Total, OrderState OrderState, PaymentSummary PaymentSummary);

public sealed record StoreDto(Guid Id, Guid CompanyId, string Name, Guid? BranchId, bool Active);
public sealed record StoreWriteDto(Guid CompanyId, Guid UserId, string Name, Guid? BranchId);

public sealed record PosDto(Guid Id, Guid CompanyId, string Name, Guid BranchId, Guid StoreId, bool Active);
public sealed record PosWriteDto(Guid CompanyId, Guid UserId, string Name, Guid BranchId, Guid StoreId);

public sealed record DiscountDto(Guid Id, Guid CompanyId, string? Description, decimal Amount, decimal MaxDiscountAmount, DateTimeOffset? ExpireDate, DiscountType DiscountType, DiscountCategory DiscountCategory, bool Active);
public sealed record DiscountWriteDto(Guid CompanyId, Guid UserId, string? Description, decimal Amount, decimal MaxDiscountAmount, DateTimeOffset? ExpireDate, DiscountType DiscountType, DiscountCategory DiscountCategory, int SortOrder);
