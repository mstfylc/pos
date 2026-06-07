using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Orders.CreateOrder;

public sealed record CreateOrderRequest(
    Guid CompanyId,
    Guid PosId,
    Guid UserId,
    Guid? CustomerId,
    ShippingType ShippingType,
    DateTimeOffset OrderTime,
    string IdempotencyKey,
    IReadOnlyList<CreateOrderLine> Lines,
    IReadOnlyList<CreateOrderPayment> Payments);

public sealed record CreateOrderLine(Guid ProductId, int Quantity, decimal UnitPrice, decimal TaxAmount = 0m);

public sealed record CreateOrderPayment(PaymentType PaymentType, decimal Amount, string Currency = "TRY", string? ExternalReference = null);

public sealed record OrderResult(Guid OrderId, string IdempotencyKey, decimal Total, PaymentSummary PaymentSummary, bool Existing);
