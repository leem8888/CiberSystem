using CiberSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Models.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
             new Category() { Id = 1, Description = "Điện Thoại" },
             new Category() { Id = 2, Description = "Máy Tính" },
             new Category() { Id = 3, Description = "Laptop" },
             new Category() { Id = 4, Description = "Phụ Kiện" }
             );
            modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Galaxy S23 Series", Price = 100000, Description = "the description of Galaxy S23 Series", Quantity = 10, CategoryID = 1 },
            new Product() { Id = 2, Name = "Xiaomi Redmi 10A 3GB-64GB", Price = 100000, Description = "the description of Xiaomi Redmi 10A 3GB-64GB", Quantity = 20, CategoryID = 1 },
            new Product() { Id = 3, Name = "Laptop Asus TUF Gaming FX506LHB", Price = 100000, Description = "the description of Laptop Asus TUF Gaming FX506LHB", Quantity = 20, CategoryID = 3 },
            new Product() { Id = 4, Name = "Laptop MSI Gaming GF63", Price = 100000, Description = "the description of Laptop MSI Gaming GF63", Quantity = 20, CategoryID = 3 },
            new Product() { Id = 5, Name = "iPad Gen 9 2021", Price = 100000, Description = "the description of iPad Gen 9 2021", Quantity = 20, CategoryID = 2 },
            new Product() { Id = 6, Name = "Samsung Galaxy Z Fold3", Price = 1000000, Description = "the description of Samsung Galaxy Z Fold3", Quantity = 20, CategoryID = 1 },
            new Product() { Id = 7, Name = "iPad mini 6", Price = 100000, Description = "the description of iPad mini 6", Quantity = 20, CategoryID = 2 },
            new Product() { Id = 8, Name = "Laptop MSI Modern 14", Price = 100000, Description = "the description of Laptop MSI Modern 14", Quantity = 20, CategoryID = 3 },
            new Product() { Id = 9, Name = "Laptop MSI Gaming GF63", Price = 100000, Description = "the description of Laptop MSI Gaming GF63", Quantity = 20, CategoryID = 4 }
            );
          
            modelBuilder.Entity<Customer>().HasData(
          new Customer() { Id = 1, Name = "Tuấn", Phone = "0353590123", Pass = "abcd1234", Address = "Phú thọ" },
          new Customer() { Id = 2, Name = "Trang", Phone = "0888888880", Pass = "abcd1234@", Address = "China" }

          );

        }
    }
}
