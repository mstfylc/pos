using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class Company : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
}

public sealed class Branch : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class Store : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Guid? BranchId { get; set; }
    public Company? Company { get; set; }
    public Branch? Branch { get; set; }
}

public sealed class Pos : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Guid BranchId { get; set; }
    public Guid StoreId { get; set; }
    public Company? Company { get; set; }
    public Branch? Branch { get; set; }
    public Store? Store { get; set; }
}

public sealed class User : AuditableEntity, ICompanyScoped
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public bool MustChangePassword { get; set; }
    public string? Pin { get; set; }
    public Guid CompanyId { get; set; }
    public Guid RoleId { get; set; }
    public Guid? CardId { get; set; }
    public Card? Card { get; set; }
    public Company? Company { get; set; }
    public Role? Role { get; set; }
}

public sealed class Role : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class Permission : Entity
{
    public string Name { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public PermissionType PermissionType { get; set; }
}

public sealed class RolePermission : Entity
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
    public bool Active { get; set; } = true;
    public Role? Role { get; set; }
    public Permission? Permission { get; set; }
}

public sealed class Card : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class CompanyOwner : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public Guid OwnerId { get; set; }
    public Company? Company { get; set; }
    public User? Owner { get; set; }
}

public sealed class BranchManager : Entity
{
    public Guid BranchId { get; set; }
    public Guid ManagerId { get; set; }
    public Branch? Branch { get; set; }
    public User? Manager { get; set; }
}

public sealed class BranchUser : Entity
{
    public Guid BranchId { get; set; }
    public Guid UserId { get; set; }
    public Branch? Branch { get; set; }
    public User? User { get; set; }
}

public sealed class PosUser : Entity
{
    public Guid PosId { get; set; }
    public Guid UserId { get; set; }
    public Pos? Pos { get; set; }
    public User? User { get; set; }
}

public sealed class ConfigParam : Entity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class Assignment : Entity
{
    public Guid UserId { get; set; }
    public AssignmentTableType AssignmentTableType { get; set; }
    public List<AssignmentRecord> AssignmentRecords { get; set; } = [];
    public User? User { get; set; }
}

public sealed class AssignmentRecord : Entity
{
    public Guid RecordId { get; set; }
    public string RecordName { get; set; } = string.Empty;
    public Guid AssignmentId { get; set; }
    public Assignment? Assignment { get; set; }
}
