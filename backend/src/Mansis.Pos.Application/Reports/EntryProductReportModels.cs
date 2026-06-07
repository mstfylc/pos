namespace Mansis.Pos.Application.Reports;

public sealed record EntryProductDeliveryReportFilter(
    Guid CompanyId,
    DateTimeOffset From,
    DateTimeOffset To,
    Guid? BranchId,
    Guid? PosId,
    Guid? ProductId);

public sealed record EntryProductDeliveryReportRow(
    DateOnly Date,
    Guid BranchId,
    string BranchName,
    Guid PosId,
    string PosName,
    Guid ProductId,
    string ProductName,
    int Quantity);
