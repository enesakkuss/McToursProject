using McTours.Business.Services;
using McTours.BusTrips;
using McTours.Vehicles;
using McTours.WebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    //[Route("[controller]")]
    public class BusTripsController : Controller
    {
        private readonly BusTripService _busTripService = new BusTripService();
        private readonly VehicleService _vehicleService = new VehicleService();
        private readonly CityService _cityService = new CityService();
        public IActionResult Index()
        {
            var trips = _busTripService.GetSummaries();
            return View(trips);
        }

        public IActionResult Create()
        {
            LoadModels();
            return View();
        }
        [HttpPost]
        public IActionResult Create(BusTripDto busTrip)
        {
            var result = _busTripService.Create(busTrip);

            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadModels();
                TempData["ResultMessage"] = result.Message;
                return View();
            }
        }
        public IActionResult Delete(BusTripDto busTrip)
        {
            var result = _busTripService.Delete(busTrip);

            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
            }
            else
            {
                TempData["ResultMessage"] = result.Message;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var vehicle = _busTripService.GetById(id);
            if (vehicle != null)
            {
                LoadModels();
                return View(vehicle);
            }
            else
            {
                ViewData["ErrorMessage"] = $"{id} ID'li kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(BusTripDto busTrip)
        {
            var result = _busTripService.Update(busTrip);

            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadModels();

                TempData["ResultMessage"] = result.Message;
                return View(busTrip);
            }
        }

        private void LoadModels()
        {
            ViewBag.VehicleSelectedList = new SelectList(_vehicleService.GetSummaries(), "Id", "VehicleName");
            ViewBag.DepartureCitySelectedList = new SelectList(_cityService.GetAll(), "Id", "Name");
            ViewBag.ArrivalCitySelectedList = new SelectList(_cityService.GetAll(), "Id", "Name");
        }

        [Route("[controller]/{id}/[action]")]
        public IActionResult Ticket (int id)
        {
            var vehicle = _busTripService.GetDetail(id);
            if(vehicle != null)
            {
                return View(vehicle);
            }
            else
            {
                ViewData["ErrorMessage"] = $"{id} ID'li kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }
    }
}
