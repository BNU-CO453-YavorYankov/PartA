namespace WebApps.Services.Posts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApps.Models.App04;

    public interface IPostService
    {
        /// <summary>
        /// Add new post to the database
        /// </summary>
        /// <param name="post">New post</param>
        Task AddPost(Post post);

        /// <summary>
        /// Edit existing post in the database
        /// </summary>
        /// <param name="post">Updated post</param>
        Task EditPost(Post post);

        /// <summary>
        /// Find and delete post by id
        /// </summary>
        /// <param name="id">Id of the post to be deleted</param>
        Task DeletePost(int id);

        /// <summary>
        /// Find and return the post with same id as the parameter
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Post</returns>
        Task<Post> GetPostById(int id);

        /// <summary>
        /// Get all posts from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Post> GetPosts();

        /// <summary>
        /// Get all posts of a given author
        /// </summary>
        /// <param name="authorId">Author id</param>
        /// <returns>Posts of an author</returns>
        IEnumerable<Post> GetPostsByAuthorId(string authorId);
    }
}
