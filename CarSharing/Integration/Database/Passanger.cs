using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Database
{
    using Integartion.Database;

    public class Passanger
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string TravelId { get; set; }
        public Travel Travel { get; set; }
    }
}
