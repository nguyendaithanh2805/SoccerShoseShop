using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<TblOrder>> GetAllOrderAsync();
        Task DeleteOrderAsync(int id);
        Task<int> AddOrderAsync(TblOrder order);
        Task UpdateOrderAsync(TblOrder tblOrder);
        Task<TblOrder> GetOrderByIdAsync(int id);
    }
}
