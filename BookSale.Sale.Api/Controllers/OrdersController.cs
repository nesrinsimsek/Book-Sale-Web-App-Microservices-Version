using AutoMapper;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete.Dtos;
using BookSale.Sale.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;


        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<OrderCreateDto>> Add([FromBody] OrderCreateDto orderCreateDto) //bunu dto yap
        {
            Order order = _mapper.Map<Order>(orderCreateDto);
            await _orderService.AddOrder(order);
            return Ok(orderCreateDto);

        }

        [Authorize(Roles = "User")]
        [HttpPut("{orderId}")]
        public async Task<ActionResult<OrderGetDto>> Update(int orderId, [FromBody] OrderUpdateDto orderUpdateDto) //bunu dto yap
        {
            Order order = _mapper.Map<Order>(orderUpdateDto);
            order.Id = orderId;
            await _orderService.UpdateOrder(order);
            OrderGetDto orderGetDto = _mapper.Map<OrderGetDto>(order);
            return Ok(orderGetDto);

        }

        [Authorize(Roles = "User")]
        [HttpDelete("{orderId}")]
        public async Task<ActionResult> Delete(int orderId) //bunu dto yap
        {
            await _orderService.DeleteOrder(orderId);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ById/{orderId}")]
        public async Task<ActionResult<OrderGetDto>> Get(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            var orderGetDto = _mapper.Map<OrderGetDto>(order);
            return Ok(orderGetDto);

        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderGetDto>>> GetListByUser(int userId)
        {
            var orders = await _orderService.GetOrderListByUser(userId);
            var orderGetDtos = _mapper.Map<List<OrderGetDto>>(orders);
            return Ok(orderGetDtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGetDto>>> GetList()
        {
            var orders = await _orderService.GetOrderList();
            var orderGetDtos = _mapper.Map<List<OrderGetDto>>(orders);
            return Ok(orderGetDtos);

        }
    }
}
