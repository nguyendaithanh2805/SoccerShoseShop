using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Product product);
    }
}
