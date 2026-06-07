using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class Supplier : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string? AuthorizedPerson { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public string? TaxOffice { get; set; }
    public string? TaxNo { get; set; }
    public bool? TaxFree { get; set; }
    public MoneyUnitType? MoneyUnitType { get; set; }
    public int? Maturity { get; set; }
    public decimal? OpeningBalance { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class Purchase : Entity, ICompanyScoped
{
    public DateTimeOffset? PurchaseTime { get; set; }
    public string? Invoice { get; set; }
    public decimal Total { get; set; }
    public bool PaymentCompleted { get; set; }
    public bool Received { get; set; }
    public Guid? PayerId { get; set; }
    public Guid? ReceiverId { get; set; }
    public Guid SupplierId { get; set; }
    public Guid StoreId { get; set; }
    public Guid CompanyId { get; set; }
    public User? Receiver { get; set; }
    public User? Payer { get; set; }
    public Supplier? Supplier { get; set; }
    public Store? Store { get; set; }
    public Company? Company { get; set; }
    public List<PurchaseProduct> PurchaseProducts { get; set; } = [];
}

public sealed class PurchaseProduct : Entity
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
    public int? Discount { get; set; }
    public int? Tax { get; set; }
    public Guid PurchaseId { get; set; }
    public Purchase? Purchase { get; set; }
}
