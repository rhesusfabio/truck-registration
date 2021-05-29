using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using TruckRegistration.Domain.Exceptions;
using TruckRegistration.Domain.Model;
using TruckRegistration.Domain.Repositories.Interfaces;
using TruckRegistration.Domain.Services.Injections;

namespace TruckRegistration.Tests
{
    [TestClass]
    public class TruckBusinessTests
    {
        private Mock<ITruckRepository> _truckRepositorMock;


        [TestInitialize]
        public void Inititialize()
        {
            _truckRepositorMock = new Mock<ITruckRepository>();
        }

        private TruckBusiness CreateTruckBusiness()
        {
            return new TruckBusiness(_truckRepositorMock.Object);
        }


        [TestMethod]
        public async Task Create_a_truck_year_before_1990_throw_validation()
        {
            //arrange
            var expected = "The truck is too old";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, 1, 1, "", "");
            var truckBusiness = CreateTruckBusiness();

            //act
            try
            {
                await truckBusiness
                    .CreateTruckAsync(truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                    truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Create_a_truck_model_before_1990_throw_validation()
        {
            //arrange
            var expected = "The truck's model is too old";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, 2007, 1, "", "");
            var truckBusiness = CreateTruckBusiness();

            //act

            try
            {
                await truckBusiness
                    .CreateTruckAsync(truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                        truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Create_a_truck_without_chassi_throw_validation()
        {
            //arrange
            var expected = "Truck's chassi is mandatory";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, DateTime.Today.Year, DateTime.Today.Year, "", "");
            var truckBusiness = CreateTruckBusiness();

            //act
            try
            {
                await truckBusiness
                    .CreateTruckAsync(truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                        truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Create_a_truck_without_description_throw_validation()
        {
            //arrange
            var expected = "Truck's description is mandatory";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, DateTime.Today.Year, DateTime.Today.Year, "11122233", "");
            var truckBusiness = CreateTruckBusiness();

            //act

            try
            {
                await truckBusiness
                    .CreateTruckAsync(truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                        truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Create_a_truck_success()
        {
            //arrange
            var truck = new Truck(TruckModel.FH, DateTime.Today.Year, DateTime.Today.Year, "11122233", "55555");
            var truckBusiness = CreateTruckBusiness();
            Truck createdTruck = (default(Truck));

            //mocking
            _truckRepositorMock.Setup(s => s.CreateAsync(It.IsAny<Truck>()))
                .Callback((Truck t) => createdTruck = t);

            //act
            await truckBusiness
                .CreateTruckAsync(truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                    truck.Description);

            //assert
            Assert.AreEqual(truck.Model, createdTruck.Model);
            Assert.AreEqual(truck.ManufactureYear, createdTruck.ManufactureYear);
            Assert.AreEqual(truck.ManufactureModel, createdTruck.ManufactureModel);
            Assert.AreEqual(truck.Chassi, createdTruck.Chassi);
            Assert.AreEqual(truck.Description, createdTruck.Description);
            Assert.AreEqual(truck.ModelString, createdTruck.ModelString);
            Assert.IsFalse(createdTruck.Id.Equals(Guid.Empty));
        }


        [TestMethod]
        public async Task Update_a_truck_year_before_1990_throw_validation()
        {
            //arrange
            var expected = "The truck is too old";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, 1, 1, "", "");
            var truckBusiness = CreateTruckBusiness();

            //act
            try
            {
                await truckBusiness
                    .UpdateTruckAsync(truck.Id, truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                    truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Update_a_truck_model_before_1990_throw_validation()
        {
            //arrange
            var expected = "The truck's model is too old";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, 2007, 1, "", "");
            var truckBusiness = CreateTruckBusiness();

            //act

            try
            {
                await truckBusiness
                    .UpdateTruckAsync(truck.Id, truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                        truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Update_a_truck_without_chassi_throw_validation()
        {
            //arrange
            var expected = "Truck's chassi is mandatory";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, DateTime.Today.Year, DateTime.Today.Year, "", "");
            var truckBusiness = CreateTruckBusiness();

            //act
            try
            {
                await truckBusiness
                    .UpdateTruckAsync(truck.Id, truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                        truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Update_a_truck_with_wrong_id_throw_validation()
        {
            //arrange
            var expected = "Truck not found";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, DateTime.Today.Year, DateTime.Today.Year, "111", "2222");
            var truckBusiness = CreateTruckBusiness();

            _truckRepositorMock.Setup(s => s.FindToModify(It.IsAny<Guid>())).ReturnsAsync(default(Truck));

            //act
            try
            {
                await truckBusiness
                    .UpdateTruckAsync(Guid.NewGuid(), truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                        truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Update_a_truck_without_description_throw_validation()
        {
            //arrange
            var expected = "Truck's description is mandatory";
            var exception = string.Empty;
            var truck = new Truck(TruckModel.FH, DateTime.Today.Year, DateTime.Today.Year, "11122233", "");
            var truckBusiness = CreateTruckBusiness();

            //act

            try
            {
                await truckBusiness
                    .UpdateTruckAsync(truck.Id, truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi,
                        truck.Description);
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Update_a_truck_success()
        {
            //arrange
            var existingTruck = new Truck(TruckModel.FM, DateTime.Today.AddYears(1).Year, DateTime.Today.AddYears(1).Year, "88888", "9999");
            var truck = new Truck(TruckModel.FH, DateTime.Today.Year, DateTime.Today.Year, "11122233", "55555");

            var truckBusiness = CreateTruckBusiness();
            Truck updatedTruck = (default(Truck));

            //mocking
            _truckRepositorMock.Setup(s => s.UpdateTruckAsync(It.IsAny<Truck>()))
                .Callback((Truck t) => updatedTruck = t);

            _truckRepositorMock.Setup(s => s.FindToModify(It.IsAny<Guid>())).ReturnsAsync(existingTruck);

            //act
            await truckBusiness
                .UpdateTruckAsync(existingTruck.Id, truck.Model, truck.ManufactureYear, truck.ManufactureModel, truck.Chassi, truck.Description);

            //assert
            Assert.AreEqual(truck.Model, updatedTruck.Model);
            Assert.AreEqual(truck.ManufactureYear, updatedTruck.ManufactureYear);
            Assert.AreEqual(truck.ManufactureModel, updatedTruck.ManufactureModel);
            Assert.AreEqual(truck.Chassi, updatedTruck.Chassi);
            Assert.AreEqual(truck.ModelString, updatedTruck.ModelString);
            Assert.AreEqual(truck.Description, updatedTruck.Description);
            Assert.AreEqual(existingTruck.Id, updatedTruck.Id);
            
        }


        [TestMethod]
        public async Task Delete_a_truck_with_wrong_id_throw_validation()
        {
            //arrange
            var expected = "Truck not found";
            var exception = string.Empty;
            var truckBusiness = CreateTruckBusiness();

            _truckRepositorMock.Setup(s => s.FindToModify(It.IsAny<Guid>())).ReturnsAsync(default(Truck));

            //act
            try
            {
                await truckBusiness.DeleteAsync(Guid.NewGuid());
            }
            catch (BusinessException e)
            {
                exception = e.Message;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            //assert
            Assert.AreEqual(expected, exception);
        }

        [TestMethod]
        public async Task Delete_a_truck_success()
        {
            //arrange
            var deletedTruck = default(Truck);
            var existingTruck = new Truck(TruckModel.FM, DateTime.Today.AddYears(1).Year, DateTime.Today.AddYears(1).Year, "88888", "9999");
            var truckBusiness = CreateTruckBusiness();

            _truckRepositorMock.Setup(s => s.FindToModify(It.IsAny<Guid>())).ReturnsAsync(existingTruck);
            _truckRepositorMock.Setup(s => s.DeleteAsync(It.IsAny<Truck>())).Callback((Truck t)=> deletedTruck = t);

            //act
            await truckBusiness.DeleteAsync(Guid.NewGuid());
            
            //assert
            Assert.AreEqual(deletedTruck, existingTruck);
        }

    }
}
