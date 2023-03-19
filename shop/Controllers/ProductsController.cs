using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
        public async Task<IActionResult> Details(int? id)
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
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.CategoryList = GetCategorys();
            var last = _context.Products.Max(cd => cd.Code);
            int _result = 1;
            int.TryParse(last, out _result);
            ViewBag.LastCode = _result+1;
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Add(product);
                    _context.SaveChanges();
                    TempData["Message"] = "  تمت اضافة المنتج  بنجاح   ";
                    TempData["MessageState"] = "1";
                    return RedirectToAction(nameof(Index));


                }
                catch (Exception ex)
                {
                    TempData["Message"] = "  لم يتم اضافة المنتج  !!!!!!!! " +ex+" ";
                    TempData["MessageState"] = "0";
                    return View(product);
                }
            }
            TempData["Message"] = "    لم يتم اضافة المنتج تحقق من المدخلات!!!!!!!! ";
            TempData["MessageState"] = "0";
            return View(product);
        }


        [HttpGet]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var _id = Convert.ToInt32(id);
            if (id == null || _context.Products == null)
            {
                TempData["Message"] = "  المنتج غير موجود !!!!!!!! ";
                TempData["MessageState"] = "0";
                return RedirectToAction(nameof(Index));

            }

            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == _id);
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
        public IActionResult Edit(Product product)

        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    _context.SaveChangesAsync();
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity,Unit,CatId")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        TempData["Message"] = "  المنتج غير موجود !!!!!!!! ";
        //        TempData["MessageState"] = "0";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //            TempData["Message"] = "  تم تعديل  المنتج  بنجاح   ";
        //            TempData["MessageState"] = "1";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            TempData["Message"] = "  المنتج غير موجود !!!!!!!! ";
        //            TempData["MessageState"] = "0";
        //            return RedirectToAction(nameof(Index));

        //        }
        //    }
        //    return View(product);
        //}


        // GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> Delete(int id)
        {
            var _id = Convert.ToInt32(id);

            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
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

        private bool ProductExists(int? id)
        {
            return _context.Products.Any(e => e.Id == id);
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
                Value = 1.ToString(),
                Text = "---- بدون مورد  ----"
            };

            lstSuppliers.Insert(0, defItem);

            return lstSuppliers;
        }
        private List<SelectListItem> GetCategorys ()
        {
            var lstSuppliers = new List<SelectListItem>();

            List<Category> categories = _context.Categories.ToList();

            lstSuppliers = categories.Select(sp => new SelectListItem()
            {
                Value = sp.Id.ToString(),
                Text = sp.Name
            }).ToList();

            //var defItem = new SelectListItem()
            //{
            //    Value = 1.ToString(),
            //    Text = "---- بدون صنف  ----"
            //};

            //lstSuppliers.Insert(0, defItem);

            return lstSuppliers;
        }


    }
}
