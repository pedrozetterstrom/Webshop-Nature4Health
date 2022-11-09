using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.Models.APIModels;

namespace ProjectLexiconWebApp.Services
{
    public class ProductsServices : IProductService
    {
        private readonly ApplicationDbContext _appContext;

        public ProductsServices(ApplicationDbContext context)
        {
            _appContext = context;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> productslist = await _appContext.Products
                    .Include(product => product.Brand)
                    .Include(product => product.Category).ToListAsync();

                List<ProductModel> productsList = new List<ProductModel>();
                foreach(var product in productslist)
                {
                    ProductModel productmodel = new ProductModel { Id = product.Id, Name = product.Name, Description = product.Description, UnitPrice = product.UnitPrice, DiscountedPrice = product.DiscountedPrice, Picture = product.Picture, Size = product.Size, ProductRate = product.ProductRate, InStock = product.InStock.ToString(), BrandName = product.Brand?.Name, CategoryName = product.Category?.Name };

                    productsList.Add(productmodel);
                }
                return productsList;

            }
            catch
            {
                throw;
            }
        }


          public async Task<ProductModel> GetProductByName(string productName)
          {
            var filter = "%" + productName + "%";

            Product product = await _appContext.Products
                .Include(product => product.Brand)
                .Include(product => product.Category).Where(product => EF.Functions.Like(product.Name, filter)).FirstAsync();

            ProductModel productmodel = new ProductModel { Id = product.Id, Name = product.Name, Description = product.Description, UnitPrice = product.UnitPrice, DiscountedPrice = product.DiscountedPrice, Picture = product.Picture, Size = product.Size, ProductRate = product.ProductRate, InStock = product.InStock.ToString(), BrandName = product.Brand?.Name, CategoryName = product.Category?.Name };

            return productmodel;

          }


        public async Task<IEnumerable<ProductModel>> GetProductsByName(string productName)
        {
            
            var filter = "%" + productName + "%";

             IEnumerable<Product> products = await _appContext.Products
               .Include(product => product.Brand)
               .Include(product => product.Category).Where(product => EF.Functions.Like(product.Name, filter)).ToListAsync();

             List<ProductModel> productslist = new List<ProductModel>();

            if (!string.IsNullOrWhiteSpace(productName))
            {
                foreach (var product in products)
                {
                    ProductModel productmodel = new ProductModel { Id = product.Id, Name = product.Name, Description = product.Description, UnitPrice = product.UnitPrice, DiscountedPrice = product.DiscountedPrice, Picture = product.Picture, Size = product.Size, ProductRate = product.ProductRate, InStock = product.InStock.ToString(), BrandName = product.Brand?.Name, CategoryName = product.Category?.Name };

                    productslist.Add(productmodel);

                }
                return productslist;
            }
            else
            {
                productslist = await GetAllProducts();
            }
            return productslist;       
        }
 

        public async Task<Product> CreateProduct(ProductModel product)
        {
           
            try
            {
                Product newProduct = new Product();
                if (!_appContext.Products.Any(p => p.Name == product.Name))
                {
                    newProduct.Name = product.Name;
                    newProduct.Description = product.Description;
                    newProduct.UnitPrice = product.UnitPrice;
                    newProduct.DiscountedPrice = product.DiscountedPrice;
                    newProduct.Picture = product.Picture;
                    newProduct.Size = product.Size;
                    newProduct.Quantity = product.Quantity;
                    newProduct.ProductRate = product.ProductRate;
                    newProduct.BrandId = _appContext.Brands.Where(brand => brand.Name == product.BrandName).First().Id;
                    newProduct.CategoryId = _appContext.Categories.Where(category => category.Name == product.CategoryName).First().Id;

                    _appContext.Products.Add(newProduct);
                    await _appContext.SaveChangesAsync();
                }
          
                return newProduct;
            }
            catch
            {
                throw;
            }
        }





    }
}

