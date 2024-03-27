using BookSale.MVC.Helpers;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BookSale.MVC.Services.Abstract;
using System.Diagnostics;

namespace BookSale.MVC.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IBookService _bookService;
        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IBookService bookService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _bookService = bookService;
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


            var cart = _cartSessionHelper.GetCart("Cart"); // sepet yoksa oluştur varsa dön
            if (_cartService.AddToCart(cart, bookDto)) // sepette o book yoksa ekle varsa 1 arttır
            {
                _cartSessionHelper.SetCart("Cart", cart);
                TempData["success"] = "Ürün başarıyla sepete eklendi.";
            }
            else
            {
                TempData["error"] = "Ürün stoğu yetersiz. Sepete eklenemedi.";
            }

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> RemoveFromCart(int bookId)
        {

            var cart = _cartSessionHelper.GetCart("Cart"); // yoksa oluştur varsa dön
            _cartService.RemoveFromCart(cart, bookId);
            _cartSessionHelper.SetCart("Cart", cart);
            return RedirectToAction("Index", "Cart");

        }

        public async Task<IActionResult> DecreaseQuantityInCart(int bookId)
        {

            var cart = _cartSessionHelper.GetCart("Cart"); // yoksa oluştur varsa dön
            _cartService.DecreaseQuantityInCart(cart, bookId);
            _cartSessionHelper.SetCart("Cart", cart);
            return RedirectToAction("Index", "Cart");

        }

        public async Task<IActionResult> IncreaseQuantityInCart(int bookId)
        {
            var response = await _bookService.GetAsync<ApiResponse>(bookId);
            var bookDto = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(response.Data));
            var cart = _cartSessionHelper.GetCart("Cart"); // yoksa oluştur varsa dön
            if (_cartService.IncreaseQuantityInCart(cart, bookDto))
            {
                _cartSessionHelper.SetCart("Cart", cart);
                TempData["success"] = "Ürün başarıyla sepete eklendi.";
            }
            else
            {
                TempData["error"] = "Ürün stoğu yetersiz. Sepete eklenemedi.";
            }

            return RedirectToAction("Index", "Cart");

        }

    }
}
