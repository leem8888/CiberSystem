using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Models.Order
{
    public class ViewOrderResult
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CusName { get; set; }
        public DateTime OrderDate { get; set; }
        public int   Amount { get; set; }
    }
}
