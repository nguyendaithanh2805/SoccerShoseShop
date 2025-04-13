using Microsoft.EntityFrameworkCore;
using SoccerShoesShop.Data;
using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TblOrder tblOrder)
        {
            await _context.TblOrders.AddAsync(tblOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.TblOrders.FindAsync(id);
            if (order is null) throw new ArgumentNullException("Order is null (Repository)");
            _context.TblOrders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TblOrder>> findAllAsync()
        {
            return await _context.TblOrders.ToListAsync();
        }

        public async Task<TblOrder> findByIdAsync(int id)
        {
            return await _context.TblOrders.FindAsync(id);
        }

        public async Task UpdateAsync(TblOrder tblOrder)
        {
            _context.TblOrders.Update(tblOrder);
            await _context.SaveChangesAsync();
        }
    }
}
