using FluentValidation;
using Mansis.Pos.Application.Common;
using Mansis.Pos.Application.Loyalty;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Orders.CreateOrder;

public sealed class CreateOrderService(
    IValidator<CreateOrderRequest> validator,
    IOrderCreationStore store,
    LoyaltyEarnCalculator loyaltyEarnCalculator)
{
    public async Task<Result<OrderResult>> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken = default)
    {
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            return Result<OrderResult>.Failure(validation.Errors[0].ErrorMessage);
        }

        var existingOrder = await store.FindByIdempotencyKeyAsync(request.CompanyId, request.IdempotencyKey, cancellationToken);
        if (existingOrder is not null)
        {
            return Result<OrderResult>.Success(ToResult(existingOrder, existing: true));
        }

        var productIds = request.Lines.Select(line => line.ProductId).Distinct().ToArray();
        var snapshot = await store.LoadSnapshotAsync(request.CompanyId, request.PosId, request.CustomerId, productIds, cancellationToken);
        var total = request.Lines.Sum(line => line.UnitPrice * line.Quantity + line.TaxAmount);
        var paymentTotal = request.Payments.Sum(payment => payment.Amount);

        if (paymentTotal != total)
        {
            return Result<OrderResult>.Failure("Payment total must equal order total.");
        }

        foreach (var line in request.Lines)
        {
            if (!snapshot.Products.TryGetValue(line.ProductId, out var product))
            {
                return Result<OrderResult>.Failure("Product not found.");
            }

            if (product.Stocktaking && product.Quantity < line.Quantity)
            {
                return Result<OrderResult>.Failure("Insufficient stock.");
            }
        }

        if (request.CustomerId.HasValue && snapshot.WalletAccount is not null && snapshot.WalletAccount.Balance < total)
        {
            return Result<OrderResult>.Failure("Insufficient wallet balance.");
        }

        var now = DateTimeOffset.UtcNow;
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CompanyId = request.CompanyId,
            PosId = request.PosId,
            UserId = request.UserId,
            CustomerId = request.CustomerId,
            ShippingType = request.ShippingType,
            OrderState = OrderState.Received,
            OrderTime = request.OrderTime.ToUniversalTime(),
            IdempotencyKey = request.IdempotencyKey,
            SubTotal = request.Lines.Sum(line => line.UnitPrice * line.Quantity),
            TaxTotal = request.Lines.Sum(line => line.TaxAmount),
            TotalDiscount = 0m,
            Total = total,
            PaymentSummary = ResolvePaymentSummary(request.Payments),
            CreatedAt = now,
            UpdatedAt = now,
            CreatedById = request.UserId,
            UpdatedById = request.UserId,
            Active = true
        };

        var orderProducts = request.Lines.Select(line => new OrderProduct
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            ProductId = line.ProductId,
            Quantity = line.Quantity,
            Total = line.UnitPrice * line.Quantity + line.TaxAmount
        }).ToArray();

        var orderPayments = request.Payments.Select(payment => new OrderPayment
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            CompanyId = request.CompanyId,
            PaymentType = payment.PaymentType,
            Amount = payment.Amount,
            Currency = payment.Currency,
            ExternalReference = payment.ExternalReference,
            State = OrderPaymentState.Captured,
            PaidAt = now
        }).ToArray();

        var stockMovements = new List<StockMovement>();
        var storeProducts = new List<StoreProduct>();
        foreach (var line in request.Lines)
        {
            var product = snapshot.Products[line.ProductId];
            if (!product.Stocktaking)
            {
                continue;
            }

            stockMovements.Add(new StockMovement
            {
                Id = Guid.NewGuid(),
                CompanyId = request.CompanyId,
                StoreId = snapshot.StoreId,
                ProductId = line.ProductId,
                OperationId = order.Id,
                MovementType = StoreProductMovementType.Order,
                Direction = LedgerDirection.Credit,
                Quantity = line.Quantity,
                State = LedgerEntryState.Posted,
                OccurredAt = now
            });

            storeProducts.Add(new StoreProduct
            {
                StoreId = snapshot.StoreId,
                ProductId = line.ProductId,
                Quantity = product.Quantity - line.Quantity
            });
        }

        var walletTransactions = new List<WalletTransaction>();
        if (snapshot.WalletAccount is not null)
        {
            snapshot.WalletAccount.Balance -= total;
            walletTransactions.Add(new WalletTransaction
            {
                Id = Guid.NewGuid(),
                CompanyId = request.CompanyId,
                WalletAccountId = snapshot.WalletAccount.Id,
                OrderId = order.Id,
                Direction = LedgerDirection.Credit,
                Amount = total,
                State = LedgerEntryState.Posted,
                Description = "Order payment",
                OccurredAt = now
            });
        }

        var loyaltyTransactions = new List<LoyaltyPointTransaction>();
        if (snapshot.LoyaltyAccount is not null)
        {
            var earnResult = loyaltyEarnCalculator.Calculate(snapshot, request.Lines, total, now);
            if (earnResult.Points > 0)
            {
                snapshot.LoyaltyAccount.PointBalance += earnResult.Points;
                snapshot.LoyaltyAccount.LifetimePoints += earnResult.Points;
                var nextTier = loyaltyEarnCalculator.ResolveTierAfterEarn(
                    snapshot.LoyaltyAccount,
                    snapshot.LoyaltyTiers,
                    earnedPoints: 0);
                if (nextTier is not null && snapshot.LoyaltyAccount.LoyaltyTierId != nextTier.Id)
                {
                    snapshot.LoyaltyAccount.LoyaltyTierId = nextTier.Id;
                }

                loyaltyTransactions.Add(new LoyaltyPointTransaction
                {
                    Id = Guid.NewGuid(),
                    CompanyId = request.CompanyId,
                    LoyaltyAccountId = snapshot.LoyaltyAccount.Id,
                    OrderId = order.Id,
                    TransactionType = LoyaltyPointTransactionType.Earn,
                    Points = earnResult.Points,
                    State = LedgerEntryState.Posted,
                    ExpiresAt = earnResult.ExpiresAt,
                    OccurredAt = now
                });
            }
        }

        await store.AddOrderGraphAsync(
            new OrderCreationGraph(
                order,
                orderProducts,
                orderPayments,
                stockMovements,
                walletTransactions,
                loyaltyTransactions,
                storeProducts,
                snapshot.WalletAccount,
                snapshot.LoyaltyAccount),
            cancellationToken);

        return Result<OrderResult>.Success(ToResult(order, existing: false));
    }

    private static OrderResult ToResult(Order order, bool existing)
    {
        return new OrderResult(order.Id, order.IdempotencyKey, order.Total, order.PaymentSummary, existing);
    }

    private static PaymentSummary ResolvePaymentSummary(IReadOnlyList<CreateOrderPayment> payments)
    {
        var distinctTypes = payments.Select(payment => payment.PaymentType).Distinct().ToArray();
        return distinctTypes.Length == 1
            ? distinctTypes[0] switch
            {
                PaymentType.Cash => PaymentSummary.Cash,
                PaymentType.CreditCard => PaymentSummary.CreditCard,
                PaymentType.Ticket => PaymentSummary.Ticket,
                PaymentType.Sodexo => PaymentSummary.Sodexo,
                PaymentType.Multinet => PaymentSummary.Multinet,
                _ => PaymentSummary.Mixed
            }
            : PaymentSummary.Mixed;
    }
}
