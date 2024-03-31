using BookSale.MVC.Models;

namespace BookSale.MVC.Services.Abstract
{
    public interface IBaseService
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
