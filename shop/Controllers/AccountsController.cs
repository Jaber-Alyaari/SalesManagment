using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Controllers
{
    public class AccountsController : Controller
    {
        private SalesManagerDBContext _context;

        // GET: Accounts
        public AccountsController(SalesManagerDBContext context)
        {
            _context=context;
        }
        public  ActionResult Index()
        {
            List <Customer> customer =  _context.Customers.Include(c=> c.Accounts).ThenInclude(j=> j.Journals).ToList();
            foreach(Customer c  in customer)
            {
                foreach(var A in c.Accounts)
                {

                    foreach (var j in A.Journals)
                    {
                        if (j.Debtor == true) 
                        { 

                            c.TotalDeptor += j.Amount;
                        }
                        else
                        {
                            c.TotalCreditor += j.Amount;
                        }

                    }
                    c.Total += c.TotalDeptor - c.TotalCreditor;

                }

            }

            
            return View( customer);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            Customer customer;
            try
            {

                 customer = _context.Customers.Where(c => c.Id == id).Include(c => c.Accounts).ThenInclude(j => j.Journals).SingleOrDefault();

                foreach (var A in customer.Accounts)
                {

                    foreach (var j in A.Journals)
                    {
                        if (j.Debtor == true)
                        {

                            customer.TotalDeptor += j.Amount;
                        }
                        else
                        {
                            customer.TotalCreditor += j.Amount;
                        }

                    }
                    customer.Total += customer.TotalDeptor - customer.TotalCreditor;

                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }

            


            return View(customer);

        }

        public ActionResult JournalDetails(int id)
        {

            Customer customer = _context.Customers.Where(c => c.Id == id).Include(c => c.Accounts).ThenInclude(j => j.Journals).SingleOrDefault();

            foreach (var A in customer.Accounts)
            {

                foreach (var j in A.Journals)
                {
                    if (j.Debtor == true)
                    {

                        customer.TotalDeptor += j.Amount;
                    }
                    else
                    {
                        customer.TotalCreditor += j.Amount;
                    }

                }
                customer.Total += customer.TotalDeptor - customer.TotalCreditor;

            }




            return View(customer);

        }




             [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Account account)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accounts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
