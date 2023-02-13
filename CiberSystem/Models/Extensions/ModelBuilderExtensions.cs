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
            new Product() { Id = 4, Name = "Laptop MSI Gaming GF63", Price = 100000, Description = "the description of Laptop MSI Gaming GF63", Quantity = 20, CategoryID = 3 }
            );
            modelBuilder.Entity<AppRole>().HasData(
             new AppRole() { Id = 1, Description = "admin" },
            new AppRole() { Id = 2, Description = "user" }
          );
            modelBuilder.Entity<Customer>().HasData(
          new Customer() { Id = 1, Name = "Tuấn", Phone = "0353590123", Pass = "abcd1234", Address = "Phú thọ", RoleId = 1 },
          new Customer() { Id = 2, Name = "Trang", Phone = "0888888880", Pass = "abcd1234@", Address = "China", RoleId = 2 }

          );

        }
    }
}
