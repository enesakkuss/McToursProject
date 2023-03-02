using McTours.Business.Services;
using McTours.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly PassengerService _passengerService = new PassengerService();
        private readonly BusTripService _busTripService = new BusTripService();
        private readonly TicketService _ticketService = new TicketService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BusTripTicketReview(int busTripId, int seatNumber,int passengerId)
        {
            var busTrip = _busTripService.GetById(busTripId);
            var passenger=_passengerService.GetById(passengerId);

            var ticketReview = new TicketReview()
            {
                BusTripId = busTripId,
                PassengerId = passengerId,
                SeatNumber = seatNumber,
                Price = busTrip.TicketPrice,
                PassengerFirstName = passenger.FirstName,
                PassengerLastName = passenger.LastName,
            };
            return PartialView(ticketReview);
        }

        [HttpPost]
        public IActionResult Create(TicketDto ticketDto)
        {
            var result = _ticketService.Create(ticketDto);

            if(result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
            }
            else
            {
                TempData["ResultMessage"] = result.Message;
            }
            return RedirectToAction("Ticket","BusTrips",new {id=ticketDto.BusTripId});
        }

    }
}
