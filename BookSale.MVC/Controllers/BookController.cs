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

        public IActionResult ListByCategory(int categoryId)
        {
            return ViewComponent("BookList", categoryId);
        }

    }
}
