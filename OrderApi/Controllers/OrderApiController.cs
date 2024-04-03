using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderBusiness.Abstract;
using OrderEntity.Dtos;
using OrderEntity.Entities;
using OrderEntity.Models;
using System.Net;

namespace OrderApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public OrderApiController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
            _response = new();
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] OrderCreateDto orderCreateDto) //bunu dto yap
        {
            Order order = _mapper.Map<Order>(orderCreateDto);

            await _orderManager.AddOrder(order);
            _response.Data = _mapper.Map<OrderDto>(order);
            _response.StatusCode = HttpStatusCode.Created;

            return _response;

        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {
            var orders = await _orderManager.GetOrderList();
            var orderDtos = _mapper.Map<List<OrderDto>>(orders);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = orderDtos;
            return Ok(_response);

        }

        [HttpGet("ById/{orderId}")]
        public async Task<ActionResult<ApiResponse>> Get(int orderId)
        {
            var order = await _orderManager.GetOrderById(orderId);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = orderDto;
            return Ok(_response);

        }
    }
}
