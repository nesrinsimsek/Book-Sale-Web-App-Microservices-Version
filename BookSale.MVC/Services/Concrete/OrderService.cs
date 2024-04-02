using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Humanizer;

namespace BookSale.MVC.Services.Concrete
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpRequestLogService _httpRequestLogService;
        private readonly IHttpResponseLogService _httpResponseLogService;
        private string _orderUrl;
        public OrderService(IHttpClientFactory clientFactory, IHttpRequestLogService httpRequestLogService, IHttpResponseLogService httpResponseLogService) 
            : base(clientFactory, httpRequestLogService, httpResponseLogService)
        {
            _clientFactory = clientFactory;
            _httpRequestLogService = httpRequestLogService;
            _httpResponseLogService = httpResponseLogService;
            _orderUrl = "https://localhost:7223";
        }


        public Task<T> CreateAsync<T>(OrderCreateDto orderCreateDto, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = orderCreateDto,
                Url = _orderUrl + "/api/Orders",
                Token = token

            });
        }
        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _orderUrl + "/api/Orders",
                Token = token

            });
        }
        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _orderUrl + "/api/Orders/ById/" + id,
                Token = token

            });
        }

    
    }
}

