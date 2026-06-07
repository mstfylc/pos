using Mansis.Pos.Application.Pos;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[Route("api/v1/app")]
[Tags("App")]
public sealed class AppPosController(PosService posService) : ControllerBase
{
    [HttpGet("pos/{posId:guid}/products")]
    [ProducesResponseType(typeof(PosProductCatalogResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PosProductCatalogResponse>> GetPosProductsAsync(
        Guid posId,
        [FromQuery] Guid companyId,
        CancellationToken cancellationToken)
    {
        var result = await posService.GetCatalogAsync(companyId, posId, cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("customers/{customerId:guid}/card-token")]
    [ProducesResponseType(typeof(CustomerCardTokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerCardTokenResponse>> IssueCustomerCardTokenAsync(
        Guid customerId,
        [FromBody] IssueCustomerCardTokenApiRequest request,
        CancellationToken cancellationToken)
    {
        var result = await posService.IssueCustomerCardTokenAsync(
            new IssueCustomerCardTokenRequest(request.CompanyId, customerId, request.ExpiresInSeconds),
            cancellationToken);
        return ToActionResult(result);
    }

    [HttpPost("customers/identify")]
    [ProducesResponseType(typeof(IdentifiedCustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IdentifiedCustomerDto>> IdentifyCustomerAsync(
        [FromBody] IdentifyCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var result = await posService.IdentifyCustomerAsync(request, cancellationToken);
        return ToActionResult(result);
    }

    [HttpPost("loyalty/preview")]
    [ProducesResponseType(typeof(LoyaltyPreviewResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoyaltyPreviewResponse>> PreviewLoyaltyAsync(
        [FromBody] LoyaltyPreviewRequest request,
        CancellationToken cancellationToken)
    {
        var result = await posService.PreviewLoyaltyAsync(request, cancellationToken);
        return ToActionResult(result);
    }

    private ActionResult<T> ToActionResult<T>(Mansis.Pos.Application.Common.Result<T> result)
    {
        return !result.IsSuccess || result.Value is null
            ? BadRequest(new ProblemDetails { Status = StatusCodes.Status400BadRequest, Detail = result.Error })
            : Ok(result.Value);
    }
}

public sealed record IssueCustomerCardTokenApiRequest(Guid CompanyId, int ExpiresInSeconds = 300);
