namespace SocialNetwork.Tests.Services
{
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Tests.Fakes;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApps.Data;
    using WebApps.Models.App04;
    using WebApps.Services.Comments;
    using WebApps.Services.Posts;
    using Xunit;

    public class PostServiceTests
    {
        private SqliteInMemoryDbContext _data;

        public PostServiceTests()
        {
            this._data = new SqliteInMemoryDbContext();
        }

        [Fact]
        public async Task AddPostShouldStorePostOnDbAsync()
        {
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var postService = new PostService(context, null);

                var post = PostFakes.GetPost();

                await postService.AddPost(post);

                context.Posts.ToList()
                    .Last()
                    .Should()
                    .BeEquivalentTo(post);
            }
        }

        [Fact]
        public async Task EditPostShouldUpdatePost()
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var postService = new PostService(context, null);

                var editedPost = PostFakes.GetPost();
                editedPost.PostId = 1;

                //Act
                await postService.EditPost(editedPost);

                //Assert
                context.Posts.ToList()
                    .Find(i => i.PostId == 1).Content
                        .Should()
                        .Be(editedPost.Content);

                context.Posts.ToList()
                    .Find(i => i.PostId == 1).CreatedOn
                        .Should()
                        .Be(editedPost.CreatedOn);
            }
        }

        [Fact]
        public void EditInvalidPostShouldThrowException()
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var postService = new PostService(context, null);

                //Assert
                postService.Invoking(s => s.EditPost(new Post { PostId = 15 }))
                    .Should()
                    .Throw<ArgumentException>();
            }
        }

        [Fact]
        public async Task DeletePostShouldRemovePostFromDb()
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var postService = new PostService(context, null);

                //Act
                await postService.DeletePost(1);

                //Assert
                context.Posts.ToList().Count
                        .Should()
                        .Be(2);
            }
        }

        [Fact]
        public async Task GetPostByIdShouldReturnPostAsync()
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var postService = new PostService(context, null);

                var expectedPost = context.Posts.ToArray().FirstOrDefault(i => i.PostId == 2);

                //Act
                var actualPost = await postService.GetPostById(2);

                //Assert
                expectedPost.Should().BeEquivalentTo(actualPost);
            }
        }

        [Fact]
        public void GetPostsShouldReturnCollectionOfPosts()
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var commentService = new CommentService(context);
                var postService = new PostService(context, commentService);

                var expectedPosts = context.Posts
                    .Include(a => a.Author)
                    .Include(ul => ul.UsersLikes)
                    .ToList();
                
                foreach (var post in expectedPosts)
                {
                    post.Comments = context.Comments
                        .Include(a =>a.Author)
                        .Where(pId => pId.PostId == post.PostId)
                        .ToList();
                }

                //Act
                var actualPosts = postService.GetPosts();

                //Assert
                expectedPosts.Select(c =>c.Content)
                    .Should()
                    .Equal(actualPosts.Select(c =>c.Content));

                expectedPosts.Select(p => p.PhotoName)
                    .Should()
                    .Equal(actualPosts.Select(p =>p.PhotoName));

                expectedPosts.Select(c => c.CreatedOn)
                    .Should()
                    .Equal(actualPosts.Select(c => c.CreatedOn));
                
                expectedPosts.Select(a => a.AuthorId)
                    .Should()
                    .Equal(actualPosts.Select(a => a.AuthorId));

                expectedPosts.Select(c => c.Comments.Count)
                    .Should()
                    .Equal(actualPosts.Select(c => c.Comments.Count));
            }
        }

        [Fact]
        public void GetPostByAuthorIdShouldReturnPostsOfAuthor()
        {
            //Arrange
            using (var context = new SocialNetworkDbContext(this._data.ContextOptions))
            {
                var commentService = new CommentService(context);
                var postService = new PostService(context, commentService);

                var authorId = context.Users
                    .Select(i =>i.Id)
                    .ToList()
                    .First();

                var expectedPosts = context.Posts
                    .Where(a =>a.AuthorId == authorId)
                    .ToList();

                //Act
                var actualPosts = postService.GetPostsByAuthorId(authorId);

                //Assert
                expectedPosts.Select(c => c.Content)
                    .Should()
                    .Equal(actualPosts.Select(c => c.Content));

                expectedPosts.Select(p => p.PhotoName)
                    .Should()
                    .Equal(actualPosts.Select(p => p.PhotoName));

                expectedPosts.Select(c => c.CreatedOn)
                    .Should()
                    .Equal(actualPosts.Select(c => c.CreatedOn));

                expectedPosts.Select(a => a.AuthorId)
                    .Should()
                    .Equal(actualPosts.Select(a => a.AuthorId));

                expectedPosts.Select(c => c.Comments.Count)
                    .Should()
                    .Equal(actualPosts.Select(c => c.Comments.Count));
            }
        }
    }
}
