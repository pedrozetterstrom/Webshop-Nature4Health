using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.ViewModels;
using System.Text;

namespace ProjectLexiconWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                    Picture = "../images/" + myProduct.Picture,
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

        //Consideration
        //Validation
        //1. Enough $$$ of customer
        //2. Enough products in stock?
        //3. Customer logged in
        //4. 
        //[HttpPost]

        public static ReceiptViewModel model = new();
        public IActionResult PlaceAnOrder()
        {
            Order newOrder = new()
            {
                OrderDate = DateTime.Now,
                Status = "pending"
            };
            Customer currentCustomer = new();
            ViewBag.Shippers = new SelectList(_context.Shippers, "Id", "Name", "Orders");

            string currentSessionString = HttpContext.Session.GetString("CurrentCustomerCart");
            Dictionary<int, int> cartDictionary = CreateCartDicFromSessionData();

            foreach (var item in cartDictionary)
            {
                int currentProductIdInCart = item.Key;         //Aka product ID
                int currentCountProductInCart = item.Value;     //Count products of that ID

                Product myProduct = _context.Products.FirstOrDefault(product => product.Id == currentProductIdInCart);

                //Not enough product(s) in stock
                if (currentCountProductInCart > myProduct.Quantity)
                {
                    return View("Denied", $"Unfortunately, there are only {myProduct.Quantity} units left of {myProduct}");
                }
                else
                {
                    OrderItem newOrderItem = new OrderItem
                    {
                        OrderId = newOrder.Id,
                        ProductId = myProduct.Id,
                        //Product = myProduct,
                        Quantity = currentCountProductInCart
                    };
                    newOrder.OrderItems.Add(newOrderItem);
                }
            }

            model.Order = newOrder;

            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
                if (_context.Customers.FirstOrDefault(c => c.UserId == user.Id) != null)
                {
                    currentCustomer = _context.Customers.FirstOrDefault(c => c.UserId == user.Id);
                }
                else
                {
                    currentCustomer.FirstName = user.FirstName;
                    currentCustomer.LastName = user.LastName;
                    currentCustomer.Address = user.Address;
                    currentCustomer.ZipCode = user.ZipCode;
                    currentCustomer.City = user.City;
                    currentCustomer.Phone = user.Phone;
                    currentCustomer.EMail = user.Email;
                    currentCustomer.CreatedAt = DateTime.Now;
                    currentCustomer.UserId = user.Id;
                    currentCustomer.Wallet = 0.0m;
                    _context.Customers.Add(currentCustomer);
                    _context.SaveChanges();
                }


            }
            else
            {
                return View("CustomerInformation", model);
            }

            newOrder.Customer = currentCustomer;
            newOrder.CustomerId = currentCustomer.Id;
            model.Customer = currentCustomer;

            return View("CustomerInformation", model);

        }

        [HttpPost]
        public IActionResult CustomerInformation(Customer currentCustomer, int shipper)
        {
            if (_context.Customers.FirstOrDefault(c => c.EMail == currentCustomer.EMail) != null)
            {
                currentCustomer = _context.Customers.FirstOrDefault(c => c.EMail == currentCustomer.EMail);
            }
            else
            {
                currentCustomer.CreatedAt = DateTime.Now;
                currentCustomer.Wallet = 0.0m;
                _context.Customers.Add(currentCustomer);
                _context.SaveChanges();
            }
            
            model.Order.ShipperId = shipper;
            //model.Order.Shipper =  _context.Shippers.FirstOrDefault(s => s.Id == shipper);

            return RedirectToAction("RegisterOrder", currentCustomer);
        }

        public IActionResult RegisterOrder(Customer currentCustomer)
        {

            string currentSessionString = HttpContext.Session.GetString("CurrentCustomerCart");
            Dictionary<int, int> cartDictionary = CreateCartDicFromSessionData();

            model.Customer = currentCustomer;
            //model.Order.Customer = currentCustomer;
            model.Order.CustomerId = currentCustomer.Id;

            _context.Orders.Add(model.Order);
            _context.SaveChanges();


            foreach (var item in model.Order.OrderItems)
            {
                //int currentProductIdInCart = item.Key;         //Aka product ID
                //int currentCountProductInCart = item.Value;     //Count products of that ID

                Product myProduct = _context.Products.FirstOrDefault(product => product.Id == item.ProductId);

                //Not enough product(s) in stock
                if (item.Quantity > myProduct.Quantity)
                {
                    return View("Denied", $"Unfortunately, there are only {myProduct.Quantity} units left of {myProduct}");
                }
                else
                {
                    //remove currentCountProductInCart cartItem(s) from db products
                    //Update product database database(s) here
                    //Lager saldo
                    myProduct.Quantity -= item.Quantity;
                    _context.Update(myProduct);
                    _context.SaveChanges();

                    item.OrderId = model.Order.Id;
                    item.ProductId = myProduct.Id;

                    _context.OrderItems.Update(item);
                    _context.SaveChanges();
                }
            }

            ClearCart();

            return View("CheckOut", model);
        }

        public IActionResult Receipt()
        {
            return View();
        }

        public int ItemCartCount()
        {
            int count = 0;

            Dictionary<int, int> cartDictionary = CreateCartDicFromSessionData();
            foreach (var item in cartDictionary)
            {
                int currentProductIdInCart = item.Key;         //Aka product ID
                int currentCountProductInCart = item.Value;     //Count products of that ID

                count += currentCountProductInCart;
            }

            Console.WriteLine("Current items in cart: " + count);

            return count;
        }

        public bool IsCartEmpty()
        {
            return ItemCartCount() <= 0 ? true : false;
        }
    }
}
