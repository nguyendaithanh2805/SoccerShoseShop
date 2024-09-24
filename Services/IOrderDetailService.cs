using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface IOrderDetailService
    {
        Task AddOrderDetailAsync(OrderDetail orderDetail, Cart cartint, int orderId);
    }
}
