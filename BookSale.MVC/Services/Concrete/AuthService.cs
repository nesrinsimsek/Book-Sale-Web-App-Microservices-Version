﻿using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Humanizer;

namespace BookSale.MVC.Services.Concrete
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpRequestLogService _httpRequestLogService;
        private readonly IHttpResponseLogService _httpResponseLogService;
        private string _authUrl;
        public AuthService(IHttpClientFactory clientFactory, IHttpRequestLogService httpRequestLogService, IHttpResponseLogService httpResponseLogService) 
            : base(clientFactory, httpRequestLogService, httpResponseLogService)
        {
            _clientFactory = clientFactory;
            _httpRequestLogService = httpRequestLogService;
            _httpResponseLogService = httpResponseLogService;
            _authUrl = "https://localhost:7152";
        }

        public Task<T> LoginAsync<T>(LoginRequestDto loginRequestDto)
        {

            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = _authUrl + "/api/Users/Login"

            });
        }


        public Task<T> RegisterAsync<T>(RegistrationRequestDto registrationRequestDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = _authUrl + "/api/Users/Register"

            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _authUrl + "/api/Users/ById/" + id,
                Token = token

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _authUrl + "/api/Users"

            });
        }

        public Task<T> UpdateUserStatusAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Url = _authUrl + "/api/Users/ActivateAccount/" + id,
                Token = token

            });
        }

        public Task<T> SendOrderAcceptedMailAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _authUrl + "/api/Users/OrderAccepted/" + id,
                Token = token

            });
        }

    }
}
