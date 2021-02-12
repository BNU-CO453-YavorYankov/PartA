namespace WebApps.Controllers
{
    using ConsoleAppProject.App01;
    using Microsoft.AspNetCore.Mvc;

    public class DistanceConverterController : Controller
    {
        [HttpGet]
        public IActionResult Convert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Convert(DistanceConverter model)
        {
            if (model.FromUnit == DistanceUnits.NoUnit || model.ToUnit == DistanceUnits.NoUnit)
            {
                TempData["error"] = $"Units cannot be of type no unit!";
                return View();
            }
            if (model.FromUnit == model.ToUnit)
            {
                TempData["error"] = $"Units cannot be a same type!";
                return View();
            }
            if (model.FromDistance < 0 || model.FromDistance is 0.00d)
            {
                TempData["error"] = $"Distance value cannot be less than or equal zero or empty!";
                return View();
            }

            model.ConvertDistance();

            TempData["result"] = $"{model.FromDistance} {model.FromUnit} is {model.ToDistance} {model.ToUnit}";

            return View();
        }
    }
}
