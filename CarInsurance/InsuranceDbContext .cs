using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarInsurance
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        public DbSet<Insuree> Insurees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insuree>(entity =>
            {
                entity.Property(e => e.Quote).HasColumnType("money");
            });
        }
    }
}
