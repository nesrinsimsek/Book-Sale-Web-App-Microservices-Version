using AuthenticationBusiness.Abstract;
using AuthenticationDomain.Models;
using AuthenticationDomain.Services.Abstract;
using AuthenticationEntity.Dtos;
using AuthenticationEntity.Entities;
using AuthenticationEntity.ResponseModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthenticationApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {

        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        protected ApiResponse _response;

        public AuthApiController(IUserManager userManager, IMapper mapper, IEmailService emailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
            _response = new();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto) //bunu dto yap
        {
            bool userIsUnique = _userManager.IsUniqueUser(registrationRequestDto.Email);

            if (!userIsUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }
            await _userManager.Register(registrationRequestDto);

            string emailContent = "Hesabınızı aktive etmek için lütfen linke tıklayınız: ";
            var email = new Email(
                registrationRequestDto.Email, 
                emailContent
                );
            _emailService.SendMail(email);

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto loginRequestDto) //bunu dto yap
        {
            var loginResponse = await _userManager.Login(loginRequestDto);
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
        [HttpGet("ById/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDto>> Get(int userId)
        {
            var user = await _userManager.GetUserById(userId);
            UserDto userDto = _mapper.Map<UserDto>(user);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDto;
            return Ok(_response);

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse>> GetList()
        {

            var users = await _userManager.GetUserList();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDtos;
            return Ok(_response);

        }
        [HttpPut("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse>> UpdateUserStatus(int userId)
        {
            User user = await _userManager.GetUserById(userId);
            user.Status = "Aktif";

            //User user = _mapper.Map<User>(userUpdateDto);
            await _userManager.UpdateUser(user);
            UserDto userDto = _mapper.Map<UserDto>(user);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDto;
            return Ok(_response);

        }
    }
}
