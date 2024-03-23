using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using FluentValidation;

namespace BookSale.MVC.ValidationRules
{
    public class OrderValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisi boş bırakılamaz");
        }
 
    }
}
