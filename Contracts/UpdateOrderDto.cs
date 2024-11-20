namespace OrderService.Contracts
{
    public class UpdateOrderDto
    {
        public List<AddressInfoDto> Addresses { get; set; } = [];
    }
}