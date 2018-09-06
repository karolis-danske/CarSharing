using System.Linq;
using System.Threading.Tasks;
using Integartion.Database;
using Integration.Database;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Travels
{
    using System.Collections.Generic;

    [Route("api/travels")]
    public class TravelsController : ControllerBase
    {
        private readonly CarSharingContext _db;

        public TravelsController(CarSharingContext context)
        {
            _db = context;
        }

        [HttpGet("{userId}")]
        public ActionResult GetTravels([FromRoute] string userId)
        {
            var travels = _db.Travels.Where(x => x.DriverUserId == userId);
            return Ok(travels);
        }

        [HttpGet("all")]
        public ActionResult GetAllTravels()
        {
            var travels = _db.Travels.ToList();
            return Ok(travels);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddTravel([FromBody] CreateTravelRequest request)
        {
            var travel = new Travel
            {
                DriverUserId = request.DriverUserId,
                Origin = request.Origin,
                Destination = request.Destination,
                DepartureTime = request.DepartureTime
            };

            _db.Travels.Add(travel);

            await _db.SaveChangesAsync();
            return Ok(travel.Id);
        }

        [HttpPost("{travelId}/{userId}")]
        public async Task<ActionResult<string>> AddPassanger([FromRoute] string travelId, [FromRoute] string userId)
        {
            var passanger = new Passenger {TravelId = travelId, PassengerUserId = userId};

            _db.Passangers.Add(passanger);

            await _db.SaveChangesAsync();
            return Ok(passanger.Id);
        }

        [HttpDelete("{travelId}/{passengerUserId}")]
        public async Task<ActionResult> RemovePassanger([FromRoute] string travelId, [FromRoute] string passengerUserId)
        {
            var passanger = _db.Passangers.Single(x => x.TravelId == travelId && x.PassengerUserId == passengerUserId);

            _db.Passangers.Remove(passanger);

            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{travelId}")]
        public ActionResult<IEnumerable<User>> GetPassangers([FromRoute] string travelId)
        {
            var users = _db.Passangers.Where(x => x.TravelId == travelId).Select(x => x.PassengerUser);
            return Ok(users);
        }

        [HttpGet("allPassengers")]
        public ActionResult<IEnumerable<User>> GetPassangers()
        {
            var users = _db.Passangers.ToList();
            return Ok(users);
        }

    }
}
