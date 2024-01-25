using BookSale.Sale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Entities.Concrete
{
    public class OrderBook : IEntity
    {
        [ForeignKey("Order")]
        public int Order_Id { get; set; }
        [ForeignKey("Book")]
        public int Book_Id { get; set; }

        public Order Order { get; set; } 
        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}
