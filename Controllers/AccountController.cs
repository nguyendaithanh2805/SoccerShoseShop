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
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            try
            {
                var CheckExistingAccount = await _accountService.AuthenticateAsync(account.Username, account.Password);
                if (CheckExistingAccount is null)
                {
                    ViewBag.Error = "Password is invalid";
                    return View();
                }
                if (!ModelState.IsValid) return View("Error");
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, CheckExistingAccount.Username),
                    new Claim(ClaimTypes.Role, CheckExistingAccount.Role.Name),
                    new Claim(ClaimTypes.NameIdentifier, CheckExistingAccount.UserId.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));
                return account.Username.ToUpper().Equals("ADMIN") ? RedirectToAction("Index", "Product", new { area = "Admin" }) : RedirectToAction("Index", "Home");
            }
            catch (ArgumentNullException)
            {
                ViewBag.Error = "Username or password is invalid";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            try
            {
                if (!ModelState.IsValid) return View("Error");
                await _accountService.AddAccountAsync(account);
                return RedirectToAction("Login", "Account");
            }
            catch (InvalidOperationException)
            {
                ViewBag.Error = "Username already exists!";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();
    }
}
