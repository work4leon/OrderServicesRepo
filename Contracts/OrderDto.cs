namespace OrderService.Contracts
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public CustomerDto Customer { get; set; } = default!;
        public CustomerDetailDto CustomerDetails { get; set; } = default!;
        public List<OrderItemDto> Items { get; set; } = [];
    }
}
