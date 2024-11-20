namespace OrderService.Domain
{
    public class AddressInfo
    {
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Country { get; set; } = default!;

        public AddressInfo(string streetName, string city, string postcode, string country)
        {
            ArgumentException.ThrowIfNullOrEmpty(streetName);
            ArgumentException.ThrowIfNullOrEmpty(city);
            ArgumentException.ThrowIfNullOrEmpty(postcode);
            StreetName = streetName;
            City = city;
            PostalCode = postcode;
            Country = country;
        }
        private AddressInfo() { }
    }


}
