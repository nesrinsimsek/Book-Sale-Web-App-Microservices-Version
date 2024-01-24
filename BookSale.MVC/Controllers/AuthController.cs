using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BookSale.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login() // login view sayfası için
        {
            LoginRequestDto obj = new();
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ApiResponse response = await _authService.LoginAsync<ApiResponse>(loginRequestDto);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Data));

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, loginResponseDto.User.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, loginResponseDto.User.Role));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                /* Başarılı bir giriş durumunda, kullanıcının JWT (Json Web Token) 
                 * belirteci (token) HttpContext.Session üzerinde saklanır. 
                 * Bu token, kullanıcının oturum bilgilerini korumak ve doğrulamak için kullanılır.*/
                HttpContext.Session.SetString("JwtToken", loginResponseDto.Token); //
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                return View(loginRequestDto);
            }
        }


        [HttpGet]
        public IActionResult Register() // register view sayfası için
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            ApiResponse result = await _authService.RegisterAsync<ApiResponse>(obj);
            if (result != null && result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JwtToken", "");
            return RedirectToAction("Index", "Home");
        }


    }
}
