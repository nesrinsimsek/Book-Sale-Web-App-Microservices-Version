using BookSale.MVC.Models;

namespace BookSale.MVC.Services.Abstract
{
    public interface IHttpResponseLogService
    {
        void Add(ApiResponse apiResponse);
    }
}
