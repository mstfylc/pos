using Mansis.Pos.Application.Abstractions.Data;
using Mansis.Pos.Application.Abstractions.Tenancy;
using Mansis.Pos.Application.Auth;
using Mansis.Pos.Application.Core;
using Mansis.Pos.Application.Loyalty.RedeemReward;
using Mansis.Pos.Application.Pos;
using Mansis.Pos.Application.Reports;
using Mansis.Pos.Application.Stock;
using Mansis.Pos.Infrastructure.Auth;
using Mansis.Pos.Application.Orders.CancelOrder;
using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Infrastructure.Persistence;
using Mansis.Pos.Infrastructure.Persistence.Repositories;
using Mansis.Pos.Infrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

        services.TryAddScoped<ITenantContext, EnvironmentTenantContext>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IAuthStore, EfAuthStore>();
        services.AddScoped<IPasswordHasher, Argon2idPasswordHasher>();
        services.AddScoped<IPasswordVerifier>(provider => provider.GetRequiredService<IPasswordHasher>());
        services.AddScoped<ICoreCrudStore, EfCoreCrudStore>();
        services.AddScoped<IRewardRedemptionStore, EfRewardRedemptionStore>();
        services.AddScoped<IOrderCancellationStore, EfOrderCancellationStore>();
        services.AddScoped<IOrderCreationStore, EfOrderCreationStore>();
        services.AddScoped<IPosStore, EfPosStore>();
        services.AddScoped<IEntryProductReportStore, EfEntryProductReportStore>();
        services.AddScoped<IStockStore, EfStockStore>();
        services.AddHostedService<DbBootstrapHostedService>();

        return services;
    }
}
