using BookSale.Sale.Entities.Abstract;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Entities.CartModels
{
    public class CartLine : ICartModel
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get { return Quantity * Book.Price; }
        }

    }
}
