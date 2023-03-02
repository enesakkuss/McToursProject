
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.VehicleDefinitions
{
    public class VehicleDefinitionDto
    {
        public VehicleDefinitionDto()
        {
            Utilities = new List<Utility>();
        }
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }// veri tabanına kaydedilmiyo diye DTO da
        public short Year { get; set; }
        public SeatingType SeatingType { get; set; }
        public int LineCount { get; set; }
        public FuelType FuelType { get; set; }
        public ICollection<Utility> Utilities { get; set; }
        public int SeatCount 
        { 
            get
            {
                if(SeatingType == SeatingType.Standart)
                {
                    return LineCount * 4;
                }
                else
                {
                    return LineCount * 3;
                }
            }
        }

        
    }
}
