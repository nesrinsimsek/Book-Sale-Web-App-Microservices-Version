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
        private string bookUrl;
        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            bookUrl = "https://localhost:7062";
        }

        public Task<T> CreateAsync<T>(BookCreateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = bookUrl + "/api/Books"
     
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = bookUrl + "/api/Books/" + id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = bookUrl + "/api/Books"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = bookUrl + "/api/Books/ById/" + id

            });
        }

        public Task<T> GetByCategoryAsync<T>(int categoryId)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = bookUrl + "/api/Books/ByCategory/" + categoryId

            });
        }

        public Task<T> UpdateAsync<T>(BookUpdateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = bookUrl + "/api/Books" + dto.Id

            });
        }
    }
}
