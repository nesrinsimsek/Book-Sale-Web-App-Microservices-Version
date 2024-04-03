using AuthenticationBusiness.Abstract;
using AuthenticationDomain.Services.Abstract;
using AuthenticationEntity.Dtos;
using AuthenticationEntity.Entities;
using AuthenticationEntity.Models;
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
            
            var user = await _userManager.GetUserByEmail(registrationRequestDto.Email);
            string mailSubject = "Hesap Aktivasyonu";
            string mailContent = "Hesabınızı aktive etmek için lütfen aşağıdaki linke tıklayınız: " +
                $"<p><a href='https://localhost:7058/Auth/ActivateAccount?id={user.Id}'>Aktivasyon Linki</a></p>";
            var email = new Email(
                user.Email,
                mailContent,
                mailSubject
                );
            _emailService.SendMail(email);

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto loginRequestDto) //bunu dto yap
        {
            var loginResponseDto = await _userManager.Login(loginRequestDto);
            if (loginResponseDto == null || string.IsNullOrEmpty(loginResponseDto.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Data = loginResponseDto;
            return Ok(_response);

        }

        [HttpGet("ById/{userId}")]
        public async Task<ActionResult<UserDto>> Get(int userId)
        {
            var user = await _userManager.GetUserById(userId);
            UserDto userDto = _mapper.Map<UserDto>(user);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDto;
            return Ok(_response);

        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {

            var users = await _userManager.GetUserList();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDtos;
            return Ok(_response);

        }

        [HttpGet("OrderAccepted/{userId}")]
        public async Task<ActionResult<ApiResponse>> SendOrderAcceptedMail(int userId)
        {

            var user = await _userManager.GetUserById(userId);
            string mailSubject = "Sipariş Onayı";
            string mailContent = "Siparişiniz onaylanmıştır.";
            var email = new Email(
                user.Email,
                mailContent,
                mailSubject
                );
            _emailService.SendMail(email);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }

        [HttpPut("ActivateAccount/{userId}")]
        public async Task<ActionResult<ApiResponse>> UpdateUserStatus(int userId)
        {
            User user = await _userManager.GetUserById(userId); // user normalde from body'den çekilir ama bu senaryoda body girmiyorum
            user.Status = "Aktif";

            await _userManager.UpdateUser(user); 
            UserDto userDto = _mapper.Map<UserDto>(user);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDto;
            return Ok(_response);

        }
    }
}
