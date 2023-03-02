using McTours.Business.Services;
using McTours.Domain;
using McTours.VehicleDefinitions;
using McTours.VehicleModels;
using McTours.WebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class VehicleDefinitionsController : Controller
    {
        private readonly VehicleDefinitionsService _vehicleDefinitionService = new VehicleDefinitionsService();
        private readonly VehicleModelService _vehicleModelService = new VehicleModelService();
        private readonly VehicleMakeService _vehicleMakeService = new VehicleMakeService();
        public IActionResult Index()
        {
            var vehicles = _vehicleDefinitionService.GetSummaries();
            return View(vehicles);
        }

        public IActionResult Create()
        {
            LoadExtraModels();

            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleDefinitionDto vehicleDefinition)
        {
            LoadExtraModels();

            var result = _vehicleDefinitionService.Create(vehicleDefinition);
            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadExtraModels();
                TempData["ResultMessage"] = result.Message;
                return View();
            }
        }

        public IActionResult Delete (VehicleDefinitionDto vehicleDefinition)
        {
            var commandResult = _vehicleDefinitionService.Delete(vehicleDefinition);
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

        public IActionResult Update (int id)
        {
            var vehicleDefinition = _vehicleDefinitionService.GetById(id);
            

            if (vehicleDefinition != null)
            {
                LoadExtraModels(vehicleDefinition.VehicleMakeId);

                return View(vehicleDefinition);
            }
            else
            {
                TempData[Keys.ErrorMessage] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public IActionResult Update (VehicleDefinitionDto vehicleDefinition)
        {
            var commandResult=_vehicleDefinitionService.Update(vehicleDefinition);

            if(commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadExtraModels(vehicleDefinition.VehicleMakeId);
                TempData["ResultMessage"] = commandResult.Message;
                return View(vehicleDefinition);
            }
        }

        private void LoadExtraModels(int vehicleMakeId = 0)
        {
            ViewBag.FuelTypes = EnumHelper.GetAllFuelType();
            ViewBag.SeatingTypes = new SelectList(EnumHelper.GetAllSeatingType(), "Value", "Name");
            ViewBag.Utilities = EnumHelper.GetAllUtilities();

            ViewBag.MakeNames = new SelectList(_vehicleMakeService.GetAll(), "Id", "Name");

            var vehicleModel = _vehicleModelService.GetAll();
            var vehicleModelOfMake = vehicleModel.Where(model => model.VehicleMakeId == vehicleMakeId);
            ViewBag.VehicleModel = new SelectList(vehicleModelOfMake, "Id", "Name");
        }
    }
    
}
