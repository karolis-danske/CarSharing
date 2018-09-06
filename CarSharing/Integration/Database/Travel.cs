using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Database
{
    using Integartion.Database;

    public class Travel
    {
        public string Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public List<Passanger> Passangers { get; set; }
        public User User { get; set; }
    }
}
