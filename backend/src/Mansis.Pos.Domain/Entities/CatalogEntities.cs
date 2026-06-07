using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class Category : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public bool BePrinted { get; set; }
    public int SortOrder { get; set; }
    public Guid CompanyId { get; set; }
    public Guid CategoryColorId { get; set; }
    public Guid CategoryShapeId { get; set; }
    public Company? Company { get; set; }
    public CategoryColor? CategoryColor { get; set; }
    public CategoryShape? CategoryShape { get; set; }
}

public sealed class CategoryColor : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class CategoryShape : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

public sealed class Product : AuditableEntity, ICompanyScoped
{
    public string Name { get; set; } = string.Empty;
    public decimal? PurchasePrice { get; set; }
    public decimal? SalePrice { get; set; }
    public string? StockCode { get; set; }
    public bool StoreProduct { get; set; }
    public bool PosProduct { get; set; }
    public bool Stocktaking { get; set; }
    public bool EntryProduct { get; set; }
    public bool FavoriteProduct { get; set; }
    public int SortOrder { get; set; }
    public string? Description { get; set; }
    public ProductUnitType ProductUnitType { get; set; }
    public string? Image { get; set; }
    public TaxType TaxType { get; set; }
    public string? Barcode { get; set; }
    public bool Main { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid? ParentId { get; set; }
    public Product? Parent { get; set; }
    public Category? Category { get; set; }
    public Company? Company { get; set; }
}

public sealed class ProductSubProduct : Entity
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal? Price { get; set; }
    public bool Default { get; set; }
    public bool Visible { get; set; }
    public Guid ProductId { get; set; }
    public Guid SubProductId { get; set; }
    public Product? Product { get; set; }
    public Product? SubProduct { get; set; }
}

public sealed class PosProduct : Entity
{
    public decimal? PurchasePrice { get; set; }
    public decimal? SalePrice { get; set; }
    public Guid ProductId { get; set; }
    public Guid PosId { get; set; }
    public Product? Product { get; set; }
    public Pos? Pos { get; set; }
}

public sealed class CustomerFavoriteProduct : Entity, ICompanyScoped
{
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public Guid CompanyId { get; set; }
    public Customer? Customer { get; set; }
    public Product? Product { get; set; }
    public Company? Company { get; set; }
}
