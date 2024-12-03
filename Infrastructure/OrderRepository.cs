using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain;


namespace OrderService.Infrastructure
{
    public class OrderRepository(OrderDbContext context) : BaseRepository
    {


        public async Task<List<Order>> GetAllOrders(Specification<Order> specification)
        {
            /*var result = await context.Orders.ToListAsync();*/
            var queryResult = SpecificationEvaluator.Default.GetQuery(
                query: context.Orders.AsQueryable(),
                specification: specification);
            return await queryResult.ToListAsync();
        }
    }
}
