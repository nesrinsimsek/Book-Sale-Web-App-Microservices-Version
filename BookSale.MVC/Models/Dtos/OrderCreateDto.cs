using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.MVC.Models.Dtos
{
    public class OrderCreateDto
    {
        public string Address { get; set; }
        public int User_Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
