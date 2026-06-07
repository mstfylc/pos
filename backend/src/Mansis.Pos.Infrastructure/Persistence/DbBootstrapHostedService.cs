using Mansis.Pos.Application.Auth;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mansis.Pos.Infrastructure.Persistence;

internal sealed class DbBootstrapHostedService(
    IServiceProvider serviceProvider,
    IConfiguration configuration) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PosDbContext>();

        if (IsEnabled("AUTO_MIGRATE"))
        {
            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        if (!IsEnabled("SEED_DATABASE"))
        {
            return;
        }

        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        await SeedAsync(dbContext, passwordHasher, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async Task SeedAsync(PosDbContext dbContext, IPasswordHasher passwordHasher, CancellationToken cancellationToken)
    {
        var superadminEmail = GetRequired("SUPERADMIN_EMAIL");
        var superadminPassword = GetRequired("SUPERADMIN_PASSWORD");
        var now = DateTimeOffset.UtcNow;
        var systemUserId = SeedIds.SuperadminUserId;

        if (!await dbContext.Companies.AnyAsync(company => company.Id == SeedIds.CompanyId, cancellationToken))
        {
            dbContext.Companies.Add(new Company
            {
                Id = SeedIds.CompanyId,
                Name = "Mansis Smoke Company",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.Roles.AnyAsync(role => role.Id == SeedIds.SuperadminRoleId, cancellationToken))
        {
            dbContext.Roles.Add(new Role
            {
                Id = SeedIds.SuperadminRoleId,
                CompanyId = SeedIds.CompanyId,
                Name = "Superadmin",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.Branches.AnyAsync(branch => branch.Id == SeedIds.BranchId, cancellationToken))
        {
            dbContext.Branches.Add(new Branch
            {
                Id = SeedIds.BranchId,
                CompanyId = SeedIds.CompanyId,
                Name = "Smoke Branch",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.Stores.AnyAsync(store => store.Id == SeedIds.StoreId, cancellationToken))
        {
            dbContext.Stores.Add(new Store
            {
                Id = SeedIds.StoreId,
                CompanyId = SeedIds.CompanyId,
                BranchId = SeedIds.BranchId,
                Name = "Smoke Store",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.PosDevices.AnyAsync(pos => pos.Id == SeedIds.PosId, cancellationToken))
        {
            dbContext.PosDevices.Add(new Domain.Entities.Pos
            {
                Id = SeedIds.PosId,
                CompanyId = SeedIds.CompanyId,
                BranchId = SeedIds.BranchId,
                StoreId = SeedIds.StoreId,
                Name = "Smoke POS",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.Users.AnyAsync(user => user.Id == SeedIds.SuperadminUserId, cancellationToken))
        {
            var password = passwordHasher.Hash(superadminPassword);
            dbContext.Users.Add(new User
            {
                Id = SeedIds.SuperadminUserId,
                CompanyId = SeedIds.CompanyId,
                RoleId = SeedIds.SuperadminRoleId,
                FirstName = "Super",
                LastName = "Admin",
                Username = superadminEmail,
                Mail = superadminEmail,
                PasswordHash = password.PasswordHash,
                PasswordSalt = password.PasswordSalt,
                MustChangePassword = true,
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.CategoryColors.AnyAsync(color => color.Id == SeedIds.CategoryColorId, cancellationToken))
        {
            dbContext.CategoryColors.Add(new CategoryColor
            {
                Id = SeedIds.CategoryColorId,
                CompanyId = SeedIds.CompanyId,
                Name = "Smoke Color",
                Content = "#2D6CDF",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.CategoryShapes.AnyAsync(shape => shape.Id == SeedIds.CategoryShapeId, cancellationToken))
        {
            dbContext.CategoryShapes.Add(new CategoryShape
            {
                Id = SeedIds.CategoryShapeId,
                CompanyId = SeedIds.CompanyId,
                Name = "Smoke Shape",
                Content = "square",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.Categories.AnyAsync(category => category.Id == SeedIds.CategoryId, cancellationToken))
        {
            dbContext.Categories.Add(new Category
            {
                Id = SeedIds.CategoryId,
                CompanyId = SeedIds.CompanyId,
                CategoryColorId = SeedIds.CategoryColorId,
                CategoryShapeId = SeedIds.CategoryShapeId,
                Name = "Smoke Category",
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        await SeedProductAsync(dbContext, SeedIds.ProductOneId, "Smoke Coffee", 10m, 10, now, cancellationToken);
        await SeedProductAsync(dbContext, SeedIds.ProductTwoId, "Smoke Cake", 15m, 1, now, cancellationToken);

        if (!await dbContext.Customers.AnyAsync(customer => customer.Id == SeedIds.CustomerId, cancellationToken))
        {
            var password = passwordHasher.Hash(Guid.NewGuid().ToString("N"));
            dbContext.Customers.Add(new Customer
            {
                Id = SeedIds.CustomerId,
                CompanyId = SeedIds.CompanyId,
                RoleId = SeedIds.SuperadminRoleId,
                Name = "Smoke",
                Surname = "Customer",
                Username = "smoke-customer",
                Phone = "+905550000000",
                Registered = true,
                PasswordHash = password.PasswordHash,
                PasswordSalt = password.PasswordSalt,
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = systemUserId,
                UpdatedById = systemUserId,
                Active = true
            });
        }

        if (!await dbContext.WalletAccounts.AnyAsync(wallet => wallet.Id == SeedIds.WalletAccountId, cancellationToken))
        {
            dbContext.WalletAccounts.Add(new WalletAccount
            {
                Id = SeedIds.WalletAccountId,
                CompanyId = SeedIds.CompanyId,
                CustomerId = SeedIds.CustomerId,
                Currency = "TRY",
                Balance = 1000m
            });
        }

        if (!await dbContext.LoyaltyAccounts.AnyAsync(loyalty => loyalty.Id == SeedIds.LoyaltyAccountId, cancellationToken))
        {
            dbContext.LoyaltyAccounts.Add(new LoyaltyAccount
            {
                Id = SeedIds.LoyaltyAccountId,
                CompanyId = SeedIds.CompanyId,
                CustomerId = SeedIds.CustomerId,
                LoyaltyTierId = SeedIds.BronzeTierId,
                PointBalance = 0
            });
        }

        if (!await dbContext.LoyaltyTiers.AnyAsync(tier => tier.Id == SeedIds.BronzeTierId, cancellationToken))
        {
            dbContext.LoyaltyTiers.Add(new LoyaltyTier
            {
                Id = SeedIds.BronzeTierId,
                CompanyId = SeedIds.CompanyId,
                Name = "Bronze",
                MinimumPoints = 0,
                EarnMultiplier = 1m,
                Active = true
            });
        }

        if (!await dbContext.LoyaltyTiers.AnyAsync(tier => tier.Id == SeedIds.SilverTierId, cancellationToken))
        {
            dbContext.LoyaltyTiers.Add(new LoyaltyTier
            {
                Id = SeedIds.SilverTierId,
                CompanyId = SeedIds.CompanyId,
                Name = "Silver",
                MinimumPoints = 50,
                EarnMultiplier = 1.25m,
                Active = true
            });
        }

        var seededLoyaltyAccount = await dbContext.LoyaltyAccounts
            .FirstOrDefaultAsync(loyalty => loyalty.Id == SeedIds.LoyaltyAccountId, cancellationToken);
        if (seededLoyaltyAccount is not null && seededLoyaltyAccount.LoyaltyTierId is null)
        {
            seededLoyaltyAccount.LoyaltyTierId = SeedIds.BronzeTierId;
        }

        if (!await dbContext.EarnRules.AnyAsync(rule => rule.Id == SeedIds.EarnRuleId, cancellationToken))
        {
            dbContext.EarnRules.Add(new EarnRule
            {
                Id = SeedIds.EarnRuleId,
                CompanyId = SeedIds.CompanyId,
                Name = "Smoke earn 1 per TRY",
                AmountPerPoint = 1m,
                MinimumOrderTotal = 0m,
                Scope = EarnRuleScope.All,
                ExpiryDays = 365,
                Active = true
            });
        }

        if (!await dbContext.Rewards.AnyAsync(reward => reward.Id == SeedIds.RewardId, cancellationToken))
        {
            dbContext.Rewards.Add(new Reward
            {
                Id = SeedIds.RewardId,
                CompanyId = SeedIds.CompanyId,
                Name = "Smoke reward",
                RequiredPoints = 10,
                RewardType = RewardType.DiscountAmount,
                DiscountAmount = 5m,
                Active = true
            });
        }

        if (!await dbContext.Campaigns.AnyAsync(campaign => campaign.Id == SeedIds.CampaignId, cancellationToken))
        {
            dbContext.Campaigns.Add(new Campaign
            {
                Id = SeedIds.CampaignId,
                CompanyId = SeedIds.CompanyId,
                Name = "Smoke campaign bonus",
                CampaignType = CampaignType.ExtraPoints,
                RuleJson = """{"minOrderTotal":50,"extraPoints":5}""",
                Priority = 10,
                Active = true
            });
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedProductAsync(
        PosDbContext dbContext,
        Guid productId,
        string name,
        decimal salePrice,
        int quantity,
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        if (!await dbContext.Products.AnyAsync(product => product.Id == productId, cancellationToken))
        {
            dbContext.Products.Add(new Product
            {
                Id = productId,
                CompanyId = SeedIds.CompanyId,
                CategoryId = SeedIds.CategoryId,
                Name = name,
                SalePrice = salePrice,
                ProductUnitType = ProductUnitType.Adet,
                TaxType = TaxType.Bir,
                Stocktaking = true,
                CreatedAt = now,
                UpdatedAt = now,
                CreatedById = SeedIds.SuperadminUserId,
                UpdatedById = SeedIds.SuperadminUserId,
                Active = true
            });
        }

        if (!await dbContext.StoreProducts.AnyAsync(item => item.StoreId == SeedIds.StoreId && item.ProductId == productId, cancellationToken))
        {
            dbContext.StoreProducts.Add(new StoreProduct
            {
                Id = Guid.NewGuid(),
                StoreId = SeedIds.StoreId,
                ProductId = productId,
                Quantity = quantity
            });
        }
    }

    private bool IsEnabled(string name)
    {
        var value = Environment.GetEnvironmentVariable(name) ?? configuration[name];
        return bool.TryParse(value, out var enabled) && enabled;
    }

    private static string GetRequired(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);
        return !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new InvalidOperationException($"{name} environment variable is required for database seed.");
    }
}

public static class SeedIds
{
    public static readonly Guid CompanyId = Guid.Parse("10000000-0000-0000-0000-000000000001");
    public static readonly Guid BranchId = Guid.Parse("10000000-0000-0000-0000-000000000002");
    public static readonly Guid StoreId = Guid.Parse("10000000-0000-0000-0000-000000000003");
    public static readonly Guid PosId = Guid.Parse("10000000-0000-0000-0000-000000000004");
    public static readonly Guid SuperadminRoleId = Guid.Parse("10000000-0000-0000-0000-000000000005");
    public static readonly Guid SuperadminUserId = Guid.Parse("10000000-0000-0000-0000-000000000006");
    public static readonly Guid CategoryColorId = Guid.Parse("10000000-0000-0000-0000-000000000007");
    public static readonly Guid CategoryShapeId = Guid.Parse("10000000-0000-0000-0000-000000000008");
    public static readonly Guid CategoryId = Guid.Parse("10000000-0000-0000-0000-000000000009");
    public static readonly Guid ProductOneId = Guid.Parse("10000000-0000-0000-0000-000000000010");
    public static readonly Guid ProductTwoId = Guid.Parse("10000000-0000-0000-0000-000000000011");
    public static readonly Guid CustomerId = Guid.Parse("10000000-0000-0000-0000-000000000012");
    public static readonly Guid WalletAccountId = Guid.Parse("10000000-0000-0000-0000-000000000013");
    public static readonly Guid LoyaltyAccountId = Guid.Parse("10000000-0000-0000-0000-000000000014");
    public static readonly Guid BronzeTierId = Guid.Parse("10000000-0000-0000-0000-000000000015");
    public static readonly Guid SilverTierId = Guid.Parse("10000000-0000-0000-0000-000000000016");
    public static readonly Guid EarnRuleId = Guid.Parse("10000000-0000-0000-0000-000000000017");
    public static readonly Guid RewardId = Guid.Parse("10000000-0000-0000-0000-000000000018");
    public static readonly Guid CampaignId = Guid.Parse("10000000-0000-0000-0000-000000000019");
}
