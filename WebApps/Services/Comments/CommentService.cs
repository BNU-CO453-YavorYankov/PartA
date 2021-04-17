namespace WebApps.Services.Comments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApps.Data;
    using WebApps.Models.App04;

    public class CommentService : ICommentService
    {
        /// <summary>
        /// Injected database
        /// </summary>
        private SocialNetworkDbContext _data;

        /// <summary>
        /// Create comment service as inject the db context
        /// </summary>
        /// <param name="data">Db context</param>
        public CommentService(SocialNetworkDbContext data)
            => this._data = data;

        public async Task AddComment(Comment comment)
        {
            await this._data.Comments.AddAsync(comment);
            await SaveChangesAsync();
        }

        public IEnumerable<Comment> GetCommentsByPostId(int postId)
            => this._data.Comments
                .Where(pId =>pId.PostId == postId)
                .ToList();

        private async Task SaveChangesAsync()
            => await this._data.SaveChangesAsync();
    }
}
