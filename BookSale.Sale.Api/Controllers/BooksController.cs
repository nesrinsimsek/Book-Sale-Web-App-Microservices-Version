using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{bookId:int}")]
        public ActionResult<Book> Get(int bookId)
        {
            var books = _bookService.GetBookById(bookId);
            return Ok(books);

        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetList()
        {
            var books = _bookService.GetBookList();
            return Ok(books);

        }

        [HttpGet("{categoryId:int}")]
        public ActionResult<IEnumerable<Book>> GetListByCategory(int categoryId)
        {
            var books = _bookService.GetBookListByCategory(categoryId);
            return Ok(books);
        }

    }
}
