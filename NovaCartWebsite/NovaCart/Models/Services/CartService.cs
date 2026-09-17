using Microsoft.AspNetCore.Http;
using System.Text.Json;
using YourProject.Models;

namespace YourProject.Services
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public List<CartItem> GetCart()
        {
            var cart = Session.GetString("cart");
            return cart == null ? new List<CartItem>() :
                JsonSerializer.Deserialize<List<CartItem>>(cart);
        }

        public void SaveCart(List<CartItem> cart)
        {
            Session.SetString("cart", JsonSerializer.Serialize(cart));
        }
    }
}