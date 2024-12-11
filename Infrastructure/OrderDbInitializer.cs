using OrderService.Infrastructure.Seeds;

namespace OrderService.Infrastructure;

internal class OrderDbInitializer
{
    private readonly OrderDbContext _dbContext;
    public OrderDbInitializer(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task SeedsAsync(CancellationToken cancellationToken)
    {
        if (!_dbContext.Orders.Any())
        {
            var orders = OrderSeeds.GetOrders();
            _dbContext.Orders.AddRange(orders);
            await _dbContext.SaveChangesAsync();
        }
    }
}

