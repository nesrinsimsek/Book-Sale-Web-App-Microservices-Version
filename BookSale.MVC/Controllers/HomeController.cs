using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BookSale.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 2)
        {
            List<BookDto> list = new List<BookDto>();


            var response = await _bookService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
            }


            int totalBooks = list.Count;
            int totalPages = (int)Math.Ceiling((double)totalBooks / pageSize);

            var skip = (pageNumber - 1) * pageSize;
            list = list
                .OrderByDescending(b => b.Id)
                .Skip(skip)
                .Take(pageSize).ToList();

            ViewBag.TotalPages = totalPages;
            ViewBag.PageNumber = pageNumber;

            return View(list);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
