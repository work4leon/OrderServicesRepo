namespace OrderService.Domain
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int OrderNo { get; set; } = default!;
        public Customer Customer = default!;
        public CustomerDetail CustomerDetails = default!;
        public List<OrderItem> Items = [];
        public decimal Total { get; set; }

        private Order() { }

        public Order(Customer customer, CustomerDetail details, List<OrderItem> items)
        {
            Customer = customer;
            CustomerDetails = details;
            Items = items;
            Total = items.Sum(i => i.Price);
        }
        public void AddOrderNo(int orderNo)
        {
            OrderNo = orderNo;
        }
    }
}
