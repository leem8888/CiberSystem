using CiberSystem.EF;
using CiberSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Models.Login
{
    public class LoginModel
    {
        private readonly CiBerDbContext _context;
        public LoginModel(CiBerDbContext context)
        {
            _context = context;
        }
        public async Task <Customer> FindByNameAsync(string phone)
        {
            var result = await  _context.Customers.Where(x => x.Phone == phone).SingleOrDefaultAsync();
            return result;
        }
        public async Task<bool> PasswordSignInAsync(Customer customer, string pass)
        {
            var result = await _context.Customers.Where(x => x.Phone == customer.Phone&& x.Pass==pass).SingleOrDefaultAsync();
            return result!=null ?true :false;
        }
    }
}
