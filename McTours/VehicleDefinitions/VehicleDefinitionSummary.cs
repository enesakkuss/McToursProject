using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.VehicleDefinitions
{
    public class VehicleDefinitionSummary
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public short Year { get; set; }
        public SeatingType SeatingType { get; set; }
        public string SeatingTypeNames
        {
            get
            {
                return EnumHelper.SeatingTypeNames.ContainsKey(SeatingType)
                      ?EnumHelper.SeatingTypeNames[SeatingType]
                      :string.Empty;
            }
        }
        public int LineCount { get; set; }
        public FuelType FuelType { get; set; }

        public string FuelTypeName
        {
            get
            {
                return EnumHelper.FuelTypeNames.ContainsKey(FuelType)
                    ? EnumHelper.FuelTypeNames[FuelType]
                    : string.Empty;
            }
        }
        public Utility Utilities { get; set; }

        public string UtilitiesName => Utilities.GetNames();
        //{
        //    get
        //    {
        //        var stringBuilder =new StringBuilder();

        //        foreach (var item in EnumHelper.UtilityNames)
        //        {
                    
        //            if(Utilities.HasFlag(item.Key))
        //            {
        //                if (stringBuilder.Length > 0)
        //                {
        //                    stringBuilder.Append(", ");
        //                }
        //                stringBuilder.Append(item.Value);
        //            }
        //        }
        //        return stringBuilder.ToString();
        //    }
        //}
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

        public string ModelName { get; set; }

        public string MakeName { get; set; }
    }
}
