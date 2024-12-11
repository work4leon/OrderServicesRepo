namespace OrderService.Domain
{
    public class CustomerDetail
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public List<AddressInfo> Addresses { get; set; } = [];
    }
}
