using FluentValidation;
using Mansis.Pos.Application.Orders.CancelOrder;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Orders;

public sealed class CancelOrderServiceTests
{
    private static readonly Guid CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    private static readonly Guid OrderId = Guid.Parse("77777777-7777-7777-7777-777777777777");
    private static readonly Guid UserId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    private static readonly Guid StoreId = Guid.Parse("66666666-6666-6666-6666-666666666666");
    private static readonly Guid ProductId = Guid.Parse("55555555-5555-5555-5555-555555555555");
    private static readonly Guid WalletAccountId = Guid.Parse("88888888-8888-8888-8888-888888888888");
    private static readonly Guid LoyaltyAccountId = Guid.Parse("99999999-9999-9999-9999-999999999999");

    [Fact]
    public async Task CancelAsync_WithValidReason_WritesReversalsAndRestoresBalances()
    {
        var store = FakeOrderCancellationStore.Ready();
        var service = CreateService(store);

        var result = await service.CancelAsync(new CancelOrderRequest(CompanyId, OrderId, UserId, "Customer changed mind"));

        Assert.True(result.IsSuccess);
        var value = Assert.IsType<CancelOrderResult>(result.Value);
        Assert.False(value.Existing);
        Assert.Equal(OrderState.Cancelled, value.OrderState);
        Assert.NotNull(store.SavedGraph);
        Assert.Equal(OrderState.Cancelled, store.SavedGraph.Order.OrderState);
        Assert.Equal("Customer changed mind", store.SavedGraph.Order.UpdateReason);
        Assert.Single(store.SavedGraph.PaymentReversals);
        Assert.Equal(OrderPaymentState.Refunded, store.SavedGraph.PaymentReversals[0].State);
        Assert.Equal("Customer changed mind", store.SavedGraph.PaymentReversals[0].Reason);
        Assert.Single(store.SavedGraph.StockReversals);
        Assert.Equal(LedgerDirection.Debit, store.SavedGraph.StockReversals[0].Direction);
        Assert.Equal(10, store.SavedGraph.StoreProductsToUpdate[0].Quantity);
        Assert.Single(store.SavedGraph.WalletReversals);
        Assert.Equal(LedgerDirection.Debit, store.SavedGraph.WalletReversals[0].Direction);
        Assert.Equal(100m, store.SavedGraph.WalletAccountsToUpdate[0].Balance);
        Assert.Single(store.SavedGraph.LoyaltyReversals);
        Assert.Equal(-20, store.SavedGraph.LoyaltyReversals[0].Points);
        Assert.Equal(0, store.SavedGraph.LoyaltyAccountsToUpdate[0].PointBalance);
    }

    [Fact]
    public async Task CancelAsync_WithBlankReason_FailsBeforePersistence()
    {
        var store = FakeOrderCancellationStore.Ready();
        var service = CreateService(store);

        var result = await service.CancelAsync(new CancelOrderRequest(CompanyId, OrderId, UserId, ""));

        Assert.False(result.IsSuccess);
        Assert.Equal("Reason is required.", result.Error);
        Assert.Null(store.SavedGraph);
    }

    private static CancelOrderService CreateService(IOrderCancellationStore store)
    {
        IValidator<CancelOrderRequest> validator = new CancelOrderValidator();
        return new CancelOrderService(validator, store);
    }

    private sealed class FakeOrderCancellationStore(OrderCancellationSnapshot snapshot) : IOrderCancellationStore
    {
        public OrderCancellationGraph? SavedGraph { get; private set; }

        public static FakeOrderCancellationStore Ready()
        {
            var order = new Order
            {
                Id = OrderId,
                CompanyId = CompanyId,
                OrderState = OrderState.Completed,
                Total = 20m
            };

            var payment = new OrderPayment
            {
                Id = Guid.NewGuid(),
                CompanyId = CompanyId,
                OrderId = OrderId,
                PaymentType = PaymentType.Cash,
                Amount = 20m,
                Currency = "TRY",
                State = OrderPaymentState.Captured,
                PaidAt = DateTimeOffset.UtcNow
            };

            var stockMovement = new StockMovement
            {
                Id = Guid.NewGuid(),
                CompanyId = CompanyId,
                StoreId = StoreId,
                ProductId = ProductId,
                OperationId = OrderId,
                MovementType = StoreProductMovementType.Order,
                Direction = LedgerDirection.Credit,
                Quantity = 2,
                State = LedgerEntryState.Posted,
                OccurredAt = DateTimeOffset.UtcNow
            };

            var walletTransaction = new WalletTransaction
            {
                Id = Guid.NewGuid(),
                CompanyId = CompanyId,
                WalletAccountId = WalletAccountId,
                OrderId = OrderId,
                Direction = LedgerDirection.Credit,
                Amount = 20m,
                State = LedgerEntryState.Posted,
                OccurredAt = DateTimeOffset.UtcNow
            };

            var loyaltyTransaction = new LoyaltyPointTransaction
            {
                Id = Guid.NewGuid(),
                CompanyId = CompanyId,
                LoyaltyAccountId = LoyaltyAccountId,
                OrderId = OrderId,
                TransactionType = LoyaltyPointTransactionType.Earn,
                Points = 20,
                State = LedgerEntryState.Posted,
                OccurredAt = DateTimeOffset.UtcNow
            };

            var storeProduct = new StoreProduct
            {
                StoreId = StoreId,
                ProductId = ProductId,
                Quantity = 8
            };
            var walletAccount = new WalletAccount
            {
                Id = WalletAccountId,
                CompanyId = CompanyId,
                CustomerId = Guid.NewGuid(),
                Balance = 80m
            };
            var loyaltyAccount = new LoyaltyAccount
            {
                Id = LoyaltyAccountId,
                CompanyId = CompanyId,
                CustomerId = Guid.NewGuid(),
                PointBalance = 20
            };

            return new FakeOrderCancellationStore(
                new OrderCancellationSnapshot(
                    order,
                    [payment],
                    [stockMovement],
                    [walletTransaction],
                    [loyaltyTransaction],
                    new Dictionary<(Guid StoreId, Guid ProductId), StoreProduct>
                    {
                        [(StoreId, ProductId)] = storeProduct
                    },
                    new Dictionary<Guid, WalletAccount>
                    {
                        [WalletAccountId] = walletAccount
                    },
                    new Dictionary<Guid, LoyaltyAccount>
                    {
                        [LoyaltyAccountId] = loyaltyAccount
                    }));
        }

        public Task<OrderCancellationSnapshot?> LoadSnapshotAsync(
            Guid companyId,
            Guid orderId,
            CancellationToken cancellationToken)
        {
            return Task.FromResult<OrderCancellationSnapshot?>(snapshot);
        }

        public Task ApplyCancellationAsync(OrderCancellationGraph graph, CancellationToken cancellationToken)
        {
            SavedGraph = graph;
            return Task.CompletedTask;
        }
    }
}
