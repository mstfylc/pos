using Mansis.Pos.Domain.Enumerations;

using Mansis.Pos.Application.Core;

namespace Mansis.Pos.Application.Stock;

public interface IStockStore
{
    Task<PagedResult<StockMovementDto>> ListMovementsAsync(StockMovementFilter filter, CancellationToken cancellationToken);
    Task<StockMovementDto?> ApplyStockMovementAsync(StockAdjustmentRequest request, StoreProductMovementType movementType, LedgerDirection direction, string? description, CancellationToken cancellationToken);
    Task<StockMovementDto?> ApplyStockCountAsync(StockCountRequest request, CancellationToken cancellationToken);
    Task<StoreProductTransferDto?> CreateTransferAsync(CreateTransferRequest request, CancellationToken cancellationToken);
    Task<StoreProductTransferDto?> ConfirmTransferAsync(Guid transferId, ConfirmTransferRequest request, CancellationToken cancellationToken);
    Task<StoreProductTransferDto?> ReceiveTransferAsync(Guid transferId, ReceiveTransferRequest request, CancellationToken cancellationToken);
    Task<StoreProductTransferDto?> CancelTransferAsync(Guid transferId, CancelTransferRequest request, CancellationToken cancellationToken);
}
