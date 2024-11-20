using OrderService.Domain;

namespace OrderService.Contracts
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public CustomerType CustomerType { get; set; } = default!;
        public string CustomerTypeName { get; set; } = default!;
    }
}