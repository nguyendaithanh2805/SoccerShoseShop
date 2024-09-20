using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<TblOrder>> GetAllOrderAsync();
        Task DeleteOrderAsync(int id);
        Task AddOrderAsync(TblOrder order, int userId, OrderDetail orderDetail);
        Task UpdateOrderAsync(TblOrder tblOrder, int userId);
    }
}
