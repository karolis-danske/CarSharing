using System;
using System.Collections.Generic;
using System.Text;

namespace Integartion.Database
{
    using System.ComponentModel.DataAnnotations;
    using Integration.Database;

    public class User
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string CarId { get; set; }
        public Car Car { get; set; }

        public List<Travel> Travels { get; set; }

        public List<Passenger> Passangers { get; set; }
    }
}
