using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface IBookService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> GetByCategoryAsync<T>(int categoryId);
        Task<T> CreateAsync<T>(BookCreateDto dto, string token);
        //Task<T> UpdateAsync<T>(BookUpdateDto dto, string token);
        //Task<T> DeleteAsync<T>(int id, string token);
    }
}
