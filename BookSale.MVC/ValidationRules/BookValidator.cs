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

            RuleFor(x => x.Category_Id)
                .NotEmpty().WithMessage("Lütfen kategori seçiniz");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat alanı boş bırakılamaz")
                .InclusiveBetween(1, 10000).WithMessage("Birim fiyat 1 TL ile 10.000 TL arasında olmalıdır");

            RuleFor(x => x.StockAmount)
                .NotEmpty().WithMessage("Stok adedi alanı boş bırakılamaz")
                .LessThanOrEqualTo(100).WithMessage("Stok adedi en fazla 100 olabilir");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Yazar alanı boş bırakılamaz");

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage("Yayınevi alanı boş bırakılamaz");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN alanı boş bırakılamaz")
                .Must(ISBNIsUnique).WithMessage("Bu ISBN zaten kullanılıyor");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Kitap resim linki alanı boş bırakılamaz");


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
