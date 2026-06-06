namespace Mansis.Pos.Workers;

public sealed class WorkerHeartbeat(ILogger<WorkerHeartbeat> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Mansis POS worker host started.");

        await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
    }
}
