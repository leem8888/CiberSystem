using CiberSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.EF
{
    public class DBInitial
    {
        private readonly CiBerDbContext _context;
        public DBInitial(CiBerDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            try
            {

                if (!_context.Categories.Any())
                {
                    _context.Categories.AddRange(new List<Category>()
                    {
                        new Category() { Id = 1, Description = "Điện Thoại" },
                        new Category() { Id = 2, Description = "Máy Tính" },
                        new Category() { Id = 3, Description = "Laptop" },
                        new Category() { Id = 4, Description = "Phụ Kiện" }
                    });
                }
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
    
