using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfOrderCreationStore(PosDbContext dbContext) : IOrderCreationStore
{
    public Task<Order?> FindByIdempotencyKeyAsync(Guid companyId, string idempotencyKey, CancellationToken cancellationToken)
    {
        return dbContext.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(
                order => order.CompanyId == companyId && order.IdempotencyKey == idempotencyKey,
                cancellationToken);
    }

    public async Task<OrderCreationSnapshot> LoadSnapshotAsync(
        Guid companyId,
        Guid posId,
        Guid? customerId,
        IReadOnlyCollection<Guid> productIds,
        CancellationToken cancellationToken)
    {
        var pos = await dbContext.PosDevices
            .AsNoTracking()
            .FirstAsync(posDevice => posDevice.CompanyId == companyId && posDevice.Id == posId, cancellationToken);

        var products = await dbContext.Products
            .AsNoTracking()
            .Where(product => product.CompanyId == companyId && productIds.Contains(product.Id))
            .Select(product => new { product.Id, product.Stocktaking })
            .ToListAsync(cancellationToken);

        var storeProducts = await dbContext.StoreProducts
            .AsNoTracking()
            .Where(storeProduct => storeProduct.StoreId == pos.StoreId && productIds.Contains(storeProduct.ProductId))
            .ToDictionaryAsync(storeProduct => storeProduct.ProductId, cancellationToken);

        var productSnapshots = products.ToDictionary(
            product => product.Id,
            product => new ProductStockSnapshot(
                product.Id,
                product.Stocktaking,
                storeProducts.TryGetValue(product.Id, out var storeProduct) ? storeProduct.Quantity : 0));

        WalletAccount? walletAccount = null;
        LoyaltyAccount? loyaltyAccount = null;
        if (customerId.HasValue)
        {
            walletAccount = await dbContext.WalletAccounts
                .FirstOrDefaultAsync(
                    wallet => wallet.CompanyId == companyId && wallet.CustomerId == customerId.Value,
                    cancellationToken);

            loyaltyAccount = await dbContext.LoyaltyAccounts
                .FirstOrDefaultAsync(
                    loyalty => loyalty.CompanyId == companyId && loyalty.CustomerId == customerId.Value,
                    cancellationToken);
        }

        return new OrderCreationSnapshot(pos.StoreId, productSnapshots, walletAccount, loyaltyAccount);
    }

    public async Task AddOrderGraphAsync(OrderCreationGraph graph, CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        dbContext.Orders.Add(graph.Order);
        dbContext.OrderProducts.AddRange(graph.OrderProducts);
        dbContext.OrderPayments.AddRange(graph.OrderPayments);
        dbContext.StockMovements.AddRange(graph.StockMovements);
        dbContext.WalletTransactions.AddRange(graph.WalletTransactions);
        dbContext.LoyaltyPointTransactions.AddRange(graph.LoyaltyPointTransactions);

        foreach (var stockUpdate in graph.StoreProductsToUpdate)
        {
            var storeProduct = await dbContext.StoreProducts.FirstAsync(
                item => item.StoreId == stockUpdate.StoreId && item.ProductId == stockUpdate.ProductId,
                cancellationToken);

            storeProduct.Quantity = stockUpdate.Quantity;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
