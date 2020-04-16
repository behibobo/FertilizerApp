using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Land
    {
        public Land()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LandTypeId { get; set; }
        public int Area { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
