using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime OverDate { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
