using Microsoft.AspNetCore.Mvc;

namespace SoccerShoesShop.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
