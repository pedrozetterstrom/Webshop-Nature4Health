using Microsoft.AspNetCore.Mvc;
using ProjectLexiconWebApp.Data;
using System.Collections.Generic;
using ProjectLexiconWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Http;
using ProjectLexiconWebApp.ViewModels;
using System.Security.Policy;

namespace ProjectLexiconWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        //The session file stores the value of productsId in format
        // 1|4|1|2|1|
        //The function returns a Dictionary in form
        //productId -> countProducts
        //1 -> 3
        //4 -> 1
        //2 -> 1
        private Dictionary<int, int> CreateCartDicFromSessionData() 
        {
            // 1|4|1|2|1
            string sessionString = HttpContext.Session.GetString("CurrentCustomerCart");
            //string sessionString = "1|4|1|2|1|";
            // "1" "4" "1" "2" "1" ""
            List<string> splittedWords = sessionString.Split('|').ToList();
            // "1" "4" "1" "2" "1" 
            var removedLastItemFromSplittedWords = splittedWords.SkipLast(1);

            List<int> listOfValidProductId = new List<int>();
            foreach (string item in removedLastItemFromSplittedWords)
            {
                int validId = Int32.Parse(item);
                listOfValidProductId.Add(validId);
            }            
            // 1 4 1 2 1
            // listOfValidProductId
                        

            Dictionary<int, int> cartDictionary = new Dictionary<int, int>();

            foreach (int aValidID in listOfValidProductId)
            {
                if (cartDictionary.ContainsKey(aValidID)) 
                {
                    int value = cartDictionary[aValidID];
                    value++;
                    cartDictionary[aValidID] = value;


                }
                else 
                {
                    cartDictionary.Add(aValidID, 1);
                }
            }

            return cartDictionary;
           

        }

        //Show current Shopping Cart items
        public IActionResult Index()
        {            
            List<ShoppingCartViewModel> listShoppingCartViewModels = new List<ShoppingCartViewModel>();                       

            Dictionary<int, int> cartDictionary = CreateCartDicFromSessionData();
            Decimal totalPriceOfCart = 0.0M;

            foreach (var item in cartDictionary) 
            {
                int key = item.Key;         //Aka product ID
                int value = item.Value;     //Count proucts of that ID

                Product myProduct = _context.Products.FirstOrDefault(prospectProduct => prospectProduct.Id == key);

                ShoppingCartViewModel myShoppingViewModel = new ShoppingCartViewModel
                {
                    Id = key,
                    //Picture = "~/images/honey.png",
                    //Picture = myProduct.Picture,                    
                    Picture = "../images/"+myProduct.Picture,
                    Quantity = value,
                    //ProductName = _context.Products.FirstOrDefault(prospectProduct => prospectProduct.Id == key).Name,
                    ProductName = myProduct.Name,
                    //UnitPrice = _context.Products.FirstOrDefault(prospectProduct => prospectProduct.Id == key).UnitPrice,
                    UnitPrice = myProduct.UnitPrice,
                    //Size = _context.Products.FirstOrDefault(prospectProduct => prospectProduct.Id == key).Size
                    Size = myProduct.Size
                };
                totalPriceOfCart += (myShoppingViewModel.Quantity * myShoppingViewModel.UnitPrice);
                listShoppingCartViewModels.Add(myShoppingViewModel);                             
            }

            //This one works    
            //shoppingCartViewModels.Add(new ShoppingCartViewModel 
            //{
            //    Id=1, Picture= "~/images/honey.png", Quantity=3, ProductName="Manuka Honey", UnitPrice=95.0M
            //});

            ViewBag.TotalCost = totalPriceOfCart.ToString("c");
            ViewBag.SessionString = HttpContext.Session.GetString("CurrentCustomerCart");
            return View(listShoppingCartViewModels);
        }

        //Adds ONE 'product id' to session string
        public IActionResult AddToCart(int id) 
        {
            Product productToAdd = _context.Products.FirstOrDefault(prospectProduct => prospectProduct.Id == id);

            string currentSessionString = HttpContext.Session.GetString("CurrentCustomerCart");
            
            string sessionStringToInsert = productToAdd.Id + "|";

            currentSessionString += sessionStringToInsert;

            HttpContext.Session.SetString("CurrentCustomerCart", currentSessionString);

            return RedirectToAction("Index");
        }

        //Removes ONE 'product id' to session string
        public IActionResult RemoveFromCart(int id)
        {
            string currentSessionString = HttpContext.Session.GetString("CurrentCustomerCart");

            List<string> listOfWords = currentSessionString.Split('|').ToList();
            var removedLastItem = listOfWords.SkipLast(1);

            List<int> validProductId = new List<int>();

            foreach (string word in removedLastItem) 
            {
                int idProduct = Int32.Parse(word);
                validProductId.Add(idProduct);
            }

            validProductId.Remove(id);

            StringBuilder sessionString = new StringBuilder();
            foreach (int validIdfoo in validProductId)
            {
                sessionString.Append(validIdfoo.ToString() + "|");
            }

            HttpContext.Session.SetString("CurrentCustomerCart", sessionString.ToString());

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart() 
        {
            HttpContext.Session.SetString("CurrentCustomerCart", "");

            return RedirectToAction("Index");
        }
    }
}
