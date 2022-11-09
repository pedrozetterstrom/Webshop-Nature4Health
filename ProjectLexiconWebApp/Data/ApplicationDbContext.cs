using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            Brand brand1 = new Brand() { Id = 1, Name = "New Foods" };
            Brand brand2 = new Brand() { Id = 2, Name = "Holistic" };
            Brand brand3 = new Brand() { Id = 3, Name = "Happy Green" };
            Brand brand4 = new Brand() { Id = 4, Name = "RawFood" };

            modelBuilder.Entity<Brand>().HasData(brand1);
            modelBuilder.Entity<Brand>().HasData(brand2);
            modelBuilder.Entity<Brand>().HasData(brand3);
            modelBuilder.Entity<Brand>().HasData(brand4);

            Category category1 = new Category() { Id = 1, Name = "Nuts and seeds" };
            Category category2 = new Category() { Id = 2, Name = "Drink" };
            Category category3 = new Category() { Id = 3, Name = "Tea" };
            Category category4 = new Category() { Id = 4, Name = "Sweeteners" };
            Category category5 = new Category() { Id = 5, Name = "Food" };

            modelBuilder.Entity<Category>().HasData(category1);
            modelBuilder.Entity<Category>().HasData(category2);
            modelBuilder.Entity<Category>().HasData(category3);
            modelBuilder.Entity<Category>().HasData(category4);
            modelBuilder.Entity<Category>().HasData(category5);


            Product p1 = new Product() { Id = 1, Name = "Honey", Description = "Sweet and good for your body. Perfect combo with tea.", UnitPrice = 34.5m, DiscountedPrice = 0.0m, Size = "100g", Quantity = 20, ProductRate = 8, CategoryId = 4, BrandId = 1 , Picture= "honey-main.png" };

            Product p2 = new Product() { Id = 2, Name = "Macadamia nuts", Description = "De extra stora macadamia nötterna är torrostade och smaksatta med en liten gnutta havssalt. Torrostningen framhäver den fina nötsmaken och gör dem lagom knapriga. Macadamianötter är en av de fetaste nötterna och är rika på omega fettsyror, protein samt fibrer och en del mineraler.", UnitPrice = 132.35m, DiscountedPrice = 0.0m, Size = "100g", Quantity = 20, ProductRate = 8, CategoryId = 1, BrandId = 2, Picture = "macadamina-main.png" };

            Product p3 = new Product() { Id = 3, Name = "Granola", Description = "Starta dagen med den smakrika och knapriga granolan från Clean Eating. Gjord på naturliga ingredienser utan tillsatser. Clean Eating Granola är ugnsrostad i kokosolja och sötad med honung och juice från frukter som ger en naturligt god och söt smak. Granolan passar både stora som små i familjen, och är ett nyttigare och godare alternativ till frukosten eller mellanmålet. Clean Eating Granola finns i tre goda smaker som passar de flesta smaklökar!", UnitPrice = 80.6m, DiscountedPrice = 0.0m, Size = "500g", Quantity = 20, ProductRate = 8, CategoryId = 5, BrandId = 3, Picture = "granola-main.png" };

            Product p4 = new Product() { Id = 4, Name = "Chamomile", Description = "Örtagubben Kamomill (Matricaria recutita) består av torkade kamomillblommor från ekologisk odling. Kamomill har en aromatisk doft och en milt bitter smak som många uppskattar. Kamomill är en välbekant blomma i den svenska floran, och en vanlig ört att använda i örtteer. Drick en kopp kamomillte på kvällen när du vill lugna ner dig och komma till ro inför natten. Kamomill är en ettårig, aromatiskt doftande ört som kan bli upp till fyra decimeter hög. Blomkorgarna är prästkragelika och sitter på långa skaft. Kamomill är ett ogräs som förekommer tämligen allmänt upp till Gästrikland och blommar från juni till oktober. Ursprungligen hör den hemma i södra och östra Europa men är numera spridd i nästan hela Europa, såväl som i Kanada och USA.", UnitPrice = 60.00m, DiscountedPrice = 0.0m, Size = "100g", Quantity = 20, ProductRate = 3, CategoryId = 3, BrandId = 4, Picture = "chamomile-main.png" };

            modelBuilder.Entity<Product>().HasData(p1);
            modelBuilder.Entity<Product>().HasData(p2);
            modelBuilder.Entity<Product>().HasData(p3);
            modelBuilder.Entity<Product>().HasData(p4);

            //modelBuilder.Entity<Order>()
            //    .HasMany(order => order.OrderItems)
            //    .WithOne(items => items.Product)
            //    .UsingEntity(j => j.HasData(new { OrdersId = 1, ProductsId = 2 }));


            Customer c1 = new Customer() { Id = 1, FirstName = "Pedro", LastName = "Feitoza", EMail = "user@user.com", Address = "Kungsgatan 1", ZipCode = "00000", City = "Göteborg", Phone = "46780964", CreatedAt = DateTime.Today, Wallet = 1000.0M };

            modelBuilder.Entity<Customer>().HasData(c1);


            Order order1 = new Order() { Id = 1, OrderDate = DateTime.Today, Status = "pending", CustomerId = 1 };


            OrderItem orderItem1 = new OrderItem() { Id = 1, OrderId = order1.Id, ProductId = p1.Id, Quantity = 2 };
            OrderItem orderItem2 = new OrderItem() { Id = 2, OrderId = order1.Id, ProductId = p2.Id, Quantity = 2 };
            OrderItem orderItem3 = new OrderItem() { Id = 3, OrderId = order1.Id, ProductId = p3.Id, Quantity = 3 };
            OrderItem orderItem4 = new OrderItem() { Id = 4, OrderId = order1.Id, ProductId = p4.Id, Quantity = 2 };

            modelBuilder.Entity<Order>().HasData(order1);
            modelBuilder.Entity<OrderItem>().HasData(orderItem1);
            modelBuilder.Entity<OrderItem>().HasData(orderItem2);
            modelBuilder.Entity<OrderItem>().HasData(orderItem3);
            modelBuilder.Entity<OrderItem>().HasData(orderItem4);

            //Seed shipper table
            modelBuilder.Entity<Shipper>().HasData
            (
                new Shipper { Id = 1, Name = "PostNord" },
                new Shipper { Id = 2, Name = "DHL" },
                new Shipper { Id = 3, Name = "DB Schenker" }
            );

            // ------------------------------------- Roles guid

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@n4h.com",
                NormalizedEmail = "ADMIN@N4H.COM",
                UserName = "admin@n4h.com",
                NormalizedUserName = "ADMIN@N4H.COM",
                FirstName = "Daniel",
                LastName = "O.",
                Address = "Adminsgatan 1",
                ZipCode = "10001",
                City = "Borås",
                Phone = "10101010101",
                PasswordHash = hasher.HashPassword(null, "password")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId
            });

            //Customer c2 = new Customer() { Id = 2, FirstName = "Customer Test", LastName = "Karlsson", EMail = "user@n4h.com", Address = "Kundsgatan 1", ZipCode = "10001", City = "Göteborg", Phone = "46780964", CreatedAt = DateTime.Today, Wallet = 1000.0M };

            //modelBuilder.Entity<Customer>().HasData(c2);

            //Order order2 = new Order() { Id = 2, OrderDate = DateTime.Today, Status = "pending", CustomerId = 2 };


            //OrderItem item1 = new OrderItem() { Id = 5, OrderId = order2.Id, ProductId = p1.Id, Quantity = 2 };
            //OrderItem item2 = new OrderItem() { Id = 6, OrderId = order2.Id, ProductId = p2.Id, Quantity = 2 };
            //OrderItem item3 = new OrderItem() { Id = 7, OrderId = order2.Id, ProductId = p3.Id, Quantity = 3 };
            //OrderItem item4 = new OrderItem() { Id = 8, OrderId = order2.Id, ProductId = p4.Id, Quantity = 2 };

            //modelBuilder.Entity<Order>().HasData(order2);
            //modelBuilder.Entity<OrderItem>().HasData(item1);
            //modelBuilder.Entity<OrderItem>().HasData(item2);
            //modelBuilder.Entity<OrderItem>().HasData(item3);
            //modelBuilder.Entity<OrderItem>().HasData(item4);
        }


    }

}

