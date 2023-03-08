using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models;
using SalesManagerDBContext = shop.Models.SalesManagerDBContext;

namespace shop.Controllers
{
    public class CategoryController : Controller
    {


        private readonly SalesManagerDBContext _context;

        public CategoryController(SalesManagerDBContext context)
        {
            _context = context;
        }

        // GET: CategoryController    
        public IActionResult Index()
        {
            List<Category> ss= _context.Categories.ToList();
            return View(ss);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }
     
        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                _context.Categories.Add(cat);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
