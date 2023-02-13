using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime OverDate { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
