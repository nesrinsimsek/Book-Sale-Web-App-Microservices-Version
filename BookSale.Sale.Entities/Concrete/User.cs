using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSale.Sale.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace BookSale.Sale.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Order> Orders { get; set; }
    }
}
