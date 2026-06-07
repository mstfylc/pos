using FluentValidation;
using Mansis.Pos.Application.Common;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Orders.CancelOrder;

public sealed class CancelOrderService(
    IValidator<CancelOrderRequest> validator,
    IOrderCancellationStore store)
{
    public async Task<Result<CancelOrderResult>> CancelAsync(
        CancelOrderRequest request,
        CancellationToken cancellationToken = default)
    {
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            return Result<CancelOrderResult>.Failure(validation.Errors[0].ErrorMessage);
        }

        var snapshot = await store.LoadSnapshotAsync(request.CompanyId, request.OrderId, cancellationToken);
        if (snapshot is null)
        {
            return Result<CancelOrderResult>.Failure("Order not found.");
        }

        if (snapshot.Order.OrderState == OrderState.Cancelled)
        {
            return Result<CancelOrderResult>.Success(ToResult(snapshot.Order, existing: true));
        }

        var now = DateTimeOffset.UtcNow;
        snapshot.Order.OrderState = OrderState.Cancelled;
        snapshot.Order.IsClosed = true;
        snapshot.Order.UpdateReason = request.Reason;
        snapshot.Order.UpdatedAt = now;
        snapshot.Order.UpdatedById = request.UserId;

        var paymentReversals = snapshot.Payments
            .Where(payment => payment.ReversalOfId is null && payment.State == OrderPaymentState.Captured)
            .Select(payment => new OrderPayment
            {
                Id = Guid.NewGuid(),
                OrderId = payment.OrderId,
                CompanyId = payment.CompanyId,
                PaymentType = payment.PaymentType,
                Amount = payment.Amount,
                Currency = payment.Currency,
                State = OrderPaymentState.Refunded,
                ExternalReference = payment.ExternalReference,
                ReversalOfId = payment.Id,
                Reason = request.Reason,
                PaidAt = now
            })
            .ToArray();

        var stockReversals = new List<StockMovement>();
        var stockUpdates = new Dictionary<(Guid StoreId, Guid ProductId), StoreProduct>();
        foreach (var movement in snapshot.StockMovements.Where(movement => movement.ReversalOfId is null))
        {
            stockReversals.Add(new StockMovement
            {
                Id = Guid.NewGuid(),
                CompanyId = movement.CompanyId,
                StoreId = movement.StoreId,
                ProductId = movement.ProductId,
                OperationId = movement.OperationId,
                MovementType = movement.MovementType,
                Direction = Opposite(movement.Direction),
                Quantity = movement.Quantity,
                State = LedgerEntryState.Posted,
                ReversalOfId = movement.Id,
                Description = request.Reason,
                OccurredAt = now
            });

            if (snapshot.StoreProducts.TryGetValue((movement.StoreId, movement.ProductId), out var storeProduct))
            {
                storeProduct.Quantity += movement.Direction == LedgerDirection.Credit
                    ? movement.Quantity
                    : -movement.Quantity;
                stockUpdates[(movement.StoreId, movement.ProductId)] = storeProduct;
            }
        }

        var walletReversals = new List<WalletTransaction>();
        var walletUpdates = new Dictionary<Guid, WalletAccount>();
        foreach (var transaction in snapshot.WalletTransactions.Where(transaction => transaction.ReversalOfId is null))
        {
            walletReversals.Add(new WalletTransaction
            {
                Id = Guid.NewGuid(),
                CompanyId = transaction.CompanyId,
                WalletAccountId = transaction.WalletAccountId,
                OrderId = transaction.OrderId,
                Direction = Opposite(transaction.Direction),
                Amount = transaction.Amount,
                State = LedgerEntryState.Posted,
                ReversalOfId = transaction.Id,
                Description = request.Reason,
                OccurredAt = now
            });

            if (snapshot.WalletAccounts.TryGetValue(transaction.WalletAccountId, out var walletAccount))
            {
                walletAccount.Balance += transaction.Direction == LedgerDirection.Credit
                    ? transaction.Amount
                    : -transaction.Amount;
                walletUpdates[walletAccount.Id] = walletAccount;
            }
        }

        var loyaltyReversals = new List<LoyaltyPointTransaction>();
        var loyaltyUpdates = new Dictionary<Guid, LoyaltyAccount>();
        foreach (var transaction in snapshot.LoyaltyPointTransactions.Where(transaction => transaction.ReversalOfId is null))
        {
            loyaltyReversals.Add(new LoyaltyPointTransaction
            {
                Id = Guid.NewGuid(),
                CompanyId = transaction.CompanyId,
                LoyaltyAccountId = transaction.LoyaltyAccountId,
                OrderId = transaction.OrderId,
                TransactionType = LoyaltyPointTransactionType.Reverse,
                Points = -transaction.Points,
                State = LedgerEntryState.Posted,
                ReversalOfId = transaction.Id,
                Description = request.Reason,
                OccurredAt = now
            });

            if (snapshot.LoyaltyAccounts.TryGetValue(transaction.LoyaltyAccountId, out var loyaltyAccount))
            {
                loyaltyAccount.PointBalance -= transaction.Points;
                if (transaction.TransactionType == LoyaltyPointTransactionType.Earn)
                {
                    loyaltyAccount.LifetimePoints = Math.Max(0, loyaltyAccount.LifetimePoints - transaction.Points);
                }

                loyaltyUpdates[loyaltyAccount.Id] = loyaltyAccount;
            }
        }

        await store.ApplyCancellationAsync(
            new OrderCancellationGraph(
                snapshot.Order,
                paymentReversals,
                stockReversals,
                walletReversals,
                loyaltyReversals,
                stockUpdates.Values.ToArray(),
                walletUpdates.Values.ToArray(),
                loyaltyUpdates.Values.ToArray()),
            cancellationToken);

        return Result<CancelOrderResult>.Success(ToResult(snapshot.Order, existing: false));
    }

    private static CancelOrderResult ToResult(Order order, bool existing)
    {
        return new CancelOrderResult(order.Id, order.OrderState, existing);
    }

    private static LedgerDirection Opposite(LedgerDirection direction)
    {
        return direction == LedgerDirection.Credit ? LedgerDirection.Debit : LedgerDirection.Credit;
    }
}
