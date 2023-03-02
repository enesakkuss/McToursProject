using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public class VehicleMake
    {
        public VehicleMake()
        {
            VehicleModels=new List<VehicleModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
