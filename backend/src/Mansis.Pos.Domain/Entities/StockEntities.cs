using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class StoreProduct : Entity
{
    public int Quantity { get; set; }
    public int? QuantityAfterStockCount { get; set; }
    public int? StockDiff { get; set; }
    public int Threshold { get; set; }
    public Guid StoreId { get; set; }
    public Guid ProductId { get; set; }
    public Store? Store { get; set; }
    public Product? Product { get; set; }
}

public sealed class StoreProductMovement : Entity
{
    public StoreProductMovementType MovementType { get; set; }
    public int Quantity { get; set; }
    public Guid OperationId { get; set; }
    public DateTimeOffset OperationTime { get; set; }
    public string? Description { get; set; }
    public Guid StoreId { get; set; }
    public Guid ProductId { get; set; }
    public Store? Store { get; set; }
    public Product? Product { get; set; }
}

public sealed class StoreProductTransfer : Entity, ICompanyScoped
{
    public ProductTransferState TransferState { get; set; }
    public Guid SourceStoreId { get; set; }
    public Guid TargetStoreId { get; set; }
    public Guid RequestedById { get; set; }
    public DateTimeOffset RequestedTime { get; set; }
    public Guid? ConfirmedById { get; set; }
    public DateTimeOffset? ConfirmedTime { get; set; }
    public Guid? ReceivedById { get; set; }
    public DateTimeOffset? ReceivedTime { get; set; }
    public bool? TransferDone { get; set; }
    public Guid CompanyId { get; set; }
    public Store? SourceStore { get; set; }
    public Store? TargetStore { get; set; }
    public User? RequestedBy { get; set; }
    public User? ConfirmedBy { get; set; }
    public User? ReceivedBy { get; set; }
    public Company? Company { get; set; }
    public List<StoreProductTransferDetail> Details { get; set; } = [];
}

public sealed class StoreProductTransferDetail : Entity
{
    public Guid StoreProductTransferId { get; set; }
    public int Quantity { get; set; }
    public int? ReceivedQuantity { get; set; }
    public ProductUnitType? Unit { get; set; }
    public decimal? UnitPrice { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public StoreProductTransfer? StoreProductTransfer { get; set; }
}
