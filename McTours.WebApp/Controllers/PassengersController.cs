using McTours.Business.Services;
using McTours.Passengers;
using McTours.VehicleDefinitions;
using McTours.WebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class PassengersController : Controller
    {
        private readonly PassengerService _passengerService=new PassengerService();
        public IActionResult Index()
        {
            var passenger = _passengerService.GetAll();
            return View(passenger);
        }

        public IActionResult SearchPassengers()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SearchPassengers(SearchPassengerModel searchPassengerModel)
        {
            var passengers = _passengerService.SearchPassengers(searchPassengerModel);

            return Json(passengers);
        }

        public IActionResult Create()
        {
            ViewBag.GenderSelectedList = EnumHelper.GetAllGenders();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PassengerDto passenger)
        {
            ViewBag.GenderSelectedList = EnumHelper.GetAllGenders();

            var result = _passengerService.Create(passenger);
            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.GenderSelectedList = EnumHelper.GetAllGenders();
                TempData["ResultMessage"] = result.Message;
                return View();
            }
        }
        public IActionResult Delete(PassengerDto passenger)
        {
            var commandResult = _passengerService.Delete(passenger);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var passenger = _passengerService.GetById(id);


            if (passenger != null)
            {
                ViewBag.GenderSelectedList = EnumHelper.GetAllGenders();

                return View(passenger);
            }
            else
            {
                TempData[Keys.ErrorMessage] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public IActionResult Update(PassengerDto passenger)
        {
            var commandResult = _passengerService.Update(passenger);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.GenderSelectedList = EnumHelper.GetAllGenders();
                TempData["ResultMessage"] = commandResult.Message;
                return View(passenger);
            }
        }
    }
}
