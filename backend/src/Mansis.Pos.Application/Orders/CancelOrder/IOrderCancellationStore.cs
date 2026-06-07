using Mansis.Pos.Domain.Entities;

namespace Mansis.Pos.Application.Orders.CancelOrder;

public interface IOrderCancellationStore
{
    Task<OrderCancellationSnapshot?> LoadSnapshotAsync(Guid companyId, Guid orderId, CancellationToken cancellationToken);
    Task ApplyCancellationAsync(OrderCancellationGraph graph, CancellationToken cancellationToken);
}

public sealed record OrderCancellationSnapshot(
    Order Order,
    IReadOnlyList<OrderPayment> Payments,
    IReadOnlyList<StockMovement> StockMovements,
    IReadOnlyList<WalletTransaction> WalletTransactions,
    IReadOnlyList<LoyaltyPointTransaction> LoyaltyPointTransactions,
    IReadOnlyDictionary<(Guid StoreId, Guid ProductId), StoreProduct> StoreProducts,
    IReadOnlyDictionary<Guid, WalletAccount> WalletAccounts,
    IReadOnlyDictionary<Guid, LoyaltyAccount> LoyaltyAccounts);

public sealed record OrderCancellationGraph(
    Order Order,
    IReadOnlyList<OrderPayment> PaymentReversals,
    IReadOnlyList<StockMovement> StockReversals,
    IReadOnlyList<WalletTransaction> WalletReversals,
    IReadOnlyList<LoyaltyPointTransaction> LoyaltyReversals,
    IReadOnlyList<StoreProduct> StoreProductsToUpdate,
    IReadOnlyList<WalletAccount> WalletAccountsToUpdate,
    IReadOnlyList<LoyaltyAccount> LoyaltyAccountsToUpdate);
