using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete.Dtos;
using BookSale.Sale.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookSale.Sale.Entities.Concrete.Models;
using System.Net;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        protected ApiResponse _response;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            _response = new();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto) //bunu dto yap
        {
            bool userIsUnique = _userService.IsUniqueUser(registrationRequestDto.Email);

            if (!userIsUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }
            await _userService.Register(registrationRequestDto);

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto loginRequestDto) //bunu dto yap
        {
            var loginResponse = await _userService.Login(loginRequestDto);
            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token)) 
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Data = loginResponse;
            return Ok(_response);

        }
    }
}
