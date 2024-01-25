using BookSale.Sale.Entities.CartModels;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Book book);
        void RemoveFromCart(Cart cart, int bookId);
        void DecreaseQuantityInCart(Cart cart, int bookId);
        void IncreaseQuantityInCart(Cart cart, int bookId);
        List<CartLine> GetCartLines(Cart cart);
    }
}
