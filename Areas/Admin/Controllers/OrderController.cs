using Microsoft.AspNetCore.Mvc;
using SoccerShoesShop.Models;
using SoccerShoesShop.Services;

namespace SoccerShoesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrderAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> EditStatus(int id, bool status)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order is null) throw new ArgumentNullException("Order is null");
            order.Status = status;
            await _orderService.UpdateOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
