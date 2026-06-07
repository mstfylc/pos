using Mansis.Pos.Application.Orders.CancelOrder;
using Mansis.Pos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfOrderCancellationStore(PosDbContext dbContext) : IOrderCancellationStore
{
    public async Task<OrderCancellationSnapshot?> LoadSnapshotAsync(
        Guid companyId,
        Guid orderId,
        CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders
            .FirstOrDefaultAsync(
                current => current.CompanyId == companyId && current.Id == orderId,
                cancellationToken);

        if (order is null)
        {
            return null;
        }

        var payments = await dbContext.OrderPayments
            .Where(payment => payment.CompanyId == companyId && payment.OrderId == orderId)
            .ToListAsync(cancellationToken);

        var stockMovements = await dbContext.StockMovements
            .Where(movement =>
                movement.CompanyId == companyId
                && movement.OperationId == orderId
                && movement.MovementType == Domain.Enumerations.StoreProductMovementType.Order)
            .ToListAsync(cancellationToken);

        var storeIds = stockMovements
            .Select(movement => movement.StoreId)
            .Distinct()
            .ToArray();
        var productIds = stockMovements
            .Select(movement => movement.ProductId)
            .Distinct()
            .ToArray();
        var storeProducts = await dbContext.StoreProducts
            .Where(storeProduct =>
                storeIds.Contains(storeProduct.StoreId)
                && productIds.Contains(storeProduct.ProductId))
            .ToDictionaryAsync(
                storeProduct => (storeProduct.StoreId, storeProduct.ProductId),
                cancellationToken);

        var walletTransactions = await dbContext.WalletTransactions
            .Where(transaction => transaction.CompanyId == companyId && transaction.OrderId == orderId)
            .ToListAsync(cancellationToken);
        var walletAccountIds = walletTransactions
            .Select(transaction => transaction.WalletAccountId)
            .Distinct()
            .ToArray();
        var walletAccounts = await dbContext.WalletAccounts
            .Where(account => account.CompanyId == companyId && walletAccountIds.Contains(account.Id))
            .ToDictionaryAsync(account => account.Id, cancellationToken);

        var loyaltyTransactions = await dbContext.LoyaltyPointTransactions
            .Where(transaction => transaction.CompanyId == companyId && transaction.OrderId == orderId)
            .ToListAsync(cancellationToken);
        var loyaltyAccountIds = loyaltyTransactions
            .Select(transaction => transaction.LoyaltyAccountId)
            .Distinct()
            .ToArray();
        var loyaltyAccounts = await dbContext.LoyaltyAccounts
            .Where(account => account.CompanyId == companyId && loyaltyAccountIds.Contains(account.Id))
            .ToDictionaryAsync(account => account.Id, cancellationToken);

        return new OrderCancellationSnapshot(
            order,
            payments,
            stockMovements,
            walletTransactions,
            loyaltyTransactions,
            storeProducts,
            walletAccounts,
            loyaltyAccounts);
    }

    public async Task ApplyCancellationAsync(OrderCancellationGraph graph, CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        dbContext.OrderPayments.AddRange(graph.PaymentReversals);
        dbContext.StockMovements.AddRange(graph.StockReversals);
        dbContext.WalletTransactions.AddRange(graph.WalletReversals);
        dbContext.LoyaltyPointTransactions.AddRange(graph.LoyaltyReversals);

        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
