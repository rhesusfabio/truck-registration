using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Model;
using TruckRegistration.Domain.Repositories.Interfaces;
using TruckRegistration.Infrastructure;

namespace TruckRegistration.Domain.Repositories.Injections
{
    public class TruckDatabase : ITruckRepository
    {
        private readonly TruckContext _context;

        public TruckDatabase(TruckContext context)
        {
            _context = context;
        }
        public async Task<Truck> CreateAsync(Truck truck)
        {
            using (var tr = _context.Database.BeginTransaction())
            {
                await _context.AddAsync(truck);

                await _context.SaveChangesAsync();

                tr.Commit();
                
                return truck;
            }

        }

        public IQueryable<Truck> List()
        {
            return _context.Trucks.AsNoTracking();
        }

        public async Task<Truck> FindToModify(Guid truckId)
        {
            return await _context.Trucks.FindAsync(truckId);
        }

        public async Task<Truck> UpdateTruckAsync(Truck truck)
        {
            await _context.SaveChangesAsync();

            return truck;
        }

        public async Task DeleteAsync(Truck truck)
        {
            _context.Trucks.Remove(truck);

            await _context.SaveChangesAsync();
        }
    }
}
