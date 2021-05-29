using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Exceptions;
using TruckRegistration.Domain.Services.Interfaces;
using TruckRegistration.ViewModels;

namespace TruckRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/Truck")]
    public class TruckController : Controller
    {
        private readonly ITruckServices _services;

        public TruckController(ITruckServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //TODO: implement automapper
            var trucks = await _services.List()
                .Select(s => new TruckListVm
                {
                    Id = s.Id,
                    Desc = s.Description,
                    Chassi = s.Chassi,
                    Year = s.ManufactureYear,
                    YearModel = s.ManufactureModel,
                    Model = s.Model.ToString()
                }).ToListAsync();

            return Ok(trucks);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            //TODO: implement automapper
            var truck = await _services.List()
                .Select(s => new TruckDetailVm
                {
                    Id = s.Id,
                    Desc = s.Description,
                    Chassi = s.Chassi,
                    Year = s.ManufactureYear,
                    YearModel = s.ManufactureModel,
                    Model = s.Model
                }).FirstOrDefaultAsync();

            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTruckVm truck)
        {
            TruckDetailVm createdTruckVm;

            try
            {
                var createdTruck = await _services.CreateTruckAsync(
                    truck.Model,
                    truck.Year,
                    truck.YearModel,
                    truck.Chassi,
                    truck.Desc);

                //TODO: implement automapper
                createdTruckVm = new TruckDetailVm
                {
                    Chassi = createdTruck.Chassi,
                    Model = createdTruck.Model,
                    Desc = createdTruck.Description,
                    Id = createdTruck.Id,
                    Year = createdTruck.ManufactureYear,
                    YearModel = createdTruck.ManufactureModel
                };

            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(createdTruckVm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]UpdateTruckVm truck)
        {
            try
            {
                await _services.UpdateTruckAsync(
                    id,
                    truck.Model,
                    truck.Year,
                    truck.YearModel,
                    truck.Chassi,
                    truck.Desc);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            await _services.DeleteAsync(id);

            return Ok();
        }
    }
}
