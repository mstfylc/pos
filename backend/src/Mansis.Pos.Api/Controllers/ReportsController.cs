using Mansis.Pos.Application.Reports;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[Route("api/v1/reports")]
[Tags("Reports")]
public sealed class ReportsController(EntryProductReportService entryProductReportService) : ControllerBase
{
    [HttpGet("entry-products")]
    public Task<IReadOnlyList<EntryProductDeliveryReportRow>> ListEntryProductDeliveriesAsync(
        [FromQuery] Guid companyId,
        [FromQuery] DateTimeOffset from,
        [FromQuery] DateTimeOffset to,
        [FromQuery] Guid? branchId,
        [FromQuery] Guid? posId,
        [FromQuery] Guid? productId,
        CancellationToken cancellationToken) =>
        entryProductReportService.ListEntryProductDeliveriesAsync(
            new EntryProductDeliveryReportFilter(
                companyId,
                from.ToUniversalTime(),
                to.ToUniversalTime(),
                branchId,
                posId,
                productId),
            cancellationToken);
}
