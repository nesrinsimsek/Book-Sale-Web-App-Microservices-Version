using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookSale.MVC.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        public IActionResult ListByCategory(int categoryId)
        {
            return ViewComponent("BookList", categoryId);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var response = await _categoryService.GetAllAsync<ApiResponse>();
            var categoryListViewModel = new CategoryListViewModel
            {
                BookCreateDto = new BookCreateDto(),
                Categories = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Data))
            };
            return View(categoryListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDto bookCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateAsync<ApiResponse>(bookCreateDto, HttpContext.Session.GetString("JwtToken"));
                return RedirectToAction("Index", "Home");
            }
            var response = await _categoryService.GetAllAsync<ApiResponse>();
            var categoryListViewModel = new CategoryListViewModel
            {
                BookCreateDto = new BookCreateDto(),
                Categories = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Data))
            };
            return View(categoryListViewModel);

        }

    }
}
