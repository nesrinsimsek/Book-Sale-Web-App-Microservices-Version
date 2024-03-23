using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using OrderBusiness.Abstract;

namespace BookSale.MVC.Services.Concrete
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, BookDto book)
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
