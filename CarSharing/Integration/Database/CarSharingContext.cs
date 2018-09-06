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
            modelBuilder.Entity<User>().HasOne<Car>(u => u.Car).WithOne(c => c.User).HasForeignKey<User>(x => x.CarId);
            modelBuilder.Entity<User>().HasMany<Travel>(u => u.Travels).WithOne(t => t.User).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<User>().HasMany<Passanger>(u => u.Passangers).WithOne(p => p.User).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Travel>().HasMany<Passanger>(t => t.Passangers).WithOne(p => p.Travel).HasForeignKey(x => x.TravelId);
        }

        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passanger> Passangers { get; set; }
    }
}
