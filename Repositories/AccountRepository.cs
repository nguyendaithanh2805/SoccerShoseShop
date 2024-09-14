using Microsoft.EntityFrameworkCore;
using SoccerShoesShop.Data;
using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) throw new ArgumentNullException("Account is null");
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Account>> findAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> findByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> findByNameAsync(string name)
        {
            return await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.Username == name);
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}