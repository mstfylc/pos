using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mansis.Pos.Infrastructure.Persistence;

public sealed class DesignTimePosDbContextFactory : IDesignTimeDbContextFactory<PosDbContext>
{
    public PosDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
            ?? "Host=localhost;Port=5432;Database=pos;Username=pos_app;Password=change-me";

        var options = new DbContextOptionsBuilder<PosDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new PosDbContext(options, new DesignTimeTenantContext());
    }
}
