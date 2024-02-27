using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface IOrderService
    {
        Task<T> GetAsync<T>(int id, string token);
        Task<T> GetAllAsync<T>(string token);
        Task<T> CreateAsync<T>(OrderCreateDto orderCreateDto, string token);
    }
}
