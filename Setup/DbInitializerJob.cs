using OrderService.Infrastructure;

namespace OrderService.Setup;

internal class DbInitializerJob(

    IServiceProvider serviceProvider) : IHostedService
{

    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetRequiredService<OrderDbInitializer>();
            await dbInitializer.SeedsAsync(cancellationToken);
        }

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
