using System.Collections.Generic;
using YourProject.Models;

namespace NovaCart.Models
{
    public class CheckoutPageViewModel
    {
        public CheckoutViewModel Checkout { get; set; } = new();

        public List<CartItem> CartItems { get; set; } = new();
    }
}