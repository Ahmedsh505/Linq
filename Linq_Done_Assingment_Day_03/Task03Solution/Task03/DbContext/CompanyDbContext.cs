using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Task03.Configuration_Classes;
using Task03.Models;
using Microsoft.EntityFrameworkCore;

namespace Task03.DbContect
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Local SQL Server Express — adjust if needed
            optionsBuilder.UseSqlServer(
                "Server=.;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfigurations());
        }
    }
}
