﻿using AutoMapper;
using MediatR;
using OrderService.Contracts;
using OrderService.Domain;

namespace OrderService.Controllers.Orders
{
    public record OrderRequest(OrderCreateDto CreateDto) : IRequest<OrderDto>;
    public class CreateOrderHandler(OrderDbContext context, IMapper mapper) : IRequestHandler<OrderRequest, OrderDto>
    {
        public async Task<OrderDto> Handle(OrderRequest request, CancellationToken cancellationToken)
        {
            var createDto = request.CreateDto;
            var customer = mapper.Map<Customer>(createDto.Customer);
            var customerDetails = mapper.Map<CustomerDetail>(createDto.CustomerDetails);
            var orderItems = mapper.Map<List<OrderItem>>(createDto.Items);

            var orderNo = context.Orders.Count();

            var order = new Order(customer, orderItems);
            order.AddOrderNo(++orderNo);

            context.Orders.Add(order);
            await context.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<OrderDto>(order);
            return result;
        }
    }
}
