using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Controllers
{
    public class BMICalculatorController : Controller
    {
        public IActionResult Calculate()
        {
            return View();
        }
    }
}
