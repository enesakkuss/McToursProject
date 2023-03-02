using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Tickets
{
    public class TicketSummary
    {
        public int Id { get; set; }
        public int BusTripId { get; set; }
        public int PassengerId { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public string PassengerName { get; set; }
        public string IdentityNumber { get; set; }
        public Gender Gender { get; set; }
        public string VehicleName { get; set; }
    }
}
