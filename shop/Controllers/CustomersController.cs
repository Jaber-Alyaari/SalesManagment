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
    public class CustomersController : Controller
    {
        private readonly SalesManagerDBContext _context;

        public CustomersController(SalesManagerDBContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Email,Address,State")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "  تمت اضافة   الزبــون   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));


                }
                catch
                {
                    TempData["Message"] = "  لم يتم اضافة الزبــون  !!!!!!!! ";
                    TempData["MessageState"] = "0";
                    return View(customer);
                }
            }
            TempData["Message"] = "   لم يتم اضافة الزبــون تحقق من المدخلات !!!!!!!! ";
            TempData["MessageState"] = "0";
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Customers == null)
            {
                TempData["Message"] = "  الزبــون غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));

            }

            var cust = await _context.Customers.FindAsync(id);
            if (cust == null)
            {
                TempData["Message"] = "  الزبــون غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));

            }
            return View(cust);
        }
        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Phone,Email,Address,State")] Customer customer)
        {
            if (id != customer.Id)
            {
                TempData["Message"] = "  الزبــون غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "  تم تعديل  الزبــون  بنجاح   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Message"] = "  الزبــون غير موجود !!!!!!!! ";
                    TempData["MessageState"] = "0";
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var cust = await _context.Customers.FindAsync(id);
            if (cust != null)
            {
                try
                {
                    _context.Customers.Remove(cust);
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


        private bool CustomerExists(long id)
        {
          return _context.Customers.Any(e => e.Id == id);
        }
    }
}
