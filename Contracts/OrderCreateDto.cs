namespace OrderService.Contracts
{
    public class OrderCreateDto
    {

        public CustomerCreateDto Customer { get; set; } = default!;
        public CustomerDetailDto CustomerDetails { get; set; } = default!;
        public List<OrderItemDto> Items { get; set; } = [];
    }
}
