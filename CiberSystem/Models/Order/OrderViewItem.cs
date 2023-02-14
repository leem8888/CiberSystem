using CiberSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Models.Order
{
    public class OrderViewItem
    {
        public List<Product> Products { get; set; }
        public string NameCus { get; set; }
        public List<ViewOrderResult> Orders { get; set; }
    }
}
