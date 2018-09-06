using System;
using System.Collections.Generic;
using System.Text;

namespace Integartion.Database
{
    using System.ComponentModel.DataAnnotations;
    using Integration.Database;

    public class Users
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Cars Car { get; set; }

        public List<Travels> Travels { get; set; }

        public List<Passangers> Passangers { get; set; }
    }
}
