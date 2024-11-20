using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Contracts;

namespace OrderService.Controllers.Orders
{
    public record GetOrderRequest(Guid OrderId) : IRequest<OrderDto>;
    public class GetOrderHandler(OrderDbContext context, IMapper mapper) : IRequestHandler<GetOrderRequest, OrderDto>
    {
        private readonly OrderDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.CustomerDetails)
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderId == request.OrderId, cancellationToken);
            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }
}
