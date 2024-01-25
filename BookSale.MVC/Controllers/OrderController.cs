using AutoMapper;
using Azure;
using BookSale.MVC.Helpers;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IOrderService = BookSale.MVC.Services.Abstract.IOrderService;
using IOrderBookService = BookSale.MVC.Services.Abstract.IOrderBookService;

namespace BookSale.MVC.Controllers
{
    public class OrderController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IOrderService _orderService;
        private IOrderBookService _orderBookService;
        private IMapper _mapper;

        public OrderController(ICartService cartService, ICartSessionHelper cartSessionHelper, IOrderService orderService, IOrderBookService orderBookService, IMapper mapper)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _orderService = orderService;
            _orderBookService = orderBookService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var orderViewModel = new OrderViewModel
            {
                Cart = _cartSessionHelper.GetCart("Cart"),
                OrderCreateDto = new OrderCreateDto(),
                OrderBookList = new List<OrderBookDto>()
            };

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
        {
            var cartLines = _cartSessionHelper.GetCart("Cart").CartLines;
            await _orderService.CreateAsync<ApiResponse>(orderCreateDto);
            var orderListResponse = await _orderService.GetAllAsync<ApiResponse>();
            var orderList = JsonConvert.DeserializeObject<List<OrderDto>>(Convert.ToString(orderListResponse.Data));
            var createdOrder = orderList.LastOrDefault();

            foreach(var cartLine in cartLines)
            {
                OrderBookDto orderBookDto = new OrderBookDto
                {
                    Order_Id = createdOrder.Id,
                    Book_Id = cartLine.Book.Id,
                    Quantity = cartLine.Quantity

                };
                _orderBookService.CreateAsync<ApiResponse>(orderBookDto);
            }

            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
