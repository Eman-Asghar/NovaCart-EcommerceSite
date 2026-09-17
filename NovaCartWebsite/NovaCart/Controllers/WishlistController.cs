using Microsoft.AspNetCore.Mvc;
using YourProject.Models;
using YourProject.Services;

namespace YourProject.Controllers
{
    public class WishlistController : Controller
    {
        private readonly WishlistService _wishlistService;

        public WishlistController(WishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public IActionResult Index()
        {
            var wishlist = _wishlistService.GetWishlist();

            return View(wishlist);
        }

        public IActionResult Add(string name, string image, decimal price)
        {
            var wishlist = _wishlistService.GetWishlist();

            var item = wishlist.FirstOrDefault(x => x.Name == name);

            if (item == null)
            {
                wishlist.Add(new WishlistItem
                {
                    Name = name,
                    Image = image,
                    Price = price
                });
            }

            _wishlistService.SaveWishlist(wishlist);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            var wishlist = _wishlistService.GetWishlist();

            var item = wishlist.FirstOrDefault(x => x.Name == name);

            if (item != null)
            {
                wishlist.Remove(item);
            }

            _wishlistService.SaveWishlist(wishlist);

            return RedirectToAction("Index");
        }
    }
}