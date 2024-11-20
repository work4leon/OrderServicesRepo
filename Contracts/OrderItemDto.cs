namespace OrderService.Contracts
{
    public class OrderItemDto
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
    }
}