using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface IAuthService
    {
        Task<T> Login<T>(LoginRequestDto loginRequestDto);
        Task<T> Register<T>(RegistrationRequestDto registrationRequestDto);
    }
}
