using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Fertilizer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
