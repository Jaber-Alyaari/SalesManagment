﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models;

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
            List<Category> ss = _context.Categories.ToList();
            return View(ss);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //[HttpGet]
        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(cat);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "  تمت اضافة الصنف  بنجاح   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));


                }
                catch
                {
                    TempData["Message"] = "  لم يتم اضافة الصنف   !!!!!!!!";
                    TempData["MessageState"] = "0";
                    return View(cat);
                }
            }
            TempData["Message"] = "   لم يتم اضافة الصنف تحقق من المدخلات!!!!!!!! ";
            TempData["MessageState"] = "0";
            return View(cat);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category) { 

                if (ModelState.IsValid)
                {
                    _context.Categories.Update(category);
                    _context.SaveChanges();


                    return RedirectToAction("Index");
                }
                return View(category);

            }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cat);
        //            await _context.SaveChangesAsync();
        //            TempData["Message"] = "  تم تعديل  الصنف  بنجاح   ";
        //            TempData["MessageState"] = "1";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            TempData["Message"] = "  الصنف غير موجود !!!!!!!! ";
        //            TempData["MessageState"] = "0";
        //            return RedirectToAction(nameof(Index));

        //        }
        //    }
        //    return View(cat);
        //}


        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'SalesManagerDBContext.Products'  is null.");
            }
            var cat = await _context.Categories.FindAsync(id);
            if (cat != null)
            {
                _context.Categories.Remove(cat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: CategoryController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
