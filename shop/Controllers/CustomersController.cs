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
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
            var AllCustomer = _context.Customers.Include(A => A.Accounts);
            return View(await AllCustomer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
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
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Email,Address")] Customer customer, bool State)
        {
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
            if (ModelState.IsValid)
            {
                try
                {


                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    //to creat account for this customer
                    Account account = new Account();
                    int reslt = 0;
                    int.TryParse( HttpContext.Session.GetString("UserId"),out reslt);
                    account.UserAdds = reslt;
                    account.CreateDate = DateTime.Now;
                    var _customerid = _context.Customers.Max(A => A.Id);
                    account.State = State;
                    account.CustomerId = _customerid;
                    _context.Accounts.Add(account);
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Email,Address")] Customer customer, bool State)
        {
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
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

                    //to Edit account for this customer
                    Account account = new Account();

                    account = _context.Accounts.SingleOrDefault(A => A.CustomerId == customer.Id);
                    if (account != null)
                    {
                        account.State = State;
                        _context.Accounts.Update(account);
                        await _context.SaveChangesAsync();

                        TempData["Message"] = "  تم تعديل  الزبــون  بنجاح   ";
                        TempData["MessageState"] = "1";
                        return RedirectToAction(nameof(Index));
                    }
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("UserName") == null) return RedirectToAction("Index", "Login");
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


        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
