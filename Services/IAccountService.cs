using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountAsync();
        Task<Account> AuthenticateAsync(string username, string password);
        Task AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task<Account> GetAccountById(int id);
        Task DeleteAccountAsync(int id);
    }
}
