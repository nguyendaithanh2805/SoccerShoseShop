using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Areas.Admin.Services;
using SoccerShoesShop.Common;
using SoccerShoesShop.Models;
using SoccerShoesShop.Services;

namespace SoccerShoesShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly GetCurrentUser _getCurrentUser;
        private readonly ICartService _cartService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, GetCurrentUser getCurrentUser, ICartService cartService, IOrderDetailService orderDetailService, IProductService productService)
        {
            _orderService = orderService;
            _getCurrentUser = getCurrentUser;
            _cartService = cartService;
            _orderDetailService = orderDetailService;
            _productService = productService;
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
            var orderId = await _orderService.AddOrderAsync(order);
            var username = await _getCurrentUser.GetUsername();
            var carts = await _cartService.GetCartByUsernameAsync(username);
            foreach (var cart in carts)
            {
                OrderDetail orderDetail = new OrderDetail();
                await _orderDetailService.AddOrderDetailAsync(orderDetail, cart, orderId);
                await _productService.UpdateQuantityAfterOrder(cart);
                await _cartService.DeleteCartByCartIdAsync(cart.CartId);
            }
            return RedirectToAction("Index", "Menu");
        }
    }
}
