using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Business.Abstract;
using Product.Entity.Dtos;
using Product.Entity.Entities;
using Product.Entity.ResponseModel;
using System.Net;

namespace Product.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public BookApiController(IBookManager bookManager, IMapper mapper)
        {
            _bookManager = bookManager;
            _mapper = mapper;
            _response = new();
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] BookCreateDto bookCreateDto) //bunu dto yap
        {
            Book book = _mapper.Map<Book>(bookCreateDto);


            await _bookManager.AddBook(book);
            _response.Data = _mapper.Map<BookDto>(book);
            _response.StatusCode = HttpStatusCode.Created;

            return _response;

        }


        //[HttpPut("{bookId}")]
        //public async Task<ActionResult<ApiResponse>> Update(int bookId, [FromBody] BookUpdateDto bookUpdateDto) //bunu dto yap
        //{
        //    Book book = _mapper.Map<Book>(bookUpdateDto);
        //    await _bookService.UpdateBook(book);
        //    _response.StatusCode = HttpStatusCode.OK;
        //    return Ok(_response);

        //}


        [HttpDelete("{bookId}")]
        public async Task<ActionResult> Delete(int bookId) //bunu dto yap
        {
            await _bookManager.DeleteBook(bookId);
            return Ok();

        }

        [HttpGet("ById/{bookId}")]
        public async Task<ActionResult<BookDto>> Get(int bookId)
        {
            var book = await _bookManager.GetBookById(bookId);
            var bookDto = _mapper.Map<BookDto>(book);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = bookDto;
            return Ok(_response);

        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<ApiResponse>> GetListByCategory(int categoryId)
        {
            var books = await _bookManager.GetBookListByCategory(categoryId);
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = bookDtos;
            return Ok(_response);
        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {

            var books = await _bookManager.GetBookList();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = bookDtos;
            return Ok(_response);

        }
    }
}
