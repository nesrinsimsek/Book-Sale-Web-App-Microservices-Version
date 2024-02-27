using AuthenticationEntity.Dtos;
using AuthenticationEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBusiness.Abstract
{
    public interface IUserManager
    {
        bool IsUniqueUser(string email);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<User> Register(RegistrationRequestDto registrationRequestDto);
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUserList();
        Task UpdateUser(User user);
    }
}
