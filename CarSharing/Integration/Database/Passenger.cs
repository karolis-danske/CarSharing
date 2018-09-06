using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Database
{
    using Integartion.Database;

    public class Passenger
    {
        public string Id { get; set; }
        public string PassengerUserId { get; set; }
        public User PassengerUser { get; set; }
        public string TravelId { get; set; }
        public Travel Travel { get; set; }
    }
}
