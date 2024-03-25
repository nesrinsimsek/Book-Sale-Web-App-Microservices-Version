using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface IAuthService
    {
        Task<T> GetAsync<T>(int id, string token);
        Task<T> GetAllAsync<T>();
        Task<T> LoginAsync<T>(LoginRequestDto loginRequestDto);
        Task<T> RegisterAsync<T>(RegistrationRequestDto registrationRequestDto);
        Task<T> UpdateUserStatusAsync<T>(int id, string token);
        Task<T> SendOrderAcceptedMailAsync<T>(int id, string token);
    }
}
