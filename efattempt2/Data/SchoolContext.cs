using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efattempt1.Models;
using Microsoft.EntityFrameworkCore;

namespace efattempt2.Data
{
    internal class SchoolContext : DbContext
    {
        public DbSet<Betyg> betyg { get; set; }
        public DbSet<Kurser> kurser { get; set; }
        public DbSet<Personal> personal { get; set; }
        public DbSet<Studenter> studenter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FVF2TLQ;Database=Skola;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
