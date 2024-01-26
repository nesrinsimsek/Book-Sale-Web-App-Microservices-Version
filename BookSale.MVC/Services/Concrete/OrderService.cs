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
        private string orderUrl;
        public OrderService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            orderUrl = "https://localhost:7062";
        }


        public Task<T> CreateAsync<T>(OrderCreateDto orderCreateDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = orderCreateDto,
                Url = orderUrl + "/api/Orders"

            });
        }
        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = orderUrl + "/api/Orders"

            });
        }
        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = orderUrl + "/api/Orders/ById/" + id

            });
        }
    }
}

