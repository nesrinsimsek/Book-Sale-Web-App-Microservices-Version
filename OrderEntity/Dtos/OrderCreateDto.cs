using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntity.Dtos
{
    public class OrderCreateDto
    {
        public string Address { get; set; }
        public int User_Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
