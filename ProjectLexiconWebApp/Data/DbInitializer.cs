using ProjectLexiconWebApp.Models;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace ProjectLexiconWebApp.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            ApplicationDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
            //Will only seed if empty
            //if (!context.Users.Any())
            //{
            //    context.AddRange
            //    (
            //        new Customer { FirstName="Daniel", LastName="Oikarainen", EMail="daniel@oikarainen.se", BirthDate = new DateTime(1979,12,16), Country="Sweden", City="Borås", ZipCode = "506 44", Address="Lindormsgatan 17", CellPhoneNumber="0704-911852"},
            //        new Customer { FirstName = "Scrooge", LastName = "McDuck", EMail = "clan@mcduck.com", BirthDate = new DateTime(1959, 6, 23), Country = "DuckyLand", City = "Ducktown", ZipCode = "121 11", Address = "Moneystreet 99", CellPhoneNumber = "999-99999" },
            //        new Customer { FirstName = "Joker", LastName = "Villain", EMail = "super@villain.se", BirthDate = new DateTime(1985, 2, 12), Country = "U.S", City = "Gotham City", ZipCode = "123 89", Address = "Jokerstreet 666", CellPhoneNumber = "666-666666" }
            //    );

            //    //Add the cahnges to the DB
            //    context.SaveChanges();
            //}

            //if (!context.Products.Any())
            //{
            //    context.AddRange
            //    (
            //        new Product { Name = "Vitamin-D", Description="Refill and protect your health with vitamin-D", Price = 205.95M , Stock=400, CreatedAt= DateTime.Now, ReviewStars=4.9 },
            //        new Product { Name = "Protein", Description = "Want big Muscle? Eat me!", Price = 121.95M, Stock = 166, CreatedAt = DateTime.Now, ReviewStars = 2.9 },
            //        new Product { Name = "Omega-6", Description = "Don't like fish? Try this insteed", Price = 195.0M, Stock = 99, CreatedAt = DateTime.Now, ReviewStars = 3.9 }
            //    );

            //    //Add the cahnges to the DB
            //    context.SaveChanges();
            //}
        }
    }
}
