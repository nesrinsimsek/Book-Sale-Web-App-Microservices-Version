﻿using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;

namespace BookSale.MVC.Services.Concrete
{
    public class OrderBookService : BaseService, IOrderBookService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpRequestLogService _httpRequestLogService;
        private readonly IHttpResponseLogService _httpResponseLogService;
        private string _orderBookUrl;
        public OrderBookService(IHttpClientFactory clientFactory, IHttpRequestLogService httpRequestLogService, IHttpResponseLogService httpResponseLogService)
            : base(clientFactory, httpRequestLogService, httpResponseLogService)
        {
            _clientFactory = clientFactory;
            _httpRequestLogService = httpRequestLogService;
            _httpResponseLogService = httpResponseLogService;
            _orderBookUrl = "https://localhost:7223";
        }

        public Task<T> CreateAsync<T>(OrderBookDto orderBookDto, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = orderBookDto,
                Url = _orderBookUrl + "/api/OrderBooks",
                Token = token

            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _orderBookUrl + "/api/OrderBooks",
                Token = token

            });
        }

    }
}
