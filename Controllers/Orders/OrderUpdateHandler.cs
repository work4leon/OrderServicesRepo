using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Contracts;
using OrderService.Domain;

namespace OrderService.Controllers.Orders
{
    public record OrderUpdateRequest(Guid OrderId, UpdateOrderDto UpdateDto) : IRequest<OrderDto>;


    public class OrderUpdateHandler(OrderDbContext context, IMapper mapper) : IRequestHandler<OrderUpdateRequest, OrderDto>
    {
        private readonly OrderDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderDto> Handle(OrderUpdateRequest request, CancellationToken cancellationToken)
        {
            var dto = request.UpdateDto;
            var orderId = request.OrderId;
            var addresses = dto.Addresses;

            var order = _context.Orders
                .Include(o => o.CustomerDetails)
                .FirstOrDefault(o => o.Id == orderId);

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
