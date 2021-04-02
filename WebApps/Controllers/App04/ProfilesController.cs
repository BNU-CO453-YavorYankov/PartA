namespace WebApps.Controllers.App04
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WebApps.Models.App04;
    using WebApps.Services.Posts;
    using System.Threading.Tasks;

    /// <summary>
    /// The controller responsible for user profile
    /// </summary>
    public class ProfilesController : Controller
    {
        private UserManager<User> _userManager;
        private IPostService _postService;

        public ProfilesController(
            UserManager<User> userManager,
            IPostService postService)
        {
            this._userManager = userManager;
            this._postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await this._userManager.GetUserAsync(User);

            currentUser.Posts = this._postService.GetPostsByAuthorId(currentUser.Id).ToList();

            return View(currentUser);
        }
    }
}
