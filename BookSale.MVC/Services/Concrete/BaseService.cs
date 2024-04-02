using Azure.Core;
using BookSale.MVC.Models;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BookSale.MVC.Services.Concrete
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory httpClient { get; set; }
        public IHttpRequestLogService httpRequestLogService {get; set; }
        public IHttpResponseLogService httpResponseLogService { get; set; }

        public BaseService(IHttpClientFactory httpClient, IHttpRequestLogService httpRequestLogService, IHttpResponseLogService httpResponseLogService)
        {
            this.httpClient = httpClient;
            this.httpRequestLogService = httpRequestLogService;
            this.httpResponseLogService = httpResponseLogService;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest) 
        {

            var client = httpClient.CreateClient("SaleAPI");

            HttpRequestMessage message = new HttpRequestMessage();

            message.Headers.Add("Accept", "application/json");

            message.RequestUri = new Uri(apiRequest.Url);

            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
            }

            switch (apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            
            if (!string.IsNullOrEmpty(apiRequest.Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.Token);
            }

            httpRequestLogService.Add(apiRequest);

            HttpResponseMessage apiResponse = await client.SendAsync(message); // HttpRequestMessage gönderiliyor

            var apiContentStr = await apiResponse.Content.ReadAsStringAsync(); // HttpResponseMessage contenti çekiliyor ve stringe çevriliyor

            var apiResponseObj = JsonConvert.DeserializeObject<T>(apiContentStr); // T = ApiResponse oluyor

            ApiResponse response = (ApiResponse)Convert.ChangeType(apiResponseObj, typeof(T));
          
            httpResponseLogService.Add(response);

            return apiResponseObj;

        }
    }
}
