using Microsoft.AspNetCore.Mvc;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Customers.ToList());
        }

        public IActionResult Create() 
        {
            //Prefer a specific viewmodel
            Customer myCustomer = new Customer();

            return View(myCustomer);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Customer myCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(myCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myCustomer);
        }


        public IActionResult Edit(int id)
        {
            Customer customerToEdit = _context.Customers.FirstOrDefault(aCustomer => aCustomer.Id == id);

            return View(customerToEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Customer customerToEdit)
        {
            if (ModelState.IsValid)
            {
                _context.Update(customerToEdit);
                //_context.Customers.Update(customerToEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customerToEdit);
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            //Customer customerToDelete = _context.Customers.FirstOrDefault(aCustomer => aCustomer.Id == id);            
            Customer customerToDelete = await _context.Customers.FindAsync(id);

            if (customerToDelete != null) 
            {
                ViewBag.CustomerDeleted = $"The Customer '{customerToDelete.FullName}' was deleted!";

                _context.Customers.Remove(customerToDelete);
                //_context.Remove(customerToDelete);
                await _context.SaveChangesAsync();
            }

            //return RedirectToAction("Index");            
            return View("Index", _context.Customers.ToList());
            
        }
    }
}
