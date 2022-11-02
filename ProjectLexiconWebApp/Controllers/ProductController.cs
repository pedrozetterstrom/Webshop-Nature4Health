using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.ViewModels;

namespace ProjectLexiconWebApp.Controllers
{
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
            /* productsModel.Products = _dbContext.Products
                                      .Include(product => product.Brand)
                                      .Include(product => product.Category).ToList();*/
            productsModel.Products =  _dbContext.Products
                                     .Include(product => product.Category).ToList();

            return View(productsModel);
        }



        public IActionResult Create()
        {   
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name").ToList();
            return View();
        }


        [HttpPost]
        // public async Task<ActionResult>Create(CreateProductViewModel vm)
        public IActionResult Create(CreateProductViewModel vm)
        {

            ModelState.Remove("Products");
            ModelState.Remove("CategoriesList");

          
            if (ModelState.IsValid)
            {

                /* if(_dbContext.Products.Any(product => product.ProductName == vm.createProductVM.ProductName && product.BrandId == vm.createProductVM.BrandId))
                 {
                     return RedirectToAction("Index");
                 }*/
                if ( _dbContext.Products.Any(product => product.Name == vm.ProductName))
                {
                    return RedirectToAction("Index");
                }
     
                Product newProduct = new Product { Name = vm.ProductName, Description = vm.Description, UnitPrice = vm.Price, DiscountedPrice = vm.Discount, Picture = vm.Picture, Size = vm.Size, Quantity = vm.Quantity, CategoryId = vm.CategoryId };

                 _dbContext.Products.Add(newProduct);
                 _dbContext.SaveChanges();

            }

            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            Product product = _dbContext.Products.Include(product => product.Category).FirstOrDefault(p => p.Id == id);
          //  productsModel.Product = product;
          //  productsModel.CategoriesList = new SelectList(_dbContext.Categories, "Id", "Name").ToList();
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name").ToList();

            return View(product);
        }


        [HttpPost]
        //public async Task<ActionResult> Create(Product pmodel)
        public IActionResult Edit(Product pmodel)   
        {
    
            Product product =  _dbContext.Products.FirstOrDefault(prod => prod.Id == pmodel.Id);
            if(product != null)
            {
                
                product.Name = pmodel.Name;
                product.Description = pmodel.Description;
                product.UnitPrice = pmodel.UnitPrice;
                product.DiscountedPrice = pmodel.DiscountedPrice;
                product.Picture = pmodel.Picture;
                product.Size = pmodel.Size;
                product.Quantity = pmodel.Quantity;
                product.CategoryId = pmodel.CategoryId;

            }

             _dbContext.Products.Update(product);
              _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }




         public IActionResult Delete(int id)
         {

            Product product = _dbContext.Products.FirstOrDefault(product => product.Id == id);
            if(product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public IActionResult Details(int id) 
        {
            Product product = _dbContext.Products.FirstOrDefault(product => product.Id == id);
            return View(product);
        }

    }
}
