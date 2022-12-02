using Customer_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Management_System.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext _context;
        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> objCatlist = _context.Customers;
            return View(objCatlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(cust);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(cust);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var custfromdb = _context.Customers.Find(id);

            if (custfromdb == null)
            {
                return NotFound();
            }
            return View(custfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer cust)
        {
            if (ModelState.IsValid)
            {
                
                _context.Customers.Update(cust);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(cust);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var empfromdb = _context.Customers.Find(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(int? id)
        {
            var deleterecord = _context.Customers.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }

        public IActionResult Search(string SearchText = "")
        {
            List<Customer> customers;
            if (SearchText != "" && SearchText != null)
            {
                customers = _context.Customers
                    .Where(p => p.CustomerName.Contains(SearchText)).OrderBy(n => n.CustomerName)
                    .ToList();

            }
            else
                customers = _context.Customers.ToList();

            return View(customers);
        }







    }

}
