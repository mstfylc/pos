using FluentValidation;
using Mansis.Pos.Application.Common;
using Mansis.Pos.Domain.Enumerations;

using Mansis.Pos.Application.Core;

namespace Mansis.Pos.Application.Stock;

public sealed class StockService(
    IStockStore store,
    IValidator<StockAdjustmentRequest> stockAdjustmentValidator,
    IValidator<DestroyStockRequest> destroyStockValidator,
    IValidator<StockCountRequest> stockCountValidator,
    IValidator<CreateTransferRequest> createTransferValidator,
    IValidator<ConfirmTransferRequest> confirmTransferValidator,
    IValidator<ReceiveTransferRequest> receiveTransferValidator,
    IValidator<CancelTransferRequest> cancelTransferValidator)
{
    public Task<PagedResult<StockMovementDto>> ListMovementsAsync(StockMovementFilter filter, CancellationToken cancellationToken) =>
        store.ListMovementsAsync(filter, cancellationToken);

    public async Task<Result<StockMovementDto>> StockInAsync(StockAdjustmentRequest request, CancellationToken cancellationToken)
    {
        var validation = await stockAdjustmentValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StockMovementDto>.Failure(validation.Errors[0].ErrorMessage);

        var result = await store.ApplyStockMovementAsync(request, StoreProductMovementType.StockIn, LedgerDirection.Credit, request.Description, cancellationToken);
        return result is null ? Result<StockMovementDto>.Failure("Invalid store or product scope.") : Result<StockMovementDto>.Success(result);
    }

    public async Task<Result<StockMovementDto>> StockOutAsync(StockAdjustmentRequest request, CancellationToken cancellationToken)
    {
        var validation = await stockAdjustmentValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StockMovementDto>.Failure(validation.Errors[0].ErrorMessage);

        var result = await store.ApplyStockMovementAsync(request, StoreProductMovementType.StockOut, LedgerDirection.Debit, request.Description, cancellationToken);
        return result is null ? Result<StockMovementDto>.Failure("Invalid store, product scope or insufficient stock.") : Result<StockMovementDto>.Success(result);
    }

    public async Task<Result<StockMovementDto>> DestroyAsync(DestroyStockRequest request, CancellationToken cancellationToken)
    {
        var validation = await destroyStockValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StockMovementDto>.Failure(validation.Errors[0].ErrorMessage);

        var stockRequest = new StockAdjustmentRequest(request.CompanyId, request.UserId, request.StoreId, request.ProductId, request.Quantity, request.Reason);
        var result = await store.ApplyStockMovementAsync(stockRequest, StoreProductMovementType.Destroy, LedgerDirection.Debit, request.Reason, cancellationToken);
        return result is null ? Result<StockMovementDto>.Failure("Invalid store, product scope or insufficient stock.") : Result<StockMovementDto>.Success(result);
    }

    public async Task<Result<StockMovementDto>> CountAsync(StockCountRequest request, CancellationToken cancellationToken)
    {
        var validation = await stockCountValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StockMovementDto>.Failure(validation.Errors[0].ErrorMessage);

        var result = await store.ApplyStockCountAsync(request, cancellationToken);
        return result is null ? Result<StockMovementDto>.Failure("Invalid store or product scope.") : Result<StockMovementDto>.Success(result);
    }

    public async Task<Result<StoreProductTransferDto>> CreateTransferAsync(CreateTransferRequest request, CancellationToken cancellationToken)
    {
        var validation = await createTransferValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StoreProductTransferDto>.Failure(validation.Errors[0].ErrorMessage);

        var result = await store.CreateTransferAsync(request, cancellationToken);
        return result is null ? Result<StoreProductTransferDto>.Failure("Invalid transfer scope.") : Result<StoreProductTransferDto>.Success(result);
    }

    public async Task<Result<StoreProductTransferDto>> ConfirmTransferAsync(Guid transferId, ConfirmTransferRequest request, CancellationToken cancellationToken)
    {
        var validation = await confirmTransferValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StoreProductTransferDto>.Failure(validation.Errors[0].ErrorMessage);

        var result = await store.ConfirmTransferAsync(transferId, request, cancellationToken);
        return result is null ? Result<StoreProductTransferDto>.Failure("Transfer not found or not confirmable.") : Result<StoreProductTransferDto>.Success(result);
    }

    public async Task<Result<StoreProductTransferDto>> ReceiveTransferAsync(Guid transferId, ReceiveTransferRequest request, CancellationToken cancellationToken)
    {
        var validation = await receiveTransferValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StoreProductTransferDto>.Failure(validation.Errors[0].ErrorMessage);

        var result = await store.ReceiveTransferAsync(transferId, request, cancellationToken);
        return result is null ? Result<StoreProductTransferDto>.Failure("Transfer not found, not receivable or insufficient stock.") : Result<StoreProductTransferDto>.Success(result);
    }

    public async Task<Result<StoreProductTransferDto>> CancelTransferAsync(Guid transferId, CancelTransferRequest request, CancellationToken cancellationToken)
    {
        var validation = await cancelTransferValidator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return Result<StoreProductTransferDto>.Failure(validation.Errors[0].ErrorMessage);

        var result = await store.CancelTransferAsync(transferId, request, cancellationToken);
        return result is null ? Result<StoreProductTransferDto>.Failure("Transfer not found or not cancellable.") : Result<StoreProductTransferDto>.Success(result);
    }
}
