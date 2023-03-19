using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using shop.Models;

namespace shop.Controllers
{
    public class LoginController : Controller
    {
        SalesManagerDBContext _context;
        public LoginController(SalesManagerDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //if(HttpContext.Features.Get<ISessionFeature>()?.Session != null)
            if (HttpContext.Session.GetString("UserName") != null) return RedirectToAction("Index", "Home");


            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user.UserName == null) return View();
            var existUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if (existUser == null) return View(user);
            HttpContext.Session.SetString("UserName", user.UserName);


            if (existUser.IsAdmin.Value)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Index", "InvoiceOrder");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
        }
    }
}
