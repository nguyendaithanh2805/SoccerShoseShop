using SoccerShoesShop.Areas.Admin.Services;
using SoccerShoesShop.Common;
using SoccerShoesShop.Models;
using SoccerShoesShop.Repositories;

namespace SoccerShoesShop.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductService _productService;

        public CartService(ICartRepository cartRepository, IProductService productService)
        {
            _cartRepository = cartRepository;
            _productService = productService;
        }

        public async Task AddOrUpdateCartAsync(int userId, int productId, int quantity)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product is null)
                throw new ArgumentNullException("Product not found");
            var existingCartProduct = await _cartRepository.findCartByProductIdAndUserIdAsync(productId, userId);
            if (existingCartProduct is null)
            {
                var newCart = new Cart
                {
                    CartId = IdGenerator.GeneratedIdBasedOnTime(),
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                    TotalBill = product.SellingPrice * quantity
                };
                await _cartRepository.AddAsync(newCart);
            }
            else
            {
                existingCartProduct.Quantity += quantity;
                existingCartProduct.TotalBill = product.SellingPrice * existingCartProduct.Quantity;
                await _cartRepository.UpdateAsync(existingCartProduct);
            }
        }

        public async Task DeleteCartAsync(int id, int userId)
        {
            var cart = await _cartRepository.findByIdAndUserIdAsync(id, userId);
            if (cart is null) throw new ArgumentNullException("Cart is null (Service)");
            await _cartRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Cart>> GetAllCartAsync()
        {
            return await _cartRepository.findAllAsync();
        }

        public async Task<Cart> GetCartByProductIdAsync(int productId, int userId)
        {
            return await _cartRepository.findCartByProductIdAndUserIdAsync(productId, userId);
        }

        public async Task<IEnumerable<Cart>> GetCartByUsernameAsync(string username)
        {
            return await _cartRepository.findByUsernameAsync(username);
        }
    }
}
