using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Database
{
    using Integartion.Database;

    public class Travels
    {
        public string Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public List<Passangers> Passangers { get; set; }
        public Users User { get; set; }
    }
}
