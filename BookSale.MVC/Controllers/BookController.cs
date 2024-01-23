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
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        //public async Task<IActionResult> Index()
        //{
        //    List<BookDto> list = new();

        //    var response = await _bookService.GetAllAsync<ApiResponse>();
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
        //    }
        //    return View(list);
        //}
    }
}
