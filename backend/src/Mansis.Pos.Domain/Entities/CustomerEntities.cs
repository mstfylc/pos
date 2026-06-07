using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class Customer : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public bool MustChangePassword { get; set; }
    public decimal Balance { get; set; }
    public string? Photo { get; set; }
    public bool Registered { get; set; }
    public Guid CompanyId { get; set; }
    public Guid RoleId { get; set; }
    public Company? Company { get; set; }
    public Role? Role { get; set; }
}

public sealed class CustomerBalanceMovement : Entity, ICompanyScoped
{
    public decimal Amount { get; set; }
    public BalanceMovementType BalanceMovementType { get; set; }
    public Guid? OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid CompanyId { get; set; }
    public Customer? Customer { get; set; }
    public Company? Company { get; set; }
}

public sealed class LoadBalanceRequest : Entity, ICompanyScoped
{
    public Guid CustomerId { get; set; }
    public Guid PosId { get; set; }
    public Guid RequestedById { get; set; }
    public int ConfirmCode { get; set; }
    public DateTimeOffset RequestedTime { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public Pos? Pos { get; set; }
    public User? RequestedBy { get; set; }
    public Customer? Customer { get; set; }
}

public sealed class Address : AuditableEntity, ICompanyScoped
{
    public AddressType AddressType { get; set; }
    public string? AddressHeader { get; set; }
    public Guid CityId { get; set; }
    public Guid TownId { get; set; }
    public string? District { get; set; }
    public string? MobilePhone { get; set; }
    public string? BusinessPhone { get; set; }
    public string? Description { get; set; }
    public Guid CompanyId { get; set; }
    public City? City { get; set; }
    public Town? Town { get; set; }
    public Company? Company { get; set; }
}

public sealed class CustomerAddress : Entity
{
    public Guid CustomerId { get; set; }
    public Guid AddressId { get; set; }
    public Customer? Customer { get; set; }
    public Address? Address { get; set; }
}

public sealed class City : Entity
{
    public string Name { get; set; } = string.Empty;
}

public sealed class Town : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid CityId { get; set; }
    public City? City { get; set; }
}
