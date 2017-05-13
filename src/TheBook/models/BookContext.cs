using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TheBook.models
{
    public class BookContext:DbContext
    {
        private IConfigurationRoot _config;

        public BookContext(IConfigurationRoot config,DbContextOptions options)
            :base(options)
        {
            _config = config;
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RoleMember> RoleMembers { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["connectionString:LocalDB"]);
        }


        
    }
}
