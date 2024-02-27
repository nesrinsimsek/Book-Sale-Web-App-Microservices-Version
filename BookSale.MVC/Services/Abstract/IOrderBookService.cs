using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface IOrderBookService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> CreateAsync<T>(OrderBookDto orderBookDto, string token);
    }
}
