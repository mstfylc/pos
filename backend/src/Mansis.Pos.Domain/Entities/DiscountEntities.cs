using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class Discount : AuditableEntity, ICompanyScoped
{
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public decimal MaxDiscountAmount { get; set; }
    public DateTimeOffset? ExpireDate { get; set; }
    public DiscountType DiscountType { get; set; }
    public DiscountCategory DiscountCategory { get; set; }
    public int SortOrder { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class DiscountBranch : Entity
{
    public Guid DiscountId { get; set; }
    public Guid BranchId { get; set; }
    public Discount? Discount { get; set; }
    public Branch? Branch { get; set; }
}

public sealed class DiscountPos : Entity
{
    public Guid DiscountId { get; set; }
    public Guid PosId { get; set; }
    public Discount? Discount { get; set; }
    public Pos? Pos { get; set; }
}

public sealed class DiscountUser : Entity
{
    public Guid DiscountId { get; set; }
    public Guid UserId { get; set; }
    public Discount? Discount { get; set; }
    public User? User { get; set; }
}

public sealed class DiscountUsageLog : Entity, ICompanyScoped
{
    public decimal Amount { get; set; }
    public DateTimeOffset OrderTime { get; set; }
    public Guid CompanyId { get; set; }
    public Guid OrderId { get; set; }
    public Guid DiscountId { get; set; }
    public Guid UserId { get; set; }
    public Company? Company { get; set; }
    public Order? Order { get; set; }
    public Discount? Discount { get; set; }
    public User? User { get; set; }
}

public sealed class OrderDiscount : Entity
{
    public decimal? Amount { get; set; }
    public Guid UserId { get; set; }
    public Guid DiscountId { get; set; }
    public Guid OrderId { get; set; }
    public Discount? Discount { get; set; }
    public User? User { get; set; }
    public Order? Order { get; set; }
}
