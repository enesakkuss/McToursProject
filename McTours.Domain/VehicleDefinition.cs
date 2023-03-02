
using McTours.VehicleDefinitions;

namespace McTours.Domain
{
    public class VehicleDefinition
    {
        public VehicleDefinition()
        {
            Vehicles=new List<Vehicle>();
        }
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public short Year { get; set; }
        public SeatingType SeatingType { get; set; }
        public int LineCount { get; set; }
        public FuelType FuelType { get; set; }
        public Utility Utilities { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
