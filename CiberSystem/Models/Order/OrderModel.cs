using CiberSystem.EF;
using CiberSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Models.Order
{
    public class OrderModel
    {
        private readonly CiBerDbContext _context;
        public OrderModel(CiBerDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var query = from p in _context.Products
                        select p;
            int totalRow = await query.CountAsync();
            return await query.ToListAsync();
        }
        public async Task<int> GetStockByProductId(int productId)
        {
            var query = from p in _context.Products
                        where p.Id == productId
                        select p.Quantity;

            return await query.FirstOrDefaultAsync();

        }
        public async Task<bool> SubtractByProductId(int productId, int amountOrder)
        {
            try
            {
                var query = (from p in _context.Products
                             where p.Id == productId
                             select p).FirstOrDefault();
                query.Quantity = query.Quantity - amountOrder;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddOrder(int amountOrder, DateTime orderDate, int idProduct, int idCus)
        {
            try
            {
                CiberSystem.Entities.Order ord = new CiberSystem.Entities.Order
                {
                    Amount = amountOrder,
                    OverDate = orderDate,
                    CustomerId = idCus,
                    ProductId = idProduct
                };

                await _context.Orders.AddAsync(ord);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<ViewOrderResult>> GetAllOrder(int page, int pageSize, int idCus)
        {
            var query = from o in _context.Orders
                        join p in _context.Products on o.ProductId equals p.Id
                        join c in _context.Categories on o.Product.CategoryID equals c.Id
                        join cu in _context.Customers on o.CustomerId equals cu.Id
                        where o.CustomerId == idCus
                        select new { o, p, c, cu };


            var data = await query.Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => new ViewOrderResult()
                    {
                        ProductName = x.p.Name,
                        CategoryName = x.c.Description,
                        CusName = x.cu.Name,
                        OrderDate = x.o.OverDate,
                        Amount = x.o.Amount

                    }).ToListAsync();


            return data;


        }
    }
}
