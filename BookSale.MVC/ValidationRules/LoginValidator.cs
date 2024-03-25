using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Models;
using BookSale.MVC.Services.Abstract;
using FluentValidation;
using Newtonsoft.Json;
using BookSale.MVC.Utility;

namespace BookSale.MVC.ValidationRules
{
    public class LoginValidator : AbstractValidator<LoginRequestDto>
    {
        private readonly IAuthService _authService;

        public LoginValidator(IAuthService authService)
        {
            _authService = authService;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta alanı boş bırakılamaz")
                .Must(UserStatusIsActive).WithMessage("Hesap aktivasyonunuz yapılmamıştır. " +
                                                      "Lütfen e-posta adresinize gönderilen linke tıklayarak " +
                                                      "aktivasyonunuzu gerçekleştiriniz.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz")
                .Must((dto, password) => UserIsFound(dto.Email, password)).WithMessage("Geçersiz e-posta veya şifre");
        }

        private bool UserIsFound(string email, string password)
        {
            var response = _authService.GetAllAsync<ApiResponse>().Result;
            var users = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(response.Data));
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == PasswordHasher.HashPassword(password));
            return user != null;
        }

        private bool UserStatusIsActive(string email)
        {
            var response = _authService.GetAllAsync<ApiResponse>().Result;
            var users = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(response.Data));
            var user = users.FirstOrDefault(u => u.Email == email);
            return user.Status == "Aktif";
        }
    }
}
