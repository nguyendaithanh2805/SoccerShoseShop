using Microsoft.AspNetCore.Mvc;

namespace SoccerShoesShop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
