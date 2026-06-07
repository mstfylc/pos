using Mansis.Pos.Application.Core;
using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfCoreCrudStore(PosDbContext dbContext) : ICoreCrudStore
{
    public async Task<IReadOnlyList<ProductDto>> ListProductsAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(product => product.CompanyId == companyId)
            .OrderBy(product => product.SortOrder)
            .ThenBy(product => product.Name)
            .Select(product => ToDto(product))
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductDto?> CreateProductAsync(ProductWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var product = new Product
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            Name = request.Name,
            CategoryId = request.CategoryId,
            SalePrice = request.SalePrice,
            Barcode = request.Barcode,
            StockCode = request.StockCode,
            ProductUnitType = request.ProductUnitType,
            TaxType = request.TaxType,
            Stocktaking = request.Stocktaking,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(product);
    }

    public async Task<ProductDto?> UpdateProductAsync(Guid id, ProductWriteDto request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (product is null) return null;
        product.Name = request.Name;
        product.CategoryId = request.CategoryId;
        product.SalePrice = request.SalePrice;
        product.Barcode = request.Barcode;
        product.StockCode = request.StockCode;
        product.ProductUnitType = request.ProductUnitType;
        product.TaxType = request.TaxType;
        product.Stocktaking = request.Stocktaking;
        Touch(product, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(product);
    }

    public Task<bool> DeactivateProductAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Products, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.Categories
            .AsNoTracking()
            .Where(category => category.CompanyId == companyId)
            .OrderBy(category => category.SortOrder)
            .ThenBy(category => category.Name)
            .Select(category => ToDto(category))
            .ToListAsync(cancellationToken);
    }

    public async Task<CategoryDto?> CreateCategoryAsync(CategoryWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var category = new Category
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            Name = request.Name,
            SortOrder = request.SortOrder,
            CategoryColorId = request.CategoryColorId,
            CategoryShapeId = request.CategoryShapeId,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(category);
    }

    public async Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryWriteDto request, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (category is null) return null;
        category.Name = request.Name;
        category.SortOrder = request.SortOrder;
        category.CategoryColorId = request.CategoryColorId;
        category.CategoryShapeId = request.CategoryShapeId;
        Touch(category, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(category);
    }

    public Task<bool> DeactivateCategoryAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Categories, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<CustomerDto>> ListCustomersAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.Customers
            .AsNoTracking()
            .Where(customer => customer.CompanyId == companyId)
            .OrderBy(customer => customer.Name)
            .ThenBy(customer => customer.Surname)
            .Select(customer => ToDto(customer))
            .ToListAsync(cancellationToken);
    }

    public async Task<CustomerDto?> CreateCustomerAsync(CustomerWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            Name = request.Name,
            Surname = request.Surname,
            Username = request.Username,
            Phone = request.Phone,
            Mail = request.Mail,
            RoleId = request.RoleId,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };
        dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(customer);
    }

    public async Task<CustomerDto?> UpdateCustomerAsync(Guid id, CustomerWriteDto request, CancellationToken cancellationToken)
    {
        var customer = await dbContext.Customers.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (customer is null) return null;
        customer.Name = request.Name;
        customer.Surname = request.Surname;
        customer.Username = request.Username;
        customer.Phone = request.Phone;
        customer.Mail = request.Mail;
        customer.RoleId = request.RoleId;
        Touch(customer, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(customer);
    }

    public Task<bool> DeactivateCustomerAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Customers, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<OrderListDto>> ListOrdersAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.Orders
            .AsNoTracking()
            .Where(order => order.CompanyId == companyId)
            .OrderByDescending(order => order.OrderTime)
            .Select(order => new OrderListDto(order.Id, order.CompanyId, order.PosId, order.CustomerId, order.OrderTime, order.Total, order.OrderState, order.PaymentSummary))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<StoreDto>> ListStoresAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.Stores.AsNoTracking()
            .Where(store => store.CompanyId == companyId)
            .OrderBy(store => store.Name)
            .Select(store => ToDto(store))
            .ToListAsync(cancellationToken);
    }

    public async Task<StoreDto?> CreateStoreAsync(StoreWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var store = new Store { Id = Guid.NewGuid(), CompanyId = request.CompanyId, Name = request.Name, BranchId = request.BranchId, CreatedAt = now, UpdatedAt = now, CreatedById = request.UserId, UpdatedById = request.UserId, Active = true };
        dbContext.Stores.Add(store);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(store);
    }

    public async Task<StoreDto?> UpdateStoreAsync(Guid id, StoreWriteDto request, CancellationToken cancellationToken)
    {
        var store = await dbContext.Stores.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (store is null) return null;
        store.Name = request.Name;
        store.BranchId = request.BranchId;
        Touch(store, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(store);
    }

    public Task<bool> DeactivateStoreAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Stores, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<PosDto>> ListPosAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.PosDevices.AsNoTracking()
            .Where(pos => pos.CompanyId == companyId)
            .OrderBy(pos => pos.Name)
            .Select(pos => ToDto(pos))
            .ToListAsync(cancellationToken);
    }

    public async Task<PosDto?> CreatePosAsync(PosWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var pos = new Domain.Entities.Pos { Id = Guid.NewGuid(), CompanyId = request.CompanyId, Name = request.Name, BranchId = request.BranchId, StoreId = request.StoreId, CreatedAt = now, UpdatedAt = now, CreatedById = request.UserId, UpdatedById = request.UserId, Active = true };
        dbContext.PosDevices.Add(pos);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(pos);
    }

    public async Task<PosDto?> UpdatePosAsync(Guid id, PosWriteDto request, CancellationToken cancellationToken)
    {
        var pos = await dbContext.PosDevices.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (pos is null) return null;
        pos.Name = request.Name;
        pos.BranchId = request.BranchId;
        pos.StoreId = request.StoreId;
        Touch(pos, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(pos);
    }

    public Task<bool> DeactivatePosAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.PosDevices, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<DiscountDto>> ListDiscountsAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.Discounts.AsNoTracking()
            .Where(discount => discount.CompanyId == companyId)
            .OrderBy(discount => discount.SortOrder)
            .Select(discount => ToDto(discount))
            .ToListAsync(cancellationToken);
    }

    public async Task<DiscountDto?> CreateDiscountAsync(DiscountWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var discount = new Discount { Id = Guid.NewGuid(), CompanyId = request.CompanyId, Description = request.Description, Amount = request.Amount, MaxDiscountAmount = request.MaxDiscountAmount, ExpireDate = request.ExpireDate, DiscountType = request.DiscountType, DiscountCategory = request.DiscountCategory, SortOrder = request.SortOrder, CreatedAt = now, UpdatedAt = now, CreatedById = request.UserId, UpdatedById = request.UserId, Active = true };
        dbContext.Discounts.Add(discount);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(discount);
    }

    public async Task<DiscountDto?> UpdateDiscountAsync(Guid id, DiscountWriteDto request, CancellationToken cancellationToken)
    {
        var discount = await dbContext.Discounts.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (discount is null) return null;
        discount.Description = request.Description;
        discount.Amount = request.Amount;
        discount.MaxDiscountAmount = request.MaxDiscountAmount;
        discount.ExpireDate = request.ExpireDate;
        discount.DiscountType = request.DiscountType;
        discount.DiscountCategory = request.DiscountCategory;
        discount.SortOrder = request.SortOrder;
        Touch(discount, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(discount);
    }

    public Task<bool> DeactivateDiscountAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Discounts, companyId, id, userId, cancellationToken);

    private async Task<bool> DeactivateAsync<TEntity>(DbSet<TEntity> set, Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken)
        where TEntity : AuditableEntity, ICompanyScoped
    {
        var entity = await set.FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (entity is null) return false;
        entity.Active = false;
        entity.DeletedAt = DateTimeOffset.UtcNow;
        Touch(entity, userId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static void Touch(AuditableEntity entity, Guid userId)
    {
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        entity.UpdatedById = userId;
    }

    private static ProductDto ToDto(Product product) => new(product.Id, product.CompanyId, product.Name, product.CategoryId, product.SalePrice, product.Barcode, product.StockCode, product.Active);
    private static CategoryDto ToDto(Category category) => new(category.Id, category.CompanyId, category.Name, category.SortOrder, category.Active);
    private static CustomerDto ToDto(Customer customer) => new(customer.Id, customer.CompanyId, customer.Name, customer.Surname, customer.Username, customer.Phone, customer.Mail, customer.Balance, customer.Active);
    private static StoreDto ToDto(Store store) => new(store.Id, store.CompanyId, store.Name, store.BranchId, store.Active);
    private static PosDto ToDto(Domain.Entities.Pos pos) => new(pos.Id, pos.CompanyId, pos.Name, pos.BranchId, pos.StoreId, pos.Active);
    private static DiscountDto ToDto(Discount discount) => new(discount.Id, discount.CompanyId, discount.Description, discount.Amount, discount.MaxDiscountAmount, discount.ExpireDate, discount.DiscountType, discount.DiscountCategory, discount.Active);
}
