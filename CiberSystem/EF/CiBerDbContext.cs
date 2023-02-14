using CiberSystem.Entities;
using CiberSystem.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CiberSystem.EF
{
    public class CiBerDbContext : DbContext
    {
        public CiBerDbContext(DbContextOptions options) :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=CiBerDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        //    modelBuilder
           //.Entity<AppRole>(
           //    eb =>
           //    {
           //        eb.HasNoKey();             
           //    });
           modelBuilder.Seed();


        }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Customer>  Customers{ get; set; }
        public DbSet<Order>  Orders{ get; set; }
        public DbSet<Product> Products { get; set; }
      
}
}
