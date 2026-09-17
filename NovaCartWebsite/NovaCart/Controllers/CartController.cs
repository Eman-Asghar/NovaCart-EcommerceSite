using Microsoft.AspNetCore.Mvc;
using YourProject.Models;
using YourProject.Services;
using System.Linq;

namespace YourProject.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        // ======================
        // CART PAGE
        // ======================
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        // ======================
        // ADD TO CART (FIXED FOR YOUR BUTTONS)
        // ======================
        public IActionResult AddToCart(string name, string image, decimal price, string? size)
        {
            var cart = _cartService.GetCart();

            var item = cart.FirstOrDefault(x => x.Name == name);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Name = name,
                    Image = image,
                    Price = price,
                    Quantity = 1,
                    Size = size
                });
            }

            _cartService.SaveCart(cart);

            return RedirectToAction("Index");
        }

        // ======================
        // REMOVE ITEM
        // ======================
        public IActionResult Remove(string name)
        {
            var cart = _cartService.GetCart();

            var item = cart.FirstOrDefault(x => x.Name == name);

            if (item != null)
            {
                cart.Remove(item);
            }

            _cartService.SaveCart(cart);

            return RedirectToAction("Index");
        }

        // ======================
        // INCREASE QUANTITY
        // ======================
        public IActionResult Increase(string name)
        {
            var cart = _cartService.GetCart();

            var item = cart.FirstOrDefault(x => x.Name == name);

            if (item != null)
            {
                item.Quantity++;
            }

            _cartService.SaveCart(cart);

            return RedirectToAction("Index");
        }

        // ======================
        // DECREASE QUANTITY
        // ======================
        public IActionResult Decrease(string name)
        {
            var cart = _cartService.GetCart();

            var item = cart.FirstOrDefault(x => x.Name == name);

            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
            }

            _cartService.SaveCart(cart);

            return RedirectToAction("Index");
        }
    }
}