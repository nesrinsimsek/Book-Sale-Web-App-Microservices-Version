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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<BookCreateDto>> Add([FromBody] BookCreateDto bookCreateDto) //bunu dto yap
        {
            Book book = _mapper.Map<Book>(bookCreateDto);
            await _bookService.AddBook(book);
            return Ok(bookCreateDto);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{bookId}")]
        public async Task<ActionResult<BookGetDto>> Update(int bookId, [FromBody] BookUpdateDto bookUpdateDto) //bunu dto yap
        {
            Book book = _mapper.Map<Book>(bookUpdateDto);
            book.Id = bookId;
            await _bookService.UpdateBook(book);
            BookGetDto bookGetDto = _mapper.Map<BookGetDto>(book);
            return Ok(bookGetDto);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{bookId}")]
        public async Task<ActionResult> Delete(int bookId) //bunu dto yap
        {
            await _bookService.DeleteBook(bookId);
            return Ok();

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("ById/{bookId}")]
        public async Task<ActionResult<BookGetDto>> Get(int bookId)
        {
            var book= await _bookService.GetBookById(bookId);
            var bookGetDto = _mapper.Map<BookGetDto>(book);
            return Ok(bookGetDto);

        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<BookGetDto>>> GetListByCategory(int categoryId)
        {
            var books = await _bookService.GetBookListByCategory(categoryId);
            var bookGetDtos = _mapper.Map<List<BookGetDto>>(books);
            return Ok(bookGetDtos);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookGetDto>>> GetList()
        {
            var books = await _bookService.GetBookList();
            var bookGetDtos = _mapper.Map<List<BookGetDto>>(books);
            return Ok(bookGetDtos);

        }

    }
}
