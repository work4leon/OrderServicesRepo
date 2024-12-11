namespace OrderService.Contracts
{
    public class CustomerDetailDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<AddressInfoDto> Addresses { get; set; } = [];
        public string Email { get; set; } = default!;
    }
}