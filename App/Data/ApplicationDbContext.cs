using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<LandType> LandTypes { get; set; }
        public DbSet<Fertilizer> Fertilizers { get; set; }
        public DbSet<CustomerFertilizer> CustomerFertilizers { get; set; }
    }
}
