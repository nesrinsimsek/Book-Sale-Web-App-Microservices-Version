using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderBusiness.Abstract;
using OrderEntity.Dtos;
using OrderEntity.Entities;
using OrderEntity.Models;
using System.Net;

namespace OrderApi.Controllers
{
    [Route("api/orderbooks")]
    [ApiController]
    public class OrderBookApiController : ControllerBase
    {
        private readonly IOrderBookManager _orderBookManager;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public OrderBookApiController(IOrderBookManager orderBookManager, IMapper mapper)
        {
            _orderBookManager = orderBookManager;
            _mapper = mapper;
            _response = new();
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] OrderBookDto orderBookDto) //bunu dto yap
        {
            OrderBook orderBook = _mapper.Map<OrderBook>(orderBookDto);

            await _orderBookManager.AddOrderBook(orderBook);
            _response.Data = _mapper.Map<OrderBookDto>(orderBook);
            _response.StatusCode = HttpStatusCode.Created;
            return _response;

        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {

            var orderBooks = await _orderBookManager.GetOrderBookList();
            var orderBookDtos = _mapper.Map<List<OrderBookDto>>(orderBooks);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = orderBookDtos;
            return Ok(_response);

        }
    }
}
