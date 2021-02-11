namespace WebApps.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DistanceConverterController : Controller
    {
        [HttpGet]
        public IActionResult Convert()
        {
            return View();
        }
    }
}
