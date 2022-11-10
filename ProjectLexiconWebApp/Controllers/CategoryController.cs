using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.ViewModels;

namespace ProjectLexiconWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
        public class CategoryController : Controller
	{
        private readonly ApplicationDbContext _context;

		public CategoryController(ApplicationDbContext context)
		{
            _context = context;
        }

        public IActionResult Index()
		{
			return View(_context.Categories.ToList());
		}

        public IActionResult Create()
        {
            Category myCategory = new Category();

            return View(myCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Category myCategory)
        {
           /* if (String.IsNullOrWhiteSpace(myCategory.Name))
            {
                return View(myCategory);
            }*/
            if (ModelState.IsValid)
            {
                if (_context.Categories.Any(category => category.Name == myCategory.Name))
                {
                    ViewBag.ErrorMessage = $"Error!!! Category {myCategory.Name} is already in the list!";
                    return PartialView("_ErrorPage");
                }
                else
                {
                   
                    _context.Categories.Add(myCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(myCategory);
            }
      

        }


        public IActionResult Edit(int id)
        {
            Category categoryToEdit = _context.Categories.FirstOrDefault(aCategory => aCategory.Id == id);

            return View(categoryToEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Category categoryToEdit)
        {
           
            if (ModelState.IsValid)
            {
                if (_context.Categories.Any(category => category.Name == categoryToEdit.Name))
                {
                    ViewBag.ErrorMessage = $"Error!!! Category {categoryToEdit.Name} is already in the list!";
                    return PartialView("_ErrorPage");
                }
                else
                {
                    _context.Update(categoryToEdit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
  
            return View(categoryToEdit);
        }



        public async Task<IActionResult> Delete(int id)
        {
            Category categoryToDelete = await _context.Categories.FindAsync(id);

            if (categoryToDelete == null)
            {
                ViewBag.ErrorMessage = "Error!!! Invalid category ID";
                return PartialView("_ErrorPage");
            }
            else
            {
                List<Product> productsList = await _context.Products.Where(product => product.CategoryId == id).ToListAsync();
                if (productsList.Count() != 0)
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
                        product.CategoryId = null;

                        _context.Products.Update(product);
                        await _context.SaveChangesAsync();
                    }
                }

                ViewBag.CategoryDeleted = $"The Category '{categoryToDelete.Name}' was deleted!";

                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();

                return View("Index", _context.Categories.ToList());

            }

        }



        [HttpPost]
        public async Task<IActionResult> SearchCategory(string search)
        {
            string filter = "%" + search + "%";

            List<Category> categories = await _context.Categories.Where(category => EF.Functions.Like(category.Name, filter)).ToListAsync();


            return View("Index", categories);

        }


    }
}
