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
            modelBuilder.Entity<User>().HasOne<Car>(u => u.Car).WithOne(c => c.User);
            modelBuilder.Entity<User>().HasMany<Travel>().WithOne();
            modelBuilder.Entity<User>().HasMany<Passanger>().WithOne();
            modelBuilder.Entity<Travel>().HasMany<Passanger>().WithOne();
        }

        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passanger> Passangers { get; set; }
    }
}
