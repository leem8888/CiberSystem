using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CiberSystem.Entities
{
    [Table("AppRoles")]
    public class AppRole
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
