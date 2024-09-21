using Microsoft.AspNetCore.Mvc;
using SoccerShoesShop.Services;

namespace SoccerShoesShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var accounts = await _accountService.GetAllAccountAsync();
			return View(accounts);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			await _accountService.DeleteAccountAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
