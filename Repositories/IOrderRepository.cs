using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<TblOrder>> findAllAsync();
        Task<TblOrder> findByIdAsync(int id);
        Task AddAsync(TblOrder tblOrder);
        Task UpdateAsync(TblOrder tblOrder);
        Task DeleteAsync(int id);
    }
}
