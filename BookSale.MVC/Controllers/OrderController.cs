using BookSale.MVC.Helpers;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.Sale.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IOrderService = BookSale.MVC.Services.Abstract.IOrderService;
using IOrderBookService = BookSale.MVC.Services.Abstract.IOrderBookService;
using IBookService = BookSale.MVC.Services.Abstract.IBookService;

namespace BookSale.MVC.Controllers
{
    public class OrderController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IOrderService _orderService;
        private IOrderBookService _orderBookService;
        private IAuthService _authService;
        private IBookService _bookService;

        public OrderController(ICartService cartService, ICartSessionHelper cartSessionHelper,
                                IOrderService orderService, IOrderBookService orderBookService,
                                IAuthService authService, IBookService bookService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _orderService = orderService;
            _orderBookService = orderBookService;
            _authService = authService;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var orderViewModel = new OrderViewModel
            {
                Cart = _cartSessionHelper.GetCart("Cart"),
                OrderCreateDto = new OrderCreateDto()
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

            foreach (var cartLine in cartLines)
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
            var orderBookListResponse = await _orderBookService.GetAllAsync<ApiResponse>();
            var orderBookList = JsonConvert.DeserializeObject<List<OrderBookDto>>(Convert.ToString(orderBookListResponse.Data));
            List<OrderListViewModel> orderListViewModelList = new List<OrderListViewModel>();

            foreach (var orderBook in orderBookList)
            {
                var orderResponse = await _orderService.GetAsync<ApiResponse>(orderBook.Order_Id);
                var order = JsonConvert.DeserializeObject<OrderDto>(Convert.ToString(orderResponse.Data));

                var userResponse = await _authService.GetAsync<ApiResponse>(order.User_Id);
                var user = JsonConvert.DeserializeObject<UserDto>(Convert.ToString(userResponse.Data));

                var bookResponse = await _bookService.GetAsync<ApiResponse>(orderBook.Book_Id);
                var book = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(bookResponse.Data));

                OrderListViewModel orderListViewModel = orderListViewModelList.FirstOrDefault(vm => vm.Order.Id == order.Id);

                if (orderListViewModel == null)
                {
                    orderListViewModel = new OrderListViewModel
                    {
                        Order = order,
                        User = user,
                    };
                    orderListViewModelList.Add(orderListViewModel);
                }

                orderListViewModel.BookList.Add(book);
                orderListViewModel.OrderBookList.Add(orderBook);
            }

            return View(orderListViewModelList);
        }

    }
}
