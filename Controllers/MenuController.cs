using Microsoft.AspNetCore.Mvc;
using SoccerShoesShop.Areas.Admin.Services;

namespace SoccerShoesShop.Controllers
{
    public class MenuController : Controller
    {
        private IProductService _productService;

        public MenuController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }
    }
}
