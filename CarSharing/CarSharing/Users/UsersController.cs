using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Users
{
    using Integartion.Database;
    using Integration.Database;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly CarSharingContext _db;

        public UsersController(CarSharingContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _db.Users.Include(x => x.Car).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var usersWithSameName = _db.Users.Where(x => x.Name == request.Name);
            if (usersWithSameName.Any())
            {
                return BadRequest("User with this name already exists");
            }

            var user = _db.Users.Add(
                new User
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                });
            await _db.SaveChangesAsync();

            if (request.Car != null)
            {
                var car = new Car {Number = request.Car.Number};
                _db.Cars.Add(car);

                user.Entity.CarId = car.Id;
                _db.Users.Update(user.Entity);

                await _db.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPost("{userId}/cars")]
        public async Task<ActionResult> AddCar([FromRoute] string userId, [FromBody] CreateCarRequest request)
        {
            var user = _db.Users.Single(x => x.Id == userId);

            _db.Cars.Add(new Car { User = user, Number = request.Number });

            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{userId}/cars")]
        public async Task<ActionResult> GetCar([FromRoute] string userId)
        {
            return Ok((await _db.Users.Include(x => x.Car).SingleAsync(x => x.Id == userId)).Car);
        }
    }
}
