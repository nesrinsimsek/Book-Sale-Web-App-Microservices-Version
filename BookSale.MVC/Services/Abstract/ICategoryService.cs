using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface ICategoryService
    {
        Task<T> GetAllAsync<T>();
    }
}
