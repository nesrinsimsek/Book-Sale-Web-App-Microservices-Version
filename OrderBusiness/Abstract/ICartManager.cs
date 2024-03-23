using OrderEntity.CartModels.Concrete;
using Product.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBusiness.Abstract
{
    public interface ICartManager
    {
        void AddToCart(Cart cart, Book book);
        void RemoveFromCart(Cart cart, int bookId);
        void DecreaseQuantityInCart(Cart cart, int bookId);
        void IncreaseQuantityInCart(Cart cart, int bookId);
        List<CartLine> GetCartLines(Cart cart);
    }
}
