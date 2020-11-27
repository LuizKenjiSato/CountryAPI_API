using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryAPI.Entities
{
    public class CountryDBContext : DbContext
    {
        public CountryDBContext() { }

        public CountryDBContext(DbContextOptions<CountryDBContext> options): base (options)
        {

        }
        public virtual DbSet<CountryEntity> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryEntity>()
                .HasIndex(p => new { p.CountryName })
                .IsUnique(true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=country-api.cow0ymyrmkbf.ca-central-1.rds.amazonaws.com; Port=5432; Database=CountryAPI;Username=postgres; Password=Padros15975369");
    }
}
