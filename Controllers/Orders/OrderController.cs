using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Contracts;
using OrderService.Domain;

namespace OrderService.Controllers.Orders
{
    [ApiController]
    [Route("api/orders/")]
    public class OrderController : ControllerBase
    {
        private OrderDbContext Context { get; set; }
        private IMapper _mapper;
        private readonly IMediator _mediator;


        public OrderController(IMapper mapper, IMediator mediator, OrderDbContext context)
        {
            _mapper = mapper;
            Context = context;
            _mediator = mediator;
        }
        [HttpGet("api/order/get")]
        public async Task<ActionResult<List<Order>>> List(Guid OrderId)
          => Ok(await _mediator.Send(new ListOrderRequest()));

        [HttpGet("api/order/{OrderId}get")]
        public async Task<ActionResult<Order>> Get(Guid OrderId)
           => Ok(await _mediator.Send(new GetOrderRequest(OrderId)));

        [HttpPost("api/order/create")]
        public async Task<ActionResult<OrderDto>> Create(OrderCreateDto createDto, CancellationToken cancellationToken)
          => Ok(await _mediator.Send(new OrderRequest(createDto), cancellationToken));

        [HttpPut("api/order/{OderId}update")]
        public async Task<ActionResult<OrderDto>> Update(Guid OderId, UpdateOrderDto updateDto)
         => Ok(await _mediator.Send(new OrderUpdateRequest(OderId, updateDto)));
    }
}
