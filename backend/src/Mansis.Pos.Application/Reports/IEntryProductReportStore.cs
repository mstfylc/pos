namespace Mansis.Pos.Application.Reports;

public interface IEntryProductReportStore
{
    Task<IReadOnlyList<EntryProductDeliveryReportRow>> ListEntryProductDeliveriesAsync(
        EntryProductDeliveryReportFilter filter,
        CancellationToken cancellationToken);
}
