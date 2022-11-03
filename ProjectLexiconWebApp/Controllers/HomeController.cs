using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using System.Diagnostics;

namespace ProjectLexiconWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _context;
        private readonly string cartId;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;

            //if (string.IsNullOrEmpty(cartId)) 
            //{
            //    cartId = Guid.NewGuid().ToString();
            //}
            
        }

        public IActionResult Index()
        {            
            IEnumerable<Product> allProducts = _context.Products.ToList();


            return View(allProducts);
        }

        public IActionResult AddToShoppingCart(int id) 
        {
            Product productToAdd = _context.Products.FirstOrDefault(prospectProduct => prospectProduct.Id == id);
           
            string currentSessionString = HttpContext.Session.GetString("CurrentCustomerCart");

            //string sessionStringToInsert = productToAdd.Id + "|" + productToAdd.Name + "|" + productToAdd.UnitPrice + "|" + productToAdd.Size + "\n" + "|";
            string sessionStringToInsert = productToAdd.Id + "|";

            currentSessionString += sessionStringToInsert;
           
            //Create a unique id for each cart
            HttpContext.Session.SetString("CurrentCustomerCart", currentSessionString);

            //string updatedSessionString = HttpContext.Session.GetString("CurrentCustomerCart");

            //Console.WriteLine("Current value from session string----------------------");
            //Console.WriteLine(updatedSessionString);

            //return RedirectToAction("Index");
            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}