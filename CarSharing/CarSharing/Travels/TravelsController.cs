using System.Linq;
using System.Threading.Tasks;
using Integartion.Database;
using Integration.Database;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Travels
{
    public class TravelsController : ControllerBase
    {
        private readonly CarSharingContext _db;

        public TravelsController(CarSharingContext context)
        {
            _db = context;
        }

        [HttpPost("{userId}/travels")]
        public async Task<ActionResult> AddCar(string userId, CreateTravelRequest request)
        {
            var user = _db.Users.Single(x => x.Id == userId);

            var travel = new Travel()
                             {
                                 User = user,
                                 Origin = request.Origin,
                                 Destination = request.Destination,
                                 DepartureTime = request.DepartureTime
                             };

            var asdf =  _db.Travels.Add(travel);

            await _db.SaveChangesAsync();
            return Ok();
        }
    }

}
