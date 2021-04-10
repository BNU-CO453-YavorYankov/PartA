namespace WebApps.Controllers.App04
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApps.Models.App04;
    using WebApps.Services.Posts;

    using static Models.ModelConstants.Post;

    [Authorize]
    public class PostsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public PostsController(
            IWebHostEnvironment env,
            IPostService postService,
            UserManager<User> userManager)
        {
            this._env = env;
            this._postService = postService;
            this._userManager = userManager;
        }

        // GET: Posts
        public IActionResult Index()
        {
            var currentUserId = this._userManager
                .GetUserId(User);

            return View(this._postService.GetPostsByAuthorId(currentUserId));
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            Validate(post);

            if (ModelState.IsValid)
            {
                var currentUserId = this._userManager.GetUserId(User);

                post.AuthorId = currentUserId;
                post.PhotoName = UploadPhoto(post.Photo, currentUserId);
                post.CreatedOn = DateTime.Now;

                await this._postService.AddPost(post);

                return RedirectToAction("Index", "HomeSocialNetwork");
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await this._postService
                .GetPostById((int)id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Post post)
        {
            Validate(post);

            if (ModelState.IsValid)
            {
                try
                {
                    await this._postService.EditPost(post);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await this._postService
                .GetPostById((int)id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._postService.DeletePost(id);

            return RedirectToAction("Index", "Profiles");
        }

        /// <summary>
        /// Increase the likes of a given post
        /// </summary>
        public async Task<JsonResult> IncreaseLikes([FromQuery] int id)
        {
            var post = await this._postService
                .GetPostById(id);

            var currentUserId = this._userManager
                .GetUserId(User);

            // Add new user like post as set post id and user id
            post.UsersLikes.Add(new UserLikePost
            {
                PostId = post.PostId,
                UserId = currentUserId
            });

            await this._postService.EditPost(post);

            return new JsonResult(true);
        }

        /// <summary>
        /// Increase the likes of a given post
        /// when it is not the current user
        /// </summary>
        [HttpPost]
        public async Task<JsonResult> IncreaseLikes([FromBody] UserLikePost userLikePost)
        {
            if (IsUserExist(userLikePost.UserId) && IsPostExist(userLikePost.PostId))
            {
                var post = await this._postService
                    .GetPostById(userLikePost.PostId);

                // Add new user like post as set post id and user id
                post.UsersLikes.Add(new UserLikePost
                {
                    PostId = userLikePost.PostId,
                    UserId = userLikePost.UserId
                });
                await this._postService.EditPost(post);

                return new JsonResult(true);
            }
            else
            {
                throw new ArgumentException($"Invalid data.");
            }
        }

        /// <summary>
        /// Save uploaded image in img folder of wwwroot
        /// </summary>
        /// <param name="uploadedPhoto">Photo to be uploaded</param>
        private string UploadPhoto(IFormFile uploadedPhoto, string authorId)
        {
            string uniqueFileName = null;

            if (uploadedPhoto != null)
            {
                string uploadsFolder = Path.Combine(this._env.WebRootPath, "img");

                uniqueFileName = $"{authorId}_{uploadedPhoto.FileName}";

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);

                uploadedPhoto.CopyTo(fileStream);
            }
            return uniqueFileName;
        }

        /// <summary>
        /// validate whether 
        /// </summary>
        /// <param name="post"></param>
        private void Validate(Post post)
        {
            if (post.Content is null || post.Content.Length < MIN_CONTENT_LENGTH || post.Content.Length > MAX_CONTENT_LENGTH)
            {
                this.ModelState.AddModelError(nameof(Post.Content), $"Content required and cannot be less than {MIN_CONTENT_LENGTH} or more than {MAX_CONTENT_LENGTH} symbols long.");
            }
        }

        private bool IsUserExist(string userId)
            => this._userManager.Users.Any(i => i.Id == userId);

        private bool IsPostExist(int postId)
            => this._postService.GetPosts().Any(p => p.PostId == postId);
    }
}
