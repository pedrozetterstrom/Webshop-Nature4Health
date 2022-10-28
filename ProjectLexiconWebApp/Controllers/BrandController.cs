using Microsoft.AspNetCore.Mvc;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.Controllers
{    
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrandController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Brands.ToList());
        }

        public IActionResult Create()
        {
            Brand myBrand  = new Brand();

            return View(myBrand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand myBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Brands.Add(myBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myBrand);
        }

        public IActionResult Edit(int id)
        {
            Brand brandToEdit = _context.Brands.FirstOrDefault(aBrand => aBrand.Id == id);

            return View(brandToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Brand myBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Update(myBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myBrand);
        }

        public async Task<IActionResult> Delete(int id)
        {            
            Brand brandToDelete = await _context.Brands.FindAsync(id);

            if (brandToDelete != null)
            {
                ViewBag.BrandDeleted = $"The Brand '{brandToDelete.Name}' was deleted!";

                _context.Brands.Remove(brandToDelete);
                await _context.SaveChangesAsync();
            }
          
            return View("Index", _context.Brands.ToList());

        }

    }
}
