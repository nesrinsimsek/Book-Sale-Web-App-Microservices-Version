using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface ICartService
    {
        bool AddToCart(Cart cart, BookDto book);
        void RemoveFromCart(Cart cart, int bookId);
        void DecreaseQuantityInCart(Cart cart, int bookId);
        bool IncreaseQuantityInCart(Cart cart, BookDto book);
        List<CartLine> GetCartLines(Cart cart);
    }
}
