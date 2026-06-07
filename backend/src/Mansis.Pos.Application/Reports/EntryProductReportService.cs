namespace Mansis.Pos.Application.Reports;

public sealed class EntryProductReportService(IEntryProductReportStore store)
{
    public Task<IReadOnlyList<EntryProductDeliveryReportRow>> ListEntryProductDeliveriesAsync(
        EntryProductDeliveryReportFilter filter,
        CancellationToken cancellationToken) =>
        store.ListEntryProductDeliveriesAsync(filter, cancellationToken);
}
