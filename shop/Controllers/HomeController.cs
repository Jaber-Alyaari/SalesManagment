﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models;
using System.Diagnostics;



namespace shop.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private SalesManagerDBContext ctx;

        public HomeController(SalesManagerDBContext context)
        {
            //_logger = logger;
            ctx = context;
        }

        //[System.Web.Mvc.OutputCache(Duration = 0, NoStore = true)]

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserIsAdmin") != true.ToString()) return RedirectToAction("Index", "InvoiceOrder");
            Dashboard dashboard = new Dashboard();
            var details = ctx.InvoiceDetails.Include("ProductCodeNavigation").Include("Invoice").Where(m => m.Invoice!.CustomerId > 0);
            var result = details
.GroupBy(cGrp => new { cGrp.ProductCode })
.Select(cGrp => new { cGrp.Key, Quantity = cGrp.Sum(m => m.Quantity), product = ctx.Products.FirstOrDefault(m => m.Code == cGrp.Key.ProductCode) })
.ToList();

            dashboard.TopProducts = new List<InvoiceDetail>();
            foreach (var item in result)
            {
                dashboard.TopProducts.Add(new InvoiceDetail()
                {
                    ProductCodeNavigation = item.product,
                    Quantity = item.Quantity,
                    Total = item.Quantity * item.product.Price

                });
            }
            var items = dashboard.TopProducts.OrderByDescending(u => u.Quantity).Take(10);
            dashboard.TopProducts = items.ToList();
            //dashboard.TopProducts = result;
            dashboard.Supplires = ctx.Suppliers.Count();
            dashboard.Sales = ctx.InvoiceDetails.Include(x => x.Invoice).Where(m => m.Invoice!.CustomerId > 0).Count();
            dashboard.Purchases = ctx.InvoiceDetails.Include(x => x.Invoice).Where(m => m.Invoice!.SupplierId > 0).Count(); ;
            dashboard.Customers = ctx.Customers.Count();
            return View(dashboard);
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("UserIsAdmin") != true.ToString()) return RedirectToAction("Index", "InvoiceOrder");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ActionResult> GetJson()
        {
            List<string> Days = new List<string>();
            List<decimal> Prices = new List<decimal>();

            DateTime? currentDay = DateTime.Now.Date;


            for (int i = 0; i < 7; i++)
            {
                decimal total = 0;

                Days.Add(currentDay.Value.DayOfWeek.ToString());
                var invoices = ctx.Invoices.Where(x => x.Date.Value.Date == currentDay.Value.Date).Include("InvoiceDetails.ProductCodeNavigation").ToList();
                if (invoices.Any())
                {
                    foreach (var item in invoices)
                    {
                        item.InvoiceDetails.ToList().ForEach(p => p.Total = p.Quantity * p.ProductCodeNavigation.Price);
                        item.Total = item.InvoiceDetails.Sum(x => x.Total);
                    }
                    total = invoices.Sum(m => m.Total);
                }
                Prices.Add(total);
                currentDay = currentDay.Value.AddDays(-1);
            }


            var data = ctx.Categories.ToList();
            var ids = data.Select(a => a.Id)
                        .Distinct()
                        .OrderBy(a => a).ToArray();

            //return new JsonResult(new { cat = ids });
            return new JsonResult(new { days = Days.ToArray(), prices = Prices });
        }
    }
}