using AutoMapper;
using MediatR;
using OrderService.Contracts;
using OrderService.Data.Specs;
using OrderService.Infrastructure;

namespace OrderService.Controllers.Orders
{
    public record GetOrderRequest(Guid OrderId) : IRequest<OrderDto>;
    public class GetOrderHandler(OrderRepository repository, IMapper mapper) : IRequestHandler<GetOrderRequest, OrderDto>
    {

        private readonly IMapper _mapper = mapper;

        public async Task<OrderDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            /* var order = await _context.Orders
                 .Include(o => o.CustomerDetails)
                 .Include(o => o.Items)
                 .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
             var result = _mapper.Map<OrderDto>(order);
             return result;*/

            var result = await repository.GetAllOrders(new OrderSpec(request.OrderId));
            return _mapper.Map<OrderDto>(result);
        }
    }
}
