using Mansis.Pos.Application.Orders.CancelOrder;
using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[Route("api/v1/app/orders")]
[Tags("App")]
public sealed class AppOrdersController(
    CreateOrderService createOrderService,
    CancelOrderService cancelOrderService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderResponse>> CreateAsync(
        [FromBody] CreateAppOrderRequest request,
        [FromHeader(Name = "Idempotency-Key")] string? idempotencyKey,
        CancellationToken cancellationToken)
    {
        var resolvedIdempotencyKey = string.IsNullOrWhiteSpace(idempotencyKey)
            ? request.IdempotencyKey
            : idempotencyKey;

        var result = await createOrderService.CreateAsync(
            new CreateOrderRequest(
                request.CompanyId,
                request.PosId,
                request.UserId,
                request.CustomerId,
                request.ShippingType,
                request.OrderTime,
                resolvedIdempotencyKey ?? string.Empty,
                request.Lines.Select(line => new CreateOrderLine(
                    line.ProductId,
                    line.Quantity,
                    line.UnitPrice,
                    line.TaxAmount)).ToArray(),
                request.Payments.Select(payment => new CreateOrderPayment(
                    payment.PaymentType,
                    payment.Amount,
                    payment.Currency,
                    payment.ExternalReference)).ToArray()),
            cancellationToken);

        if (!result.IsSuccess || result.Value is null)
        {
            return BadRequest(new ProblemDetails { Status = StatusCodes.Status400BadRequest, Detail = result.Error });
        }

        var response = OrderResponse.From(result.Value);
        return result.Value.Existing
            ? Ok(response)
            : CreatedAtAction(nameof(GetAsync), new { orderId = response.OrderId, companyId = request.CompanyId }, response);
    }

    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAsync(Guid orderId, [FromQuery] Guid companyId)
    {
        return NoContent();
    }

    [HttpPost("{orderId:guid}/cancel")]
    [ProducesResponseType(typeof(CancelOrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public Task<ActionResult<CancelOrderResponse>> CancelAsync(
        Guid orderId,
        [FromBody] ReasonRequest request,
        CancellationToken cancellationToken)
    {
        return CancelOrRefundAsync(orderId, request, cancellationToken);
    }

    [HttpPost("{orderId:guid}/refund")]
    [ProducesResponseType(typeof(CancelOrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public Task<ActionResult<CancelOrderResponse>> RefundAsync(
        Guid orderId,
        [FromBody] ReasonRequest request,
        CancellationToken cancellationToken)
    {
        return CancelOrRefundAsync(orderId, request, cancellationToken);
    }

    private async Task<ActionResult<CancelOrderResponse>> CancelOrRefundAsync(
        Guid orderId,
        ReasonRequest request,
        CancellationToken cancellationToken)
    {
        var result = await cancelOrderService.CancelAsync(
            new CancelOrderRequest(request.CompanyId, orderId, request.UserId, request.Reason),
            cancellationToken);

        if (!result.IsSuccess || result.Value is null)
        {
            return BadRequest(new ProblemDetails { Status = StatusCodes.Status400BadRequest, Detail = result.Error });
        }

        return Ok(CancelOrderResponse.From(result.Value));
    }
}

public sealed record CreateAppOrderRequest(
    Guid CompanyId,
    Guid PosId,
    Guid UserId,
    Guid? CustomerId,
    ShippingType ShippingType,
    DateTimeOffset OrderTime,
    string? IdempotencyKey,
    IReadOnlyList<CreateAppOrderLineRequest> Lines,
    IReadOnlyList<CreateAppOrderPaymentRequest> Payments);

public sealed record CreateAppOrderLineRequest(Guid ProductId, int Quantity, decimal UnitPrice, decimal TaxAmount = 0m);

public sealed record CreateAppOrderPaymentRequest(
    PaymentType PaymentType,
    decimal Amount,
    string Currency = "TRY",
    string? ExternalReference = null);

public sealed record ReasonRequest(Guid CompanyId, Guid UserId, string Reason);

public sealed record OrderResponse(
    Guid OrderId,
    string IdempotencyKey,
    decimal Total,
    PaymentSummary PaymentSummary,
    bool Existing)
{
    public static OrderResponse From(OrderResult result)
    {
        return new OrderResponse(result.OrderId, result.IdempotencyKey, result.Total, result.PaymentSummary, result.Existing);
    }
}

public sealed record CancelOrderResponse(Guid OrderId, OrderState OrderState, bool Existing)
{
    public static CancelOrderResponse From(CancelOrderResult result)
    {
        return new CancelOrderResponse(result.OrderId, result.OrderState, result.Existing);
    }
}
