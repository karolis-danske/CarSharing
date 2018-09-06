﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Database
{
    using System.ComponentModel.DataAnnotations;
    using Integartion.Database;

    public class Cars
    {
        public string Id { get; set; }
        [Required]
        public string Number { get; set; }
        public Users User { get; set; }
    }
}
