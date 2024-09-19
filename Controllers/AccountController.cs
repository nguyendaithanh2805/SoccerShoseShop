using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SoccerShoesShop.Models;
using SoccerShoesShop.Services;
using System.Security.Claims;

namespace SoccerShoesShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            var accountCheck = await _accountService.AuthenticateAsync(account.Username, account.Password);
            if (accountCheck == null) throw new ArgumentNullException("Account is null (controller)");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, accountCheck.Username), // Luu username vao Claim
                new Claim(ClaimTypes.Role, accountCheck.Role.Name) // Luu Role cua nguoi dung vao claim
            };
            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth"); // Cac claim duoc gan vao ClaimIdentity dung de tao danh tinh nguoi dung cho session
            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity)); // HttpContext.SignInAsync duoc goi de thuc hien Login, su dung cookie xac thuc 'CookieAuth'
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            if (ModelState.IsValid)
            {
                await _accountService.AddAccountAsync(account);
                return RedirectToAction("Login", "Account");
            }
            return View(account);
        }
    }
}
