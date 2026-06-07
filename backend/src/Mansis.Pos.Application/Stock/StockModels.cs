using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Stock;

public sealed record StockMovementDto(
    Guid Id,
    Guid CompanyId,
    Guid StoreId,
    Guid ProductId,
    Guid? OperationId,
    StoreProductMovementType MovementType,
    LedgerDirection Direction,
    int Quantity,
    LedgerEntryState State,
    Guid? ReversalOfId,
    string? Description,
    DateTimeOffset OccurredAt,
    int CurrentQuantity);

public sealed record StockAdjustmentRequest(
    Guid CompanyId,
    Guid UserId,
    Guid StoreId,
    Guid ProductId,
    int Quantity,
    string? Description);

public sealed record DestroyStockRequest(
    Guid CompanyId,
    Guid UserId,
    Guid StoreId,
    Guid ProductId,
    int Quantity,
    string Reason);

public sealed record StockCountRequest(
    Guid CompanyId,
    Guid UserId,
    Guid StoreId,
    Guid ProductId,
    int CountedQuantity,
    string? Description);

public sealed record StockMovementFilter(
    Guid CompanyId,
    Guid? StoreId,
    Guid? ProductId,
    StoreProductMovementType? MovementType,
    DateTimeOffset? From,
    DateTimeOffset? To,
    int Page = 1,
    int PageSize = 50,
    string? Sort = null,
    string? Filter = null);

public sealed record TransferLineWriteDto(Guid ProductId, int Quantity, ProductUnitType? Unit, decimal? UnitPrice);

public sealed record StoreProductTransferDto(
    Guid Id,
    Guid CompanyId,
    Guid SourceStoreId,
    Guid TargetStoreId,
    Guid RequestedById,
    DateTimeOffset RequestedTime,
    ProductTransferState TransferState,
    Guid? ConfirmedById,
    DateTimeOffset? ConfirmedTime,
    Guid? ReceivedById,
    DateTimeOffset? ReceivedTime,
    Guid? CancelledById,
    DateTimeOffset? CancelledTime,
    string? CancelReason,
    bool? TransferDone,
    IReadOnlyList<StoreProductTransferLineDto> Lines);

public sealed record StoreProductTransferLineDto(
    Guid Id,
    Guid ProductId,
    int Quantity,
    int? ReceivedQuantity,
    ProductUnitType? Unit,
    decimal? UnitPrice);

public sealed record CreateTransferRequest(
    Guid CompanyId,
    Guid UserId,
    Guid SourceStoreId,
    Guid TargetStoreId,
    IReadOnlyList<TransferLineWriteDto> Lines);

public sealed record ConfirmTransferRequest(Guid CompanyId, Guid UserId);
public sealed record ReceiveTransferLineDto(Guid ProductId, int ReceivedQuantity);
public sealed record ReceiveTransferRequest(Guid CompanyId, Guid UserId, IReadOnlyList<ReceiveTransferLineDto> Lines);
public sealed record CancelTransferRequest(Guid CompanyId, Guid UserId, string Reason);
