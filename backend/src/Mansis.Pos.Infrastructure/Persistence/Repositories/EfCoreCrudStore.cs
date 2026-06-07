using Mansis.Pos.Application.Core;
using Mansis.Pos.Application.Auth;
using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfCoreCrudStore(PosDbContext dbContext, IPasswordHasher passwordHasher) : ICoreCrudStore
{
    public async Task<PagedResult<ProductDto>> ListProductsAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Products
            .AsNoTracking()
            .Where(product => product.CompanyId == companyId);

        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(product =>
                product.Name.ToLower().Contains(filter)
                || (product.Barcode != null && product.Barcode.ToLower().Contains(filter))
                || (product.StockCode != null && product.StockCode.ToLower().Contains(filter)));
        }

        query = NormalizeSort(listQuery.Sort) switch
        {
            "name_desc" => query.OrderByDescending(product => product.Name),
            "sale_price" => query.OrderBy(product => product.SalePrice),
            "sale_price_desc" => query.OrderByDescending(product => product.SalePrice),
            "active" => query.OrderBy(product => product.Active).ThenBy(product => product.Name),
            "active_desc" => query.OrderByDescending(product => product.Active).ThenBy(product => product.Name),
            "sort_order_desc" => query.OrderByDescending(product => product.SortOrder).ThenBy(product => product.Name),
            _ => query.OrderBy(product => product.SortOrder).ThenBy(product => product.Name)
        };

        return await ToPagedResultAsync(query.Select(product => ToDto(product)), listQuery, cancellationToken);
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

    public async Task<IReadOnlyList<PosProductDto>> ListPosProductsForProductAsync(Guid companyId, Guid productId, CancellationToken cancellationToken)
    {
        var productExists = await dbContext.Products.AnyAsync(product => product.CompanyId == companyId && product.Id == productId, cancellationToken);
        if (!productExists) return [];

        return await dbContext.PosProducts
            .AsNoTracking()
            .Include(posProduct => posProduct.Pos)
            .Where(posProduct => posProduct.ProductId == productId && posProduct.Pos != null && posProduct.Pos.CompanyId == companyId)
            .OrderBy(posProduct => posProduct.Pos!.Name)
            .Select(posProduct => ToDto(posProduct, companyId))
            .ToListAsync(cancellationToken);
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

    public async Task<PagedResult<CustomerDto>> ListCustomersAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Customers
            .AsNoTracking()
            .Where(customer => customer.CompanyId == companyId);

        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(customer =>
                customer.Name.ToLower().Contains(filter)
                || customer.Surname.ToLower().Contains(filter)
                || customer.Username.ToLower().Contains(filter)
                || (customer.Phone != null && customer.Phone.ToLower().Contains(filter))
                || (customer.Mail != null && customer.Mail.ToLower().Contains(filter)));
        }

        query = NormalizeSort(listQuery.Sort) switch
        {
            "name_desc" => query.OrderByDescending(customer => customer.Name).ThenByDescending(customer => customer.Surname),
            "balance" => query.OrderBy(customer => customer.Balance),
            "balance_desc" => query.OrderByDescending(customer => customer.Balance),
            "active" => query.OrderBy(customer => customer.Active).ThenBy(customer => customer.Name),
            "active_desc" => query.OrderByDescending(customer => customer.Active).ThenBy(customer => customer.Name),
            _ => query.OrderBy(customer => customer.Name).ThenBy(customer => customer.Surname)
        };

        return await ToPagedResultAsync(query.Select(customer => ToDto(customer)), listQuery, cancellationToken);
    }

    public async Task<CustomerDetailDto?> GetCustomerAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var customer = await dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (customer is null) return null;

        return await ToCustomerDetailDtoAsync(customer, cancellationToken);
    }

    public async Task<CustomerDto?> CreateCustomerAsync(CustomerWriteDto request, CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
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
        dbContext.WalletAccounts.Add(new WalletAccount
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            CustomerId = customer.Id,
            Currency = "TRY",
            Balance = 0m
        });
        dbContext.LoyaltyAccounts.Add(new LoyaltyAccount
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            CustomerId = customer.Id,
            PointBalance = 0,
            LifetimePoints = 0
        });
        await dbContext.SaveChangesAsync(cancellationToken);
        await SyncCustomerAddressesAsync(customer.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
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
        await SyncCustomerAddressesAsync(customer.Id, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(customer);
    }

    public Task<bool> DeactivateCustomerAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Customers, companyId, id, userId, cancellationToken);

    public async Task<WalletAdjustmentDto?> AdjustCustomerWalletAsync(Guid customerId, CustomerWalletAdjustmentRequest request, CancellationToken cancellationToken)
    {
        var customer = await dbContext.Customers.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == customerId, cancellationToken);
        if (customer is null) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var wallet = await dbContext.WalletAccounts.FirstOrDefaultAsync(account => account.CompanyId == request.CompanyId && account.CustomerId == customerId, cancellationToken);
        if (wallet is null)
        {
            wallet = new WalletAccount { Id = Guid.NewGuid(), CompanyId = request.CompanyId, CustomerId = customerId, Currency = "TRY" };
            dbContext.WalletAccounts.Add(wallet);
        }

        if (request.Direction == LedgerDirection.Debit && wallet.Balance < request.Amount) return null;
        wallet.Balance += request.Direction == LedgerDirection.Credit ? request.Amount : -request.Amount;
        customer.Balance = wallet.Balance;
        Touch(customer, request.UserId);
        var walletTransaction = new WalletTransaction
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            WalletAccountId = wallet.Id,
            Direction = request.Direction,
            Amount = request.Amount,
            State = LedgerEntryState.Posted,
            Description = request.Reason,
            OccurredAt = DateTimeOffset.UtcNow
        };
        dbContext.WalletTransactions.Add(walletTransaction);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return new WalletAdjustmentDto(ToDto(wallet), walletTransaction.Id);
    }

    public async Task<LoyaltyAdjustmentDto?> AdjustCustomerLoyaltyAsync(Guid customerId, CustomerLoyaltyAdjustmentRequest request, CancellationToken cancellationToken)
    {
        var customerExists = await dbContext.Customers.AnyAsync(customer => customer.CompanyId == request.CompanyId && customer.Id == customerId, cancellationToken);
        if (!customerExists) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var loyalty = await dbContext.LoyaltyAccounts.FirstOrDefaultAsync(account => account.CompanyId == request.CompanyId && account.CustomerId == customerId, cancellationToken);
        if (loyalty is null)
        {
            loyalty = new LoyaltyAccount { Id = Guid.NewGuid(), CompanyId = request.CompanyId, CustomerId = customerId };
            dbContext.LoyaltyAccounts.Add(loyalty);
        }

        if (request.Direction == LedgerDirection.Debit && loyalty.PointBalance < request.Points) return null;
        loyalty.PointBalance += request.Direction == LedgerDirection.Credit ? request.Points : -request.Points;
        if (request.Direction == LedgerDirection.Credit)
        {
            loyalty.LifetimePoints += request.Points;
        }

        var pointTransaction = new LoyaltyPointTransaction
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            LoyaltyAccountId = loyalty.Id,
            TransactionType = LoyaltyPointTransactionType.Adjust,
            Points = request.Direction == LedgerDirection.Credit ? request.Points : -request.Points,
            State = LedgerEntryState.Posted,
            Description = request.Reason,
            OccurredAt = DateTimeOffset.UtcNow
        };
        dbContext.LoyaltyPointTransactions.Add(pointTransaction);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return new LoyaltyAdjustmentDto(ToDto(loyalty), pointTransaction.Id);
    }

    public async Task<PagedResult<UserDto>> ListUsersAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Users
            .AsNoTracking()
            .Where(user => user.CompanyId == companyId);

        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(user =>
                user.FirstName.ToLower().Contains(filter)
                || user.LastName.ToLower().Contains(filter)
                || user.Username.ToLower().Contains(filter)
                || (user.Phone != null && user.Phone.ToLower().Contains(filter))
                || (user.Mail != null && user.Mail.ToLower().Contains(filter)));
        }

        query = NormalizeSort(listQuery.Sort) switch
        {
            "name_desc" => query.OrderByDescending(user => user.FirstName).ThenByDescending(user => user.LastName),
            "username" => query.OrderBy(user => user.Username),
            "username_desc" => query.OrderByDescending(user => user.Username),
            "active" => query.OrderBy(user => user.Active).ThenBy(user => user.FirstName),
            "active_desc" => query.OrderByDescending(user => user.Active).ThenBy(user => user.FirstName),
            _ => query.OrderBy(user => user.FirstName).ThenBy(user => user.LastName)
        };

        var page = NormalizePage(listQuery.Page);
        var pageSize = NormalizePageSize(listQuery.PageSize);
        var totalCount = await query.CountAsync(cancellationToken);
        var users = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        var items = await ToUserDtosAsync(companyId, users, cancellationToken);
        return new PagedResult<UserDto>(items, page, pageSize, totalCount, TotalPages(totalCount, pageSize));
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

    public async Task<PagedResult<OrderListDto>> ListOrdersAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Orders
            .AsNoTracking()
            .Where(order => order.CompanyId == companyId);

        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(order =>
                order.OrderNumber.ToString().Contains(filter)
                || (order.Description != null && order.Description.ToLower().Contains(filter))
                || order.IdempotencyKey.ToLower().Contains(filter));
        }

        query = NormalizeSort(listQuery.Sort) switch
        {
            "time" => query.OrderBy(order => order.OrderTime),
            "total" => query.OrderBy(order => order.Total),
            "total_desc" => query.OrderByDescending(order => order.Total),
            "state" => query.OrderBy(order => order.OrderState).ThenByDescending(order => order.OrderTime),
            "state_desc" => query.OrderByDescending(order => order.OrderState).ThenByDescending(order => order.OrderTime),
            _ => query.OrderByDescending(order => order.OrderTime)
        };

        return await ToPagedResultAsync(
            query.Select(order => new OrderListDto(
                order.Id,
                order.CompanyId,
                order.PosId,
                order.CustomerId,
                order.OrderTime,
                order.SubTotal,
                order.TaxTotal,
                order.TotalDiscount,
                order.Total,
                order.OrderState,
                order.PaymentSummary,
                order.Description,
                order.AddressId)),
            listQuery,
            cancellationToken);
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

    public async Task<PagedResult<DiscountDto>> ListDiscountsAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Discounts.AsNoTracking().Where(discount => discount.CompanyId == companyId);
        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(discount => discount.Description != null && discount.Description.ToLower().Contains(filter));
        }

        query = NormalizeSort(listQuery.Sort) switch
        {
            "amount" => query.OrderBy(discount => discount.Amount),
            "amount_desc" => query.OrderByDescending(discount => discount.Amount),
            "active" => query.OrderBy(discount => discount.Active).ThenBy(discount => discount.SortOrder),
            "active_desc" => query.OrderByDescending(discount => discount.Active).ThenBy(discount => discount.SortOrder),
            "sort_order_desc" => query.OrderByDescending(discount => discount.SortOrder),
            _ => query.OrderBy(discount => discount.SortOrder)
        };

        var page = NormalizePage(listQuery.Page);
        var pageSize = NormalizePageSize(listQuery.PageSize);
        var totalCount = await query.CountAsync(cancellationToken);
        var discounts = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        var items = await ToDiscountDtosAsync(companyId, discounts, cancellationToken);
        return new PagedResult<DiscountDto>(items, page, pageSize, totalCount, TotalPages(totalCount, pageSize));
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

    public async Task<PagedResult<CampaignDto>> ListCampaignsAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Campaigns
            .AsNoTracking()
            .Where(campaign => campaign.CompanyId == companyId);

        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(campaign =>
                campaign.Name.ToLower().Contains(filter)
                || (campaign.Description != null && campaign.Description.ToLower().Contains(filter)));
        }

        query = NormalizeSort(listQuery.Sort) switch
        {
            "name" => query.OrderBy(campaign => campaign.Name),
            "name_desc" => query.OrderByDescending(campaign => campaign.Name),
            "priority" => query.OrderBy(campaign => campaign.Priority),
            "active" => query.OrderBy(campaign => campaign.Active).ThenBy(campaign => campaign.Name),
            "active_desc" => query.OrderByDescending(campaign => campaign.Active).ThenBy(campaign => campaign.Name),
            _ => query.OrderByDescending(campaign => campaign.Priority).ThenBy(campaign => campaign.Name)
        };

        return await ToPagedResultAsync(query.Select(campaign => ToDto(campaign)), listQuery, cancellationToken);
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

    public async Task<PagedResult<EarnRuleDto>> ListEarnRulesAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.EarnRules
            .AsNoTracking()
            .Where(rule => rule.CompanyId == companyId);
        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(rule => rule.Name.ToLower().Contains(filter));
        }
        query = NormalizeSort(listQuery.Sort) == "name_desc" ? query.OrderByDescending(rule => rule.Name) : query.OrderBy(rule => rule.Name);
        return await ToPagedResultAsync(query.Select(rule => ToDto(rule)), listQuery, cancellationToken);
    }

    public async Task<EarnRuleDto?> GetEarnRuleAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var rule = await dbContext.EarnRules.AsNoTracking().FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        return rule is null ? null : ToDto(rule);
    }

    public async Task<EarnRuleDto?> CreateEarnRuleAsync(EarnRuleWriteDto request, CancellationToken cancellationToken)
    {
        if (!await EarnRuleScopeIsValidAsync(request, cancellationToken)) return null;

        var rule = new EarnRule { Id = Guid.NewGuid(), CompanyId = request.CompanyId };
        ApplyEarnRuleWrite(rule, request);
        dbContext.EarnRules.Add(rule);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(rule);
    }

    public async Task<EarnRuleDto?> UpdateEarnRuleAsync(Guid id, EarnRuleWriteDto request, CancellationToken cancellationToken)
    {
        if (!await EarnRuleScopeIsValidAsync(request, cancellationToken)) return null;

        var rule = await dbContext.EarnRules.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (rule is null) return null;

        ApplyEarnRuleWrite(rule, request);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(rule);
    }

    public async Task<bool> DeleteEarnRuleAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var rule = await dbContext.EarnRules.FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (rule is null) return false;

        rule.Active = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<PagedResult<LoyaltyTierDto>> ListLoyaltyTiersAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.LoyaltyTiers
            .AsNoTracking()
            .Where(tier => tier.CompanyId == companyId);
        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(tier => tier.Name.ToLower().Contains(filter));
        }
        query = NormalizeSort(listQuery.Sort) switch
        {
            "name" => query.OrderBy(tier => tier.Name),
            "name_desc" => query.OrderByDescending(tier => tier.Name),
            "min_points_desc" => query.OrderByDescending(tier => tier.MinimumPoints),
            _ => query.OrderBy(tier => tier.MinimumPoints)
        };
        return await ToPagedResultAsync(query.Select(tier => ToDto(tier)), listQuery, cancellationToken);
    }

    public async Task<LoyaltyTierDto?> GetLoyaltyTierAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var tier = await dbContext.LoyaltyTiers.AsNoTracking().FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        return tier is null ? null : ToDto(tier);
    }

    public async Task<LoyaltyTierDto?> CreateLoyaltyTierAsync(LoyaltyTierWriteDto request, CancellationToken cancellationToken)
    {
        var tier = new LoyaltyTier { Id = Guid.NewGuid(), CompanyId = request.CompanyId };
        ApplyLoyaltyTierWrite(tier, request);
        dbContext.LoyaltyTiers.Add(tier);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(tier);
    }

    public async Task<LoyaltyTierDto?> UpdateLoyaltyTierAsync(Guid id, LoyaltyTierWriteDto request, CancellationToken cancellationToken)
    {
        var tier = await dbContext.LoyaltyTiers.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (tier is null) return null;

        ApplyLoyaltyTierWrite(tier, request);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(tier);
    }

    public async Task<bool> DeleteLoyaltyTierAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var tier = await dbContext.LoyaltyTiers.FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (tier is null) return false;

        tier.Active = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<PagedResult<RewardDto>> ListRewardsAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Rewards
            .AsNoTracking()
            .Where(reward => reward.CompanyId == companyId);
        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(reward => reward.Name.ToLower().Contains(filter));
        }
        query = NormalizeSort(listQuery.Sort) == "name_desc" ? query.OrderByDescending(reward => reward.Name) : query.OrderBy(reward => reward.Name);
        return await ToPagedResultAsync(query.Select(reward => ToDto(reward)), listQuery, cancellationToken);
    }

    public async Task<RewardDto?> GetRewardAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var reward = await dbContext.Rewards.AsNoTracking().FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        return reward is null ? null : ToDto(reward);
    }

    public async Task<RewardDto?> CreateRewardAsync(RewardWriteDto request, CancellationToken cancellationToken)
    {
        if (!await RewardScopeIsValidAsync(request, cancellationToken)) return null;

        var reward = new Reward { Id = Guid.NewGuid(), CompanyId = request.CompanyId };
        ApplyRewardWrite(reward, request);
        dbContext.Rewards.Add(reward);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(reward);
    }

    public async Task<RewardDto?> UpdateRewardAsync(Guid id, RewardWriteDto request, CancellationToken cancellationToken)
    {
        if (!await RewardScopeIsValidAsync(request, cancellationToken)) return null;

        var reward = await dbContext.Rewards.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (reward is null) return null;

        ApplyRewardWrite(reward, request);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(reward);
    }

    public async Task<bool> DeleteRewardAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var reward = await dbContext.Rewards.FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (reward is null) return false;

        reward.Active = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<PagedResult<StampCardDto>> ListStampCardsAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.StampCards
            .AsNoTracking()
            .Where(stampCard => stampCard.CompanyId == companyId);
        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(stampCard => stampCard.Name.ToLower().Contains(filter));
        }
        query = NormalizeSort(listQuery.Sort) == "name_desc" ? query.OrderByDescending(stampCard => stampCard.Name) : query.OrderBy(stampCard => stampCard.Name);
        return await ToPagedResultAsync(query.Select(stampCard => ToDto(stampCard)), listQuery, cancellationToken);
    }

    public async Task<StampCardDto?> GetStampCardAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var stampCard = await dbContext.StampCards.AsNoTracking().FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        return stampCard is null ? null : ToDto(stampCard);
    }

    public async Task<StampCardDto?> CreateStampCardAsync(StampCardWriteDto request, CancellationToken cancellationToken)
    {
        if (!await StampCardScopeIsValidAsync(request, cancellationToken)) return null;

        var stampCard = new StampCard { Id = Guid.NewGuid(), CompanyId = request.CompanyId };
        ApplyStampCardWrite(stampCard, request);
        dbContext.StampCards.Add(stampCard);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(stampCard);
    }

    public async Task<StampCardDto?> UpdateStampCardAsync(Guid id, StampCardWriteDto request, CancellationToken cancellationToken)
    {
        if (!await StampCardScopeIsValidAsync(request, cancellationToken)) return null;

        var stampCard = await dbContext.StampCards.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (stampCard is null) return null;

        ApplyStampCardWrite(stampCard, request);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(stampCard);
    }

    public async Task<bool> DeleteStampCardAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var stampCard = await dbContext.StampCards.FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (stampCard is null) return false;

        stampCard.Active = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<PagedResult<SupplierDto>> ListSuppliersAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Suppliers.AsNoTracking().Where(supplier => supplier.CompanyId == companyId);
        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(supplier =>
                supplier.Name.ToLower().Contains(filter)
                || (supplier.Phone != null && supplier.Phone.ToLower().Contains(filter))
                || (supplier.Mail != null && supplier.Mail.ToLower().Contains(filter))
                || (supplier.TaxNo != null && supplier.TaxNo.ToLower().Contains(filter)));
        }

        query = NormalizeSort(listQuery.Sort) == "name_desc" ? query.OrderByDescending(supplier => supplier.Name) : query.OrderBy(supplier => supplier.Name);
        return await ToPagedResultAsync(query.Select(supplier => ToDto(supplier)), listQuery, cancellationToken);
    }

    public async Task<SupplierDto?> GetSupplierAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var supplier = await dbContext.Suppliers.AsNoTracking().FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        return supplier is null ? null : ToDto(supplier);
    }

    public async Task<SupplierDto?> CreateSupplierAsync(SupplierWriteDto request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var supplier = new Supplier
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };
        ApplySupplierWrite(supplier, request);
        dbContext.Suppliers.Add(supplier);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(supplier);
    }

    public async Task<SupplierDto?> UpdateSupplierAsync(Guid id, SupplierWriteDto request, CancellationToken cancellationToken)
    {
        var supplier = await dbContext.Suppliers.FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (supplier is null) return null;

        ApplySupplierWrite(supplier, request);
        Touch(supplier, request.UserId);
        await dbContext.SaveChangesAsync(cancellationToken);
        return ToDto(supplier);
    }

    public Task<bool> DeactivateSupplierAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) =>
        DeactivateAsync(dbContext.Suppliers, companyId, id, userId, cancellationToken);

    public async Task<PagedResult<PurchaseDto>> ListPurchasesAsync(Guid companyId, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var query = dbContext.Purchases.AsNoTracking().Where(purchase => purchase.CompanyId == companyId);
        if (!string.IsNullOrWhiteSpace(listQuery.Filter))
        {
            var filter = listQuery.Filter.Trim().ToLower();
            query = query.Where(purchase => purchase.Invoice != null && purchase.Invoice.ToLower().Contains(filter));
        }

        query = NormalizeSort(listQuery.Sort) switch
        {
            "time" => query.OrderBy(purchase => purchase.PurchaseTime),
            "total" => query.OrderBy(purchase => purchase.Total),
            "total_desc" => query.OrderByDescending(purchase => purchase.Total),
            _ => query.OrderByDescending(purchase => purchase.PurchaseTime)
        };

        var page = NormalizePage(listQuery.Page);
        var pageSize = NormalizePageSize(listQuery.PageSize);
        var totalCount = await query.CountAsync(cancellationToken);
        var purchases = await query
            .Include(purchase => purchase.PurchaseProducts)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        return new PagedResult<PurchaseDto>(purchases.Select(ToDto).ToArray(), page, pageSize, totalCount, TotalPages(totalCount, pageSize));
    }

    public async Task<PurchaseDto?> GetPurchaseAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var purchase = await dbContext.Purchases
            .AsNoTracking()
            .Include(item => item.PurchaseProducts)
            .FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        return purchase is null ? null : ToDto(purchase);
    }

    public async Task<PurchaseDto?> CreatePurchaseAsync(PurchaseWriteDto request, CancellationToken cancellationToken)
    {
        if (!await PurchaseScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var purchase = new Purchase { Id = Guid.NewGuid(), CompanyId = request.CompanyId };
        ApplyPurchaseWrite(purchase, request);
        dbContext.Purchases.Add(purchase);
        await dbContext.SaveChangesAsync(cancellationToken);
        await SyncPurchaseLinesAsync(purchase, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetPurchaseAsync(request.CompanyId, purchase.Id, cancellationToken);
    }

    public async Task<PurchaseDto?> UpdatePurchaseAsync(Guid id, PurchaseWriteDto request, CancellationToken cancellationToken)
    {
        if (!await PurchaseScopeIsValidAsync(request, cancellationToken)) return null;

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var purchase = await dbContext.Purchases
            .Include(item => item.PurchaseProducts)
            .FirstOrDefaultAsync(item => item.CompanyId == request.CompanyId && item.Id == id, cancellationToken);
        if (purchase is null) return null;

        ApplyPurchaseWrite(purchase, request);
        dbContext.PurchaseProducts.RemoveRange(purchase.PurchaseProducts);
        await SyncPurchaseLinesAsync(purchase, request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return await GetPurchaseAsync(request.CompanyId, purchase.Id, cancellationToken);
    }

    public async Task<bool> DeletePurchaseAsync(Guid companyId, Guid id, CancellationToken cancellationToken)
    {
        var purchase = await dbContext.Purchases.Include(item => item.PurchaseProducts).FirstOrDefaultAsync(item => item.CompanyId == companyId && item.Id == id, cancellationToken);
        if (purchase is null) return false;

        dbContext.PurchaseProducts.RemoveRange(purchase.PurchaseProducts);
        dbContext.Purchases.Remove(purchase);
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

    private static async Task<PagedResult<T>> ToPagedResultAsync<T>(IQueryable<T> query, ListQuery listQuery, CancellationToken cancellationToken)
    {
        var page = NormalizePage(listQuery.Page);
        var pageSize = NormalizePageSize(listQuery.PageSize);
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return new PagedResult<T>(items, page, pageSize, totalCount, TotalPages(totalCount, pageSize));
    }

    private static int NormalizePage(int page) => page < 1 ? 1 : page;
    private static int NormalizePageSize(int pageSize) => pageSize switch
    {
        < 1 => 50,
        > 200 => 200,
        _ => pageSize
    };

    private static int TotalPages(int totalCount, int pageSize) => totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);
    private static string NormalizeSort(string? sort) => (sort ?? string.Empty).Trim().Replace("-", "_").ToLowerInvariant();

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

    private async Task SyncCustomerAddressesAsync(Guid customerId, CustomerWriteDto request, CancellationToken cancellationToken)
    {
        if (request.Addresses is null) return;

        var currentLinks = await dbContext.CustomerAddresses
            .Include(link => link.Address)
            .Where(link => link.CustomerId == customerId)
            .ToListAsync(cancellationToken);
        dbContext.CustomerAddresses.RemoveRange(currentLinks);
        dbContext.Addresses.RemoveRange(currentLinks.Select(link => link.Address).OfType<Address>());

        foreach (var addressWrite in request.Addresses)
        {
            var address = new Address
            {
                Id = addressWrite.Id.GetValueOrDefault(Guid.NewGuid()),
                CompanyId = request.CompanyId,
                AddressType = addressWrite.AddressType,
                AddressHeader = addressWrite.AddressHeader,
                CityId = addressWrite.CityId,
                TownId = addressWrite.TownId,
                District = addressWrite.District,
                MobilePhone = addressWrite.MobilePhone,
                BusinessPhone = addressWrite.BusinessPhone,
                Description = addressWrite.Description,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,
                CreatedById = request.UserId,
                UpdatedById = request.UserId,
                Active = true
            };
            dbContext.Addresses.Add(address);
            dbContext.CustomerAddresses.Add(new CustomerAddress { Id = Guid.NewGuid(), CustomerId = customerId, AddressId = address.Id });
        }
    }

    private async Task<CustomerDetailDto> ToCustomerDetailDtoAsync(Customer customer, CancellationToken cancellationToken)
    {
        var addresses = await dbContext.CustomerAddresses
            .AsNoTracking()
            .Include(link => link.Address)
            .Where(link => link.CustomerId == customer.Id && link.Address != null && link.Address.CompanyId == customer.CompanyId)
            .Select(link => ToDto(link.Address!))
            .ToListAsync(cancellationToken);
        var wallet = await dbContext.WalletAccounts.AsNoTracking().FirstOrDefaultAsync(account => account.CompanyId == customer.CompanyId && account.CustomerId == customer.Id, cancellationToken);
        var loyalty = await dbContext.LoyaltyAccounts.AsNoTracking().FirstOrDefaultAsync(account => account.CompanyId == customer.CompanyId && account.CustomerId == customer.Id, cancellationToken);

        return new CustomerDetailDto(
            customer.Id,
            customer.CompanyId,
            customer.Name,
            customer.Surname,
            customer.Username,
            customer.Phone,
            customer.Mail,
            customer.Balance,
            customer.Active,
            addresses,
            wallet is null ? null : ToDto(wallet),
            loyalty is null ? null : ToDto(loyalty));
    }

    private static void ApplySupplierWrite(Supplier supplier, SupplierWriteDto request)
    {
        supplier.Name = request.Name;
        supplier.AuthorizedPerson = request.AuthorizedPerson;
        supplier.Address = request.Address;
        supplier.Phone = request.Phone;
        supplier.Mail = request.Mail;
        supplier.TaxOffice = request.TaxOffice;
        supplier.TaxNo = request.TaxNo;
        supplier.TaxFree = request.TaxFree;
        supplier.MoneyUnitType = request.MoneyUnitType;
        supplier.Maturity = request.Maturity;
        supplier.OpeningBalance = request.OpeningBalance;
    }

    private async Task<bool> PurchaseScopeIsValidAsync(PurchaseWriteDto request, CancellationToken cancellationToken)
    {
        var supplierExists = await dbContext.Suppliers.AnyAsync(supplier => supplier.CompanyId == request.CompanyId && supplier.Id == request.SupplierId, cancellationToken);
        var storeExists = await dbContext.Stores.AnyAsync(store => store.CompanyId == request.CompanyId && store.Id == request.StoreId, cancellationToken);
        var productsExist = await CompanyIdsExistAsync(dbContext.Products, request.CompanyId, request.Lines.Select(line => line.ProductId).ToArray(), cancellationToken);
        return supplierExists && storeExists && productsExist;
    }

    private static void ApplyPurchaseWrite(Purchase purchase, PurchaseWriteDto request)
    {
        purchase.PurchaseTime = request.PurchaseTime;
        purchase.Invoice = request.Invoice;
        purchase.PaymentCompleted = request.PaymentCompleted;
        purchase.Received = request.Received;
        purchase.PayerId = request.PayerId;
        purchase.ReceiverId = request.ReceiverId;
        purchase.SupplierId = request.SupplierId;
        purchase.StoreId = request.StoreId;
        purchase.Total = request.Lines.Sum(line => line.Quantity * line.Price);
    }

    private Task SyncPurchaseLinesAsync(Purchase purchase, PurchaseWriteDto request, CancellationToken cancellationToken)
    {
        purchase.PurchaseProducts = request.Lines.Select(line => new PurchaseProduct
        {
            Id = Guid.NewGuid(),
            PurchaseId = purchase.Id,
            ProductId = line.ProductId,
            Quantity = line.Quantity,
            Price = line.Price,
            Total = line.Quantity * line.Price,
            Discount = line.Discount,
            Tax = line.Tax
        }).ToList();
        return Task.CompletedTask;
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

    private async Task<bool> EarnRuleScopeIsValidAsync(EarnRuleWriteDto request, CancellationToken cancellationToken)
    {
        return request.Scope switch
        {
            EarnRuleScope.All => true,
            EarnRuleScope.Branch => request.BranchId.HasValue
                && await dbContext.Branches.AnyAsync(branch => branch.CompanyId == request.CompanyId && branch.Id == request.BranchId.Value, cancellationToken),
            EarnRuleScope.Category => request.CategoryId.HasValue
                && await dbContext.Categories.AnyAsync(category => category.CompanyId == request.CompanyId && category.Id == request.CategoryId.Value, cancellationToken),
            _ => false
        };
    }

    private static void ApplyEarnRuleWrite(EarnRule rule, EarnRuleWriteDto request)
    {
        rule.Name = request.Name;
        rule.AmountPerPoint = 1m / request.PointsPerCurrency;
        rule.MinimumOrderTotal = request.MinOrder;
        rule.ExpiryDays = request.ExpiryDays;
        rule.Scope = request.Scope;
        rule.BranchId = request.Scope == EarnRuleScope.Branch ? request.BranchId : null;
        rule.CategoryId = request.Scope == EarnRuleScope.Category ? request.CategoryId : null;
        rule.StartsAt = request.StartsAt;
        rule.EndsAt = request.EndsAt;
        rule.Active = request.Active;
    }

    private static void ApplyLoyaltyTierWrite(LoyaltyTier tier, LoyaltyTierWriteDto request)
    {
        tier.Name = request.Name;
        tier.MinimumPoints = request.MinPoints;
        tier.EarnMultiplier = request.PointMultiplier;
        tier.Benefits = request.Benefits;
        tier.Active = request.Active;
    }

    private async Task<bool> RewardScopeIsValidAsync(RewardWriteDto request, CancellationToken cancellationToken)
    {
        if (!request.ProductId.HasValue) return true;
        return await dbContext.Products.AnyAsync(product => product.CompanyId == request.CompanyId && product.Id == request.ProductId.Value, cancellationToken);
    }

    private static void ApplyRewardWrite(Reward reward, RewardWriteDto request)
    {
        reward.Name = request.Name;
        reward.RequiredPoints = request.PointCost;
        reward.RewardType = request.RewardType;
        reward.DiscountAmount = request.DiscountAmount;
        reward.Image = request.Image;
        reward.ProductId = request.ProductId;
        reward.Active = request.Active;
    }

    private async Task<bool> StampCardScopeIsValidAsync(StampCardWriteDto request, CancellationToken cancellationToken)
    {
        if (!request.RewardId.HasValue) return true;
        return await dbContext.Rewards.AnyAsync(reward => reward.CompanyId == request.CompanyId && reward.Id == request.RewardId.Value, cancellationToken);
    }

    private static void ApplyStampCardWrite(StampCard stampCard, StampCardWriteDto request)
    {
        stampCard.Name = request.Name;
        stampCard.RequiredStamps = request.RequiredStamps;
        stampCard.RewardId = request.RewardId;
        stampCard.StartsAt = request.StartsAt;
        stampCard.EndsAt = request.EndsAt;
        stampCard.Active = request.Active;
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
    private static AddressDto ToDto(Address address) => new(address.Id, address.AddressType, address.AddressHeader, address.CityId, address.TownId, address.District, address.MobilePhone, address.BusinessPhone, address.Description);
    private static WalletAccountDto ToDto(WalletAccount account) => new(account.Id, account.CompanyId, account.CustomerId, account.Currency, account.Balance);
    private static LoyaltyAccountDto ToDto(LoyaltyAccount account) => new(account.Id, account.CompanyId, account.CustomerId, account.LoyaltyTierId, account.PointBalance, account.LifetimePoints);
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

    private static EarnRuleDto ToDto(EarnRule rule) => new(
        rule.Id,
        rule.CompanyId,
        rule.Name,
        rule.AmountPerPoint > 0m ? 1m / rule.AmountPerPoint : 0m,
        rule.MinimumOrderTotal,
        rule.ExpiryDays,
        rule.Scope,
        rule.BranchId,
        rule.CategoryId,
        rule.StartsAt,
        rule.EndsAt,
        rule.Active);

    private static LoyaltyTierDto ToDto(LoyaltyTier tier) => new(
        tier.Id,
        tier.CompanyId,
        tier.Name,
        tier.MinimumPoints,
        tier.EarnMultiplier,
        tier.Benefits,
        tier.Active);

    private static RewardDto ToDto(Reward reward) => new(
        reward.Id,
        reward.CompanyId,
        reward.Name,
        reward.RequiredPoints,
        reward.RewardType,
        reward.DiscountAmount,
        reward.Image,
        reward.ProductId,
        reward.Active);

    private static StampCardDto ToDto(StampCard stampCard) => new(
        stampCard.Id,
        stampCard.CompanyId,
        stampCard.Name,
        stampCard.RequiredStamps,
        stampCard.RewardId,
        stampCard.StartsAt,
        stampCard.EndsAt,
        stampCard.Active);

    private static SupplierDto ToDto(Supplier supplier) => new(
        supplier.Id,
        supplier.CompanyId,
        supplier.Name,
        supplier.AuthorizedPerson,
        supplier.Address,
        supplier.Phone,
        supplier.Mail,
        supplier.TaxOffice,
        supplier.TaxNo,
        supplier.TaxFree,
        supplier.MoneyUnitType,
        supplier.Maturity,
        supplier.OpeningBalance,
        supplier.Active);

    private static PurchaseDto ToDto(Purchase purchase) => new(
        purchase.Id,
        purchase.CompanyId,
        purchase.PurchaseTime,
        purchase.Invoice,
        purchase.Total,
        purchase.PaymentCompleted,
        purchase.Received,
        purchase.PayerId,
        purchase.ReceiverId,
        purchase.SupplierId,
        purchase.StoreId,
        purchase.PurchaseProducts.Select(line => new PurchaseLineDto(
            line.Id,
            line.ProductId,
            line.Quantity,
            line.Price,
            line.Total,
            line.Discount,
            line.Tax)).ToArray());
}
