using AutoMapper;
using BookSale.MVC.Helpers;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderBusiness.Abstract;
using Product.Entity.Entities;
using BookSale.MVC.Services.Abstract;

namespace BookSale.MVC.Controllers
{
    public class CartController : Controller
    {
        private ICartManager _cartManager;
        private ICartSessionHelper _cartSessionHelper;
        private IBookService _bookService;
        private IMapper _mapper;

        public CartController(ICartManager cartManager, ICartSessionHelper cartSessionHelper, IBookService bookService, IMapper mapper)
        {
            _cartManager = cartManager;
            _cartSessionHelper = cartSessionHelper;
            _bookService = bookService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var cartListViewModel = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart("Cart")
            };

            return View(cartListViewModel);
        }

        public async Task<IActionResult> AddToCart(int bookId)
        {
            var response = await _bookService.GetAsync<ApiResponse>(bookId);
            var bookDto = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Data));
            var book = _mapper.Map<Book>(bookDto);

            var cart = _cartSessionHelper.GetCart("Cart"); // sepet yoksa oluştur varsa dön
            _cartManager.AddToCart(cart, book); // sepette o book yoksa ekle varsa 1 arttır
            _cartSessionHelper.SetCart("Cart", cart);
            return RedirectToAction("Index", "Home");


        }

        public async Task<IActionResult> RemoveFromCart(int bookId)
        {
            
            var cart = _cartSessionHelper.GetCart("Cart"); // yoksa oluştur varsa dön
            _cartManager.RemoveFromCart(cart, bookId);
            _cartSessionHelper.SetCart("Cart", cart);
            return RedirectToAction("Index", "Cart");


        }

        public async Task<IActionResult> DecreaseQuantityInCart(int bookId)
        { 

            var cart = _cartSessionHelper.GetCart("Cart"); // yoksa oluştur varsa dön
            _cartManager.DecreaseQuantityInCart(cart, bookId);
            _cartSessionHelper.SetCart("Cart", cart);
            return RedirectToAction("Index", "Cart");


        }

        public async Task<IActionResult> IncreaseQuantityInCart(int bookId)
        {

            var cart = _cartSessionHelper.GetCart("Cart"); // yoksa oluştur varsa dön
            _cartManager.IncreaseQuantityInCart(cart, bookId);
            _cartSessionHelper.SetCart("Cart", cart);
            return RedirectToAction("Index", "Cart");


        }
    }
}
