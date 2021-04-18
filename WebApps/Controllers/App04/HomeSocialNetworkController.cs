namespace WebApps.Controllers.App04
{
    using Microsoft.AspNetCore.Mvc;
    using System;
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

        public IActionResult Index(string dateFilter = null)
        {
            if (dateFilter is not null)
            {
                var date = DateTime.Parse(dateFilter).ToString("dd/MM/yyyy");

                TempData["dateFilter"] = $"Posts published on {date}";

                return View(this._postService.GetPosts()
                    .Where(c =>c.CreatedOn.ToString("dd/MM/yyyy") == date)
                    .OrderByDescending(c =>c.CreatedOn)
                    .ToList());
            }
            return View(this._postService.GetPosts()
                .OrderByDescending(c =>c.CreatedOn)
                .ToList());
        }
    }
}
