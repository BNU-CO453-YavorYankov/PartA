namespace WebApps.Controllers.App04
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using WebApps.Models.App04;
    using WebApps.Services.Comments;
    using WebApps.Services.Posts;

    using static Models.ModelConstants.Post;

    [Authorize]
    public class CommentsController : Controller
    {
        /// <summary>
        /// Injected post service
        /// </summary>
        private IPostService _postService;
        /// <summary>
        /// Injected comment service
        /// </summary>
        private ICommentService _commentService;
        /// <summary>
        /// Injected user manager
        /// </summary>
        private UserManager<User> _userManager;

        public CommentsController(
            IPostService postService,
            ICommentService commentService,
            UserManager<User> userManager)
        {
            this._postService = postService;
            this._commentService = commentService;
            this._userManager = userManager;
        }

        //GET: Comments/ListCommentsByPostId
        public IActionResult ListCommentsByPostId(int postId)
        {
            if (this._postService.IsPostExist(postId))
            {
                var comments = this._commentService
                    .GetCommentsByPostId(postId);

                return View(comments);
            }
            return NotFound(postId);
        }

        // GET: Comments/Create
        public IActionResult Create(int postId)
        {
            if (this._postService.IsPostExist(postId))
            {
                return View(new Comment
                {
                    PostId = postId
                });
            }
            return NotFound(postId);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment)
        {
            Validate(comment);

            if (ModelState.IsValid)
            {
                comment.AuthorId = this._userManager.GetUserId(User);
                comment.CreatedOn = DateTime.Now;

                await this._commentService.AddComment(comment);

                return RedirectToAction("Index", "HomeSocialNetwork");
            }
            return View(comment);
        }

        /// <summary>
        /// validate whether the comment valid
        /// </summary>
        /// <param name="comment">the comment to be validated</param>
        private void Validate(Comment comment)
        {
            if (comment.Content is null || comment.Content.Length < MIN_CONTENT_LENGTH || comment.Content.Length > MAX_CONTENT_LENGTH)
            {
                this.ModelState.AddModelError(nameof(Comment.Content), $"Content required and cannot be less than {MIN_CONTENT_LENGTH} or more than {MAX_CONTENT_LENGTH} symbols long.");
            }
        }
    }
}
