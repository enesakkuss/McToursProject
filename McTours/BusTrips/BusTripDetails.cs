using McTours.VehicleDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.BusTrips
{
    public class BusTripDetails
    {
        public int Id { get; set; }
        public SeatingType SeatingType { get; set; }
        public int LineCount { get; set; }
        public FuelType FuelType { get; set; }
        public Utility Utilities { get; set; }

        public int SeatCount
        {
            get
            {
                if (SeatingType == SeatingType.Standart)
                {
                    return LineCount * 4;
                }
                else
                {
                    return LineCount * 3;
                }
            }
        }
        public string VehicleName { get; set; }
        public string Route { get; set; }
    }
}
