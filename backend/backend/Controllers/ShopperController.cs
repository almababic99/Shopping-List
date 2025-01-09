using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShopperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
