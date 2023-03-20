using Microsoft.AspNetCore.Mvc;

namespace shop.Controllers
{
    public class UiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
