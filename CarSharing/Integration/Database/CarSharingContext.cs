using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integartion.Database
{
    using Microsoft.EntityFrameworkCore;

    public class CarSharingContext : DbContext
    {
        public CarSharingContext(DbContextOptions<CarSharingContext> options) : base(options)
        {
        }

        public DbSet<TestTable> TestTables { get; set; }
    }
}
