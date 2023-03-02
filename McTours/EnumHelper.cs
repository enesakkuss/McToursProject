using McTours.Coomon;
using McTours.VehicleDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours
{
    public static class EnumHelper
    {
        public static readonly Dictionary<FuelType, string> FuelTypeNames = new Dictionary<FuelType, string>()
        {
            [FuelType.Diesel] = "Dizel",
            [FuelType.Gasoline] = "Benzin"
        };

        public static IEnumerable<ValueNameObject> GetAllFuelType()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in FuelTypeNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value = (int)item.Key,
                    Name = item.Value
                });
            }
            return all;
        }
        public static readonly Dictionary<SeatingType, string> SeatingTypeNames = new Dictionary<SeatingType, string>()
        {
            [SeatingType.Vip] = "2+1",
            [SeatingType.Standart] = "2+2"
        };

        public static IEnumerable<ValueNameObject>GetAllSeatingType()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in SeatingTypeNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value = (int)item.Key,
                    Name = item.Value
                });
            }
            return all;
        }

        public static readonly Dictionary<Utility, string> UtilityNames = new Dictionary<Utility, string>()
        {
            [Utility.Wifi] = "Kablosuz İnternet",
            [Utility.SmartScreen] = "Akıllı Ekran",
            [Utility.Plug] = "Priz",
            [Utility.Toilet] = "WC",
            [Utility.Hanger] = "Askılık"
        };

        public static IEnumerable<ValueNameObject> GetAllUtilities()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in UtilityNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value = (int)item.Key,
                    Name = item.Value
                });
            }
            return all;
        }

        public static readonly Dictionary<Gender, string> GenderNames = new Dictionary<Gender, string>()
        {
            [Gender.Man] = "Erkek",
            [Gender.Woman] = "Kadın"
        };

        public static string GetGenderName(this Gender type)
        {
            return GenderNames.ContainsKey(type)
                ? GenderNames[type]
                : string.Empty;
        }

        public static IEnumerable<ValueNameObject> GetAllGenders()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in GenderNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value=(int)item.Key,
                    Name=item.Value
                });
            }
            return all;
        }
        public static string GetNames (this Utility utilities)
        {
                var stringBuilder = new StringBuilder();

                foreach (var item in EnumHelper.UtilityNames)
                {

                    if (utilities.HasFlag(item.Key))
                    {
                        if (stringBuilder.Length > 0)
                        {
                            stringBuilder.Append(", ");
                        }
                        stringBuilder.Append(item.Value);
                    }
                }
                return stringBuilder.ToString();
        }

    }
}
