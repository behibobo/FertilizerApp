using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Customer
    {
        public Customer()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get;  set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(150)]
        public string LastName { get; set; }
        public string FatherName { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string Mobile { get; set; }
        [StringLength(20)]
        public string Nid { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
