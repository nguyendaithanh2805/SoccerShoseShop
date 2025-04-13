using Microsoft.AspNetCore.Identity;
using SoccerShoesShop.Common;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;

namespace SoccerShoesShop.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher<Account> _passwordHasher;

        public AccountService(IAccountRepository accountRepository, IPasswordHasher<Account> passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task AddAccountAsync(Account account)
        {
            var roleId = account.Username.ToUpper().Equals("ADMIN") ? 1 : 2;
            var hashedPassword = _passwordHasher.HashPassword(account, account.Password);
            var newAccount = new Account
            {
                UserId = IdGenerator.GeneratedIdBasedOnTime(),
                Username = account.Username,
                Password = hashedPassword,
                RoleId = roleId
            };
            await _accountRepository.AddAsync(newAccount);
        }

        public async Task<Account> AuthenticateAsync(string username, string password)
        {
            var account = await _accountRepository.findByNameAsync(username);
            if (account == null) return null;
            var result = _passwordHasher.VerifyHashedPassword(account, account.Password, password);
            return result == PasswordVerificationResult.Success ? account : null;
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
            if(!string.IsNullOrEmpty(account.Password))
            {
                existingAccount.Password = _passwordHasher.HashPassword(existingAccount, account.Password);
            }
            existingAccount.Username = account.Username;
            existingAccount.RoleId = account.RoleId;
            await _accountRepository.UpdateAsync(account);
        }
    }
}
