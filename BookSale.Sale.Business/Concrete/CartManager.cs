using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.CartModels;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Book book)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Book.Id == book.Id);

            if (cartLine != null)
            {
                cartLine.Quantity++;
            }
            else
            {
                cart.CartLines.Add(new CartLine { Book = book, Quantity = 1 });
            }
        }

        public void DecreaseQuantityInCart(Cart cart, int bookId)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Book.Id == bookId);

            cartLine.Quantity--;


        }

        public void IncreaseQuantityInCart(Cart cart, int bookId)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Book.Id == bookId);

            cartLine.Quantity++;


        }

        public List<CartLine> GetCartLines(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int bookId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Book.Id == bookId));
        }
    }
}
