using Microsoft.EntityFrameworkCore;

namespace OrderService.Domain
{
    public class OrderItem
    {
        public string Name { get; set; } = default!;
        [Precision(10, 2)]
        public decimal Price { get; set; }

        private OrderItem() { }

        public OrderItem(string name, decimal price)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
            Price = price;
        }
    }
}
