namespace OrderService.Contracts
{
    public class AddressInfoDto
    {
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
}