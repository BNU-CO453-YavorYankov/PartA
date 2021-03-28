namespace WebApps.Controllers.App04
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WebApps.Services.Posts;

    /// <summary>
    /// The name of this controller is chosen in order to 
    /// be referenced easier and not to affect the main HomeController
    /// </summary>
    public class HomeSocialNetworkController : Controller
    {
        private IPostService _postService;

        public HomeSocialNetworkController(IPostService postService)
            => this._postService = postService;

        public ActionResult Index()
        {
            return View(this._postService.GetPosts().ToList());
        }
    }
}
