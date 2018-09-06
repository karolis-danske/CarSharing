﻿using System;

namespace CarSharing.Travels
{
    public class CreateTravelRequest
    {
        public string Origin { get; set; }

        public string Destination { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
    }
}
