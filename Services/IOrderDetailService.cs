using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailAsync();
        Task DeleteOrderDetailAsync(int id);
        Task AddOrderDetailAsync(OrderDetail orderDetail, Cart cart,TblOrder order, int userId);
    }
}
