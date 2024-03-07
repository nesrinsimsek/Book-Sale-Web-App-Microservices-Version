using AuthenticationBusiness.Abstract;
using AuthenticationDataAccess.Abstract;
using AuthenticationDataAccess.Context;
using AuthenticationEntity.Dtos;
using AuthenticationEntity.Entities;
using AuthenticationUtility;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBusiness.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly UserDbContext _userDbContext;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        private string _secretKey;

        public UserManager(UserDbContext userDbContext, IMapper mapper, IConfiguration configuration, IUserDal userDal)
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _userDbContext = userDbContext;
            _mapper = mapper;
            _userDal = userDal;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userDal.Get(u => u.Email == email);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userDal.Get(u => u.Id == userId);
        }

        public async Task<List<User>> GetUserList()
        {
            return await _userDal.GetList();
        }

        public bool IsUniqueUser(string email)
        {
            var user = _userDbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var userList = await _userDal.GetList();
            var user = userList.FirstOrDefault(u => u.Email.ToLower() == loginRequestDto.Email.ToLower()
                                && u.Password == PasswordHasher.HashPassword(loginRequestDto.Password) 
                                && (u.Status == "Aktif" || u.Role == "Admin"));


            if (user == null)
            {
                return new LoginResponseDto
                {
                    Token = "",
                    User = null
                };
            }

        
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey); // string olan key binary yapılıyor

            // jwt nin içinde taşınacak olan bilgiler atanıyor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role) // authorization için kullanıcının rolü claim'e atanıyor
               }),
                Expires = DateTime.UtcNow.AddDays(7), //tokenin geçerlilik süresi, dolunca kullanıcı tekrar giriş yapmalı ve yeni tokenini edinmeli login olmak için
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
             
            // token oluşturuluyor
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDTO = new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token), // token serialize edilip atanıyor
                User = user

            };
            return loginResponseDTO;

        }

        public async Task<User> Register(RegistrationRequestDto registrationRequestDto)
        {
            User user = _mapper.Map<User>(registrationRequestDto);
            user.Password = PasswordHasher.HashPassword(user.Password);
            await _userDal.Add(user);
            user.Password = "";
            return user;

        }
        public async Task UpdateUser(User user)
        {
            await _userDal.Update(user);
        }
    }
}
