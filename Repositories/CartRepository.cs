using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SoccerShoesShop.Data;
using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        { 
            var cart = await _context.Carts.FindAsync(id);
            if (cart is null) throw new ArgumentNullException("Cart is null (Repository");
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cart>> findAllAsync()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> findByIdAsync(int id)
        {   
            return await _context.Carts.FindAsync(id);
        }

        public async Task<IEnumerable<Cart>> findByUsernameAsync(string username)
        {
            return await _context.Carts.Include(c => c.Product).Where(c => c.User.Username == username).ToListAsync();
        }

        public async Task<Cart> findCartByProductIdAndUserIdAsync(int productId, int userId)
        {
            return await _context.Carts.Include(c => c.Product).Where(c => c.Product.ProductId == productId && c.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
    }
}
