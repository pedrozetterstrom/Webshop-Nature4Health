using Microsoft.AspNetCore.Mvc;

namespace ProjectLexiconWebApp.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //Calculate numbers of item in cart
            Dictionary<int, int> cartDictionary = CreateCartDicFromSessionData();
            if (cartDictionary == null)
            {
                ViewBag.CountNumberItemInCart = 0;
            }
            else
            {
                int totalItemInCart = 0;
                foreach (var item in cartDictionary)
                {
                    int key = item.Key;         //Aka product ID
                    int value = item.Value;     //Count proucts of that ID

                    totalItemInCart += value;
                }
                ViewBag.CountNumberItemInCart = totalItemInCart;
            }

            //ViewBag.CountNumberItemInCart = 5;
            return View();
        }


        //Copy paste in action...DRY not implemented
        private Dictionary<int, int> CreateCartDicFromSessionData()
        {
            string sessionString = HttpContext.Session.GetString("CurrentCustomerCart");
            if (sessionString != null)
            {
                List<string> splittedWords = sessionString.Split('|').ToList();
                var removedLastItemFromSplittedWords = splittedWords.SkipLast(1);

                List<int> listOfValidProductId = new List<int>();
                foreach (string item in removedLastItemFromSplittedWords)
                {
                    int validId = Int32.Parse(item);
                    listOfValidProductId.Add(validId);
                }

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
            else
                return null;

        }
    }
}
