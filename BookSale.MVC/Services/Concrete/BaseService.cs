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
        public ApiResponse responseModel {  get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;

        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            //try
            //    {
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

                HttpResponseMessage apiResponse = null;

                //if (!string.IsNullOrEmpty(apiRequest.Token))
                //{
                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.Token);
                //}

                apiResponse = await client.SendAsync(message);

                var apiContentStr = await apiResponse.Content.ReadAsStringAsync();
            //    try
            //    {
            //        ApiResponse responseObj = JsonConvert.DeserializeObject<ApiResponse>(apiContentStr);
            //        if (responseObj != null && (responseObj.StatusCode == System.Net.HttpStatusCode.BadRequest
            //            || responseObj.StatusCode == System.Net.HttpStatusCode.NotFound))
            //        {
            //            responseObj.StatusCode = System.Net.HttpStatusCode.BadRequest;
            //            responseObj.IsSuccess = false;
            //            var returnObjStr = JsonConvert.SerializeObject(responseObj);
            //            var returnObj = JsonConvert.DeserializeObject<T>(returnObjStr);
            //            return returnObj;
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        var exceptionReturnObj = JsonConvert.DeserializeObject<T>(apiContentStr);
            //        return exceptionReturnObj;
            //    }
            //    var apiResponseReturnObj = JsonConvert.DeserializeObject<T>(apiContentStr);
            //    return apiResponseReturnObj;

            //}
            //catch (Exception e)
            //{
                //var dto = new ApiResponse
                //{
                //    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                //    IsSuccess = false
                //};
                //var res = JsonConvert.SerializeObject(dto);
                var apiResponseExceptionReturnObj = JsonConvert.DeserializeObject<T>(apiContentStr);
                return apiResponseExceptionReturnObj;
            //}
        }
    }
}
