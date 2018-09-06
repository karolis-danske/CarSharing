using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Login
{
    using Integartion.Database;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly CarSharingContext _db;

        public LoginController(CarSharingContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult> Login(string userName)
        {
            var id = await _db.Users.SingleAsync(x => x.Name == userName);

            return Ok(id);
        }
    }
}
