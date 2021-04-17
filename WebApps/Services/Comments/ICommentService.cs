namespace WebApps.Services.Comments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApps.Models.App04;

    public interface ICommentService
    {
        Task AddComment(Comment comment);
        IEnumerable<Comment> GetCommentsByPostId(int postId);
    }
}
