using Microsoft.EntityFrameworkCore;
using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Data;

namespace SoccerShoesShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // Dependency Injection
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new ArgumentNullException("Category is null (repository)");
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> findAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> findCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
