using SoccerShoesShop.Models;

namespace SoccerShoesShop.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> findAllAsync();
        Task<Cart> findByIdAsync(int id);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int id);
        Task<IEnumerable<Cart>> findByUsernameAsync(string username);
        Task<Cart> findCartByProductIdAndUserIdAsync(int productId, int userId);
    }
}
