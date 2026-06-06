using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Persistence;

public sealed class PosDbContext(DbContextOptions<PosDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pos");

        base.OnModelCreating(modelBuilder);
    }
}
