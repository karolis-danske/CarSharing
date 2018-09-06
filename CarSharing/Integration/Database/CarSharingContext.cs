using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integartion.Database
{
    using Integration.Database;
    using Microsoft.EntityFrameworkCore;

    public class CarSharingContext : DbContext
    {
        public CarSharingContext(DbContextOptions<CarSharingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasOne<Cars>(u => u.Car).WithOne(c => c.User);
            modelBuilder.Entity<Users>().HasMany<Travels>().WithOne();
            modelBuilder.Entity<Users>().HasMany<Passangers>().WithOne();
            modelBuilder.Entity<Travels>().HasMany<Passangers>().WithOne();
        }

        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Travels> Travels { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Passangers> Passangers { get; set; }
    }
}
