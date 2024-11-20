namespace OrderService.Contracts
{
    public class CustomerCreateDto
    {
        public int Type { get; set; }
        public required string FirstName { get; set; } = default!;
        public required string LastName { get; set; } = default!;


    }
}