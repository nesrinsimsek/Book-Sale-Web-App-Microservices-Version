using AutoMapper;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete.Dtos;
using BookSale.Sale.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BookSale.Sale.Entities.Concrete.Models;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
            _response = new();
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] OrderCreateDto orderCreateDto) //bunu dto yap
        {
            Order order = _mapper.Map<Order>(orderCreateDto);

            await _orderService.AddOrder(order);
            _response.Data = _mapper.Map<OrderDto>(order);
            _response.StatusCode = HttpStatusCode.Created;

            return _response;

        }

     
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {
            var orders = await _orderService.GetOrderList();
            var orderDtos = _mapper.Map<List<OrderDto>>(orders);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = orderDtos;
            return Ok(_response);

        }
        [HttpGet("ById/{orderId}")]
        public async Task<ActionResult<ApiResponse>> Get(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = orderDto;
            return Ok(_response);

        }
    }
}
