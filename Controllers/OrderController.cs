using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerShoesShop.Common;
using SoccerShoesShop.Models;
using SoccerShoesShop.Services;

namespace SoccerShoesShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly GetCurrentUser _getCurrentUser;

        public OrderController(IOrderService orderService, GetCurrentUser getCurrentUser)
        {
            _orderService = orderService;
            _getCurrentUser = getCurrentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrderAsync();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var paymentMethods = new List<SelectListItem>
            {
                new SelectListItem {Value = "Online", Text = "Direct Payment"},
                new SelectListItem {Value = "CashOnDelivery", Text = "Cash On Delivery"},
            };
            ViewBag.PaymentMethods = paymentMethods;
            return View("Checkout", new TblOrder());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(TblOrder order)
        {
            var userId = await _getCurrentUser.GetUserId();
            await _orderService.AddOrderAsync(order, userId);
            return RedirectToAction("Index", "Menu");
        }
    }
}
