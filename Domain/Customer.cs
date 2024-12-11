namespace OrderService.Domain
{
    public class Customer
    {
        public CustomerType Type { get; set; }
        public CustomerDetail CustomerDetail { get; set; } = new();
        private Customer() { }
        public Customer(int type, string firstName, string lastName)
        {
            ArgumentException.ThrowIfNullOrEmpty(firstName);
            ArgumentException.ThrowIfNullOrEmpty(lastName);
            Type = (CustomerType)type;
            CustomerDetail.FirstName = firstName;
            CustomerDetail.LastName = lastName;
        }
    }

    public enum CustomerType
    {
        Regular,
        Premium,
        Vip
    }
}
