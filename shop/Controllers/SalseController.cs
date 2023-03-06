using Microsoft.AspNetCore.Mvc;

namespace shop.Controllers
{
    public class SalseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult DailySalse()
        {
            return View();
        }
    }
}
