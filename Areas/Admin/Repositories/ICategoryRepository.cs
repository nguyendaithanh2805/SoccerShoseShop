using SoccerShoesShop.Areas.Admin.Models;

namespace SoccerShoesShop.Areas.Admin.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> findAllCategoriesAsync();
        Task<Category> findCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
