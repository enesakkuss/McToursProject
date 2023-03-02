using McTours.Business.Services;
using McTours.Vehicles;
using McTours.WebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService = new VehicleService();
        private readonly VehicleModelService _vehicleModelService = new VehicleModelService();
        private readonly VehicleDefinitionsService _vehicleDefinitionService = new VehicleDefinitionsService();
        private readonly VehicleMakeService _vehicleMakeService = new VehicleMakeService();

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetSummaries();

            return View(vehicles);
        }

        public IActionResult Create()
        {
            ViewBag.VehicleDefinitionWithName = _vehicleDefinitionService.GetIdAndName();
            return View();
        }

        private void LoadExtraModels(int vehicleMakeId=0)
        {
            ViewBag.MakeNames = new SelectList(_vehicleMakeService.GetAll(), "Id", "Name");

            var vehicleModel = _vehicleModelService.GetAll();
            var vehicleModelOfMake = vehicleModel.Where(model => model.VehicleMakeId == vehicleMakeId);
            ViewBag.VehicleModel = new SelectList(vehicleModelOfMake, "Id", "Name");
        }

        [HttpPost]
        public IActionResult Create(VehicleDto vehicle)
        {
            var result = _vehicleService.Create(vehicle);

            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.VehicleDefinitionWithName = _vehicleDefinitionService.GetIdAndName();
                TempData["ErrorMessage"] = result.Message;
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle != null)
            {
                ViewBag.VehicleDefinitionWithName = _vehicleDefinitionService.GetIdAndName();
                return View(vehicle);
            }
            else
            {
                ViewData["ErrorMessage"] = $"{id} ID'li kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Update(VehicleDto vehicle)
        {
            var result = _vehicleService.Update(vehicle);

            if (result.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadExtraModels(vehicle.VehicleMakeId);

                ViewData[Keys.ErrorMessage] = result.Message;
                return View(vehicle);
            }
        }
        public IActionResult Delete(VehicleDto vehicle)
        {
            var result = _vehicleService.Delete(vehicle);

            if (result.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = result.Message;
            }
            else
            {
                TempData[Keys.ErrorMessage] = result.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
