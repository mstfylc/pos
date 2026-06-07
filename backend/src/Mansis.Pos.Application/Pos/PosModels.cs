using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Pos;

public sealed record PosProductCatalogResponse(IReadOnlyList<PosProductCategoryDto> Categories);

public sealed record PosProductCategoryDto(
    Guid CategoryId,
    string Name,
    int SortOrder,
    string? ColorName,
    string? ColorContent,
    string? ShapeName,
    string? ShapeContent,
    IReadOnlyList<PosProductSaleDto> Products);

public sealed record PosProductSaleDto(
    Guid ProductId,
    Guid PosProductId,
    string Name,
    Guid CategoryId,
    decimal? BaseSalePrice,
    decimal? SalePrice,
    decimal? PurchasePrice,
    string? Barcode,
    string? StockCode,
    string? Image,
    ProductUnitType ProductUnitType,
    TaxType TaxType,
    bool Stocktaking,
    bool FavoriteProduct,
    int SortOrder,
    int StockQuantity);

public sealed record IssueCustomerCardTokenRequest(Guid CompanyId, Guid CustomerId, int ExpiresInSeconds = 300);

public sealed record CustomerCardTokenResponse(Guid CustomerId, string Token, DateTimeOffset ExpiresAt);

public sealed record IdentifyCustomerRequest(Guid CompanyId, string? Token, string? CardNumber);

public sealed record IdentifiedCustomerDto(
    Guid CustomerId,
    string Name,
    string Surname,
    string? Phone,
    string? Mail,
    decimal WalletBalance,
    int PointBalance,
    int LifetimePoints,
    Guid? TierId,
    string? TierName);

public sealed record LoyaltyPreviewRequest(
    Guid CompanyId,
    Guid PosId,
    Guid CustomerId,
    IReadOnlyList<LoyaltyPreviewLine> Lines);

public sealed record LoyaltyPreviewLine(Guid ProductId, int Quantity, decimal UnitPrice, decimal TaxAmount = 0m);

public sealed record LoyaltyPreviewResponse(
    decimal GrossTotal,
    decimal CampaignDiscount,
    decimal FinalTotal,
    int EarnPoints,
    DateTimeOffset? EarnExpiresAt,
    int CampaignExtraPoints,
    IReadOnlyList<string> AppliedCampaigns,
    IReadOnlyList<AvailableRewardDto> AvailableRewards);

public sealed record AvailableRewardDto(
    Guid RewardId,
    string Name,
    int RequiredPoints,
    RewardType RewardType,
    decimal? DiscountAmount,
    Guid? ProductId);
