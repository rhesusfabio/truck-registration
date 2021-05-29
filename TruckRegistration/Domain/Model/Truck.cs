using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TruckRegistration.Domain.Model
{
    public class Truck
    {
        public Guid Id { get; private set; }

        [NotMapped]
        public TruckModel Model { get; private set; }

        [StringLength(2)]
        public string ModelString
        {
            get => Model.ToString();
            set => Model = (TruckModel)Enum.Parse(typeof(TruckModel), value, true);
        }

        public int ManufactureYear  { get; private set; }
        public int ManufactureModel { get; private set; }

        [StringLength(100)]
        public string Chassi { get; private set; }

        [StringLength(100)]
        public string Description { get; private set; }

        public Truck(TruckModel model, int manufactureYear, int manufactureModel, string chassi, string description)
        {
            Id = Guid.NewGuid();
            Model = model;
            ManufactureYear = manufactureYear;
            ManufactureModel = manufactureModel;
            Chassi = chassi;
            Description = description;
        }

        protected Truck()
        {
            //EF 
        }

        public void Update(TruckModel model, int manufactureYear, int manufactureModel, string chassi, string description)
        {
            Model = model;
            ManufactureYear = manufactureYear;
            ManufactureModel = manufactureModel;
            Chassi = chassi;
            Description = description;
        }
    }

    public enum TruckModel
    {
        FH,
        FM
    }
}
