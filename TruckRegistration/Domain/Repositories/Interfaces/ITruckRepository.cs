using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Model;

namespace TruckRegistration.Domain.Repositories.Interfaces
{
    public interface ITruckRepository
    {
        Task<Truck> CreateAsync(Truck truck);
        IQueryable<Truck> List();
        Task<Truck> FindToModify(Guid truckId);
        Task<Truck> UpdateTruckAsync(Truck truck);
        Task DeleteAsync(Truck truck);
    }
}
