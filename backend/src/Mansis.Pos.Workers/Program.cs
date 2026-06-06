using Hangfire;
using Hangfire.PostgreSql;
using Mansis.Pos.Application;
using Mansis.Pos.Infrastructure;
using Mansis.Pos.Workers;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog((services, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var hangfireConnectionString = Environment.GetEnvironmentVariable("HANGFIRE_CONNECTION_STRING")
    ?? builder.Configuration.GetConnectionString("Hangfire")
    ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? builder.Configuration.GetConnectionString("Default");

if (string.IsNullOrWhiteSpace(hangfireConnectionString))
{
    throw new InvalidOperationException("HANGFIRE_CONNECTION_STRING or DB_CONNECTION_STRING environment variable is required.");
}

builder.Services.AddHangfire(configuration =>
    configuration.UsePostgreSqlStorage(options =>
        options.UseNpgsqlConnection(hangfireConnectionString)));

builder.Services.AddHangfireServer();
builder.Services.AddHostedService<WorkerHeartbeat>();

var host = builder.Build();
host.Run();
