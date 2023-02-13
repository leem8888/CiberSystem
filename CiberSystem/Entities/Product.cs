using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
    }
}
