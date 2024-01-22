using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Entities.Concrete.Dtos
{
    public class LoginResponseDto
    {
        public User User {  get; set; }
        public string Token { get; set; } // will be used to authenticate or validate identity of user
    }
}
