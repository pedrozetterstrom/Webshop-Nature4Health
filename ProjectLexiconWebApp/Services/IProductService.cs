using System;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.Models.APIModels;

namespace ProjectLexiconWebApp.Services
{
    public interface IProductService
    {

        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductByName(string productName);
        Task<IEnumerable<ProductModel>> GetProductsByName(string producName);
        Task<Product> CreateProduct(ProductModel product);
       // Task<ProductModel> EditProduct(ProductModel product);
       // Task DeleteProduct(ProductModel product);



    }
}

