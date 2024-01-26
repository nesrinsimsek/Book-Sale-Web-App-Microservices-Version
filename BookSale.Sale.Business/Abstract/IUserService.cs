using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Abstract
{
    public interface IUserService
    {
        bool IsUniqueUser(string email);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<User> Register(RegistrationRequestDto registrationRequestDto);
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUserList();
    }
}
