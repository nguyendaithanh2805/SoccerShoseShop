using Microsoft.EntityFrameworkCore;
using SoccerShoesShop.Data;
using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail is null) throw new ArgumentNullException("OrderDetail is null");
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDetail>> findAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> findByIdAsync(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }
    }
}
