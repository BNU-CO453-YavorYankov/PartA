namespace WebApps.Services.Posts
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApps.Data;
    using WebApps.Models.App04;
    using WebApps.Services.Comments;

    /// <summary>
    /// Post service implement post service interface.
    /// It can add, edit and delete posts.
    /// </summary>
    public class PostService : IPostService
    {
        /// <summary>
        /// Injected database
        /// </summary>
        private SocialNetworkDbContext _data;
        /// <summary>
        /// Injected comment service
        /// </summary>
        private ICommentService _commentService;

        /// <summary>
        /// Create post service as inject the db context and comment service
        /// </summary>
        /// <param name="data">Db context</param>
        /// <param name="data">Comment service interface</param>
        public PostService(SocialNetworkDbContext data, ICommentService commentService)
        {
            this._data = data;
            this._commentService = commentService;
        }

        public async Task AddPost(Post post)
        {
            await this._data.Posts.AddAsync(post);
            await SaveChangesAsync();
        }

        public async Task EditPost(Post post)
        {
            IsPostExist(post.PostId);

            this._data.Posts.Update(post);

            await SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            IsPostExist(id);

            var post = await GetPostById(id);
            this._data.Posts.Remove(post);
            await SaveChangesAsync();
        }

        public async Task<Post> GetPostById(int id)
            => await this._data.Posts
                .Include(a => a.Author)
                .Include(l => l.UsersLikes)
                .FirstOrDefaultAsync(i => i.PostId == id);

        public IEnumerable<Post> GetPosts()
        {
            var posts = this._data.Posts
                    .Include(a => a.Author)
                    .Include(ul => ul.UsersLikes)
                    .AsNoTracking()
                    .ToList();

            foreach (var post in posts)
            {
                post.Comments = this._commentService
                    .GetCommentsByPostId(post.PostId)
                    .ToList();
            }

            return posts;
        }

        /// <summary>
        /// Get all posts then on each post get its comments
        /// </summary>
        /// <param name="authorId">The id of the author</param>
        /// <returns></returns>
        public IEnumerable<Post> GetPostsByAuthorId(string authorId)
            => GetPosts()
                  .Where(aId => aId.AuthorId == authorId)
                  .ToList();

        public bool IsPostExist(int postId)
        {
            if (this._data.Posts.Any(i => i.PostId == postId))
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Post with {postId} cannot be found");
            }
        }

        private async Task SaveChangesAsync()
            => await this._data.SaveChangesAsync();

    }
}
