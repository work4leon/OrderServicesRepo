using AutoMapper;
using Microsoft.OpenApi.Extensions;
using OrderService.Contracts;
using OrderService.Domain;

namespace OrderService.Controllers.Orders
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.Customer, opt => opt.MapFrom(x => x.Customer))
                .ForMember(x => x.Items, opt => opt.MapFrom(x => x.Items))

                .ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>()
                 .ForMember(x => x.CustomerDetail, opt => opt.MapFrom(x => x.CustomerDetail))
                 .ForMember(x => x.CustomerTypeName, opt => opt.MapFrom(x => x.Type.GetDisplayName()));
            CreateMap<CustomerDetail, CustomerDetailDto>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email));

            CreateMap<AddressInfoDto, AddressInfo>().ReverseMap();
            CreateMap<CustomerCreateDto, Customer>();

        }
    }
}
