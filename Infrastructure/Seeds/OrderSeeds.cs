using OrderService.Domain;

namespace OrderService.Infrastructure.Seeds
{
    public class OrderSeeds
    {
        public static List<Order> GetOrders()
        {

            var shampooItem = new OrderItem("shampoo", 10);
            var soapItem = new OrderItem("soap", 5);

            var customerDetail = new CustomerDetail
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "test@email.com"
            };


            var customer = new Customer(1, "Leon", "Weiss");
            var customerAddresses1 = new AddressInfo("street1", "city1", "postcode1", "Israel1", true);
            var customerAddresses2 = new AddressInfo("street2", "city2", "postcode2", "Israel2", false);

            var customerAddresses = new List<AddressInfo>()
            {
                customerAddresses1, customerAddresses2
            };


            customerDetail.Addresses = customerAddresses;
            customer.CustomerDetail = customerDetail;
            // Additional code to return a list of orders
            var orders = new List<Order>
            {
                new(customer, [shampooItem,soapItem])
            };

            return orders;
        }
    }
}

