using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBook.models;

namespace TheBook.Repository
{
    public class TheBookRepository: ITheBookRepository
    {
        private BookContext _context;

        public TheBookRepository(BookContext context)
        {
            _context = context;
        }

        public EntityEntry<Car> AddNewCar(Car newCar)
        {
            return _context.Add(newCar);
        }

        public EntityEntry<TeamMember> AddNewMember(TeamMember newTeamMember)
        {
            return _context.Add(newTeamMember);
        }

        public EntityEntry<RoleMember> AddNewRole(RoleMember newRoleMember)
        {
           return _context.Add(newRoleMember);
        }
        public EntityEntry<Stop> AddNewLocation(Stop newStop)
        {
            return _context.Add(newStop);
        }
        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }
        public IEnumerable<RoleMember> GetAllRoles()
        {
            return _context.RoleMembers.ToList();
        }
        public IEnumerable<Stop> GetAllStops()
        {
            return _context.Stops.ToList();
        }
        public IEnumerable<TeamMember> GetAllTeamMembers()
        {
            return _context.TeamMembers.ToList();
        }

        public async Task<bool> SaveChangesAsyn()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public EntityEntry<Trip> AddTrip(Trip theTrip)
        {
            return _context.Add(theTrip);
        }

        public Trip GetTripByName(string nameOfTrip)
        {
            return _context
                .Trips.Include(trip => trip.Stops)
                .Where(trip => trip.Name.Equals(nameOfTrip))
                .FirstOrDefault();
        }

        public void AddNewStop(string nameOfTrip, Stop newStop)
        {
            var trip = GetTripByName(nameOfTrip);
            if (!trip.Equals(null))
            {
                trip.Stops.Add(newStop);
                _context.Add(newStop);
            }
        }
    }
}
