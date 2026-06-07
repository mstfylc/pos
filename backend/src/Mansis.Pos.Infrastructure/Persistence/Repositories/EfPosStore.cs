using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Application.Pos;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfPosStore(PosDbContext dbContext) : IPosStore
{
    public async Task<PosProductCatalogResponse?> GetCatalogAsync(Guid companyId, Guid posId, CancellationToken cancellationToken)
    {
        var pos = await dbContext.PosDevices
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == posId, cancellationToken);
        if (pos is null)
        {
            return null;
        }

        var rows = await dbContext.PosProducts
            .AsNoTracking()
            .Include(item => item.Product)
                .ThenInclude(product => product!.Category)
                    .ThenInclude(category => category!.CategoryColor)
            .Include(item => item.Product)
                .ThenInclude(product => product!.Category)
                    .ThenInclude(category => category!.CategoryShape)
            .Where(item =>
                item.PosId == posId &&
                item.Product != null &&
                item.Product.CompanyId == companyId &&
                item.Product.Active &&
                item.Product.PosProduct)
            .OrderBy(item => item.Product!.Category!.SortOrder)
            .ThenBy(item => item.Product!.SortOrder)
            .ThenBy(item => item.Product!.Name)
            .ToListAsync(cancellationToken);

        var productIds = rows.Select(row => row.ProductId).ToArray();
        var stock = await dbContext.StoreProducts
            .AsNoTracking()
            .Where(item => item.StoreId == pos.StoreId && productIds.Contains(item.ProductId))
            .ToDictionaryAsync(item => item.ProductId, item => item.Quantity, cancellationToken);

        var categories = rows
            .GroupBy(row => row.Product!.Category!)
            .OrderBy(group => group.Key.SortOrder)
            .ThenBy(group => group.Key.Name)
            .Select(group => new PosProductCategoryDto(
                group.Key.Id,
                group.Key.Name,
                group.Key.SortOrder,
                group.Key.CategoryColor?.Name,
                group.Key.CategoryColor?.Content,
                group.Key.CategoryShape?.Name,
                group.Key.CategoryShape?.Content,
                group.Select(row =>
                {
                    var product = row.Product!;
                    return new PosProductSaleDto(
                        product.Id,
                        row.Id,
                        product.Name,
                        product.CategoryId,
                        product.SalePrice,
                        row.SalePrice ?? product.SalePrice,
                        row.PurchasePrice ?? product.PurchasePrice,
                        product.Barcode,
                        product.StockCode,
                        product.Image,
                        product.ProductUnitType,
                        product.TaxType,
                        product.Stocktaking,
                        product.FavoriteProduct,
                        product.SortOrder,
                        stock.TryGetValue(product.Id, out var quantity) ? quantity : 0);
                }).ToArray()))
            .ToArray();

        return new PosProductCatalogResponse(categories);
    }

    public Task<Customer?> GetCustomerAsync(Guid companyId, Guid customerId, CancellationToken cancellationToken)
    {
        return dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(customer => customer.CompanyId == companyId && customer.Id == customerId && customer.Active, cancellationToken);
    }

    public async Task AddCustomerCardTokenAsync(CustomerCardToken token, CancellationToken cancellationToken)
    {
        dbContext.CustomerCardTokens.Add(token);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IdentifiedCustomerDto?> IdentifyCustomerByTokenAsync(
        Guid companyId,
        string tokenHash,
        bool consume,
        CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var token = await dbContext.CustomerCardTokens
            .Include(item => item.Customer)
            .FirstOrDefaultAsync(
                item =>
                    item.CompanyId == companyId &&
                    item.TokenHash == tokenHash &&
                    item.State == TokenState.Active &&
                    item.ExpiresAt >= now &&
                    item.Customer != null &&
                    item.Customer.Active,
                cancellationToken);
        if (token is null || token.Customer is null)
        {
            return null;
        }

        var wallet = await dbContext.WalletAccounts
            .AsNoTracking()
            .FirstOrDefaultAsync(account => account.CompanyId == companyId && account.CustomerId == token.CustomerId, cancellationToken);
        var loyalty = await dbContext.LoyaltyAccounts
            .AsNoTracking()
            .FirstOrDefaultAsync(account => account.CompanyId == companyId && account.CustomerId == token.CustomerId, cancellationToken);
        LoyaltyTier? tier = null;
        if (loyalty?.LoyaltyTierId is not null)
        {
            tier = await dbContext.LoyaltyTiers
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == loyalty.LoyaltyTierId, cancellationToken);
        }

        if (consume)
        {
            token.State = TokenState.Used;
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        return new IdentifiedCustomerDto(
            token.Customer.Id,
            token.Customer.Name,
            token.Customer.Surname,
            token.Customer.Phone,
            token.Customer.Mail,
            wallet?.Balance ?? 0m,
            loyalty?.PointBalance ?? 0,
            loyalty?.LifetimePoints ?? 0,
            tier?.Id,
            tier?.Name);
    }

    public async Task<OrderCreationSnapshot?> LoadLoyaltyPreviewSnapshotAsync(
        Guid companyId,
        Guid posId,
        Guid customerId,
        IReadOnlyCollection<Guid> productIds,
        CancellationToken cancellationToken)
    {
        var pos = await dbContext.PosDevices
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == posId, cancellationToken);
        if (pos is null)
        {
            return null;
        }

        var products = await dbContext.Products
            .AsNoTracking()
            .Where(product => product.CompanyId == companyId && productIds.Contains(product.Id))
            .Select(product => new { product.Id, product.CategoryId, product.Stocktaking })
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
                storeProducts.TryGetValue(product.Id, out var storeProduct) ? storeProduct.Quantity : 0));

        var walletAccount = await dbContext.WalletAccounts
            .AsNoTracking()
            .FirstOrDefaultAsync(wallet => wallet.CompanyId == companyId && wallet.CustomerId == customerId, cancellationToken);
        var loyaltyAccount = await dbContext.LoyaltyAccounts
            .AsNoTracking()
            .FirstOrDefaultAsync(loyalty => loyalty.CompanyId == companyId && loyalty.CustomerId == customerId, cancellationToken);
        var earnRules = await dbContext.EarnRules
            .AsNoTracking()
            .Where(rule => rule.CompanyId == companyId && rule.Active)
            .ToListAsync(cancellationToken);
        var loyaltyTiers = await dbContext.LoyaltyTiers
            .AsNoTracking()
            .Where(tier => tier.CompanyId == companyId && tier.Active)
            .ToListAsync(cancellationToken);
        var campaigns = await dbContext.Campaigns
            .AsNoTracking()
            .Where(campaign => campaign.CompanyId == companyId && campaign.Active)
            .ToListAsync(cancellationToken);

        return new OrderCreationSnapshot(
            pos.StoreId,
            pos.BranchId,
            productSnapshots,
            new Dictionary<Guid, DiscountSnapshot>(),
            walletAccount,
            loyaltyAccount,
            earnRules,
            loyaltyTiers,
            campaigns);
    }

    public async Task<IReadOnlyList<Reward>> ListAvailableRewardsAsync(Guid companyId, int pointBalance, CancellationToken cancellationToken)
    {
        return await dbContext.Rewards
            .AsNoTracking()
            .Where(reward => reward.CompanyId == companyId && reward.Active && reward.RequiredPoints <= pointBalance)
            .OrderBy(reward => reward.RequiredPoints)
            .ThenBy(reward => reward.Name)
            .ToListAsync(cancellationToken);
    }
}
