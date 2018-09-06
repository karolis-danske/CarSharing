using System;
using System.Collections.Generic;
using System.Text;

namespace Integartion.Database
{
    using Integration.Database;

    public class Users
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Cars Car { get; set; }

        public List<Travels> Travels { get; set; }

        public List<Passangers> Passangers { get; set; }
    }
}
