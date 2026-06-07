using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Orders.CancelOrder;

public sealed record CancelOrderRequest(Guid CompanyId, Guid OrderId, Guid UserId, string Reason);

public sealed record CancelOrderResult(Guid OrderId, OrderState OrderState, bool Existing);
