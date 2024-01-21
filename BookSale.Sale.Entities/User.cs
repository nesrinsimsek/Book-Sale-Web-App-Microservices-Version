using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookSale.Sale.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Order> Orders { get; set; }
    }
}
