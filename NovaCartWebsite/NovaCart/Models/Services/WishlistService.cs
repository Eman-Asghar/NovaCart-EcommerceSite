using Microsoft.AspNetCore.Http;
using System.Text.Json;
using YourProject.Models;

namespace YourProject.Services
{
    public class WishlistService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WishlistService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public List<WishlistItem> GetWishlist()
        {
            var wishlist = Session.GetString("wishlist");

            return wishlist == null
                ? new List<WishlistItem>()
                : JsonSerializer.Deserialize<List<WishlistItem>>(wishlist);
        }

        public void SaveWishlist(List<WishlistItem> wishlist)
        {
            Session.SetString("wishlist",
                JsonSerializer.Serialize(wishlist));
        }
    }
}