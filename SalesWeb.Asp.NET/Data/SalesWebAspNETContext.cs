using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWeb.Asp.NET.Models
{
    public class SalesWebAspNETContext : DbContext
    {
        public SalesWebAspNETContext (DbContextOptions<SalesWebAspNETContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWeb.Asp.NET.Models.Department> Department { get; set; }
    }
}
