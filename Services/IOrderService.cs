using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<TblOrder>> GetAllOrderAsync();
        Task DeleteOrderAsync(int id);
        Task AddOrderAsync(TblOrder tblOrder, int userId);
        Task UpdateOrderAsync(TblOrder tblOrder, int userId);
    }
}
