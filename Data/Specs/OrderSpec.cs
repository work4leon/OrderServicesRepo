using Ardalis.Specification;
using OrderService.Domain;

namespace OrderService.Data.Specs
{
    public class OrderSpec : Specification<Order>
    {
        public OrderSpec(Guid orderId)
        {
            Query.Include(x => x.Customer);
            Query.Include(x => x.Items);
            Query.Where(o => o.Id == orderId);
        }

        public OrderSpec()
        {
            Query.Include(x => x.Customer);
            Query.Include(x => x.Items);
        }
    }
}
