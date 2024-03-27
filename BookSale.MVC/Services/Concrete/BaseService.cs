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
        public ApiResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;

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


            HttpResponseMessage apiResponse = await client.SendAsync(message); // HttpRequestMessage gönderiliyor

            var apiContentStr = await apiResponse.Content.ReadAsStringAsync(); // HttpResponseMessage çekiliyor

            var apiResponseObj = JsonConvert.DeserializeObject<T>(apiContentStr); // T = ApiResponse

            return apiResponseObj;

        }
    }
}
