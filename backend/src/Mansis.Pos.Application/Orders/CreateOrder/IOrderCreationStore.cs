using Mansis.Pos.Domain.Entities;

namespace Mansis.Pos.Application.Orders.CreateOrder;

public interface IOrderCreationStore
{
    Task<Order?> FindByIdempotencyKeyAsync(Guid companyId, string idempotencyKey, CancellationToken cancellationToken);
    Task<OrderCreationSnapshot> LoadSnapshotAsync(Guid companyId, Guid posId, Guid? customerId, IReadOnlyCollection<Guid> productIds, CancellationToken cancellationToken);
    Task AddOrderGraphAsync(OrderCreationGraph graph, CancellationToken cancellationToken);
}

public sealed record OrderCreationSnapshot(
    Guid StoreId,
    Guid BranchId,
    IReadOnlyDictionary<Guid, ProductStockSnapshot> Products,
    WalletAccount? WalletAccount,
    LoyaltyAccount? LoyaltyAccount,
    IReadOnlyList<EarnRule> EarnRules,
    IReadOnlyList<LoyaltyTier> LoyaltyTiers);

public sealed record ProductStockSnapshot(Guid ProductId, Guid CategoryId, bool Stocktaking, int Quantity);

public sealed record OrderCreationGraph(
    Order Order,
    IReadOnlyList<OrderProduct> OrderProducts,
    IReadOnlyList<OrderPayment> OrderPayments,
    IReadOnlyList<StockMovement> StockMovements,
    IReadOnlyList<WalletTransaction> WalletTransactions,
    IReadOnlyList<LoyaltyPointTransaction> LoyaltyPointTransactions,
    IReadOnlyList<StoreProduct> StoreProductsToUpdate,
    WalletAccount? WalletAccountToUpdate,
    LoyaltyAccount? LoyaltyAccountToUpdate);
