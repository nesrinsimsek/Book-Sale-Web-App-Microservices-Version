using BookSale.MVC.Models.Dtos;
using FluentValidation;

namespace BookSale.MVC.ValidationRules
{
    public class RegistrationValidator : AbstractValidator<RegistrationRequestDto>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş bırakılamaz");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır")
                .MaximumLength(16).WithMessage("Şifre en fazla 16 karakter olmalıdır")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon alanı boş bırakılamaz");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Lütfen doğum tarihinizi seçiniz")
                .Must(BeAtLeast18YearsOld).WithMessage("18 yaşından küçük olamazsınız");

        }

        private bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            // doğum tarihinden 18 yıl önceki tarihi alıyor
            var minimumDateOfBirth = DateTime.Today.AddYears(-18);

            // girilen doğum tarihi minimum doğum tarihinden geride veya eşitse true dönüyor
            return birthDate <= minimumDateOfBirth;
        }

    }
}
