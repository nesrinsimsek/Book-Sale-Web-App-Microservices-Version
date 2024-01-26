using AutoMapper;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using BookSale.Sale.Entities.Concrete.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBooksController : ControllerBase
    {
        private readonly IOrderBookService _orderBookService;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public OrderBooksController(IOrderBookService orderBookService, IMapper mapper)
        {
            _orderBookService = orderBookService;
            _mapper = mapper;
            _response = new();
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] OrderBookDto orderBookDto) //bunu dto yap
        {
            OrderBook orderBook = _mapper.Map<OrderBook>(orderBookDto);

            await _orderBookService.AddOrderBook(orderBook);
            _response.Data = _mapper.Map<OrderBookDto>(orderBook);
            _response.StatusCode = HttpStatusCode.Created;
            return _response;

        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {

            var orderBooks = await _orderBookService.GetOrderBookList();
            var orderBookDtos = _mapper.Map<List<OrderBookDto>>(orderBooks);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = orderBookDtos;
            return Ok(_response);

        }

    }
}
