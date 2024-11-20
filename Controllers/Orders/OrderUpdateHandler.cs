using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Contracts;
using OrderService.Domain;

namespace OrderService.Controllers.Orders
{
    public record OrderUpdateRequest(Guid OrderId, UpdateOrderDto UpdateDto) : IRequest<OrderDto>;


    public class OrderUpdateHandler : IRequestHandler<OrderUpdateRequest, OrderDto>
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public OrderUpdateHandler(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(OrderUpdateRequest request, CancellationToken cancellationToken)
        {
            var dto = request.UpdateDto;
            var orderId = request.OrderId;
            var addresses = dto.Addresses;

            var order = _context.Orders
                .Include(o => o.CustomerDetails)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order is not null)
            {
                var d = addresses.Select(a => _mapper.Map<AddressInfo>(a)).ToList();
                order.CustomerDetails.Addresses.Clear();
                order.CustomerDetails.Addresses.AddRange(d);
                _context.Update(order);
                await _context.SaveChangesAsync(cancellationToken);
            }
            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }


}
