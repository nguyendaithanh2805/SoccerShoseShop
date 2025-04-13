using System.Security.Claims;

namespace SoccerShoesShop.Common
{
    public class GetCurrentUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public GetCurrentUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<string> GetUsername()
        {
            // Truy cap context de lay thong tin user hien tai
            var user = _contextAccessor.HttpContext?.User;
            if (user == null) throw new ArgumentNullException("User is not authenticated");

            // Lay UserId tu Claims
            var username = user.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("Username is null");
            return await Task.FromResult(username);
        }

        public async Task<int> GetUserId()
        {
            // Truy cap context de lay thong tin user hien tai
            var user = _contextAccessor.HttpContext?.User;
            if (user == null) throw new ArgumentNullException("UserId is not authenticated");

            // Lay UserId tu Claims
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("UserId is null");
            return await Task.FromResult(int.Parse(userId));
        }
    }
}
