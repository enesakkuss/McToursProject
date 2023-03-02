using McTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Validators
{
    internal class VehicleModelValidator
    {
        public ValidationResult Validate (VehicleModel vehicleModel)
        {
            var validationResult = new ValidationResult();

            if(string.IsNullOrWhiteSpace(vehicleModel.Name))
            {
                validationResult.AddError("Araç Model Adı Boş Geçilemez");
            }
            if(vehicleModel.VehicleMakeId <= 0)
            {
                validationResult.AddError("Marka Alanı Boş Geçilemez");
            }
            return validationResult;
        }
    }
}
