using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using shop.Models;
using shop.Tools;

namespace shop.Controllers
{
    public class InvoiceOrderController : Controller
    {
        private readonly SalesManagerDBContext _context;

        public InvoiceOrderController( SalesManagerDBContext context)
        {
            _context=context;
        }



        private string _errors = "";

        public string GetErrors()
        {
            return _errors;
        }



        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Id");
            sortModel.AddColumn("PoNumber");
            sortModel.AddColumn("Date");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Invoice> items = GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;
            return View(items);
        }



        private List<Invoice> DoSort(List<Invoice> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "ponumber")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.PoNumber).ToList();
                else
                    items = items.OrderByDescending(n => n.PoNumber).ToList();
            }
            //else if (SortProperty.ToLower() == "quotationno")
            //{
            //    if (sortOrder == SortOrder.Ascending)
            //        items = items.OrderBy(n => n.QuotationNo).ToList();
            //    else
            //        items = items.OrderByDescending(n => n.QuotationNo).ToList();
            //}
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderByDescending(d => d.Id).ToList();
                else
                    items = items.OrderBy(d => d.Id).ToList();
            }

            return items;
        }

        public PaginatedList<Invoice> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Invoice> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Invoices.Where(n => n.PoNumber.Contains(SearchText))
                    .Include(s => s.Supplier)
                    .Include(c => c.Customer)
                    .ToList();
            }
            else
                items = _context.Invoices
                   .Include(s => s.Supplier)
                   .Include(c => c.Customer)
                   .ToList();




            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Invoice> retItems = new PaginatedList<Invoice>(items, pageIndex, pageSize);

            return retItems;
        }


        public IActionResult Create()
        {
            Invoice item = new Invoice();
            item.InvoiceDetails.Add(new InvoiceDetail() { Id = 1 });
            ViewBag.ProductList = GetProducts();
            ViewBag.SupplierList = GetSuppliers();
           
            ViewBag.UnitNames = GetUnitNames();
            ViewBag.Price = GetPrice();



            item.PoNumber = GetNewINNumber();
            return View(item);
        }

        [HttpPost]
        public IActionResult Create(Invoice item)
        {
           
            item.InvoiceDetails.ToList().RemoveAll(a => a.Quantity == 0);


            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = Create1(item);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }


            if (bolret == false)
            {
                errMessage = errMessage + " " + GetErrors();

                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);
            }
            else
            {
                TempData["SuccessMessage"] = "" + item.PoNumber + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }



        public bool Create1(Invoice invo)
        {
            bool retVal = false;
            _errors = "";

            try
            {
                _context.Invoices.Add(invo);
                _context.SaveChanges();
                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }



        public IActionResult Details(int id)
        {
            Invoice item = GetItem(id);
            ViewBag.ProductList = GetProducts();
            ViewBag.SupplierList = GetSuppliers();
           

            return View(item);
        }


        public Invoice GetItem(int Id)
        {
            Invoice item = _context.Invoices.Where(i => i.Id == Id).Include(d => d.InvoiceDetails).ThenInclude(i => i.Product).FirstOrDefault();

            
            item.InvoiceDetails.ToList().ForEach(i => i.UnitName = i.Product.Unit);
            item.InvoiceDetails.ToList().ForEach(p => p.Description = p.Product.Name);
            item.InvoiceDetails.ToList().ForEach(p => p.Total = p.Quantity * p.Price);

            return item;
        }


        public IActionResult Edit(int id)
        {
            Invoice item = GetItem(id);

            ViewBag.ProductList = GetProducts();
            ViewBag.SupplierList = GetSuppliers();
          
            ViewBag.UnitNames = GetUnitNames();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Invoice item)
        {
            item.InvoiceDetails.ToList().RemoveAll(a => a.Quantity == 0);


            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = Edit1(item);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }


            if (bolret == false)
            {
                errMessage = errMessage + " " + GetErrors();

                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);
            }
            else
            {
                TempData["SuccessMessage"] = "" + item.PoNumber + " Modified Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Delete(int id)
        {
            Invoice item = GetItem(id);

            ViewBag.ProductList = GetProducts();
            ViewBag.SupplierList = GetSuppliers();
            //ViewBag.PoCurrencyList = GetPoCurrencies();
            //ViewBag.BaseCurrencyList = GetBaseCurrencies();


            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(Invoice item)
        {
            item.InvoiceDetails.ToList().RemoveAll(a => a.Quantity == 0);


            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = Delete1(item);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }


            if (bolret == false)
            {
                errMessage = errMessage + " " + GetErrors();

                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);
            }
            else
            {
                TempData["SuccessMessage"] = "" + item.PoNumber + " Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
        }



        public bool Delete1(Invoice invo)
        {
            bool retVal = false;
            _errors = "";

            try
            {
                _context.Attach(invo);
                _context.Entry(invo).State = EntityState.Deleted;
                _context.SaveChanges();
                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Delete Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        public bool Edit1(Invoice invo)
        {
            bool retVal = false;
            _errors = "";

            try
            {

                List<InvoiceDetail> poDetails = _context.InvoiceDetails.Where(d => d.Id == invo.Id).ToList();
                _context.InvoiceDetails.RemoveRange(poDetails);
                _context.SaveChanges();

                _context.Attach(invo);
                _context.Entry(invo).State = EntityState.Modified;
                _context.InvoiceDetails.AddRange(invo.InvoiceDetails);
                _context.SaveChanges();


                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        private List<SelectListItem> GetProducts()
        {
            var lstProducts = new List<SelectListItem>();

            List<Product> products = _context.Products.ToList();

            lstProducts = products.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Product----"
            };

            lstProducts.Insert(0, defItem);

            return lstProducts;
        }

        private List<SelectListItem> GetSuppliers()
        {
            var lstSuppliers = new List<SelectListItem>();

            List<Supplier> suppliers = _context.Suppliers.ToList();

            lstSuppliers = suppliers.Select(sp => new SelectListItem()
            {
                Value = sp.Id.ToString(),
                Text = sp.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Supplier ----"
            };

            lstSuppliers.Insert(0, defItem);

            return lstSuppliers;
        }

        private List<SelectListItem> GetUnitNames()
        {
            var lstProducts = new List<SelectListItem>();

            List<Product> products = _context.Products.ToList();

            lstProducts = products.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Unit
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Unit----"
            };

            lstProducts.Insert(0, defItem);

            return lstProducts;
        }

        private List<SelectListItem> GetPrice()
        {
            var lstProducts = new List<SelectListItem>();

            List<Product> products = _context.Products.ToList();

            lstProducts = products.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Price.ToString(),
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Price----"
            };

            lstProducts.Insert(0, defItem);

            return lstProducts;
        }
        public string GetNewINNumber()
        {

            string ponumber = "";
            var LastPoNumber = _context.Invoices.Max(cd => cd.PoNumber);

            if (LastPoNumber == null)
                ponumber = "PO00001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 5).ToString(), out lastdigit);


                ponumber = "PO" + (lastdigit + 1).ToString().PadLeft(5, '0');
            }


            return ponumber;


        }


    }
}

