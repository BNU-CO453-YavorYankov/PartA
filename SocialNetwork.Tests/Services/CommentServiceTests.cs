namespace SocialNetwork.Tests.Services
{
    using FluentAssertions;
    using SocialNetwork.Tests.Fakes;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApps.Data;
    using WebApps.Services.Comments;
    using Xunit;

    public class CommentServiceTests
    {
        private SqliteInMemoryDbContext _data;

        public CommentServiceTests()
        {
            this._data = new SqliteInMemoryDbContext();
        }

        [Fact]
        public async Task AddCommentToPostShouldAddCommentAsync()
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var commentService = new CommentService(context);

                var comment = CommentFakes.GetComment();
                comment.PostId = 1;

                //Act
                await commentService.AddComment(comment);

                //Assert
                context.Comments.ToList()
                    .Last()
                    .Should()
                    .BeEquivalentTo(comment);
            }
        }

        [Fact]
        public void GetCommentsByPostIdShouldReturnCollectionOfComments() 
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var commentService = new CommentService(context);

                var postId = context.Posts
                    .Select(i => i.PostId)
                    .ToList()
                    .First();

                var expectedComments = context.Comments
                    .Where(p => p.PostId == postId)
                    .ToList();

                //Act
                var actualComments = commentService.GetCommentsByPostId(postId);

                //Assert
                expectedComments.Select(c => c.Content)
                    .Should()
                    .Equal(actualComments.Select(c => c.Content));

                expectedComments.Select(c => c.CreatedOn)
                    .Should()
                    .Equal(actualComments.Select(c => c.CreatedOn));

                expectedComments.Select(a => a.AuthorId)
                    .Should()
                    .Equal(actualComments.Select(a => a.AuthorId));
            }
        }
    }
}
