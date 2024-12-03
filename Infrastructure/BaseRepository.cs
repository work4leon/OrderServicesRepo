using Ardalis.Specification;
using OrderService.Domain;

namespace OrderService.Infrastructure
{
    public interface BaseRepository
    {

        Task<List<Order>> GetAllOrders(Specification<Order> specification);
    }
}
