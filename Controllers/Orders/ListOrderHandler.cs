using AutoMapper;
using MediatR;
using OrderService.Contracts;
using OrderService.Data.Specs;
using OrderService.Domain;
using OrderService.Infrastructure;

namespace OrderService.Controllers.Orders
{
    public record ListOrderRequest() : IRequest<List<OrderDto>>;
    public class ListOrderHandler : IRequestHandler<ListOrderRequest, List<OrderDto>>
    {
        private readonly IReadRepository<Order> _repository;
        private readonly IMapper _mapper;

        public ListOrderHandler(IReadRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(ListOrderRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.ListAsync(cancellationToken);
            var spec = new OrderSpec(Guid.NewGuid());
            return _mapper.Map<List<OrderDto>>(result);
        }
    }
}
