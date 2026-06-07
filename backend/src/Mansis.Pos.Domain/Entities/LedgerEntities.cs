using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class StockMovement : Entity, ICompanyScoped, IAppendOnly
{
    public Guid CompanyId { get; set; }
    public Guid StoreId { get; set; }
    public Guid ProductId { get; set; }
    public Guid? OperationId { get; set; }
    public StoreProductMovementType MovementType { get; set; }
    public LedgerDirection Direction { get; set; }
    public int Quantity { get; set; }
    public LedgerEntryState State { get; set; }
    public Guid? ReversalOfId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset OccurredAt { get; set; }
    public Store? Store { get; set; }
    public Product? Product { get; set; }
    public StockMovement? ReversalOf { get; set; }
}

public sealed class WalletAccount : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public Guid CustomerId { get; set; }
    public string Currency { get; set; } = "TRY";
    public decimal Balance { get; set; }
    public Customer? Customer { get; set; }
}

public sealed class WalletTransaction : Entity, ICompanyScoped, IAppendOnly
{
    public Guid CompanyId { get; set; }
    public Guid WalletAccountId { get; set; }
    public Guid? OrderId { get; set; }
    public LedgerDirection Direction { get; set; }
    public decimal Amount { get; set; }
    public LedgerEntryState State { get; set; }
    public Guid? ReversalOfId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset OccurredAt { get; set; }
    public WalletAccount? WalletAccount { get; set; }
    public Order? Order { get; set; }
    public WalletTransaction? ReversalOf { get; set; }
}

public sealed class LoyaltyAccount : Entity, ICompanyScoped
{
    public Guid CompanyId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? LoyaltyTierId { get; set; }
    public int PointBalance { get; set; }
    public int LifetimePoints { get; set; }
    public Customer? Customer { get; set; }
    public LoyaltyTier? LoyaltyTier { get; set; }
}

public sealed class LoyaltyPointTransaction : Entity, ICompanyScoped, IAppendOnly
{
    public Guid CompanyId { get; set; }
    public Guid LoyaltyAccountId { get; set; }
    public Guid? OrderId { get; set; }
    public LoyaltyPointTransactionType TransactionType { get; set; }
    public int Points { get; set; }
    public LedgerEntryState State { get; set; }
    public Guid? ReversalOfId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
    public DateTimeOffset OccurredAt { get; set; }
    public LoyaltyAccount? LoyaltyAccount { get; set; }
    public Order? Order { get; set; }
    public LoyaltyPointTransaction? ReversalOf { get; set; }
}
