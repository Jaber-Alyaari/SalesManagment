using Microsoft.AspNetCore.Mvc;

using Microsoft.Build.Framework;
using shop.Models;
using System.Diagnostics;



namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        //[System.Web.Mvc.OutputCache(Duration = 0, NoStore = true)]

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
            return View();
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}