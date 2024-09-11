using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
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
