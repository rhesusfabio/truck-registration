using System;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Exceptions;
using TruckRegistration.Domain.Model;
using TruckRegistration.Domain.Repositories.Interfaces;
using TruckRegistration.Domain.Services.Interfaces;

namespace TruckRegistration.Domain.Services.Injections
{
    public class TruckBusiness : ITruckServices
    {
        private readonly ITruckRepository _repository;

        public TruckBusiness(ITruckRepository repository)
        {
            _repository = repository;
        }

        public async Task<Truck> CreateTruckAsync(TruckModel model, int mYear, int mModel, string chassi, string description)
        {
            CommonValidations(mYear, mModel, chassi, description);

            var truck = new Truck(
                model,
                mYear,
                mModel,
                chassi,
                description);

            return await _repository.CreateAsync(truck);
        }

        public async Task<Truck> UpdateTruckAsync(Guid truckId, TruckModel model, int mYear, int mModel, string chassi, string description)
        {
            CommonValidations(mYear, mModel, chassi, description);

            var truck = await _repository.FindToModify(truckId);

            truck.Update(
                model,
                mYear,
                mModel,
                chassi,
                description);

            return await _repository.UpdateTruckAsync(truck);
        }

        public async Task DeleteAsync(Guid id)
        {
            var truck = await _repository.FindToModify(id);

            await _repository.DeleteAsync(truck);
        }

        private static void CommonValidations(int mYear, int mModel, string chassi, string description)
        {
            if (mYear <= 1990)
            {
                throw new BusinessException("The truck is too old");
            }

            if (mModel <= 1990)
            {
                throw new BusinessException("The truck's model is too old");
            }

            if (string.IsNullOrWhiteSpace(chassi))
            {
                throw new BusinessException("Truck's chassi is mandatory");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new BusinessException("Truck's description is mandatory");
            }
        }

        public IQueryable<Truck> List()
        {
            return _repository.List();
        }

        
    }
}
