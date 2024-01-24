using AutoMapper;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using BookSale.Sale.Entities.Concrete.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
            _response = new();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] BookCreateDto bookCreateDto) //bunu dto yap
        {
            Book book = _mapper.Map<Book>(bookCreateDto);
            await _bookService.AddBook(book);
            return Ok(bookCreateDto);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{bookId}")]
        public async Task<ActionResult<BookDto>> Update(int bookId, [FromBody] BookUpdateDto bookUpdateDto) //bunu dto yap
        {
            Book book = _mapper.Map<Book>(bookUpdateDto);
            await _bookService.UpdateBook(book);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{bookId}")]
        public async Task<ActionResult> Delete(int bookId) //bunu dto yap
        {
            await _bookService.DeleteBook(bookId);
            return Ok();

        }

        [HttpGet("ById/{bookId}")]
        public async Task<ActionResult<BookDto>> Get(int bookId)
        {
            var book= await _bookService.GetBookById(bookId);
            var bookDto = _mapper.Map<BookDto>(book);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = bookDto;
            return Ok(_response);

        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<ApiResponse>> GetListByCategory(int categoryId)
        {
            var books = await _bookService.GetBookListByCategory(categoryId);
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = bookDtos;
            return Ok(_response);
        }

 
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {
           
            var books = await _bookService.GetBookList();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = bookDtos;
            return Ok(_response);

        }

    }
}
