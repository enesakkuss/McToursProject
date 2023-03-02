using McTours.Business.Services;
using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleMakes;
using McTours.VehicleModels;
using McTours.WebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace McTours.WebApp.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly VehicleModelService _vehicleModelService = new VehicleModelService();
        private readonly VehicleMakeService _vehicleMakeService = new VehicleMakeService();
        private McToursContext db = new McToursContext();
        public IActionResult Index()
        {
            var vehicleModels=_vehicleModelService.GetSummaries();
            return View(vehicleModels);
        }
        public IActionResult Create()
        {
            ViewBag.VehicleMakes = _vehicleMakeService.GetAll();
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(VehicleModelDto vehicleModel)
        {
            var commandResult = _vehicleModelService.Create(vehicleModel);
            ViewBag.VehicleMakes = _vehicleMakeService.GetAll();
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"]=commandResult.Message;
              return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            var updateId=_vehicleModelService.GetById(id);
            if (updateId != null)
            {
                //ViewBag.VehicleMakes = _vehicleMakeService.GetAll();
                var vehicleMakes = _vehicleMakeService.GetAll();
                ViewBag.VehicleMakes = new SelectList(vehicleMakes, "Id", "Name");
                return View(updateId);
            }
            else
            {
                TempData[Keys.ErrorMessage] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(VehicleModelDto vehicleModel)
        {
            var commandResult = _vehicleModelService.Update(vehicleModel);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                var vehicleMakes = _vehicleMakeService.GetAll();
                ViewBag.VehicleMakes = new SelectList(vehicleMakes, "Id", "Name");
                TempData["ResultMessage"] = commandResult.Message;
                return View(vehicleModel);
            }
        }
        public IActionResult Delete(VehicleModelDto vehicleModel)
        {
            var commandResult = _vehicleModelService.Delete(vehicleModel);
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

        [HttpGet]
        public IActionResult GetByMakeId (int makeId)
        {
            var vehicleModels = _vehicleModelService.GetAll();

            var vehicleModelsByMakeId = vehicleModels.Where(m => m.VehicleMakeId == makeId);

            return Json(vehicleModelsByMakeId);
        }

    }
}
