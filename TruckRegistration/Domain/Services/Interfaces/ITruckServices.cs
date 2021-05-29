using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Model;

namespace TruckRegistration.Domain.Services.Interfaces
{
    public interface ITruckServices
    {
        Task<Truck> CreateTruckAsync(TruckModel model, int mYear, int mModel, string chassi, string description);

        Task<Truck> UpdateTruckAsync(Guid truckId, TruckModel model, int mYear, int mModel, string chassi,
            string description);

        IQueryable<Truck> List();
        Task DeleteAsync(Guid id);
    }
}
