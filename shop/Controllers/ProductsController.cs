﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop.Models;
using SalesManagerDBContext = shop.Models.SalesManagerDBContext;

namespace shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SalesManagerDBContext _context;

        public ProductsController(SalesManagerDBContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var salesManagerDBContext = _context.Products.Include(p => p.Cat);
            return View(await salesManagerDBContext.ToListAsync());
        }




        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            //ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }



    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Quantity,Unit,CatId,SupplierID")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "  تمت اضافة المنتج  بنجاح   ";
                    TempData["MessageState"] ="1";
                    return RedirectToAction(nameof(Index));
                   

                }
                catch
                {
                    TempData["Message"] = "  لم يتم اضافة المنتج  !!!!!!!! ";
                    TempData["MessageState"] = "0";
                    return View(product);
                }
            }
            TempData["Message"] = "    لم يتم اضافة المنتج تحقق من المدخلات!!!!!!!! ";
            TempData["MessageState"] = "0";
            //ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Id", product.Id);
            return View(product);
        }



        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Products == null)
            {
                TempData["Message"] = "  المنتج غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));

            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                TempData["Message"] = "  المنتج غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));

            }
            return View(product);
        }



        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Price,Quantity,Unit,CatId")] Product product)
        {
            if (id != product.Id)
            {
                TempData["Message"] = "  المنتج غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "  تم تعديل  المنتج  بنجاح   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Message"] = "  المنتج غير موجود !!!!!!!! ";
                    TempData["MessageState"] = "0";
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(product);
        }




        // GET: Products/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null || _context.Products == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .Include(p => p.Cat)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // POST: Products/Delete/5
       // [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
         
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                try
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "   ...  تم الحذف بنجاح  .... ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));
                }

                catch
                {
                    TempData["Message"] = "   لم يتم الحذف !!!!!!!! ";
                    TempData["MessageState"] = "0";
                }

            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}