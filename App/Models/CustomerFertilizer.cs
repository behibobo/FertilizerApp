using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class CustomerFertilizer
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FertilizerId { get; set; }
        public float Amount { get; set; }
    }
}
