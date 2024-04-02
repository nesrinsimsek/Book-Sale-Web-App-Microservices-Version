using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Humanizer;
using NuGet.Common;

namespace BookSale.MVC.Services.Concrete
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpRequestLogService _httpRequestLogService;
        private readonly IHttpResponseLogService _httpResponseLogService;
        private string _categoryUrl;
        public CategoryService(IHttpClientFactory clientFactory, IHttpRequestLogService httpRequestLogService, IHttpResponseLogService httpResponseLogService)
            : base(clientFactory, httpRequestLogService, httpResponseLogService)
        {
            _clientFactory = clientFactory;
            _httpRequestLogService = httpRequestLogService;
            _httpResponseLogService = httpResponseLogService;
            _categoryUrl = "https://localhost:7160";
        }


        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _categoryUrl + "/api/Categories"

            });
        }


    }
}
