using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Services.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, BookDto book);
        void RemoveFromCart(Cart cart, int bookId);
        void DecreaseQuantityInCart(Cart cart, int bookId);
        void IncreaseQuantityInCart(Cart cart, int bookId);
        List<CartLine> GetCartLines(Cart cart);
    }
}
