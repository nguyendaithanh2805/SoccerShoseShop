using SoccerShoesShop.Common;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;

namespace SoccerShoesShop.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task AddAccountAsync(Account account)
        {
            var roleId = account.Equals("ADMIN") ? 1 : 2;
            var newAccount = new Account
            {
                UserId = IdGenerator.GeneratedIdBasedOnTime(),
                RoleId = roleId,
                Username = account.Username,
                Password = account.Password
            };
            await _accountRepository.AddAsync(newAccount);
        }

        public async Task<Account> AuthenticateAsync(string username, string password)
        {
            var account = await _accountRepository.findByNameAsync(username);
            if (account == null || account.Password != password) return null;
            return account;
        }

        public async Task DeleteAccountAsync(int id)
        {
            await _accountRepository.DeleteAsync(id);
        }

        public async Task<Account> GetAccountById(int id)
        {
           return await _accountRepository.findByIdAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAccountAsync()
        {
            return await _accountRepository.findAllAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            var existingAccount = await _accountRepository.findByIdAsync(account.UserId);
            if (existingAccount == null) throw new ArgumentNullException("Account is null");
            existingAccount.Username = account.Username;
            existingAccount.Password = account.Password;
            existingAccount.RoleId = account.RoleId;
            await _accountRepository.UpdateAsync(account);
        }
    }
}
