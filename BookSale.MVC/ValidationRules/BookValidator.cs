using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Models;
using FluentValidation;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookSale.MVC.ValidationRules
{
    public class BookValidator : AbstractValidator<BookCreateDto>
    {
        private readonly IBookService _bookService;
        public BookValidator(IBookService bookService)
        {
            _bookService = bookService;
            RuleFor(x => x.ISBN)
               .Must(ISBNIsUnique).WithMessage("Bu ISBN zaten kullanılıyor");
        }

        private bool ISBNIsUnique(string isbn)
        {
            // Bu kısımda asenkron bir işlem yapmak yerine senkron bir şekilde veritabanından kontrol yapabilirsiniz.
            // _bookService kullanarak veritabanından ISBN kontrolü yapabilirsiniz.
            // Örneğin:
            // var existingBook = _bookService.GetBookByISBN(isbn);
            // return existingBook == null;

            // Burada bir senkron kontrol örneği:
            var response = _bookService.GetAllAsync<ApiResponse>().Result;
            var books = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            return book == null;
        }

    }
}
