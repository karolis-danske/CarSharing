using System.Linq;
using System.Threading.Tasks;
using Integartion.Database;
using Integration.Database;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Travels
{
    [Route("api/travels")]
    public class TravelsController : ControllerBase
    {
        private readonly CarSharingContext _db;

        public TravelsController(CarSharingContext context)
        {
            _db = context;
        }

        [HttpGet]
        public ActionResult GetTravels([FromRoute] string userId)
        {
            var travels = _db.Travels.Where(x => x.UserId == userId);
            return Ok(travels);
        }

        [HttpPost]
        public async Task<ActionResult> AddTravel([FromBody] CreateTravelRequest request)
        {
            var travel = new Travel
            {
                UserId = request.UserId,
                Origin = request.Origin,
                Destination = request.Destination,
                DepartureTime = request.DepartureTime
            };

            _db.Travels.Add(travel);

            await _db.SaveChangesAsync();
            return Ok(travel.Id);
        }

        [HttpPost("{travelId}/{userId}")]
        public async Task<ActionResult> AddPassanger([FromRoute] string travelId, [FromRoute] string userId)
        {
            var passanger = new Passenger {TravelId = travelId, UserId = userId};

            _db.Passangers.Add(passanger);

            await _db.SaveChangesAsync();
            return Ok();
        }
    }

}
