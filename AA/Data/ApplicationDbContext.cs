using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AA.Models;

namespace AA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AA.Models.Bil> Bil { get; set; }
        public DbSet<AA.Models.Marke> Marke { get; set; }
        public DbSet<AA.Models.Kategori> Kategori { get; set; }
        
    }
}
