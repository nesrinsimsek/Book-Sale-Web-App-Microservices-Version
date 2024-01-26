using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;

namespace BookSale.MVC.Services.Concrete
{
    public class OrderBookService : BaseService, IOrderBookService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string orderBookUrl;
        public OrderBookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            orderBookUrl = "https://localhost:7062";
        }

        public Task<T> CreateAsync<T>(OrderBookDto orderBookDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = orderBookDto,
                Url = orderBookUrl + "/api/OrderBooks"

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = orderBookUrl + "/api/OrderBooks"

            });
        }

    }
}
