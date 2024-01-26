using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Humanizer;

namespace BookSale.MVC.Services.Concrete
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string authUrl;
        public AuthService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            authUrl = "https://localhost:7062";
        }

        public Task<T> LoginAsync<T>(LoginRequestDto loginRequestDto)
        {

            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = authUrl + "/api/Users/Login"

            });
        }


        public Task<T> RegisterAsync<T>(RegistrationRequestDto registrationRequestDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = authUrl + "/api/Users/Register"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = authUrl + "/api/Users/ById/" + id

            });
        }
    }
}
