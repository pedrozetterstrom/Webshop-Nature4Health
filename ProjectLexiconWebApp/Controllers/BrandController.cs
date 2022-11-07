using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Migrations;
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
        public async Task<IActionResult> Create([Bind("Name")] Brand myBrand)
        {
            if (ModelState.IsValid)
            {
                if (_context.Brands.Any(brand => brand.Name == myBrand.Name))
                {
                    ViewBag.ErrorMessage = $"Error!!! Brand {myBrand.Name} is already in the brand list!";
                    return PartialView("_ErrorPage");
                }
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
        public async Task<IActionResult> Edit([Bind("Name")] Brand myBrand)
        {
            if (ModelState.IsValid)
            {
                if (_context.Brands.Any(brand => brand.Name == myBrand.Name))
                {
                    ViewBag.ErrorMessage = $"Error!!! Brand {myBrand.Name} is already in the brand list!";
                    return PartialView("_ErrorPage");
                }
                _context.Update(myBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myBrand);
        }

        public async Task<IActionResult> Delete(int id)
        {            
            Brand brandToDelete = await _context.Brands.FindAsync(id);

            List<Product> productsList = await _context.Products.Where(product => product.BrandId == id).ToListAsync();
          /*  if (productsList.Count() != 0)
            {
                foreach (var product in productsList)
                {
                    product.Name = product.Name;
                    product.Description = product.Description;
                    product.UnitPrice = product.UnitPrice;
                    product.DiscountedPrice = product.DiscountedPrice;
                    product.Picture = product.Picture;
                    product.Size = product.Size;
                    product.Quantity = product.Quantity;
                    product.CategoryId = product.CategoryId;
                    product.BrandId = null;

                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                }
                
            }*/
           if(productsList.Count() > 0)
            {
                ViewBag.ErrorMessage = $"Error!!! Brand {brandToDelete.Name} can not be deleted!";
                return PartialView("_ErrorPage");
            }
            else
            {
                if (brandToDelete != null)
                {
                    ViewBag.BrandDeleted = $"The Brand '{brandToDelete.Name}' was deleted!";

                    _context.Brands.Remove(brandToDelete);
                    await _context.SaveChangesAsync();
                }          
            }
         
            return View("Index", _context.Brands.ToList());

        }

    }
}
