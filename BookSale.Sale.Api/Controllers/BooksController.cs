using AutoMapper;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;


        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("ById/{bookId}")]
        public ActionResult<Book> Get(int bookId)
        {
            var book= _bookService.GetBookById(bookId);
            var bookGetDto = _mapper.Map<BookGetDto>(book);
            return Ok(bookGetDto);

        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetList()
        {
            var books = _bookService.GetBookList();
            var bookGetDtos = _mapper.Map<List<BookGetDto>>(books);
            return Ok(bookGetDtos);

        }

        [HttpGet("ByCategory/{categoryId}")]
        public ActionResult<IEnumerable<Book>> GetListByCategory(int categoryId)
        {
            var books = _bookService.GetBookListByCategory(categoryId);
            var bookGetDtos = _mapper.Map<List<BookGetDto>>(books);
            return Ok(bookGetDtos);
        }

        [HttpPost]
        public ActionResult Add([FromBody] BookCreateDto bookCreateDto) //bunu dto yap
        {
            Book book = _mapper.Map<Book>(bookCreateDto);
            _bookService.AddBook(book);
            return Ok(bookCreateDto);

        }

    }
}
