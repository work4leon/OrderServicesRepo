namespace OrderService.Domain
{
    public class AddressInfo
    {
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Country { get; set; } = default!;
        public bool IsPrimary { get; set; } = false;

        public AddressInfo(string streetName, string city, string postcode, string country, bool primary)
        {
            ArgumentException.ThrowIfNullOrEmpty(streetName);
            ArgumentException.ThrowIfNullOrEmpty(city);
            ArgumentException.ThrowIfNullOrEmpty(postcode);
            StreetName = streetName;
            City = city;
            PostalCode = postcode;
            Country = country;
            IsPrimary = primary;
        }
        private AddressInfo() { }
    }


}
