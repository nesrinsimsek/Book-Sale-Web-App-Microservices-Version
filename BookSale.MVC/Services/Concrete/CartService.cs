using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using OrderBusiness.Abstract;
using Product.Entity.Entities;

namespace BookSale.MVC.Services.Concrete
{
    public class CartService : ICartService
    {
        public bool AddToCart(Cart cart, BookDto book)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Book.Id == book.Id);


            if (cartLine != null && (cartLine.Quantity < book.StockAmount)) // o kitap sepete daha önce eklendiyse
            {
                cartLine.Quantity++; // sepetteki sayısını bir arttır
                return true;
            }
            else if(cartLine == null && book.StockAmount >= 1)
            {
                cart.CartLines.Add(new CartLine { Book = book, Quantity = 1 }); // sepette hiç yoksa kitabı sepete ekle
                return true;
            }
            return false;
        }

        public void DecreaseQuantityInCart(Cart cart, int bookId)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Book.Id == bookId);

            if(cartLine.Quantity > 0)
            {
                cartLine.Quantity--;
            }
            
        }

        public bool IncreaseQuantityInCart(Cart cart, BookDto book)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Book.Id == book.Id);

            if (cartLine.Quantity < book.StockAmount) // o kitap sepete daha önce eklendiyse
            {
                cartLine.Quantity++; // sepetteki sayısını bir arttır
                return true;
            }
            return false;
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
