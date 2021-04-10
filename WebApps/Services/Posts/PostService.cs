namespace WebApps.Services.Posts
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApps.Data;
    using WebApps.Models.App04;

    /// <summary>
    /// Post service implement post service interface.
    /// It can add, edit and delete posts.
    /// </summary>
    public class PostService : IPostService
    {
        /// <summary>
        /// Injected database
        /// </summary>
        private readonly SocialNetworkDbContext _data;

        /// <summary>
        /// Create post service as inject the db context
        /// </summary>
        /// <param name="data">Db context</param>
        public PostService(SocialNetworkDbContext data)
            => this._data = data;

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
                .Include(a =>a.Author)
                .Include(l =>l.UsersLikes)
                .FirstOrDefaultAsync(i => i.PostId == id);

        public IEnumerable<Post> GetPosts()
            => this._data.Posts
                .Include(a =>a.Author)
                .Include(ul =>ul.UsersLikes)
                .AsNoTracking();
        
        public IEnumerable<Post> GetPostsByAuthorId(string authorId)
            => GetPosts()
                .Where(aId => aId.AuthorId == authorId)
                .ToList();

        private bool IsPostExist(int postId)
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
