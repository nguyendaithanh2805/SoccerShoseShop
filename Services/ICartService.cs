using SoccerShoesShop.Models;

namespace SoccerShoesShop.Services
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAllCartAsync();
        Task DeleteCartAsync(int id, int userId);
        Task<IEnumerable<Cart>> GetCartByUsernameAsync(string username);
        Task AddOrUpdateCartAsync(int userId, int productId, int quantity);
    }
}
