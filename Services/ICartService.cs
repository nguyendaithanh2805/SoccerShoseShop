using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAllCartAsync();
        Task<Cart> GetCartById(int id);
        Task DeleteCartAsync(int id);
        Task<IEnumerable<Cart>> GetCartByUsernameAsync(string username);
        Task AddOrUpdateCartAsync(int userId, int productId, int quantity);
    }
}
