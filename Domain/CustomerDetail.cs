namespace OrderService.Domain
{
    public class CustomerDetail
    {
        public string Email { get; set; } = default!;
        public List<AddressInfo> Addresses { get; set; } = [];
    }
}
