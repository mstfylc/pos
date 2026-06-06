using Mansis.Pos.Application.Abstractions.Data;

namespace Mansis.Pos.Infrastructure.Persistence.Repositories;

internal sealed class EfUnitOfWork(PosDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}
