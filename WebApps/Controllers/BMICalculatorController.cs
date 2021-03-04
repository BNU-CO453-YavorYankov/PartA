namespace WebApps.Controllers
{
    using System;
    using ConsoleAppProject.App02;
    using Microsoft.AspNetCore.Mvc;

    using static ConsoleAppProject.Common.Constants.BMICalculator;

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
            if (IsValid(model))
            {
                model.CalculateBMI();
                model.SetWeightStatus();

                TempData["result"] = true;
                TempData["BMI"] = Math.Round(model.BodyMassIndex);
                TempData["WeightStatus"] = model.WeightStatus;
            }
            return View();
        }

        /// <summary>
        /// Checks is the model valid
        /// </summary>
        /// <param name="model">The model of BMI Calculator</param>
        /// <returns>true if it valid, false if it is not</returns>
        private bool IsValid(BMICalculator model)
        {
            if (model.UnitType == UnitTypes.Imperial)
            {
                if (model.WeightInStones == 0)
                {
                    TempData["error"] = ZERO_STONES_ERROR_MSG;
                }
                else if (model.HeightInFeet == 0)
                {
                    TempData["error"] = ZERO_FEET_ERROR_MSG;
                }
                else if (model.WeightInStones < 0 ||
                        model.WeightInPounds < 0)
                {
                    TempData["error"] = NEGATIVE_WEIGHT_MSG;
                }
                else if (model.HeightInFeet < 0 ||
                        model.HeightInInches < 0)
                {
                    TempData["error"] = NEGATIVE_HEIGHT_MSG;
                }
            }
            else
            {
                if (model.WeightInKg == 0)
                {
                    TempData["error"] = ZERO_KG_ERROR_MSG;
                }
                else if (model.HeightInMetres == 0)
                {
                    TempData["error"] = ZERO_METRES_ERROR_MSG;
                }
                else if (model.WeightInKg < 0)
                {
                    TempData["error"] = NEGATIVE_WEIGHT_MSG;
                }
                else if (model.HeightInMetres < 0)
                {
                    TempData["error"] = NEGATIVE_HEIGHT_MSG;
                }
            }

            if (TempData["error"] != null)
            {
                return false;
            }
            return true;
        }
    }
}
