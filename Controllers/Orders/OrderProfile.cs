using AutoMapper;
using OrderService.Contracts;
using OrderService.Domain;

namespace OrderService.Controllers.Orders
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<CustomerDetailDto, CustomerDetail>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<AddressInfoDto, AddressInfo>().ReverseMap();
            CreateMap<CustomerCreateDto, Customer>();

        }
    }
}
