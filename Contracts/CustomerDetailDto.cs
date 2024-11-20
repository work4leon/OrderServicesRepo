namespace OrderService.Contracts
{
    public class CustomerDetailDto
    {
        public List<AddressInfoDto> Adresses { get; set; } = [];
        public string Email { get; set; } = default!;
    }
}