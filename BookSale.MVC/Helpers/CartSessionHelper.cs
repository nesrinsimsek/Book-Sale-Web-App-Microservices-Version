using BookSale.MVC.Extensions;
using BookSale.Sale.Entities.CartModels;

namespace BookSale.MVC.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
        private IHttpContextAccessor _contextAccessor;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = new HttpContextAccessor();
        }
        public void Clear()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }

        public Cart GetCart(string key)
        {
            Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(key);
            if (cartToCheck == null)
            {
                SetCart(key, new Cart());
                cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(key);
            }
            return cartToCheck;
        }

        public void SetCart(string key, Cart cart)
        {
            _contextAccessor.HttpContext.Session.SetObject(key, cart);
        }
    }
}
