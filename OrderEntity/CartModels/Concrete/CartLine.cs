using OrderEntity.CartModels.Abstract;
using Product.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntity.CartModels.Concrete
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
