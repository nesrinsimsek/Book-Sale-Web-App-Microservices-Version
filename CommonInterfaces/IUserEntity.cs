using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IUserEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
        string Role { get; set; }
        DateTime BirthDate { get; set; }
    }
}
