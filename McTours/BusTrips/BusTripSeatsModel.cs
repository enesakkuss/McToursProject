using McTours.VehicleDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.BusTrips
{
    public class BusTripSeatsModel
    {
        public BusTripSeatsModel()
        {
            SoldSeatNumbers = new List<int>();
        }
        
        public int Id { get; set; }
        public SeatingType SeatingType { get; set; }
        public int LineCount { get; set; }
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

        public ICollection<int> SoldSeatNumbers { get; }
    }
}
