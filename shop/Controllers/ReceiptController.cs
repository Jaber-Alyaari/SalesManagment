using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace shop.Controllers
{
    public class ReceiptController : Controller
    {


        private readonly SalesManagerDBContext _context;

        public ReceiptController(SalesManagerDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserIsAdmin") != true.ToString()) return RedirectToAction("Index", "InvoiceOrder");
            List<Receipt> ss = _context.Receipts.Include(r=>r.UserAdd).Include(r=>r.UserModifi).ToList();
            return View(ss);
        }


        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("UserIsAdmin") != true.ToString()) return RedirectToAction("Index", "InvoiceOrder");
            Receipt item = new Receipt();

            ViewBag.CustomerList = GetCustomers().Concat(GetSuppliers());


            item.PoNumber = GetNewRENumber();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Receipt rec)
        {
            if (HttpContext.Session.GetString("UserIsAdmin") != true.ToString()) return RedirectToAction("Index", "InvoiceOrder");
            ViewBag.CustomerList = GetCustomers().Concat(GetSuppliers());
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Receipts.Add(rec);
                    await _context.SaveChangesAsync();

                    AddJournals(rec);

                    TempData["Message"] = "  تمت اضافة السند  بنجاح   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));


                }
                catch
                {
                    TempData["Message"] = "  لم يتم اضافة السند   !!!!!!!!";
                    TempData["MessageState"] = "0";
                    return View(rec);
                }
            }
            TempData["Message"] = "   لم يتم اضافة السند تحقق من المدخلات!!!!!!!! ";
            TempData["MessageState"] = "0";
            return View(rec);
        }

        private List<SelectListItem> GetSuppliers()
        {
            var lstSuppliers = new List<SelectListItem>();

            List<Account> Supplieraccounts = _context.Accounts.Include("Supplier").Where(a => a.AccountNumber > 5 && a.SupplierId != null).ToList();

            if (Supplieraccounts is not null)
            {
                lstSuppliers = Supplieraccounts.Select(sp => new SelectListItem()
                {
                    Value = sp.AccountNumber.ToString(),
                    Text = sp.Supplier.Name
                }).ToList();
            }
          

            return lstSuppliers;
        }
        private List<SelectListItem> GetCustomers()
        {
            var lstCustomer = new List<SelectListItem>();

            List<Account> Customeraccounts = _context.Accounts.Include("Customer").Where(a => a.AccountNumber > 5 && a.CustomerId!=null ).ToList();
            if (Customeraccounts is not null)
            {


                lstCustomer = Customeraccounts.Select(sp => new SelectListItem()
                {
                    Value = sp.AccountNumber.ToString(),
                    Text = sp.Customer.Name
                }).ToList();

                return lstCustomer;
            }
            else
            { return new List<SelectListItem>(); }
        }

        private bool AddJournals(Receipt rec)
        {
            bool retVal = false;

                if (rec.AccountNumber != null)
                {

                    Journal NewJournal = new Journal();
                    Journal NewJournal2 = new Journal();
                    if (rec.IsCatch.Value)
                    {
                        NewJournal.Debtor = false;
                        NewJournal.Creditor = true;
                        NewJournal2.Debtor = true;
                        NewJournal2.Creditor = false;
                        NewJournal.ProcessType = " سند قبض ";

                    }
                    else
                    {
                        NewJournal.Debtor = true;
                        NewJournal.Creditor = false;
                        NewJournal2.Debtor = false;
                        NewJournal2.Creditor = true;
                        NewJournal.ProcessType = " سند صرف ";

                    }
                    NewJournal2.ProcessType = NewJournal.ProcessType;
                    NewJournal.AccountNumber =rec.AccountNumber;
                    NewJournal2.AccountNumber = 4;
                    NewJournal.Amount = NewJournal2.Amount = rec.Amount;
                    NewJournal.Date = NewJournal2.Date = DateTime.Now;
                    NewJournal.ReferenceId = NewJournal2.ReferenceId = rec.Id;


                        _context.Attach(NewJournal);
                        _context.Entry(NewJournal).State = EntityState.Added;
                        _context.SaveChanges();

                        _context.Attach(NewJournal2);
                        _context.Entry(NewJournal2).State = EntityState.Added;
                        _context.SaveChanges();

                
                        retVal = true;

                    }

            return retVal;
        }

        private string GetNewRENumber()
        {

            string ponumber = "";
            var LastPoNumber = _context.Receipts.Max(cd => cd.PoNumber);

            if (LastPoNumber == null)
                ponumber = "RE00001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 5).ToString(), out lastdigit);


                ponumber = "RE" + (lastdigit + 1).ToString().PadLeft(5, '0');
            }


            return ponumber;


        }

    }
}
