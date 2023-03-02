using McTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Validators
{
    internal class PassengerValidator
    {
        public ValidationResult Validate(Passenger passenger)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(passenger.FirstName))
            {
                validationResult.AddError("İsim Boş Geçilemez");
            }
            if (string.IsNullOrWhiteSpace(passenger.LastName))
            {
                validationResult.AddError("Soyisim Boş Geçilemez");
            }
            if (string.IsNullOrWhiteSpace(passenger.IdentityNumber))
            {
                validationResult.AddError("Kimlik No Boş Geçilemez");
            }
            if (passenger.DateOfBirth == null)
            {
                validationResult.AddError("Doğum Günü Boş Geçilemez");
            }
            if (passenger.Gender <= 0)
            {
                validationResult.AddError("Cinsiyet Boş Geçilemez");
            }
            return validationResult;
        }
    }
}
