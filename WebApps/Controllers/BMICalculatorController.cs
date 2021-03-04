namespace WebApps.Controllers
{
    using ConsoleAppProject.App02;
    using Microsoft.AspNetCore.Mvc;
    
    public class BMICalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        //[HttpPost]
        //[IgnoreAntiforgeryToken]
        //public IActionResult Calculate(BMICalculator model) 
        //{

        //}
    }
}
