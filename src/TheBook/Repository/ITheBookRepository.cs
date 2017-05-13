using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBook.models;

namespace TheBook.Repository
{
    public interface ITheBookRepository
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<RoleMember> GetAllRoles();
        IEnumerable<Stop> GetAllStops();
        IEnumerable<TeamMember> GetAllTeamMembers();
        Task<bool> SaveChangesAsyn();
        EntityEntry<RoleMember> AddNewRole(RoleMember newRoleMember);
        EntityEntry<TeamMember> AddNewMember(TeamMember newTeamMember);
        EntityEntry<Car> AddNewCar(Car newCar);
        EntityEntry<Stop> AddNewLocation(Stop newStop);

        EntityEntry<Trip> AddTrip(Trip theTrip);
        Trip GetTripByName(string nameOfTrip);
        void AddNewStop(string nameOfTrip, Stop newStop);
    }
}