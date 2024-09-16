using SoccerShoesShop.Common;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace SoccerShoesShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public ProductService(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task AddProductAsync(Product product)
        {
            var newProduct = new Product
            {
                ProductId = IdGenerator.GeneratedIdBasedOnTime(),
                CategoryId = 1,
                UserId = 1,
                Name = product.Name,
                Description = product.Description,
                Discount = product.Discount,
                Image = product.Image,
                Quantity = product.Quantity,
                SellingPrice = product.SellingPrice
            };
            await _productRepository.AddAsync(newProduct);
            _logger.LogInformation("Save Product successfully");
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
            _logger.LogInformation($"Deleted {id} successfully");
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.findAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.findByIdAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var productExisting = await _productRepository.findByIdAsync(product.ProductId);
            if (productExisting == null) throw new ArgumentNullException("ProductExisting is null");
            productExisting.CategoryId = product.CategoryId;
            productExisting.UserId = product.UserId;
            productExisting.Name = product.Name;
            productExisting.Description = product.Description;
            productExisting.Discount = product.Discount;
            productExisting.Image = product.Image;
            productExisting.Quantity = product.Quantity;
            productExisting.SellingPrice = product.SellingPrice;
        }
    }
}
