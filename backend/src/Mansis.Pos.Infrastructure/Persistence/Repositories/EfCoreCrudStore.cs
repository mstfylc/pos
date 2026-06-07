using Mansis.Pos.Application.Core;
using Mansis.Pos.Application.Auth;
using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfCoreCrudStore(PosDbContext dbContext, IPasswordHasher passwordHasher) : ICoreCrudStore
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
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };
        ApplyProductWrite(product, request);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(product);
    }

    public async Task<ProductDto?> UpdateProductAsync(Guid id, ProductWriteDto request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (product is null) return null;
        ApplyProductWrite(product, request);
        Touch(product, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(product);
    }

    public Task<bool> DeactivateProductAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Products, companyId, id, userId, cancellationToken);

    public async Task<PosProductDto?> CreatePosProductAsync(PosProductWriteDto request, CancellationToken cancellationToken)
    {
        var scopeIsValid = await ProductAndPosBelongToCompanyAsync(request.CompanyId, request.ProductId, request.PosId, cancellationToken);
        if (!scopeIsValid) return null;

        var duplicateExists = await dbContext.PosProducts.AnyAsync(
            posProduct => posProduct.PosId == request.PosId && posProduct.ProductId == request.ProductId,
            cancellationToken);
        if (duplicateExists) return null;

        var posProduct = new PosProduct
        {
            Id = Guid.NewGuid(),
            PosId = request.PosId,
            ProductId = request.ProductId,
            PurchasePrice = request.PurchasePrice,
            SalePrice = request.SalePrice
        };

        dbContext.PosProducts.Add(posProduct);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(posProduct, request.CompanyId);
    }

    public async Task<PosProductDto?> UpdatePosProductAsync(Guid id, PosProductWriteDto request, CancellationToken cancellationToken)
    {
        var scopeIsValid = await ProductAndPosBelongToCompanyAsync(request.CompanyId, request.ProductId, request.PosId, cancellationToken);
        if (!scopeIsValid) return null;

        var posProduct = await dbContext.PosProducts
            .Include(item => item.Pos)
            .FirstOrDefaultAsync(item => item.Id == id && item.Pos != null && item.Pos.CompanyId == request.CompanyId, cancellationToken);
        if (posProduct is null) return null;

        var duplicateExists = await dbContext.PosProducts.AnyAsync(
            item => item.Id != id && item.PosId == request.PosId && item.ProductId == request.ProductId,
            cancellationToken);
        if (duplicateExists) return null;

        posProduct.PosId = request.PosId;
        posProduct.ProductId = request.ProductId;
        posProduct.PurchasePrice = request.PurchasePrice;
        posProduct.SalePrice = request.SalePrice;
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(posProduct, request.CompanyId);
    }

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

    public async Task<IReadOnlyList<UserDto>> ListUsersAsync(Guid companyId, CancellationToken cancellationToken)
    {
        var users = await dbContext.Users
            .AsNoTracking()
            .Where(user => user.CompanyId == companyId)
            .OrderBy(user => user.FirstName)
            .ThenBy(user => user.LastName)
            .ToListAsync(cancellationToken);

        return await ToUserDtosAsync(companyId, users, cancellationToken);
    }

    public async Task<UserDto?> GetUserAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (user is null) return null;

        return (await ToUserDtosAsync(companyId, [user], cancellationToken)).Single();
    }

    public async Task<UserDto?> CreateUserAsync(UserWriteDto request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Password)) return null;
        if (!await UserScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var now = DateTimeOffset.UtcNow;
        var password = passwordHasher.Hash(request.Password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true,
            PasswordHash = password.PasswordHash,
            PasswordSalt = password.PasswordSalt,
            MustChangePassword = true
        };
        ApplyUserWrite(user, request, updatePassword: false);

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);
        await SyncUserAssignmentsAsync(user.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetUserAsync(request.CompanyId, user.Id, cancellationToken);
    }

    public async Task<UserDto?> UpdateUserAsync(Guid id, UserWriteDto request, CancellationToken cancellationToken)
    {
        if (!await UserScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var user = await dbContext.Users.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (user is null) return null;

        ApplyUserWrite(user, request, updatePassword: true);
        Touch(user, request.UserId);
        await SyncUserAssignmentsAsync(user.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetUserAsync(request.CompanyId, user.Id, cancellationToken);
    }

    public Task<bool> DeactivateUserAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Users, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<RoleDto>> ListRolesAsync(Guid companyId, CancellationToken cancellationToken)
    {
        var roles = await dbContext.Roles
            .AsNoTracking()
            .Where(role => role.CompanyId == companyId)
            .OrderBy(role => role.Name)
            .ToListAsync(cancellationToken);

        return await ToRoleDtosAsync(companyId, roles, cancellationToken);
    }

    public async Task<RoleDto?> GetRoleAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var role = await dbContext.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (role is null) return null;

        return (await ToRoleDtosAsync(companyId, [role], cancellationToken)).Single();
    }

    public async Task<RoleDto?> CreateRoleAsync(RoleWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var role = new Role
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            Name = request.Name,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };

        dbContext.Roles.Add(role);
        await dbContext.SaveChangesAsync(cancellationToken);
        return await GetRoleAsync(request.CompanyId, role.Id, cancellationToken);
    }

    public async Task<RoleDto?> UpdateRoleAsync(Guid id, RoleWriteDto request, CancellationToken cancellationToken)
    {
        var role = await dbContext.Roles.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (role is null) return null;

        role.Name = request.Name;
        Touch(role, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return await GetRoleAsync(request.CompanyId, role.Id, cancellationToken);
    }

    public Task<bool> DeactivateRoleAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Roles, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<PermissionDto>> ListPermissionsAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Permissions
            .AsNoTracking()
            .OrderBy(permission => permission.Name)
            .Select(permission => ToDto(permission))
            .ToListAsync(cancellationToken);
    }

    public async Task<RoleDto?> UpdateRolePermissionsAsync(Guid roleId, RolePermissionWriteDto request, CancellationToken cancellationToken)
    {
        var roleExists = await dbContext.Roles.AnyAsync(role => role.CompanyId == request.CompanyId && role.Id == roleId, cancellationToken);
        if (!roleExists) return null;

        var requestedPermissionIds = request.PermissionIds.Distinct().ToArray();
        var validPermissionCount = await dbContext.Permissions.CountAsync(permission => requestedPermissionIds.Contains(permission.Id), cancellationToken);
        if (validPermissionCount != requestedPermissionIds.Length) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var existing = await dbContext.RolePermissions.Where(item => item.RoleId == roleId).ToListAsync(cancellationToken);
        dbContext.RolePermissions.RemoveRange(existing);
        dbContext.RolePermissions.AddRange(requestedPermissionIds.Select(permissionId => new RolePermission
        {
            Id = Guid.NewGuid(),
            RoleId = roleId,
            PermissionId = permissionId,
            Active = true
        }));
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetRoleAsync(request.CompanyId, roleId, cancellationToken);
    }

    public async Task<IReadOnlyList<AssignmentDto>> ListAssignmentsAsync(Guid companyId, Guid? userId, CancellationToken cancellationToken)
    {
        var query = dbContext.Assignments
            .AsNoTracking()
            .Include(assignment => assignment.AssignmentRecords)
            .Include(assignment => assignment.User)
            .Where(assignment => assignment.User != null && assignment.User.CompanyId == companyId);

        if (userId.HasValue)
        {
            query = query.Where(assignment => assignment.UserId == userId.Value);
        }

        var assignments = await query.OrderBy(assignment => assignment.UserId).ToListAsync(cancellationToken);
        return assignments.Select(assignment => ToDto(assignment, companyId)).ToArray();
    }

    public async Task<AssignmentDto?> GetAssignmentAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var assignment = await dbContext.Assignments
            .AsNoTracking()
            .Include(item => item.AssignmentRecords)
            .Include(item => item.User)
            .FirstOrDefaultAsync(item => item.Id == id && item.User != null && item.User.CompanyId == companyId, cancellationToken);

        return assignment is null ? null : ToDto(assignment, companyId);
    }

    public async Task<AssignmentDto?> CreateAssignmentAsync(AssignmentWriteDto request, CancellationToken cancellationToken)
    {
        if (!await AssignmentScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var assignment = new Assignment
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            AssignmentTableType = request.AssignmentTableType
        };
        dbContext.Assignments.Add(assignment);
        await dbContext.SaveChangesAsync(cancellationToken);
        await SyncAssignmentRecordsAsync(assignment.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetAssignmentAsync(request.CompanyId, assignment.Id, cancellationToken);
    }

    public async Task<AssignmentDto?> UpdateAssignmentAsync(Guid id, AssignmentWriteDto request, CancellationToken cancellationToken)
    {
        if (!await AssignmentScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var assignment = await dbContext.Assignments
            .Include(item => item.User)
            .FirstOrDefaultAsync(item => item.Id == id && item.User != null && item.User.CompanyId == request.CompanyId, cancellationToken);
        if (assignment is null) return null;

        assignment.UserId = request.UserId;
        assignment.AssignmentTableType = request.AssignmentTableType;
        await SyncAssignmentRecordsAsync(assignment.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetAssignmentAsync(request.CompanyId, assignment.Id, cancellationToken);
    }

    public async Task<bool> DeleteAssignmentAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var assignment = await dbContext.Assignments
            .Include(item => item.AssignmentRecords)
            .Include(item => item.User)
            .FirstOrDefaultAsync(item => item.Id == id && item.User != null && item.User.CompanyId == companyId, cancellationToken);
        if (assignment is null) return false;

        dbContext.AssignmentRecords.RemoveRange(assignment.AssignmentRecords);
        dbContext.Assignments.Remove(assignment);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

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
        var discounts = await dbContext.Discounts.AsNoTracking()
            .Where(discount => discount.CompanyId == companyId)
            .OrderBy(discount => discount.SortOrder)
            .ToListAsync(cancellationToken);
        return await ToDiscountDtosAsync(companyId, discounts, cancellationToken);
    }

    public async Task<DiscountDto?> GetDiscountAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var discount = await dbContext.Discounts
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (discount is null) return null;

        return (await ToDiscountDtosAsync(companyId, [discount], cancellationToken)).Single();
    }

    public async Task<DiscountDto?> CreateDiscountAsync(DiscountWriteDto request, CancellationToken cancellationToken)
    {
        if (!await DiscountScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var now = DateTimeOffset.UtcNow;
        var discount = new Discount
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };
        ApplyDiscountWrite(discount, request);
        dbContext.Discounts.Add(discount);
        await dbContext.SaveChangesAsync(cancellationToken);
        await SyncDiscountScopesAsync(discount.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetDiscountAsync(request.CompanyId, discount.Id, cancellationToken);
    }

    public async Task<DiscountDto?> UpdateDiscountAsync(Guid id, DiscountWriteDto request, CancellationToken cancellationToken)
    {
        if (!await DiscountScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var discount = await dbContext.Discounts.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (discount is null) return null;
        ApplyDiscountWrite(discount, request);
        Touch(discount, request.UserId);
        await SyncDiscountScopesAsync(discount.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetDiscountAsync(request.CompanyId, discount.Id, cancellationToken);
    }

    public Task<bool> DeactivateDiscountAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Discounts, companyId, id, userId, cancellationToken);

    public async Task<IReadOnlyList<CampaignDto>> ListCampaignsAsync(Guid companyId, CancellationToken cancellationToken)
    {
        return await dbContext.Campaigns
            .AsNoTracking()
            .Where(campaign => campaign.CompanyId == companyId)
            .OrderByDescending(campaign => campaign.Priority)
            .ThenBy(campaign => campaign.Name)
            .Select(campaign => ToDto(campaign))
            .ToListAsync(cancellationToken);
    }

    public async Task<CampaignDto?> GetCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var campaign = await dbContext.Campaigns
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        return campaign is null ? null : ToDto(campaign);
    }

    public async Task<CampaignDto?> CreateCampaignAsync(CampaignWriteDto request, CancellationToken cancellationToken)
    {
        if (!await CampaignScopeIsValidAsync(request, cancellationToken)) return null;

        var campaign = new Campaign
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId
        };
        ApplyCampaignWrite(campaign, request);
        dbContext.Campaigns.Add(campaign);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(campaign);
    }

    public async Task<CampaignDto?> UpdateCampaignAsync(Guid id, CampaignWriteDto request, CancellationToken cancellationToken)
    {
        if (!await CampaignScopeIsValidAsync(request, cancellationToken)) return null;

        var campaign = await dbContext.Campaigns.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (campaign is null) return null;

        ApplyCampaignWrite(campaign, request);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(campaign);
    }

    public async Task<bool> DeleteCampaignAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var campaign = await dbContext.Campaigns.FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (campaign is null) return false;

        campaign.Active = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

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

    private static void ApplyProductWrite(Product product, ProductWriteDto request)
    {
        product.Name = request.Name;
        product.CategoryId = request.CategoryId;
        product.PurchasePrice = request.PurchasePrice;
        product.SalePrice = request.SalePrice;
        product.Barcode = request.Barcode;
        product.StockCode = request.StockCode;
        product.ProductUnitType = request.ProductUnitType;
        product.TaxType = request.TaxType;
        product.Stocktaking = request.Stocktaking;
        product.Image = request.Image;
        product.StoreProduct = request.StoreProduct;
        product.PosProduct = request.PosProduct;
        product.EntryProduct = request.EntryProduct;
        product.FavoriteProduct = request.FavoriteProduct;
        product.SortOrder = request.SortOrder;
        product.Description = request.Description;
        product.Main = request.Main;
        product.ParentId = request.ParentId;
    }

    private async Task<bool> ProductAndPosBelongToCompanyAsync(Guid companyId, Guid productId, Guid posId, CancellationToken cancellationToken)
    {
        var productExists = await dbContext.Products.AnyAsync(product => product.CompanyId == companyId && product.Id == productId, cancellationToken);
        var posExists = await dbContext.PosDevices.AnyAsync(pos => pos.CompanyId == companyId && pos.Id == posId, cancellationToken);
        return productExists && posExists;
    }

    private async Task<bool> UserScopeIsValidAsync(UserWriteDto request, CancellationToken cancellationToken)
    {
        var roleExists = await dbContext.Roles.AnyAsync(role => role.CompanyId == request.CompanyId && role.Id == request.RoleId, cancellationToken);
        if (!roleExists) return false;

        if (request.CardId.HasValue)
        {
            var cardExists = await dbContext.Cards.AnyAsync(card => card.CompanyId == request.CompanyId && card.Id == request.CardId.Value, cancellationToken);
            if (!cardExists) return false;
        }

        return await CompanyIdsExistAsync(dbContext.Branches, request.CompanyId, request.BranchIds, cancellationToken)
            && await CompanyIdsExistAsync(dbContext.PosDevices, request.CompanyId, request.PosIds, cancellationToken)
            && await CompanyIdsExistAsync(dbContext.Stores, request.CompanyId, request.StoreIds, cancellationToken);
    }

    private void ApplyUserWrite(User user, UserWriteDto request, bool updatePassword)
    {
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Username = request.Username;
        user.Phone = request.Phone;
        user.Mail = request.Mail;
        user.RoleId = request.RoleId;
        user.CardId = request.CardId;
        user.Pin = request.Pin;
        user.MustChangePassword = request.MustChangePassword || !updatePassword;

        if (updatePassword && !string.IsNullOrWhiteSpace(request.Password))
        {
            var password = passwordHasher.Hash(request.Password);
            user.PasswordHash = password.PasswordHash;
            user.PasswordSalt = password.PasswordSalt;
            user.MustChangePassword = true;
        }
    }

    private async Task SyncUserAssignmentsAsync(Guid targetUserId, UserWriteDto request, CancellationToken cancellationToken)
    {
        await SyncAssignmentForUserAsync(targetUserId, AssignmentTableType.Branch, request.BranchIds, cancellationToken);
        await SyncAssignmentForUserAsync(targetUserId, AssignmentTableType.Pos, request.PosIds, cancellationToken);
        await SyncAssignmentForUserAsync(targetUserId, AssignmentTableType.Store, request.StoreIds, cancellationToken);
    }

    private async Task SyncAssignmentForUserAsync(Guid targetUserId, AssignmentTableType type, IReadOnlyList<Guid> recordIds, CancellationToken cancellationToken)
    {
        var assignment = await dbContext.Assignments
            .Include(item => item.AssignmentRecords)
            .FirstOrDefaultAsync(item => item.UserId == targetUserId && item.AssignmentTableType == type, cancellationToken);

        if (recordIds.Count == 0)
        {
            if (assignment is not null)
            {
                dbContext.AssignmentRecords.RemoveRange(assignment.AssignmentRecords);
                dbContext.Assignments.Remove(assignment);
            }
            return;
        }

        if (assignment is null)
        {
            assignment = new Assignment { Id = Guid.NewGuid(), UserId = targetUserId, AssignmentTableType = type };
            dbContext.Assignments.Add(assignment);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        var write = new AssignmentWriteDto(Guid.Empty, targetUserId, type, recordIds);
        await SyncAssignmentRecordsAsync(assignment.Id, write, cancellationToken);
    }

    private async Task<IReadOnlyList<UserDto>> ToUserDtosAsync(Guid companyId, IReadOnlyList<User> users, CancellationToken cancellationToken)
    {
        var userIds = users.Select(user => user.Id).ToArray();
        var assignments = await dbContext.Assignments
            .AsNoTracking()
            .Include(assignment => assignment.AssignmentRecords)
            .Where(assignment => userIds.Contains(assignment.UserId))
            .ToListAsync(cancellationToken);

        var byUser = assignments.GroupBy(assignment => assignment.UserId).ToDictionary(group => group.Key, group => group.ToArray());
        return users.Select(user =>
        {
            byUser.TryGetValue(user.Id, out var userAssignments);
            userAssignments ??= [];
            return new UserDto(
                user.Id,
                companyId,
                user.FirstName,
                user.LastName,
                user.Username,
                user.Phone,
                user.Mail,
                user.RoleId,
                user.CardId,
                user.Pin,
                user.MustChangePassword,
                user.Active,
                AssignmentIds(userAssignments, AssignmentTableType.Branch),
                AssignmentIds(userAssignments, AssignmentTableType.Pos),
                AssignmentIds(userAssignments, AssignmentTableType.Store));
        }).ToArray();
    }

    private static IReadOnlyList<Guid> AssignmentIds(IReadOnlyList<Assignment> assignments, AssignmentTableType type) =>
        assignments
            .Where(assignment => assignment.AssignmentTableType == type)
            .SelectMany(assignment => assignment.AssignmentRecords)
            .Select(record => record.RecordId)
            .ToArray();

    private async Task<IReadOnlyList<RoleDto>> ToRoleDtosAsync(Guid companyId, IReadOnlyList<Role> roles, CancellationToken cancellationToken)
    {
        var roleIds = roles.Select(role => role.Id).ToArray();
        var permissions = await dbContext.RolePermissions
            .AsNoTracking()
            .Where(item => roleIds.Contains(item.RoleId) && item.Active)
            .ToListAsync(cancellationToken);

        var byRole = permissions.GroupBy(item => item.RoleId).ToDictionary(group => group.Key, group => group.Select(item => item.PermissionId).ToArray());
        return roles.Select(role => new RoleDto(
            role.Id,
            companyId,
            role.Name,
            role.Active,
            byRole.TryGetValue(role.Id, out var permissionIds) ? permissionIds : [])).ToArray();
    }

    private async Task<bool> AssignmentScopeIsValidAsync(AssignmentWriteDto request, CancellationToken cancellationToken)
    {
        var userExists = await dbContext.Users.AnyAsync(user => user.CompanyId == request.CompanyId && user.Id == request.UserId, cancellationToken);
        if (!userExists) return false;

        return request.AssignmentTableType switch
        {
            AssignmentTableType.Branch => await CompanyIdsExistAsync(dbContext.Branches, request.CompanyId, request.RecordIds, cancellationToken),
            AssignmentTableType.Pos => await CompanyIdsExistAsync(dbContext.PosDevices, request.CompanyId, request.RecordIds, cancellationToken),
            AssignmentTableType.Store => await CompanyIdsExistAsync(dbContext.Stores, request.CompanyId, request.RecordIds, cancellationToken),
            _ => false
        };
    }

    private async Task SyncAssignmentRecordsAsync(Guid assignmentId, AssignmentWriteDto request, CancellationToken cancellationToken)
    {
        var current = await dbContext.AssignmentRecords.Where(record => record.AssignmentId == assignmentId).ToListAsync(cancellationToken);
        dbContext.AssignmentRecords.RemoveRange(current);

        var names = await ResolveAssignmentRecordNamesAsync(request.AssignmentTableType, request.RecordIds, cancellationToken);
        dbContext.AssignmentRecords.AddRange(request.RecordIds.Distinct().Select(recordId => new AssignmentRecord
        {
            Id = Guid.NewGuid(),
            AssignmentId = assignmentId,
            RecordId = recordId,
            RecordName = names.TryGetValue(recordId, out var name) ? name : string.Empty
        }));
    }

    private async Task<Dictionary<Guid, string>> ResolveAssignmentRecordNamesAsync(AssignmentTableType type, IReadOnlyList<Guid> recordIds, CancellationToken cancellationToken)
    {
        var ids = recordIds.Distinct().ToArray();
        return type switch
        {
            AssignmentTableType.Branch => await dbContext.Branches.AsNoTracking().Where(item => ids.Contains(item.Id)).ToDictionaryAsync(item => item.Id, item => item.Name, cancellationToken),
            AssignmentTableType.Pos => await dbContext.PosDevices.AsNoTracking().Where(item => ids.Contains(item.Id)).ToDictionaryAsync(item => item.Id, item => item.Name, cancellationToken),
            AssignmentTableType.Store => await dbContext.Stores.AsNoTracking().Where(item => ids.Contains(item.Id)).ToDictionaryAsync(item => item.Id, item => item.Name, cancellationToken),
            _ => []
        };
    }

    private async Task<bool> DiscountScopeIsValidAsync(DiscountWriteDto request, CancellationToken cancellationToken)
    {
        return await CompanyIdsExistAsync(dbContext.Branches, request.CompanyId, request.BranchIds, cancellationToken)
            && await CompanyIdsExistAsync(dbContext.PosDevices, request.CompanyId, request.PosIds, cancellationToken)
            && await CompanyIdsExistAsync(dbContext.Users, request.CompanyId, request.UserIds, cancellationToken);
    }

    private static void ApplyDiscountWrite(Discount discount, DiscountWriteDto request)
    {
        discount.Description = request.Description;
        discount.Amount = request.Amount;
        discount.MaxDiscountAmount = request.MaxDiscountAmount;
        discount.MonthlyLimit = request.MonthlyLimit;
        discount.ExpireDate = request.ExpireDate;
        discount.DiscountType = request.DiscountType;
        discount.DiscountCategory = request.DiscountCategory;
        discount.SortOrder = request.SortOrder;
    }

    private async Task SyncDiscountScopesAsync(Guid discountId, DiscountWriteDto request, CancellationToken cancellationToken)
    {
        dbContext.DiscountBranches.RemoveRange(await dbContext.DiscountBranches.Where(item => item.DiscountId == discountId).ToListAsync(cancellationToken));
        dbContext.DiscountPoses.RemoveRange(await dbContext.DiscountPoses.Where(item => item.DiscountId == discountId).ToListAsync(cancellationToken));
        dbContext.DiscountUsers.RemoveRange(await dbContext.DiscountUsers.Where(item => item.DiscountId == discountId).ToListAsync(cancellationToken));

        dbContext.DiscountBranches.AddRange(request.BranchIds.Distinct().Select(branchId => new DiscountBranch { Id = Guid.NewGuid(), DiscountId = discountId, BranchId = branchId }));
        dbContext.DiscountPoses.AddRange(request.PosIds.Distinct().Select(posId => new DiscountPos { Id = Guid.NewGuid(), DiscountId = discountId, PosId = posId }));
        dbContext.DiscountUsers.AddRange(request.UserIds.Distinct().Select(userId => new DiscountUser { Id = Guid.NewGuid(), DiscountId = discountId, UserId = userId }));
    }

    private async Task<IReadOnlyList<DiscountDto>> ToDiscountDtosAsync(Guid companyId, IReadOnlyList<Discount> discounts, CancellationToken cancellationToken)
    {
        var discountIds = discounts.Select(discount => discount.Id).ToArray();
        var branchIds = await dbContext.DiscountBranches.AsNoTracking().Where(item => discountIds.Contains(item.DiscountId)).ToListAsync(cancellationToken);
        var posIds = await dbContext.DiscountPoses.AsNoTracking().Where(item => discountIds.Contains(item.DiscountId)).ToListAsync(cancellationToken);
        var userIds = await dbContext.DiscountUsers.AsNoTracking().Where(item => discountIds.Contains(item.DiscountId)).ToListAsync(cancellationToken);

        return discounts.Select(discount => ToDto(
            discount,
            branchIds.Where(item => item.DiscountId == discount.Id).Select(item => item.BranchId).ToArray(),
            posIds.Where(item => item.DiscountId == discount.Id).Select(item => item.PosId).ToArray(),
            userIds.Where(item => item.DiscountId == discount.Id).Select(item => item.UserId).ToArray())).ToArray();
    }

    private async Task<bool> CampaignScopeIsValidAsync(CampaignWriteDto request, CancellationToken cancellationToken)
    {
        if (!request.TargetTierId.HasValue) return true;
        return await dbContext.LoyaltyTiers.AnyAsync(tier => tier.CompanyId == request.CompanyId && tier.Id == request.TargetTierId.Value, cancellationToken);
    }

    private static void ApplyCampaignWrite(Campaign campaign, CampaignWriteDto request)
    {
        campaign.Name = request.Name;
        campaign.Description = request.Description;
        campaign.CampaignType = request.CampaignType;
        campaign.RuleJson = request.RuleJson;
        campaign.Priority = request.Priority;
        campaign.MaxTotalDiscount = request.MaxTotalDiscount;
        campaign.TargetTierId = request.TargetTierId;
        campaign.StartsAt = request.StartsAt;
        campaign.EndsAt = request.EndsAt;
        campaign.Active = request.Active;
    }

    private static async Task<bool> CompanyIdsExistAsync<TEntity>(DbSet<TEntity> set, Guid companyId, IReadOnlyList<Guid> ids, CancellationToken cancellationToken)
        where TEntity : class, ICompanyScoped
    {
        var uniqueIds = ids.Distinct().ToArray();
        if (uniqueIds.Length == 0) return true;

        var count = await set.CountAsync(item => item.CompanyId == companyId && uniqueIds.Contains(EF.Property<Guid>(item, nameof(Entity.Id))), cancellationToken);
        return count == uniqueIds.Length;
    }

    private static AssignmentDto ToDto(Assignment assignment, Guid companyId) => new(
        assignment.Id,
        assignment.UserId,
        companyId,
        assignment.AssignmentTableType,
        assignment.AssignmentRecords
            .Select(record => new AssignmentRecordDto(record.RecordId, record.RecordName))
            .ToArray());

    private static ProductDto ToDto(Product product) => new(
        product.Id,
        product.CompanyId,
        product.Name,
        product.CategoryId,
        product.PurchasePrice,
        product.SalePrice,
        product.Barcode,
        product.StockCode,
        product.ProductUnitType,
        product.TaxType,
        product.Stocktaking,
        product.Image,
        product.StoreProduct,
        product.PosProduct,
        product.EntryProduct,
        product.FavoriteProduct,
        product.SortOrder,
        product.Description,
        product.Main,
        product.ParentId,
        product.Active);

    private static PosProductDto ToDto(PosProduct posProduct, Guid companyId) => new(
        posProduct.Id,
        companyId,
        posProduct.PosId,
        posProduct.ProductId,
        posProduct.PurchasePrice,
        posProduct.SalePrice);

    private static PermissionDto ToDto(Permission permission) => new(permission.Id, permission.Name, permission.DisplayName, permission.PermissionType);

    private static CategoryDto ToDto(Category category) => new(category.Id, category.CompanyId, category.Name, category.SortOrder, category.Active);
    private static CustomerDto ToDto(Customer customer) => new(customer.Id, customer.CompanyId, customer.Name, customer.Surname, customer.Username, customer.Phone, customer.Mail, customer.Balance, customer.Active);
    private static StoreDto ToDto(Store store) => new(store.Id, store.CompanyId, store.Name, store.BranchId, store.Active);
    private static PosDto ToDto(Domain.Entities.Pos pos) => new(pos.Id, pos.CompanyId, pos.Name, pos.BranchId, pos.StoreId, pos.Active);
    private static DiscountDto ToDto(Discount discount, IReadOnlyList<Guid> branchIds, IReadOnlyList<Guid> posIds, IReadOnlyList<Guid> userIds) => new(
        discount.Id,
        discount.CompanyId,
        discount.Description,
        discount.Amount,
        discount.MaxDiscountAmount,
        discount.MonthlyLimit,
        discount.ExpireDate,
        discount.DiscountType,
        discount.DiscountCategory,
        discount.SortOrder,
        discount.Active,
        branchIds,
        posIds,
        userIds);

    private static CampaignDto ToDto(Campaign campaign) => new(
        campaign.Id,
        campaign.CompanyId,
        campaign.Name,
        campaign.Description,
        campaign.CampaignType,
        campaign.RuleJson,
        campaign.Priority,
        campaign.MaxTotalDiscount,
        campaign.TargetTierId,
        campaign.StartsAt,
        campaign.EndsAt,
        campaign.Active);
}
