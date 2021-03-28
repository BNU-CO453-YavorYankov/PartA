using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApps.Models.App04;
using WebApps.Services.Posts;

namespace WebApps.Controllers.App04
{
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
            if (ModelState.IsValid)
            {
                var currentUserId = this._userManager.GetUserId(User);

                //Set current user id to be author id
                post.AuthorId = currentUserId;
                
                //Upload photo if there is so
                post.PhotoName = UploadPhoto(post.Photo, currentUserId);

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
            
            return RedirectToAction(nameof(Index));
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
    }
}
