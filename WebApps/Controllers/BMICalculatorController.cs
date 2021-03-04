namespace WebApps.Controllers
{
    using ConsoleAppProject.App02;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class BMICalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Calculate(BMICalculator model)
        {
            model.CalculateBMI();
            model.SetWeightStatus();

            TempData["result"] = true;
            TempData["BMI"] = Math.Round(model.BodyMassIndex);
            TempData["WeightStatus"] = model.WeightStatus;
            
            return View();
        }
    }
}
