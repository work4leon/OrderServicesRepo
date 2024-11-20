namespace OrderService.Domain
{
    public class Customer
    {
        public CustomerType Type { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        private Customer() { }
        public Customer(int type, string firstName, string lastName)
        {
            ArgumentException.ThrowIfNullOrEmpty(firstName);
            ArgumentException.ThrowIfNullOrEmpty(lastName);
            Type = (CustomerType)type;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public enum CustomerType
    {
        Standart,
        Premium,
        Vip
    }
}
