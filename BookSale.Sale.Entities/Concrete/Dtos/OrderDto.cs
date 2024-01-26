using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Entities.Concrete.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int User_Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
