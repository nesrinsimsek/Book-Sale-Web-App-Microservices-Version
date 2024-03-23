using BookSale.MVC.Helpers;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderBusiness.Abstract;

namespace BookSale.MVC.Controllers
{
    public class OrderController : Controller
    {
        private ICartSessionHelper _cartSessionHelper;
        private IOrderService _orderService;
        private IOrderBookService _orderBookService;
        private IAuthService _authService;
        private IBookService _bookService;

        public OrderController(ICartSessionHelper cartSessionHelper,
                                IOrderService orderService, IOrderBookService orderBookService,
                                IAuthService authService, IBookService bookService)
        {
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
            
            if (ModelState.IsValid)
            {
                var cartLines = _cartSessionHelper.GetCart("Cart").CartLines;
                await _orderService.CreateAsync<ApiResponse>(orderCreateDto, HttpContext.Session.GetString("JwtToken"));
                var response = await _orderService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString("JwtToken"));
                var orderList = JsonConvert.DeserializeObject<List<OrderDto>>(Convert.ToString(response.Data));
                var createdOrder = orderList.LastOrDefault(); // son oluşan order'ın id'sine ulaşmak için order tablosundan çekmem gerekti
                                                              // çünkü ordercreatedto objesinin id'si yok

                foreach (var cartLine in cartLines)
                {
                    OrderBookDto orderBookDto = new OrderBookDto
                    {
                        Order_Id = createdOrder.Id,
                        Book_Id = cartLine.Book.Id,
                        Quantity = cartLine.Quantity

                    };
                    await _orderBookService.CreateAsync<ApiResponse>(orderBookDto, HttpContext.Session.GetString("JwtToken"));
                }
                return RedirectToAction("Index", "Home");
            }

            var orderViewModel = new OrderViewModel
            {
                Cart = _cartSessionHelper.GetCart("Cart"),
                OrderCreateDto = orderCreateDto
            };

            return View(orderViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orderBookResponse = await _orderBookService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString("JwtToken"));
            var orderBookList = JsonConvert.DeserializeObject<List<OrderBookDto>>(Convert.ToString(orderBookResponse.Data));
            List<OrderListViewModel> orderListViewModels = new List<OrderListViewModel>(); // order bilgilerini tutan liste

            foreach (var orderBook in orderBookList)
            {
                var orderResponse = await _orderService.GetAsync<ApiResponse>(orderBook.Order_Id, HttpContext.Session.GetString("JwtToken"));
                var order = JsonConvert.DeserializeObject<OrderDto>(Convert.ToString(orderResponse.Data));

                var userResponse = await _authService.GetAsync<ApiResponse>(order.User_Id, HttpContext.Session.GetString("JwtToken"));
                var user = JsonConvert.DeserializeObject<UserDto>(Convert.ToString(userResponse.Data));

                var bookResponse = await _bookService.GetAsync<ApiResponse>(orderBook.Book_Id);
                var book = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(bookResponse.Data));

                // listede ilgili order var mı bakıyor
                OrderListViewModel orderListViewModel = orderListViewModels.FirstOrDefault(vm => vm.Order.Id == order.Id);
                // yoksa oluşturuyor (yani order.Id değişince)
                if (orderListViewModel == null)
                {
                    orderListViewModel = new OrderListViewModel
                    {
                        Order = order, // aynı order için order sabit
                        User = user,  // aynı order için user sabit
                    };
                    orderListViewModels.Add(orderListViewModel);  // listeye orderı ekledi
                }

                orderListViewModel.BookList.Add(book); // ilgili orderdaki kitabı listeye ekliyor (kitap bilgilerini çekebilmek için)
                orderListViewModel.OrderBookList.Add(orderBook); // ilgili orderbooku listeye ekliyor (quantity çekebilmek için)
            }

            return View(orderListViewModels);
        }

    }
}
