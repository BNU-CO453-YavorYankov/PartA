namespace WebApps.Controllers.App04
{
    using Microsoft.AspNetCore.Mvc;
    
    /// <summary>
    /// The name of this controller is chosen in order to 
    /// be referenced easier and not to affect the main HomeController
    /// </summary>
    public class HomeSocialNetworkController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
