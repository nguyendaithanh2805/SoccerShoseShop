using SoccerShoesShop.Areas.Admin.Models;

namespace SoccerShoesShop.Areas.Admin.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> findAllAsync();
        Task<Product> findByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
