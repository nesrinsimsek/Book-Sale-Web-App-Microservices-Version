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

            RuleFor(x => x.Price)
              .InclusiveBetween(1, 10000).WithMessage("Birim fiyat 1 TL ile 10.000 TL arasında olmalıdır");

            RuleFor(x => x.StockAmount)
                .LessThanOrEqualTo(100).WithMessage("Stok adedi en fazla 100 olabilir");
        }

        private bool ISBNIsUnique(string isbn)
        {
            var response = _bookService.GetAllAsync<ApiResponse>().Result;
            var books = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            return book == null;
        }

    }
}
