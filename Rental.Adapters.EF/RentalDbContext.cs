using System;
using Microsoft.EntityFrameworkCore;
using Rental.Adapters.EF.Entities;
using Rental.Domain;

namespace Rental.Adapters.EF
{
    public class RentalDbContext : DbContext
    {
        private readonly string _connectionString;

        public RentalDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CarBookingEntity> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>().Property(c => c.Currency)
                .HasConversion(
                    v => (short) v,
                    v => (Currency) v);
        }
    }
}
