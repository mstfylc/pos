using System.Linq.Expressions;
using Mansis.Pos.Application.Abstractions.Tenancy;
using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mansis.Pos.Infrastructure.Persistence;

public sealed class PosDbContext(
    DbContextOptions<PosDbContext> options,
    ITenantContext tenantContext) : DbContext(options)
{
    private Guid CurrentCompanyId => tenantContext.CompanyId ?? Guid.Empty;

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AssignmentRecord> AssignmentRecords => Set<AssignmentRecord>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<BranchActivityLog> BranchActivityLogs => Set<BranchActivityLog>();
    public DbSet<BranchManager> BranchManagers => Set<BranchManager>();
    public DbSet<BranchUser> BranchUsers => Set<BranchUser>();
    public DbSet<Card> Cards => Set<Card>();
    public DbSet<Campaign> Campaigns => Set<Campaign>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<CategoryColor> CategoryColors => Set<CategoryColor>();
    public DbSet<CategoryShape> CategoryShapes => Set<CategoryShape>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyActivityLog> CompanyActivityLogs => Set<CompanyActivityLog>();
    public DbSet<CompanyOwner> CompanyOwners => Set<CompanyOwner>();
    public DbSet<ConfigParam> ConfigParams => Set<ConfigParam>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
    public DbSet<CustomerCardToken> CustomerCardTokens => Set<CustomerCardToken>();
    public DbSet<CustomerBalanceMovement> CustomerBalanceMovements => Set<CustomerBalanceMovement>();
    public DbSet<CustomerFavoriteProduct> CustomerFavoriteProducts => Set<CustomerFavoriteProduct>();
    public DbSet<Discount> Discounts => Set<Discount>();
    public DbSet<DiscountBranch> DiscountBranches => Set<DiscountBranch>();
    public DbSet<DiscountPos> DiscountPoses => Set<DiscountPos>();
    public DbSet<DiscountUsageLog> DiscountUsageLogs => Set<DiscountUsageLog>();
    public DbSet<DiscountUser> DiscountUsers => Set<DiscountUser>();
    public DbSet<DeviceToken> DeviceTokens => Set<DeviceToken>();
    public DbSet<EarnRule> EarnRules => Set<EarnRule>();
    public DbSet<LoadBalanceRequest> LoadBalanceRequests => Set<LoadBalanceRequest>();
    public DbSet<LoyaltyAccount> LoyaltyAccounts => Set<LoyaltyAccount>();
    public DbSet<LoyaltyPointTransaction> LoyaltyPointTransactions => Set<LoyaltyPointTransaction>();
    public DbSet<LoyaltyTier> LoyaltyTiers => Set<LoyaltyTier>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDiscount> OrderDiscounts => Set<OrderDiscount>();
    public DbSet<OrderPayment> OrderPayments => Set<OrderPayment>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<OrderSubProduct> OrderSubProducts => Set<OrderSubProduct>();
    public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Domain.Entities.Pos> PosDevices => Set<Domain.Entities.Pos>();
    public DbSet<PosActivityLog> PosActivityLogs => Set<PosActivityLog>();
    public DbSet<PosProduct> PosProducts => Set<PosProduct>();
    public DbSet<PosUser> PosUsers => Set<PosUser>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductSubProduct> ProductSubProducts => Set<ProductSubProduct>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<PurchaseProduct> PurchaseProducts => Set<PurchaseProduct>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Reward> Rewards => Set<Reward>();
    public DbSet<RewardRedemption> RewardRedemptions => Set<RewardRedemption>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<StoreActivityLog> StoreActivityLogs => Set<StoreActivityLog>();
    public DbSet<StoreProduct> StoreProducts => Set<StoreProduct>();
    public DbSet<StoreProductMovement> StoreProductMovements => Set<StoreProductMovement>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();
    public DbSet<StoreProductTransfer> StoreProductTransfers => Set<StoreProductTransfer>();
    public DbSet<StoreProductTransferDetail> StoreProductTransferDetails => Set<StoreProductTransferDetail>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<TagBranch> TagBranches => Set<TagBranch>();
    public DbSet<TagColor> TagColors => Set<TagColor>();
    public DbSet<TagDiscount> TagDiscounts => Set<TagDiscount>();
    public DbSet<TagOrder> TagOrders => Set<TagOrder>();
    public DbSet<TagPos> TagPoses => Set<TagPos>();
    public DbSet<TagProduct> TagProducts => Set<TagProduct>();
    public DbSet<TagShape> TagShapes => Set<TagShape>();
    public DbSet<Town> Towns => Set<Town>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserActivityLog> UserActivityLogs => Set<UserActivityLog>();
    public DbSet<WalletAccount> WalletAccounts => Set<WalletAccount>();
    public DbSet<WalletTransaction> WalletTransactions => Set<WalletTransaction>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Enum>().HaveConversion<string>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        PreventAppendOnlyDeletes();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        PreventAppendOnlyDeletes();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pos");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PosDbContext).Assembly);
        ConfigureConventions(modelBuilder);
        ConfigureIndexes(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureIndexes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasIndex(order => new { order.CompanyId, order.IdempotencyKey })
            .IsUnique();

        modelBuilder.Entity<Order>()
            .HasIndex(order => new { order.CompanyId, order.PosId, order.OrderTime });

        modelBuilder.Entity<Order>()
            .HasIndex(order => new { order.CompanyId, order.CustomerId, order.OrderTime });

        modelBuilder.Entity<OrderPayment>()
            .HasIndex(payment => new { payment.CompanyId, payment.OrderId });

        modelBuilder.Entity<StockMovement>()
            .HasIndex(movement => new { movement.CompanyId, movement.OperationId, movement.MovementType });

        modelBuilder.Entity<WalletTransaction>()
            .HasIndex(transaction => new { transaction.CompanyId, transaction.OrderId });

        modelBuilder.Entity<LoyaltyPointTransaction>()
            .HasIndex(transaction => new { transaction.CompanyId, transaction.OrderId });

        modelBuilder.Entity<StoreProduct>()
            .HasIndex(storeProduct => new { storeProduct.StoreId, storeProduct.ProductId })
            .IsUnique();

        modelBuilder.Entity<WalletAccount>()
            .HasIndex(account => new { account.CompanyId, account.CustomerId, account.Currency })
            .IsUnique();

        modelBuilder.Entity<LoyaltyAccount>()
            .HasIndex(account => new { account.CompanyId, account.CustomerId })
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(product => new { product.CompanyId, product.CategoryId, product.Active });

        modelBuilder.Entity<Product>()
            .HasIndex(product => new { product.CompanyId, product.Barcode });

        modelBuilder.Entity<Product>()
            .HasIndex(product => new { product.CompanyId, product.StockCode });

        modelBuilder.Entity<Customer>()
            .HasIndex(customer => new { customer.CompanyId, customer.Username })
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(customer => new { customer.CompanyId, customer.Phone });

        modelBuilder.Entity<Customer>()
            .HasIndex(customer => new { customer.CompanyId, customer.Mail });

        modelBuilder.Entity<CustomerCardToken>()
            .HasIndex(token => new { token.CompanyId, token.TokenHash });

        modelBuilder.Entity<DiscountUsageLog>()
            .HasIndex(usage => new { usage.CompanyId, usage.DiscountId, usage.OrderTime });

        modelBuilder.Entity<DiscountUsageLog>()
            .HasIndex(usage => new { usage.CompanyId, usage.OrderId });

        modelBuilder.Entity<RolePermission>()
            .HasIndex(rolePermission => new { rolePermission.RoleId, rolePermission.PermissionId })
            .IsUnique();

        modelBuilder.Entity<PosProduct>()
            .HasIndex(posProduct => new { posProduct.PosId, posProduct.ProductId })
            .IsUnique();

        modelBuilder.Entity<ProductSubProduct>()
            .HasIndex(productSubProduct => new { productSubProduct.ProductId, productSubProduct.SubProductId })
            .IsUnique();

        modelBuilder.Entity<BranchUser>()
            .HasIndex(branchUser => new { branchUser.BranchId, branchUser.UserId })
            .IsUnique();

        modelBuilder.Entity<PosUser>()
            .HasIndex(posUser => new { posUser.PosId, posUser.UserId })
            .IsUnique();

        modelBuilder.Entity<TagProduct>()
            .HasIndex(tagProduct => new { tagProduct.TagId, tagProduct.ProductId })
            .IsUnique();

        modelBuilder.Entity<TagOrder>()
            .HasIndex(tagOrder => new { tagOrder.TagId, tagOrder.OrderId })
            .IsUnique();
    }

    private void ConfigureConventions(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            ConfigureTable(entityType);
            ConfigureProperties(entityType);
            ConfigureTenantFilter(modelBuilder, entityType);
        }
    }

    private static void ConfigureTable(IMutableEntityType entityType)
    {
        entityType.SetTableName(ToSnakeCase(entityType.GetTableName() ?? entityType.ClrType.Name));
    }

    private static void ConfigureProperties(IMutableEntityType entityType)
    {
        foreach (var property in entityType.GetProperties())
        {
            property.SetColumnName(ToSnakeCase(property.Name));

        }
    }

    private void PreventAppendOnlyDeletes()
    {
        var deletedAppendOnlyEntries = ChangeTracker
            .Entries()
            .Where(entry => entry.State == EntityState.Deleted && entry.Entity is IAppendOnly)
            .ToList();

        if (deletedAppendOnlyEntries.Count > 0)
        {
            throw new InvalidOperationException("Append-only ledger rows cannot be deleted; write a reversal row instead.");
        }
    }

    private void ConfigureTenantFilter(ModelBuilder modelBuilder, IMutableEntityType entityType)
    {
        if (!typeof(ICompanyScoped).IsAssignableFrom(entityType.ClrType))
        {
            return;
        }

        var parameter = Expression.Parameter(entityType.ClrType, "entity");
        var property = Expression.Property(parameter, nameof(ICompanyScoped.CompanyId));
        var currentTenant = Expression.Property(Expression.Constant(this), nameof(CurrentCompanyId));
        var body = Expression.Equal(property, currentTenant);
        var lambda = Expression.Lambda(body, parameter);

        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
    }

    private static string ToSnakeCase(string value)
    {
        var chars = new List<char>(value.Length + 8);

        for (var i = 0; i < value.Length; i++)
        {
            var current = value[i];
            if (char.IsUpper(current) && i > 0)
            {
                chars.Add('_');
            }

            chars.Add(char.ToLowerInvariant(current));
        }

        return new string(chars.ToArray());
    }
}
