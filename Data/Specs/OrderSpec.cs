using Ardalis.Specification;
using OrderService.Domain;

namespace OrderService.Data.Specs
{
    public class OrderSpec : Specification<Order>
    {
        public OrderSpec(Guid orderId)
        {
            Query.Where(o => o.Id == orderId);
        }
    }
}
