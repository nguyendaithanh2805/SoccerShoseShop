using SoccerShoesShop.Common;
using SoccerShoesShop.Data;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;

namespace SoccerShoesShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            var newCategory = new Category
            {
                CategoryId = IdGenerator.GeneratedIdBasedOnTime(),
                Name = category.Name
            };
            await _categoryRepository.AddCategoryAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<IEnumerable<Category>> getAllCategoriesAsync()
        {
            return await _categoryRepository.findAllCategoriesAsync();
        }

        public async Task<Category> getCategoryByIdAsync(int id)
        {
            return await _categoryRepository.findCategoryByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _categoryRepository.findCategoryByIdAsync(category.CategoryId);
            if (existingCategory == null) throw new ArgumentNullException("Category is null (Service)");
            existingCategory.Name = category.Name;
            await _categoryRepository.UpdateCategoryAsync(existingCategory);
        }
    }
}
