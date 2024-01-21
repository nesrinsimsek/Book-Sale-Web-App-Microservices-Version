using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }
    }
}
