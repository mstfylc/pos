using Mansis.Pos.Application.Common;
using Mansis.Pos.Application.Stock;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[Route("api/v1/stock")]
[Tags("Stock")]
public sealed class StockController(StockService stockService) : ControllerBase
{
    [HttpGet("movements")]
    public Task<Mansis.Pos.Application.Core.PagedResult<StockMovementDto>> ListMovementsAsync(
        [FromQuery] Guid companyId,
        [FromQuery] Guid? storeId,
        [FromQuery] Guid? productId,
        [FromQuery] StoreProductMovementType? movementType,
        [FromQuery] DateTimeOffset? from,
        [FromQuery] DateTimeOffset? to,
        CancellationToken cancellationToken,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 50,
        [FromQuery] string? sort = null,
        [FromQuery] string? filter = null) =>
        stockService.ListMovementsAsync(new StockMovementFilter(companyId, storeId, productId, movementType, from, to, page, pageSize, sort, filter), cancellationToken);

    [HttpPost("stock-in")]
    public async Task<ActionResult<StockMovementDto>> StockInAsync([FromBody] StockAdjustmentRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.StockInAsync(request, cancellationToken));

    [HttpPost("stock-out")]
    public async Task<ActionResult<StockMovementDto>> StockOutAsync([FromBody] StockAdjustmentRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.StockOutAsync(request, cancellationToken));

    [HttpPost("destroy")]
    public async Task<ActionResult<StockMovementDto>> DestroyAsync([FromBody] DestroyStockRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.DestroyAsync(request, cancellationToken));

    [HttpPost("count")]
    public async Task<ActionResult<StockMovementDto>> CountAsync([FromBody] StockCountRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.CountAsync(request, cancellationToken));

    [HttpPost("transfers")]
    public async Task<ActionResult<StoreProductTransferDto>> CreateTransferAsync([FromBody] CreateTransferRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.CreateTransferAsync(request, cancellationToken));

    [HttpPost("transfers/{id:guid}/confirm")]
    public async Task<ActionResult<StoreProductTransferDto>> ConfirmTransferAsync(Guid id, [FromBody] ConfirmTransferRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.ConfirmTransferAsync(id, request, cancellationToken));

    [HttpPost("transfers/{id:guid}/receive")]
    public async Task<ActionResult<StoreProductTransferDto>> ReceiveTransferAsync(Guid id, [FromBody] ReceiveTransferRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.ReceiveTransferAsync(id, request, cancellationToken));

    [HttpPost("transfers/{id:guid}/cancel")]
    public async Task<ActionResult<StoreProductTransferDto>> CancelTransferAsync(Guid id, [FromBody] CancelTransferRequest request, CancellationToken cancellationToken) =>
        ToActionResult(await stockService.CancelTransferAsync(id, request, cancellationToken));

    private ActionResult<T> ToActionResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(new ProblemDetails { Title = "Request validation failed.", Detail = result.Error });
    }
}
