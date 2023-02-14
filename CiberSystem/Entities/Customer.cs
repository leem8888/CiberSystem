using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Entities
{
    [Table("Customers")]
    public class Customer 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        [MinLength(3)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(128)]
        [MinLength(3)]
        public string Pass { get; set; }
        [Required]
        [MaxLength(128)]
        [MinLength(3)]
        public string Address { get; set; }

    }
}
