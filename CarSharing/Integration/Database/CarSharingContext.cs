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
            //modelBuilder.Entity<User>().HasOne<Car>(u => u.Car).WithOne(c => c.User).HasForeignKey<User>(x => x.CarId);
            modelBuilder.Entity<User>().HasMany<Travel>(u => u.Travels).WithOne(t => t.DriverUser).HasForeignKey(x => x.DriverUserId);
            modelBuilder.Entity<User>().HasMany<Passenger>(u => u.Passangers).WithOne(p => p.PassengerUser).HasForeignKey(x => x.PassengerUserId);
            modelBuilder.Entity<Travel>().HasMany<Passenger>(t => t.Passengers).WithOne(p => p.Travel).HasForeignKey(x => x.TravelId);

            var car = new Car { Id = "CarVeryUniqueGuid", Number = "YAU123" };
            modelBuilder.Entity<Car>().HasData(car);

            var driverUser = new User()
            {
                Id = "UserVeryUniqueGuid1",
                CarId = car.Id,
                Name = "Domas Sostronk",
                PhoneNumber = "86656911"
            };
            var passengerUser = new User()
            {
                Id = "UserVeryUniqueGuid2",
                Name = "Alisa Selezniova",
                PhoneNumber = "864001010"
            };
            var users = new List<User>() { driverUser, passengerUser };
            modelBuilder.Entity<User>().HasData(driverUser, passengerUser);

            var travel = new Travel()
            {
                Id = "TravelVeryUniqueGuid",
                DepartureTime = new DateTimeOffset(new DateTime(2018, 9, 28, 9, 0, 0)),
                Destination = "54.700690, 25.261981",
                Origin = "54.670396, 25.284133",
                DriverUserId = driverUser.Id
            };
            modelBuilder.Entity<Travel>().HasData(travel);

            var passenger = new Passenger()
            {   
                Id = "PassengerVeryUniqueGuid",
                TravelId = travel.Id,
                PassengerUserId = passengerUser.Id
            };
            modelBuilder.Entity<Passenger>().HasData(passenger);
        }

        

        public DbSet<Car> Cars { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passangers { get; set; }
    }
}
