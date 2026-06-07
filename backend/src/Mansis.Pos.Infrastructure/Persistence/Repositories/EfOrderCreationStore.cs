using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;
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
        Guid userId,
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
            .Select(product => new { product.Id, product.CategoryId, product.Stocktaking, product.EntryProduct })
            .ToListAsync(cancellationToken);

        var storeProducts = await dbContext.StoreProducts
            .AsNoTracking()
            .Where(storeProduct => storeProduct.StoreId == pos.StoreId && productIds.Contains(storeProduct.ProductId))
            .ToDictionaryAsync(storeProduct => storeProduct.ProductId, cancellationToken);

        var productSnapshots = products.ToDictionary(
            product => product.Id,
                product => new ProductStockSnapshot(
                    product.Id,
                    product.CategoryId,
                    product.Stocktaking,
                    product.EntryProduct,
                    storeProducts.TryGetValue(product.Id, out var storeProduct) ? storeProduct.Quantity : 0));

        var firstDayOfMonth = new DateTimeOffset(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, 1, 0, 0, 0, TimeSpan.Zero);
        var discounts = await dbContext.Discounts
            .AsNoTracking()
            .Where(discount => discount.CompanyId == companyId && discount.Active)
            .Select(discount => new
            {
                discount.Id,
                discount.DiscountCategory,
                discount.MaxDiscountAmount,
                UsedThisMonth = dbContext.DiscountUsageLogs
                    .Where(log => log.CompanyId == companyId && log.DiscountId == discount.Id && log.OrderTime >= firstDayOfMonth)
                    .Sum(log => (decimal?)log.Amount) ?? 0m,
                AppliesToAll = discount.DiscountCategory == DiscountCategory.All,
                AppliesToBranch = discount.DiscountCategory == DiscountCategory.Branch
                    && dbContext.DiscountBranches.Any(scope => scope.DiscountId == discount.Id && scope.BranchId == pos.BranchId),
                AppliesToPos = discount.DiscountCategory == DiscountCategory.Pos
                    && dbContext.DiscountPoses.Any(scope => scope.DiscountId == discount.Id && scope.PosId == posId),
                AppliesToUser = discount.DiscountCategory == DiscountCategory.Personnel
                    && dbContext.DiscountUsers.Any(scope => scope.DiscountId == discount.Id && scope.UserId == userId)
            })
            .ToDictionaryAsync(
                discount => discount.Id,
                discount => new DiscountSnapshot(
                    discount.Id,
                    discount.MaxDiscountAmount,
                    discount.UsedThisMonth,
                    discount.AppliesToAll,
                    discount.AppliesToBranch,
                    discount.AppliesToPos,
                    discount.AppliesToUser),
                cancellationToken);

        WalletAccount? walletAccount = null;
        LoyaltyAccount? loyaltyAccount = null;
        List<EarnRule> earnRules = [];
        List<LoyaltyTier> loyaltyTiers = [];
        List<Campaign> campaigns = [];
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

            earnRules = await dbContext.EarnRules
                .AsNoTracking()
                .Where(rule => rule.CompanyId == companyId && rule.Active)
                .ToListAsync(cancellationToken);

            loyaltyTiers = await dbContext.LoyaltyTiers
                .AsNoTracking()
                .Where(tier => tier.CompanyId == companyId && tier.Active)
                .ToListAsync(cancellationToken);

            campaigns = await dbContext.Campaigns
                .AsNoTracking()
                .Where(campaign => campaign.CompanyId == companyId && campaign.Active)
                .ToListAsync(cancellationToken);
        }

        return new OrderCreationSnapshot(pos.StoreId, pos.BranchId, productSnapshots, discounts, walletAccount, loyaltyAccount, earnRules, loyaltyTiers, campaigns);
    }

    public async Task AddOrderGraphAsync(OrderCreationGraph graph, CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        dbContext.Orders.Add(graph.Order);
        dbContext.OrderProducts.AddRange(graph.OrderProducts);
        dbContext.OrderPayments.AddRange(graph.OrderPayments);
        dbContext.OrderDiscounts.AddRange(graph.OrderDiscounts);
        dbContext.DiscountUsageLogs.AddRange(graph.DiscountUsageLogs);
        dbContext.StockMovements.AddRange(graph.StockMovements);
        dbContext.WalletTransactions.AddRange(graph.WalletTransactions);
        dbContext.LoyaltyPointTransactions.AddRange(graph.LoyaltyPointTransactions);

        if (graph.LoyaltyAccountToUpdate is not null)
        {
            dbContext.LoyaltyAccounts.Update(graph.LoyaltyAccountToUpdate);
        }

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
