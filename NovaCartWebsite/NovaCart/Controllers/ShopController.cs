using Microsoft.AspNetCore.Mvc;

namespace NovaCart.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}