using BookSale.MVC.Models;

namespace BookSale.MVC.Services.Abstract
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
