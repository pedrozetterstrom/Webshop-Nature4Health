using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.ViewModels;

namespace ProjectLexiconWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        ProductsViewModel productsModel = new ProductsViewModel();


        public ProductController(ApplicationDbContext context)
        {
            _dbContext = context;
        }



        public IActionResult Index()
        {
             productsModel.Products = _dbContext.Products
                                      .Include(product => product.Brand)
                                      .Include(product => product.Category).ToList();
         
   
            return View(productsModel);
        }



        public IActionResult Create()
        {
            ViewBag.Brands = new SelectList(_dbContext.Brands, "Id", "Name").ToList();
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name").ToList();
            return View();
        }



        [HttpPost]
         public async Task<IActionResult>Create(CreateProductViewModel vm)
         {

            ModelState.Remove("Products");
            ModelState.Remove("CategoriesList");

          
            if (ModelState.IsValid)
            {

                 if(_dbContext.Products.Any(product => product.Name == vm.ProductName && product.Size == vm.Size))
                 {
                    ViewBag.ErrorMessage = $"Error!!! Product with name {vm.ProductName} and size: {vm.Size} is already in the product list!";
                    return PartialView("_ErrorPage");
                 }
             
                Product newProduct = new Product { Name = vm.ProductName, Description = vm.Description, UnitPrice = vm.Price, DiscountedPrice = vm.Discount, Picture = vm.Picture, Size = vm.Size, Quantity = vm.Quantity, BrandId = vm.BrandId, CategoryId = vm.CategoryId };

                 _dbContext.Products.Add(newProduct);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            ViewBag.Brands = new SelectList(_dbContext.Brands, "Id", "Name").ToList();
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name").ToList();
            return View(vm);
        }



        public IActionResult Edit(int id)
        {
            Product product = _dbContext.Products.Include(product => product.Category).FirstOrDefault(p => p.Id == id);

            ViewBag.Brands = new SelectList(_dbContext.Brands, "Id", "Name").ToList();
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name").ToList();

            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult>Edit(Product pmodel)
        {

            if (ModelState.IsValid)
            {
                if (_dbContext.Products.Any(product => product.Name == pmodel.Name && product.Size == pmodel.Size && product.Id != pmodel.Id))
                {
                    ViewBag.ErrorMessage = $"Error!!! Product with name: {pmodel.Name} and size: {pmodel.Size} is already in the product list!";
                    return PartialView("_ErrorPage");
                }

                Product product = _dbContext.Products.FirstOrDefault(prod => prod.Id == pmodel.Id);
                if (product != null)
                {

                    product.Name = pmodel.Name;
                    product.Description = pmodel.Description;
                    product.UnitPrice = pmodel.UnitPrice;
                    product.DiscountedPrice = pmodel.DiscountedPrice;
                    product.Picture = pmodel.Picture;
                    product.Size = pmodel.Size;
                    product.Quantity = pmodel.Quantity;
                    product.BrandId = pmodel.BrandId;
                    product.CategoryId = pmodel.CategoryId;

                }
                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.Brands = new SelectList(_dbContext.Brands, "Id", "Name").ToList();
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name").ToList();
            return View(pmodel);

        }



        public IActionResult Delete(int id)
        {

            Product product = _dbContext.Products.FirstOrDefault(product => product.Id == id);
            if(product != null)
            {
                 _dbContext.Products.Remove(product);
                 _dbContext.SaveChanges();
                 return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Error!!! Product Not Found";
                return PartialView("_ErrorPage");
            }
        }

    }
}
