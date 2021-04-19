using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using WebApps.Data;
using WebApps.Models.App04;

namespace SocialNetwork.Tests
{
    public class SqliteInMemoryDbContext
    {
        internal SqliteInMemoryDbContext()
        {
            // Set SocialNetworkDbContext options to use Sqlite in memory db
            this.ContextOptions = new DbContextOptionsBuilder<SocialNetworkDbContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options;

            Seed();
        }

        /// <summary>
        /// Db context options
        /// </summary>
        internal DbContextOptions<SocialNetworkDbContext> ContextOptions { get; }

        /// <summary>
        /// Create in memory database with connection string
        /// </summary>
        /// <returns>Opened connection</returns>
        private DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        /// <summary>
        /// The reason of using context instnces 
        /// twice is that when user is stored in the db it will be set id.
        /// When creating posts these users` ids will be used as authorIds.
        /// And finally when posts have their ids it will be used for postId 
        /// prop in the creation of comments.
        /// </summary>
        private void Seed()
        {
            SeedUsers();
            
            #region Seed posts

            using (var context = new SocialNetworkDbContext(this.ContextOptions))
            {
                var usersIds = context.Users.Select(i =>i.Id).ToArray();

                var post = new Post
                {
                    Content = "first post",
                    PhotoName = "first-post.jpg",
                    CreatedOn = DateTime.Parse("21/03/2021"),
                    AuthorId = usersIds[0]
                };

                var secondPost = new Post
                {
                    Content = "second post",
                    PhotoName = "second-post.jpg",
                    CreatedOn = DateTime.Parse("28/03/2021"),
                    AuthorId = usersIds[1]
                };

                var thirdPost = new Post
                {
                    Content = "third post",
                    PhotoName = "third-post.jpg",
                    CreatedOn = DateTime.Parse("01/04/2021"),
                    AuthorId = usersIds[2]
                };

                context.AddRange(post, secondPost, thirdPost);
                context.SaveChanges();
            }

            #endregion

            #region Seed comments

            using (var context = new SocialNetworkDbContext(this.ContextOptions))
            {
                var usersIds = context.Users.Select(i => i.Id).ToArray();
                var postsIds = context.Posts.Select(i => i.PostId).ToArray();

                var comment = new Comment
                {
                    Content = "first comment",
                    CreatedOn = DateTime.Parse("22/03/2021"),
                    AuthorId = usersIds[2],
                    PostId = postsIds[0]
                };

                var secondComment = new Comment
                {
                    Content = "second comment",
                    CreatedOn = DateTime.Parse("29/03/2021"),
                    AuthorId = usersIds[1],
                    PostId = postsIds[1]
                };

                var thirdComment = new Comment
                {
                    Content = "third comment",
                    CreatedOn = DateTime.Parse("02/04/2021"),
                    AuthorId = usersIds[0],
                    PostId = postsIds[2]
                };

                context.Comments.AddRange(comment, secondComment, thirdComment);
                context.SaveChanges();
            }
            #endregion
        }

        private void SeedUsers()
        {
            using var context = new SocialNetworkDbContext(this.ContextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var user = new User
            {
                FirstName = "Test user",
                LastName = "one",
                Email = "test.user.1@gmail.com"
            };

            var secondUser = new User
            {
                FirstName = "Test user",
                LastName = "two",
                Email = "test.user.2@gmail.com"
            };

            var thirdUser = new User
            {
                FirstName = "Test user",
                LastName = "three",
                Email = "test.user.3@gmail.com"
            };

            context.Users.AddRange(user, secondUser, thirdUser);
            context.SaveChanges();
        }
    }
}
