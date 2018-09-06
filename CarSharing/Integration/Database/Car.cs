using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Database
{
    using System.ComponentModel.DataAnnotations;
    using Integartion.Database;

    public class Car
    {
        public string Id { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
