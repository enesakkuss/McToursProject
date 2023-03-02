using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // /Ajax/GetPlayerName
        public string GetPlayerName()
        {
            return "Tsubasa Ozora";
        }

        public IActionResult GetPlayerNames()
        {
            var players = new List<object>()
            {
               new {FirstName = "Tsubasa", LastName = "Ozora"},
               new {FirstName = "Taro", LastName = "Misaki"},
            };

            return Json(players);
            //JSON => JavaScript Object Notation
            //Nesnelerin JavaScript nesnesi tipinde/görünümünde string bir biçime çevrilmesi

        }

    }
}
