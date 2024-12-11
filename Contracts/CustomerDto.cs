namespace OrderService.Contracts
{
    public class CustomerDto
    {
        public CustomerDetailDto CustomerDetail { get; set; } = default!;
        public int Type { get; set; } = default!;
        public string CustomerTypeName { get; set; } = default!;
    }
}