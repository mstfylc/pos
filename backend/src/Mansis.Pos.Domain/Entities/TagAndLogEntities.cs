using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class Tag : Entity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Guid TagColorId { get; set; }
    public Guid TagShapeId { get; set; }
    public bool Active { get; set; } = true;
    public Company? Company { get; set; }
    public TagColor? TagColor { get; set; }
    public TagShape? TagShape { get; set; }
}

public sealed class TagColor : Entity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public bool Active { get; set; } = true;
    public Company? Company { get; set; }
}

public sealed class TagShape : Entity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class TagBranch : Entity { public Guid TagId { get; set; } public Guid BranchId { get; set; } public Tag? Tag { get; set; } public Branch? Branch { get; set; } }
public sealed class TagDiscount : Entity { public Guid TagId { get; set; } public Guid DiscountId { get; set; } public Tag? Tag { get; set; } public Discount? Discount { get; set; } }
public sealed class TagOrder : Entity { public Guid TagId { get; set; } public Guid OrderId { get; set; } public Tag? Tag { get; set; } public Order? Order { get; set; } }
public sealed class TagPos : Entity { public Guid TagId { get; set; } public Guid PosId { get; set; } public Tag? Tag { get; set; } public Pos? Pos { get; set; } }
public sealed class TagProduct : Entity { public Guid TagId { get; set; } public Guid ProductId { get; set; } public Tag? Tag { get; set; } public Product? Product { get; set; } }

public abstract class ActivityLog : Entity
{
    public LogActivityType LogActivityType { get; set; }
    public Guid AuthorId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}

public sealed class CompanyActivityLog : ActivityLog, ICompanyScoped { public Guid CompanyId { get; set; } public Company? Company { get; set; } }
public sealed class BranchActivityLog : ActivityLog { public Guid BranchId { get; set; } public Branch? Branch { get; set; } }
public sealed class PosActivityLog : ActivityLog { public Guid PosId { get; set; } public Pos? Pos { get; set; } }
public sealed class StoreActivityLog : ActivityLog { public Guid StoreId { get; set; } public Store? Store { get; set; } }
public sealed class UserActivityLog : ActivityLog { public Guid UserId { get; set; } public User? User { get; set; } }
