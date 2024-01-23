using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Entities.Concrete.Dtos
{
    public class OrderBookDto
    {
        public int Order_Id { get; set; }
        public int Book_Id { get; set; }
        public int Quantity { get; set; }
    }
}
