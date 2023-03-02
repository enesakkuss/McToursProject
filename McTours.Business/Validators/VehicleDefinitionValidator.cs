using McTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Validators
{
    internal class VehicleDefinitionValidator
    {
        public ValidationResult Validate(VehicleDefinition vehicleDefinition)
        {
            var validationResult = new ValidationResult();

            if (vehicleDefinition.FuelType <= 0)
            {
                validationResult.AddError("Yakıt Tipi Boş Geçilemez");
            }
            if (vehicleDefinition.SeatingType <= 0)
            {
                validationResult.AddError("Oturma Düzeni Boş Geçilemez");
            }
            if (vehicleDefinition.LineCount <= 0)
            {
                validationResult.AddError("Sıra Sayısı Boş Geçilemez");
            }
            if (vehicleDefinition.Year <= 0)
            {
                validationResult.AddError("Yıl Boş Geçilemez");
            }
            if (vehicleDefinition.VehicleModelId <= 0)
            {
                validationResult.AddError("Model Boş Geçilemez");
            }
            return validationResult;
        }
    }
}
