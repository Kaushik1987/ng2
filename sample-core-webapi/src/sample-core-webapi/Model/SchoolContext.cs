using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sample_core_webapi.Model
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions opts) : base(opts)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own confguration here
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}
