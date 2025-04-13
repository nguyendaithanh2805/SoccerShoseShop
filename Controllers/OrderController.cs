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
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICartService _cartService;

        public OrderController(IOrderService orderService, GetCurrentUser getCurrentUser, IOrderDetailService orderDetailService, ICartService cartService)
        {
            _orderService = orderService;
            _getCurrentUser = getCurrentUser;
            _orderDetailService = orderDetailService;
            _cartService = cartService;
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
        public async Task<IActionResult> Checkout(TblOrder order, OrderDetail orderDetail)
        {
            var userId = await _getCurrentUser.GetUserId();
            var username = await _getCurrentUser.GetUsername();
            var carts = await _cartService.GetCartByUsernameAsync(username);
            foreach(var cart in carts)
                await _orderDetailService.AddOrderDetailAsync(orderDetail, cart, order, userId);
            return RedirectToAction("Index", "Menu");
        }
    }
}
