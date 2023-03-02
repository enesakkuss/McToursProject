using McTours.Business.Services;
using McTours.VehicleMakes;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class VehicleMakesController : Controller
    {
        private readonly VehicleMakeService _vehicleMakeService = new VehicleMakeService();
        public IActionResult Index()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();

            return View(vehicleMakes);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleMakeDto vehicleMake)
        {
            var commandResult = _vehicleMakeService.Create(vehicleMake);
            
            if(commandResult.IsSuccess)
            {
                // TempData üzerindeki veriler, en az bir kez okunana kadar (get edilene kadar)
                // sunucuda muhafaza edilir. En az bir kez okunduğunda, Response tamamlandıktan 
                // sonra silinir
                TempData["ResultMessage"] = commandResult.Message;
                
                return RedirectToAction("Index");
            }
            else
            {
                // ViewBag, ViewData, TempData
                // Bir view'a model dışında ekstra bilgi taşımanın yöntemleri

                //TempData["ResultMessage"] = commandResult.Message;

                // ViewData ise adından anlaşılacağı üzere doğrudan View ile ilgilidir. Eğer
                // bir action View() döndürüyorsa ViewData üzerindeki değerler View tarafında
                // okunabilir. Eğer action metodu View dışında başka bir result döndürüyorsa
                // (RedirectToAction, Content, Json vs..) ViewData muhafaza edilmez
                
                // ViewData-> Dictionary <string, object> tipinde
                //ViewData["ResultMessage"] = commandResult.Message;

                // ViewBag-> dynamic tipinde
                ViewBag.ResultMessage=commandResult.Message;

                // Aslında ViewData ile ViewBag nesneleri aynı nesneler
                // Sadece kullanım (yazım) şekli farklıdır; sentaksları farklı
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            var updateId = _vehicleMakeService.GetById(id);
            if(updateId != null)
            {
                return View(updateId);
            }
            else
            {
                TempData ["ErrorMessage"]="Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(VehicleMakeDto vehicleMake)
        {
            
            var commandResult = _vehicleMakeService.Update(vehicleMake);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(vehicleMake);
            }
        }

        public IActionResult Delete(int id)
        {
            var vehicleMake = _vehicleMakeService.GetById(id);
            if (vehicleMake !=null)
            {
                return View(vehicleMake);
            }
            else
            {
                TempData["ErrorMessage"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete (VehicleMakeDto vehicleMake)
        {
            var commandResult=_vehicleMakeService.Delete(vehicleMake);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(vehicleMake);
            }
        }
        


        [HttpPost] // Bu sınırlandırmayı yaptırmazsak manuel olarak veri kaydı yapılabilir (Kaydet, Güncelle ve Sil de kullanılmalı)
        
        // Doğrudan Model olarak karşılamak
        public IActionResult CreateConfirmed(VehicleMakeDto vehicleMake)
        {
            var result = _vehicleMakeService.Create(vehicleMake);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // ViewBag, ViewData, TempData
                // Bir view'a model dışında ekstra bilgi taşımanın yöntemleri

                //TempData.Add("ResultMessage",result.Message);
                TempData["ResultMessage"] = result.Message;

                return RedirectToAction("Creat");
            }
        }
        

            //public IActionResult CreateConfirmed()
            //{
            //    var makeName = Request.Form["name"];
            //    var vehicleMakesDto = new VehicleMakeDto()
            //    {
            //        Name = makeName
            //    };
            //    _vehicleMakeService.Create(vehicleMakesDto);
            //    return new EmptyResult();
            //}

            //public IActionResult CreateConfirmed(IFormCollection formValues)
            //{
            //    var makeName = formValues["name"];
            //    var number = formValues["number"];
            //    var numberValues = int.Parse(number);

            //    var vehicleMakeDto = new VehicleMakeDto()
            //    {
            //        Name = makeName,
            //    };

            //    _vehicleMakeService.Create(vehicleMakeDto);

            //    return new EmptyResult();
            //}

            //public IActionResult CreateConfirmed(string name)
            //{
            //    var vehicleMakeDto = new VehicleMakeDto()
            //    {
            //        Name = name
            //    };

            //    _vehicleMakeService.Create(vehicleMakeDto);

            //    return new EmptyResult();
            //}


        }
}
