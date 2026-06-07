using Mansis.Pos.Application.Reports;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfEntryProductReportStore(PosDbContext dbContext) : IEntryProductReportStore
{
    public async Task<IReadOnlyList<EntryProductDeliveryReportRow>> ListEntryProductDeliveriesAsync(
        EntryProductDeliveryReportFilter filter,
        CancellationToken cancellationToken)
    {
        var query = dbContext.OrderProducts
            .AsNoTracking()
            .Where(line => line.IsEntry)
            .Where(line => line.Order != null && line.Order.CompanyId == filter.CompanyId)
            .Where(line => line.Order!.OrderTime >= filter.From && line.Order.OrderTime <= filter.To);

        if (filter.PosId.HasValue)
        {
            query = query.Where(line => line.Order!.PosId == filter.PosId.Value);
        }

        if (filter.ProductId.HasValue)
        {
            query = query.Where(line => line.ProductId == filter.ProductId.Value);
        }

        if (filter.BranchId.HasValue)
        {
            query = query.Where(line => line.Order!.Pos != null && line.Order.Pos.BranchId == filter.BranchId.Value);
        }

        var rows = await query
            .Select(line => new
            {
                line.Quantity,
                line.ProductId,
                ProductName = line.Product != null ? line.Product.Name : string.Empty,
                OrderTime = line.Order!.OrderTime,
                PosId = line.Order.PosId,
                PosName = line.Order.Pos != null ? line.Order.Pos.Name : string.Empty,
                BranchId = line.Order.Pos != null ? line.Order.Pos.BranchId : Guid.Empty,
                BranchName = line.Order.Pos != null && line.Order.Pos.Branch != null ? line.Order.Pos.Branch.Name : string.Empty
            })
            .ToListAsync(cancellationToken);

        return rows
            .GroupBy(row => new
            {
                Date = DateOnly.FromDateTime(row.OrderTime.UtcDateTime),
                row.BranchId,
                row.BranchName,
                row.PosId,
                row.PosName,
                row.ProductId,
                row.ProductName
            })
            .OrderBy(group => group.Key.Date)
            .ThenBy(group => group.Key.BranchName)
            .ThenBy(group => group.Key.PosName)
            .ThenBy(group => group.Key.ProductName)
            .Select(group => new EntryProductDeliveryReportRow(
                group.Key.Date,
                group.Key.BranchId,
                group.Key.BranchName,
                group.Key.PosId,
                group.Key.PosName,
                group.Key.ProductId,
                group.Key.ProductName,
                group.Sum(row => row.Quantity)))
            .ToArray();
    }
}
