using Microsoft.EntityFrameworkCore;
using ASPWebNETCoreAPI.Models;

namespace ASPWebNETCoreAPI.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic Items",
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothes",
                    Description = "Dresses",
                },
                new Category
                {
                    Id = 3,
                    Name = "Grocery",
                    Description = "Grocery Items",
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Apple",
                    Description = "Buy Apple",
                    Price = 100,
                    CategoryId = 5

                },
                new Product
                {
                    Id = 2,
                    Name = "Orange",
                    Description = "Buy Orange",
                    Price = 100,
                    CategoryId = 6
                },
                new Product
                {
                    Id = 3,
                    Name = "Banana",
                    Description = "Buy Banana",
                    Price = 100,
                    CategoryId = 7
                }
            );;


        }




    }
}