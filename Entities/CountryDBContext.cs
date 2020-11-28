using Microsoft.EntityFrameworkCore;
using Npgsql;
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
            
    }
}
