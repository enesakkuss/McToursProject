using McTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Validators
{
    internal class TicketValidator
    {
        public ValidationResult Validate(Ticket ticket)
        {
            var validationResult = new ValidationResult();

            if(ticket.BusTripId <= 0)
            {
                validationResult.AddError("Sefer Boş Geçilemez");
            }
            if (ticket.PassengerId <= 0)
            {
                validationResult.AddError("Yolcu Boş Geçilemez");
            }
            if (ticket.SeatNumber <= 0)
            {
                validationResult.AddError("Koltuk Seçmediniz");
            }
            if (ticket.Price <= 0)
            {
                validationResult.AddError("Ücret Boş Geçilemez");
            }
            return validationResult;
        }
    }
}
