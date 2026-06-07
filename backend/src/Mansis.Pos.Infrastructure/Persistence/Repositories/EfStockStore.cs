using Mansis.Pos.Application.Stock;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfStockStore(PosDbContext dbContext) : IStockStore
{
    public async Task<IReadOnlyList<StockMovementDto>> ListMovementsAsync(StockMovementFilter filter, CancellationToken cancellationToken)
    {
        var query = dbContext.StockMovements
            .AsNoTracking()
            .Where(movement => movement.CompanyId == filter.CompanyId);

        if (filter.StoreId.HasValue) query = query.Where(movement => movement.StoreId == filter.StoreId.Value);
        if (filter.ProductId.HasValue) query = query.Where(movement => movement.ProductId == filter.ProductId.Value);
        if (filter.MovementType.HasValue) query = query.Where(movement => movement.MovementType == filter.MovementType.Value);
        if (filter.From.HasValue) query = query.Where(movement => movement.OccurredAt >= filter.From.Value);
        if (filter.To.HasValue) query = query.Where(movement => movement.OccurredAt <= filter.To.Value);

        return await query
            .OrderByDescending(movement => movement.OccurredAt)
            .Select(movement => ToDto(
                movement,
                dbContext.StoreProducts
                    .Where(storeProduct => storeProduct.StoreId == movement.StoreId && storeProduct.ProductId == movement.ProductId)
                    .Select(storeProduct => storeProduct.Quantity)
                    .FirstOrDefault()))
            .ToListAsync(cancellationToken);
    }

    public async Task<StockMovementDto?> ApplyStockMovementAsync(
        StockAdjustmentRequest request,
        StoreProductMovementType movementType,
        LedgerDirection direction,
        string? description,
        CancellationToken cancellationToken)
    {
        if (!await StoreAndProductBelongToCompanyAsync(request.CompanyId, request.StoreId, request.ProductId, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var storeProduct = await GetOrCreateStoreProductAsync(request.StoreId, request.ProductId, cancellationToken);
        if (direction == LedgerDirection.Debit && storeProduct.Quantity < request.Quantity) return null;

        storeProduct.Quantity += direction == LedgerDirection.Credit ? request.Quantity : -request.Quantity;
        var movement = NewStockMovement(request.CompanyId, request.StoreId, request.ProductId, movementType, direction, request.Quantity, description);
        dbContext.StockMovements.Add(movement);
        dbContext.StoreProductMovements.Add(NewLegacyMovement(request.StoreId, request.ProductId, movementType, request.Quantity, movement.Id, description));
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return ToDto(movement, storeProduct.Quantity);
    }

    public async Task<StockMovementDto?> ApplyStockCountAsync(StockCountRequest request, CancellationToken cancellationToken)
    {
        if (!await StoreAndProductBelongToCompanyAsync(request.CompanyId, request.StoreId, request.ProductId, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var storeProduct = await GetOrCreateStoreProductAsync(request.StoreId, request.ProductId, cancellationToken);
        var diff = request.CountedQuantity - storeProduct.Quantity;
        var movementType = diff >= 0 ? StoreProductMovementType.StockIn : StoreProductMovementType.StockOut;
        var direction = diff >= 0 ? LedgerDirection.Credit : LedgerDirection.Debit;
        var quantity = Math.Abs(diff);

        storeProduct.QuantityAfterStockCount = request.CountedQuantity;
        storeProduct.StockDiff = diff;
        storeProduct.Quantity = request.CountedQuantity;

        var description = request.Description ?? $"Stock count diff: {diff}";
        var movement = NewStockMovement(request.CompanyId, request.StoreId, request.ProductId, movementType, direction, quantity, description);
        dbContext.StockMovements.Add(movement);
        dbContext.StoreProductMovements.Add(NewLegacyMovement(request.StoreId, request.ProductId, movementType, quantity, movement.Id, description));
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return ToDto(movement, storeProduct.Quantity);
    }

    public async Task<StoreProductTransferDto?> CreateTransferAsync(CreateTransferRequest request, CancellationToken cancellationToken)
    {
        if (!await StoresBelongToCompanyAsync(request.CompanyId, request.SourceStoreId, request.TargetStoreId, cancellationToken)) return null;
        if (!await ProductsBelongToCompanyAsync(request.CompanyId, request.Lines.Select(line => line.ProductId).ToArray(), cancellationToken)) return null;

        var transfer = new StoreProductTransfer
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            SourceStoreId = request.SourceStoreId,
            TargetStoreId = request.TargetStoreId,
            RequestedById = request.UserId,
            RequestedTime = DateTimeOffset.UtcNow,
            TransferState = ProductTransferState.Requested,
            TransferDone = false,
            Details = request.Lines.Select(line => new StoreProductTransferDetail
            {
                Id = Guid.NewGuid(),
                ProductId = line.ProductId,
                Quantity = line.Quantity,
                Unit = line.Unit,
                UnitPrice = line.UnitPrice
            }).ToList()
        };

        dbContext.StoreProductTransfers.Add(transfer);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(transfer);
    }

    public async Task<StoreProductTransferDto?> ConfirmTransferAsync(Guid transferId, ConfirmTransferRequest request, CancellationToken cancellationToken)
    {
        var transfer = await LoadTransferAsync(request.CompanyId, transferId, cancellationToken);
        if (transfer is null || transfer.TransferState != ProductTransferState.Requested) return null;

        transfer.TransferState = ProductTransferState.Confirmed;
        transfer.ConfirmedById = request.UserId;
        transfer.ConfirmedTime = DateTimeOffset.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(transfer);
    }

    public async Task<StoreProductTransferDto?> ReceiveTransferAsync(Guid transferId, ReceiveTransferRequest request, CancellationToken cancellationToken)
    {
        var transfer = await LoadTransferAsync(request.CompanyId, transferId, cancellationToken);
        if (transfer is null || transfer.TransferState != ProductTransferState.Confirmed) return null;

        var receivedByProduct = request.Lines.ToDictionary(line => line.ProductId, line => line.ReceivedQuantity);
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        foreach (var detail in transfer.Details)
        {
            var receivedQuantity = receivedByProduct.TryGetValue(detail.ProductId, out var quantity) ? quantity : detail.Quantity;
            if (receivedQuantity < 0 || receivedQuantity > detail.Quantity) return null;

            var source = await GetOrCreateStoreProductAsync(transfer.SourceStoreId, detail.ProductId, cancellationToken);
            var target = await GetOrCreateStoreProductAsync(transfer.TargetStoreId, detail.ProductId, cancellationToken);
            if (source.Quantity < receivedQuantity) return null;

            source.Quantity -= receivedQuantity;
            target.Quantity += receivedQuantity;
            detail.ReceivedQuantity = receivedQuantity;

            var outMovement = NewStockMovement(request.CompanyId, transfer.SourceStoreId, detail.ProductId, StoreProductMovementType.TransferOut, LedgerDirection.Debit, receivedQuantity, $"Transfer {transfer.Id}");
            var inMovement = NewStockMovement(request.CompanyId, transfer.TargetStoreId, detail.ProductId, StoreProductMovementType.TransferIn, LedgerDirection.Credit, receivedQuantity, $"Transfer {transfer.Id}");
            dbContext.StockMovements.AddRange(outMovement, inMovement);
            dbContext.StoreProductMovements.AddRange(
                NewLegacyMovement(transfer.SourceStoreId, detail.ProductId, StoreProductMovementType.TransferOut, receivedQuantity, outMovement.Id, outMovement.Description),
                NewLegacyMovement(transfer.TargetStoreId, detail.ProductId, StoreProductMovementType.TransferIn, receivedQuantity, inMovement.Id, inMovement.Description));
        }

        transfer.TransferState = ProductTransferState.Received;
        transfer.ReceivedById = request.UserId;
        transfer.ReceivedTime = DateTimeOffset.UtcNow;
        transfer.TransferDone = true;
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return ToDto(transfer);
    }

    public async Task<StoreProductTransferDto?> CancelTransferAsync(Guid transferId, CancelTransferRequest request, CancellationToken cancellationToken)
    {
        var transfer = await LoadTransferAsync(request.CompanyId, transferId, cancellationToken);
        if (transfer is null || transfer.TransferState == ProductTransferState.Received || transfer.TransferState == ProductTransferState.Cancelled) return null;

        transfer.TransferState = ProductTransferState.Cancelled;
        transfer.CancelledById = request.UserId;
        transfer.CancelledTime = DateTimeOffset.UtcNow;
        transfer.CancelReason = request.Reason;
        transfer.TransferDone = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(transfer);
    }

    private async Task<StoreProductTransfer?> LoadTransferAsync(Guid companyId, Guid transferId, CancellationToken cancellationToken)
    {
        return await dbContext.StoreProductTransfers
            .Include(transfer => transfer.Details)
            .FirstOrDefaultAsync(transfer => transfer.CompanyId == companyId && transfer.Id == transferId, cancellationToken);
    }

    private async Task<StoreProduct> GetOrCreateStoreProductAsync(Guid storeId, Guid productId, CancellationToken cancellationToken)
    {
        var storeProduct = await dbContext.StoreProducts.FirstOrDefaultAsync(
            item => item.StoreId == storeId && item.ProductId == productId,
            cancellationToken);
        if (storeProduct is not null) return storeProduct;

        storeProduct = new StoreProduct { Id = Guid.NewGuid(), StoreId = storeId, ProductId = productId, Quantity = 0 };
        dbContext.StoreProducts.Add(storeProduct);
        return storeProduct;
    }

    private async Task<bool> StoreAndProductBelongToCompanyAsync(Guid companyId, Guid storeId, Guid productId, CancellationToken cancellationToken)
    {
        var storeExists = await dbContext.Stores.AnyAsync(store => store.CompanyId == companyId && store.Id == storeId, cancellationToken);
        var productExists = await dbContext.Products.AnyAsync(product => product.CompanyId == companyId && product.Id == productId, cancellationToken);
        return storeExists && productExists;
    }

    private async Task<bool> StoresBelongToCompanyAsync(Guid companyId, Guid sourceStoreId, Guid targetStoreId, CancellationToken cancellationToken)
    {
        var storeIds = new[] { sourceStoreId, targetStoreId }.Distinct().ToArray();
        var count = await dbContext.Stores.CountAsync(store => store.CompanyId == companyId && storeIds.Contains(store.Id), cancellationToken);
        return count == storeIds.Length;
    }

    private async Task<bool> ProductsBelongToCompanyAsync(Guid companyId, IReadOnlyCollection<Guid> productIds, CancellationToken cancellationToken)
    {
        var ids = productIds.Distinct().ToArray();
        var count = await dbContext.Products.CountAsync(product => product.CompanyId == companyId && ids.Contains(product.Id), cancellationToken);
        return count == ids.Length;
    }

    private static StockMovement NewStockMovement(
        Guid companyId,
        Guid storeId,
        Guid productId,
        StoreProductMovementType movementType,
        LedgerDirection direction,
        int quantity,
        string? description) => new()
        {
            Id = Guid.NewGuid(),
            CompanyId = companyId,
            StoreId = storeId,
            ProductId = productId,
            OperationId = Guid.NewGuid(),
            MovementType = movementType,
            Direction = direction,
            Quantity = quantity,
            State = LedgerEntryState.Posted,
            Description = description,
            OccurredAt = DateTimeOffset.UtcNow
        };

    private static StoreProductMovement NewLegacyMovement(
        Guid storeId,
        Guid productId,
        StoreProductMovementType movementType,
        int quantity,
        Guid operationId,
        string? description) => new()
        {
            Id = Guid.NewGuid(),
            StoreId = storeId,
            ProductId = productId,
            MovementType = movementType,
            Quantity = quantity,
            OperationId = operationId,
            OperationTime = DateTimeOffset.UtcNow,
            Description = description
        };

    private static StockMovementDto ToDto(StockMovement movement, int currentQuantity) => new(
        movement.Id,
        movement.CompanyId,
        movement.StoreId,
        movement.ProductId,
        movement.OperationId,
        movement.MovementType,
        movement.Direction,
        movement.Quantity,
        movement.State,
        movement.ReversalOfId,
        movement.Description,
        movement.OccurredAt,
        currentQuantity);

    private static StoreProductTransferDto ToDto(StoreProductTransfer transfer) => new(
        transfer.Id,
        transfer.CompanyId,
        transfer.SourceStoreId,
        transfer.TargetStoreId,
        transfer.RequestedById,
        transfer.RequestedTime,
        transfer.TransferState,
        transfer.ConfirmedById,
        transfer.ConfirmedTime,
        transfer.ReceivedById,
        transfer.ReceivedTime,
        transfer.CancelledById,
        transfer.CancelledTime,
        transfer.CancelReason,
        transfer.TransferDone,
        transfer.Details.Select(detail => new StoreProductTransferLineDto(
            detail.Id,
            detail.ProductId,
            detail.Quantity,
            detail.ReceivedQuantity,
            detail.Unit,
            detail.UnitPrice)).ToArray());
}
