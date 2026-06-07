using Mansis.Pos.Application.Abstractions.Data;
using Mansis.Pos.Application.Abstractions.Tenancy;
using Mansis.Pos.Application.Orders.CancelOrder;
using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Infrastructure.Persistence;
using Mansis.Pos.Infrastructure.Persistence.Repositories;
using Mansis.Pos.Infrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mansis.Pos.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
            ?? configuration.GetConnectionString("Default");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("DB_CONNECTION_STRING environment variable is required.");
        }

        services.AddDbContext<PosDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ITenantContext, EnvironmentTenantContext>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IOrderCancellationStore, EfOrderCancellationStore>();
        services.AddScoped<IOrderCreationStore, EfOrderCreationStore>();

        return services;
    }
}
