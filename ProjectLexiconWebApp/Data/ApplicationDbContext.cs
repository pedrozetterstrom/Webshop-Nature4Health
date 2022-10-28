﻿using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.Data
{
    public class ApplicationDbContext : DbContext
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



          /*  Brand brand1 = new Brand() { Id = 1, BrandName = "New Foods" };
            Brand brand2 = new Brand() { Id = 2, BrandName = "Holistic" };
            Brand brand3 = new Brand() { Id = 3, BrandName = "Happy Green" };
            Brand brand4 = new Brand() { Id = 4, BrandName = "RawFood" };

            modelBuilder.Entity<Brand>().HasData(brand1);
            modelBuilder.Entity<Brand>().HasData(brand2);
            modelBuilder.Entity<Brand>().HasData(brand3);
            modelBuilder.Entity<Brand>().HasData(brand4);

            Category category1 = new Category() { Id = 1, CategoryName = "Nuts and seeds" };
            Category category2 = new Category() { Id = 2, CategoryName = "Drink" };
            Category category3 = new Category() { Id = 3, CategoryName = "Tea" };
            Category category4 = new Category() { Id = 4, CategoryName = "Sweeteners" };
            Category category5 = new Category() { Id = 5, CategoryName = "Food" };

            modelBuilder.Entity<Category>().HasData(category1);
            modelBuilder.Entity<Category>().HasData(category2);
            modelBuilder.Entity<Category>().HasData(category3);
            modelBuilder.Entity<Category>().HasData(category4);
            modelBuilder.Entity<Category>().HasData(category5);


            Product p1 = new Product() { Id = 1, ProductName = "Honey", Description = "", Price = 34.5m, Discount = 0.0m, Size = "100g", Quantity = 20, ProductRate = 8, CategoryId = 4 };

            Product p2 = new Product() { Id = 2, ProductName = "Macadamia nuts", Description = "", Price = 132.35m, Discount = 0.0m, Size = "100g", Quantity = 20, ProductRate = 8, CategoryId = 1 };

            Product p3 = new Product() { Id = 3, ProductName = "Granola", Description = "", Price = 80.6m, Discount = 0.0m, Size = "500g", Quantity = 20, ProductRate = 8, CategoryId = 5 };

            Product p4 = new Product() { Id = 4, ProductName = "Chamomile", Description = "", Price = 60.00m, Discount = 0.0m, Size = "100g", Quantity = 20, ProductRate = 3, CategoryId = 3 };

            modelBuilder.Entity<Product>().HasData(p1);
            modelBuilder.Entity<Product>().HasData(p2);
            modelBuilder.Entity<Product>().HasData(p3);
            modelBuilder.Entity<Product>().HasData(p4);

            //modelBuilder.Entity<Order>()
            //    .HasMany(order => order.OrderItems)
            //    .WithOne(items => items.Product)
            //    .UsingEntity(j => j.HasData(new { OrdersId = 1, ProductsId = 2 }));


            Customer c1 = new Customer() { Id = 1, FirstName = "Pedro", LastName = "Feitoza", EMail = "user@user.com", Address = "Kungsgatan 1", ZipCode = "00000", City = "Göteborg", Phone = "46780964", CreatedAt = DateTime.Today, Wallet = 1000.0m };

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
            modelBuilder.Entity<OrderItem>().HasData(orderItem4);*/

        }

    }

}

