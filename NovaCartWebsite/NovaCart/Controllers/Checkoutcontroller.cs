using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovaCart.Data;
using NovaCart.Models;
using YourProject.Models;
using YourProject.Services;

namespace YourProject.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly CartService _cartService;
        private readonly ApplicationDbContext _context;

        public CheckoutController(
            CartService cartService,
            ApplicationDbContext context)
        {
            _cartService = cartService;
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new CheckoutPageViewModel
            {
                CartItems = _cartService.GetCart()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult PlaceOrder(CheckoutPageViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CartItems = _cartService.GetCart();
                return View("Index", vm);
            }
            
            var cartItems = _cartService.GetCart();

            if (cartItems == null || cartItems.Count == 0)
                return RedirectToAction("Index", "Cart");

            var order = new Order
            {
                Name = vm.Checkout.Name,
                Email = vm.Checkout.Email,
                Phone = vm.Checkout.Phone,
                Address = vm.Checkout.Address,
                PaymentMethod = vm.Checkout.PaymentMethod,
                Total = cartItems.Sum(x => x.Price * x.Quantity)
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cartItems)
            {
                _context.OrderItems.Add(new OrderItem
                {
                    OrderId = order.Id,
                    ProductName = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Image = item.Image
                });
            }

            _context.SaveChanges();

            _cartService.SaveCart(new List<CartItem>());

            return RedirectToAction("Success");
        }

        //public IActionResult Success()
        //{
        //    var totalOrders = _context.Orders.Count();

        //    return Content("Total Orders in Database: " + totalOrders);
        //}

        public IActionResult Success()
        {
            return View();
        }
    }
}
