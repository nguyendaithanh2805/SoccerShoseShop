using SoccerShoesShop.Areas.Admin.Models;

namespace SoccerShoesShop.Areas.Admin.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> getAllCategoriesAsync();
        Task<Category> getCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
