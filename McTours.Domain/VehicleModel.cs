using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public class VehicleModel
    {
        public VehicleModel()
        {
            VehicleDefinitions = new List<VehicleDefinition>();
        }
            
        public int Id { get; set; }
        public string Name { get; set; }
        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public ICollection<VehicleDefinition> VehicleDefinitions { get; set; }
    }
}
