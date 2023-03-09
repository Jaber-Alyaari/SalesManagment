using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SalesManagerDBContext _context;

        public SuppliersController(SalesManagerDBContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            
              return View(await _context.Suppliers.Include(A => A.Accounts).ToListAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Email,Address")] Supplier supplier,bool State)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(supplier);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "  تمت اضافة   المورد   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));


                }
                catch
                {
                    TempData["Message"] = "  لم يتم اضافة المورد  !!!!!!!! ";
                    TempData["MessageState"] = "0";
                    return View(supplier);
                }
            }
            TempData["Message"] = "   لم يتم اضافة المورد تحقق من المدخلات !!!!!!!! ";
            TempData["MessageState"] = "0";
            return View(supplier);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                TempData["Message"] = "  المورد غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));

            }

            var sup = await _context.Suppliers.FindAsync(id);
            if (sup == null)
            {
                TempData["Message"] = "  المورد غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));

            }
            return View(sup);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Phone,Email,Address,State")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                TempData["Message"] = "  المورد غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "  تم تعديل  المورد  بنجاح   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Message"] = "  المورد غير موجود !!!!!!!! ";
                    TempData["MessageState"] = "0";
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var sup = await _context.Suppliers.FindAsync(id);
            if (sup != null)
            {
                try
                {
                    _context.Suppliers.Remove(sup);
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

        // POST: Suppliers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    if (_context.Suppliers == null)
        //    {
        //        return Problem("Entity set 'SalesManagerDBContext.Suppliers'  is null.");
        //    }
        //    var supplier = await _context.Suppliers.FindAsync(id);
        //    if (supplier != null)
        //    {
        //        _context.Suppliers.Remove(supplier);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SupplierExists(long id)
        {
          return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}
