using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectLexiconWebApp.Models.APIModels;
using ProjectLexiconWebApp.Services;

namespace ProjectLexiconWebApp.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {


        private IProductService _productService;

        public ProductsAPIController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ProductModel>>> GetProducts()
        {
            try
            {
                var productslist = await _productService.GetAllProducts();
                return Ok(productslist);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while trying to return the products list");
            }


        }



        [HttpGet("name", Name = "GetProduct")]
        public async Task<ActionResult<ProductModel>> GetProduct(string name)
        {

            try
            {
                var product = await _productService.GetProductByName(name);
                if(product == null)
                {
                    return NotFound($"Product with name = {name} was not found!");
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest("Invalid Request");
            }


        }



        [HttpGet("ProductsByName")]
        public async Task<ActionResult<IAsyncEnumerable<ProductModel>>> GetProductsByName([FromQuery] string productName)
        {
            try
            {
                var products = await _productService.GetProductsByName(productName);
                if(products.Count() == 0)
                {
                    return NotFound($"No products with name {productName}");
                }
                return Ok(products);
            }
            catch
            {
                return BadRequest("Invalid Request");

            }

        }


        [HttpPost("Post")]
        public async Task<ActionResult<ProductModel>> CreateProduct([FromBody] ProductModel product)
        {

            try
            {
                if(product != null)
                {
                    await _productService.CreateProduct(product);
                    return CreatedAtRoute(nameof(GetProduct), new {name = product.Name }, product);
                }
                else
                {
                    return BadRequest("The product data was inconsistent!");
                }
            }
            catch
            {
                return BadRequest("Invalid Request");
            }

        }






        }
}

