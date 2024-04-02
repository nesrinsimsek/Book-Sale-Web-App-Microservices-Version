using BookSale.MVC.Models;

namespace BookSale.MVC.Services.Abstract
{
    public interface IHttpRequestLogService
    {
        // IEntityRepository extend edilecek
        // void Add() metodu yazılacak. parametre tipi ApiRequest

        void Add(ApiRequest apiRequest);
    }
}
