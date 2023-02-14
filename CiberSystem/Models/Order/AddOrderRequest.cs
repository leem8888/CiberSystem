using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Models.Order
{
    public class AddOrderRequest
    {
        public string nameOrder { get; set; }
        public int idProduct { get; set; }
        public string nameProduct { get; set; }
        public DateTime orderDate { get; set; }
        public int amountOrder { get; set; }
    }
}
