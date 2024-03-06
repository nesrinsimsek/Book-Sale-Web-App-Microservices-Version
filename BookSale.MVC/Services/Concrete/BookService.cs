using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Humanizer;
using NuGet.Common;

namespace BookSale.MVC.Services.Concrete
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _bookUrl;
        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _bookUrl = "https://localhost:7160";
        }

        public Task<T> CreateAsync<T>(BookCreateDto dto, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = _bookUrl + "/api/Books",
                Token = token

            });
        }


        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _bookUrl + "/api/Books"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _bookUrl + "/api/Books/ById/" + id

            });
        }

        public Task<T> GetByCategoryAsync<T>(int categoryId)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _bookUrl + "/api/Books/ByCategory/" + categoryId

            });
        }


    }
}
