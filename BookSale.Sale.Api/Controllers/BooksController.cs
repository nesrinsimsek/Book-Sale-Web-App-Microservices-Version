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
        public async Task<ActionResult<Book>> Get(int bookId)
        {
            var book= await _bookService.GetBookById(bookId);
            var bookGetDto = _mapper.Map<BookGetDto>(book);
            return Ok(bookGetDto);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetList()
        {
            var books = await _bookService.GetBookList();
            var bookGetDtos = _mapper.Map<List<BookGetDto>>(books);
            return Ok(bookGetDtos);

        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetListByCategory(int categoryId)
        {
            var books = await _bookService.GetBookListByCategory(categoryId);
            var bookGetDtos = _mapper.Map<List<BookGetDto>>(books);
            return Ok(bookGetDtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] BookCreateDto bookCreateDto) //bunu dto yap
        {
            Book book = _mapper.Map<Book>(bookCreateDto);
            await _bookService.AddBook(book);
            return Ok(bookCreateDto);

        }

    }
}
