using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.models
{
    public class Trip
    {
        public int Id { get; set; }
        /// <summary>
        /// use for description instead
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Date when trip created
        /// </summary>
        public DateTime DateCreadted { get; set; }
        /// <summary>
        /// people name who own this trip
        /// </summary>
        public string UserName { get; set; }
        public int Order { get; set; }
        /// <summary>
        /// each trip have at least one stop
        /// </summary>
        public ICollection<Stop> Stops { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}
