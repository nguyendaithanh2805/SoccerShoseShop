using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> findAllAsync();
        Task<Account> findByIdAsync(int id);
        Task<Account> findByNameAsync(string name);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(int id);
    }
}
