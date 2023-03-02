using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int VehicleDefinitionId { get; set; }

        public string PlateNumber { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime RegistrationDate { get; set; }
        public VehicleDefinition VehicleDefinition { get; set; }

        public ICollection<BusTrip> BusTrips { get; set; }
    }
}
