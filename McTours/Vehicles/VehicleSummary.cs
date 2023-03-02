using McTours.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Vehicles
{
	public class VehicleSummary
	{
		public int Id { get; set; }

		public int VehicleDefinitionId { get; set; }

		public string PlateNumber { get; set; }

		public string RegistrationNumber { get; set; }

		public DateTime RegistrationDate { get; set; }

		public string VehicleMakeName { get; set; }
		public string VehicleModelName { get; set; }

		public string VehicleName => string.Concat(PlateNumber, "-", VehicleMakeName, "/", VehicleModelName);

	}
}
