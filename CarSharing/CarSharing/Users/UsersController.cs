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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _db.Users.Include(x => x.Car).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserRequest request)
        {
            _db.Users.Add(
                new User
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Car = new Car
                    {
                        Number = request.Car.Number
                    }
                });

            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("{id}/cars")]
        public async Task<ActionResult> AddCar(string userId, CreateCarRequest request)
        {
            var user = _db.Users.Single(x => x.Id == userId);

            _db.Cars.Add(new Car { User = user, Number = request.Number });

            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
