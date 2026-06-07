using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class Order : AuditableEntity, ICompanyScoped
{
    public decimal SubTotal { get; set; }
    public decimal TaxTotal { get; set; }
    public decimal? TotalDiscount { get; set; }
    public decimal Total { get; set; }
    public ShippingType ShippingType { get; set; }
    public OrderState OrderState { get; set; }
    public DateTimeOffset OrderTime { get; set; }
    public int OrderNumber { get; set; }
    public bool IsClosed { get; set; }
    public bool OfflineOrder { get; set; }
    public string? UpdateReason { get; set; }
    public string? Description { get; set; }
    public Guid? AddressId { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid PosId { get; set; }
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public Pos? Pos { get; set; }
    public User? User { get; set; }
    public Company? Company { get; set; }
    public Customer? Customer { get; set; }
    public Address? Address { get; set; }
    public List<OrderProduct> OrderProducts { get; set; } = [];
    public List<OrderDiscount> OrderDiscounts { get; set; } = [];
    public List<OrderPayment> Payments { get; set; } = [];
}

public sealed class OrderPayment : Entity, ICompanyScoped, IAppendOnly
{
    public Guid OrderId { get; set; }
    public Guid CompanyId { get; set; }
    public PaymentType PaymentType { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "TRY";
    public OrderPaymentState State { get; set; }
    public string? ExternalReference { get; set; }
    public Guid? ReversalOfId { get; set; }
    public DateTimeOffset PaidAt { get; set; }
    public Order? Order { get; set; }
    public OrderPayment? ReversalOf { get; set; }
}

public sealed class OrderProduct : Entity
{
    public int Quantity { get; set; }
    public decimal? Total { get; set; }
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public Product? Product { get; set; }
    public Order? Order { get; set; }
}

public sealed class OrderSubProduct : Entity
{
    public string? Name { get; set; }
    public Guid ProductId { get; set; }
    public Guid OrderProductId { get; set; }
    public Guid OrderId { get; set; }
    public Product? Product { get; set; }
    public OrderProduct? OrderProduct { get; set; }
    public Order? Order { get; set; }
}
