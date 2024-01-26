using AutoMapper;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.DataAccess.Abstract.Dals;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Contexts;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Dals;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using BookSale.Sale.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly SaleDbContext _saleDbContext;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        private string secretKey;

        public UserManager(SaleDbContext saleDbContext, IMapper mapper, IConfiguration configuration, IUserDal userDal)
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _saleDbContext = saleDbContext;
            _mapper = mapper;
            _userDal = userDal;
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
            var user = _saleDbContext.Users.FirstOrDefault(u => u.Email == email);
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
                                && u.Password == PasswordHasher.HashPassword(loginRequestDto.Password));


            if (user == null)
            {
                return new LoginResponseDto
                {
                    Token = "",
                    User = null
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // jwt nin içinde taşınacak olan bilgiler 
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
               }),
                Expires = DateTime.UtcNow.AddDays(7), //tokenin geçerlilik süresi, dolunca kullanıcı tekrar giriş yapmalı
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDTO = new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token),
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
    }
}
