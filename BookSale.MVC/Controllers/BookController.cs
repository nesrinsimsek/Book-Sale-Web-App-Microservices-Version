using AutoMapper;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookSale.MVC.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _mapper = mapper;
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
            await _bookService.CreateAsync<ApiResponse>(bookCreateDto);
            return RedirectToAction("Index", "Home");
        }

    }
}
