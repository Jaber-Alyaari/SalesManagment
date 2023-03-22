using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using shop.Models;

namespace shop.Controllers
{
    public class ReportsController : Controller
    {


        private readonly SalesManagerDBContext _context;

        public ReportsController(SalesManagerDBContext context)
        {
            _context = context;
        }

        // GET: ReportsController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("UserIsAdmin") != true.ToString()) return RedirectToAction("Index", "InvoiceOrder");
            ViewBag.ProductList = GetProducts();

            ViewBag.CustomerList = GetCustomers();
            List<InvoiceDetail> items = items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                    Where(i => i.Invoice.Customer != null).ToList(); ;

            return View(items);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetSalse(int id =0,DateTime? date=null, DateTime? todate = null,string? code=null)
        {
            if (HttpContext.Session.GetString("UserIsAdmin") != true.ToString()) return RedirectToAction("Index", "InvoiceOrder");

            List<InvoiceDetail> items = new List<InvoiceDetail>();
            ViewBag.ProductList = GetProducts();

            ViewBag.CustomerList = GetCustomers();
            TempData["Message"] = "    تم عرض التقرير بنجاح   ";
            TempData["MessageState"] = "1";
            if (date.HasValue && todate.HasValue)
            {
                items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                Where(i => i.Invoice.Customer != null  && i.Invoice.Date >= date && i.Invoice.Date <= todate).ToList();
                if (id != 0 && code!=null)
                {
                    items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                        Where(i => i.Invoice.Customer != null && i.ProductCode == code && i.Invoice.CustomerId==id && i.Invoice.Date>=date && i.Invoice.Date<=todate).ToList();
                }
                else if(id!=0)
                {
                    items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                      Where(i => i.Invoice.Customer != null && i.Invoice.CustomerId == id && i.Invoice.Date >= date && i.Invoice.Date <= todate).ToList();
                }
                else if(code!=null)
                {
                    items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                  Where(i => i.Invoice.Customer != null && i.ProductCode == code && i.Invoice.Date >= date && i.Invoice.Date <= todate).ToList();

                }

            }
            else if(!date.HasValue && !todate.HasValue)
            {
                items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                    Where(i => i.Invoice.Customer != null).ToList();
                if (id != 0 && code != null)
                {
                    items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                    Where(i => i.Invoice.Customer != null && i.ProductCode == code && i.Invoice.CustomerId == id).ToList();

                }
                else if (id != 0)
                {
                    items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                    Where(i => i.Invoice.Customer != null && i.Invoice.CustomerId == id).ToList();
                }
                else if (code != null)
                {
                    items = _context.InvoiceDetails.Include("Invoice.Customer").Include("ProductCodeNavigation").
                    Where(i => i.Invoice.Customer != null && i.ProductCode == code).ToList();
                }
           
            }
            else
            {
                TempData["Message"] = " ادخل تاريخ البداية والنهاية  !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction("Index");
            }

            return View("Index",items);
        }



        private List<SelectListItem> GetCustomers()
        {
            var lstCustomer = new List<SelectListItem>();

            List<Customer> customers = _context.Customers.ToList();

            lstCustomer = customers.Select(sp => new SelectListItem()
            {
                Value = sp.Id.ToString(),
                Text = sp.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = 0.ToString(),
                Text = "----  جميع الزبائن  ----"
            };

            lstCustomer.Insert(0, defItem);

            return lstCustomer;
        }


        private List<SelectListItem> GetProducts()
        {
            var lstProducts = new List<SelectListItem>();

            List<Product> products = _context.Products.ToList();

            lstProducts = products.Select(ut => new SelectListItem()
            {
                Value = ut.Code.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----جميع المنتجات----"
            };

            lstProducts.Insert(0, defItem);

            return lstProducts;
        }


    }
}
