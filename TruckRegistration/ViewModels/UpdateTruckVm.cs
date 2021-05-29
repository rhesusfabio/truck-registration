using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Model;

namespace TruckRegistration.ViewModels
{
    public class UpdateTruckVm
    {
        public string Desc { get; set; }
        public int Year { get; set; }
        public int YearModel { get; set; }
        public TruckModel Model { get; set; }
        public string Chassi { get; set; }
    }
}
