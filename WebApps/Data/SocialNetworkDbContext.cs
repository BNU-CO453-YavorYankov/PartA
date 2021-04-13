namespace WebApps.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebApps.Models.App04;

    public class SocialNetworkDbContext : IdentityDbContext<User>
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options)
            : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserLikePost> UsersLikePosts { get; set; }

        /// <summary>
        /// Override fluent api to configure models` mapping properties
        /// and types
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User configuration
            builder.Entity<User>(entity =>
            {
                // Set first and last name and gender props required
                entity.Property(fn => fn.FirstName).IsRequired();
                entity.Property(ln => ln.LastName).IsRequired();
                entity.Property(g => g.Gender).IsRequired();

                /*  Establish one to many relationship and the foreign key.
                    Also delete behavior will be cascade which means that 
                    if the user delete its account all of its posts will 
                    be deleted as well.*/
                entity.HasMany<Post>()
                    .WithOne(a => a.Author)
                    .HasForeignKey(aId => aId.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            // Post configuration
            builder.Entity<Post>(entity =>
            {
                //Specify the primary key of each post entity
                entity.HasKey(p => p.PostId);

                //Set content prop required
                entity.Property(c => c.Content).IsRequired();
            });

            //User like post mapping table configuration
            builder.Entity<UserLikePost>(entity =>
            {
                // Set primary keys for the mapping table to be userId and postId
                entity.HasKey(up => new { up.UserId, up.PostId });

                /* Establish connection between the mapping table`s User prop 
                 * with User entity`s collection Liked posts and 
                 * set foreign key to be UserId prop from mapping table.
                 */
                entity.HasOne(up => up.User)
                    .WithMany(u => u.LikedPosts)
                    .HasForeignKey(up => up.UserId);

                /* Establish connection between the mapping table`s Post prop 
                 * with Post entity`s collection users likes and 
                 * set foreign key to be PostId prop from mapping table.
                 */
                entity.HasOne(up => up.Post)
                    .WithMany(p => p.UsersLikes)
                    .HasForeignKey(up => up.PostId);
            });

            //Comment model configuration
            builder.Entity<Comment>(entity =>
            {
                //Set content prop required
                entity.Property(c => c.Content).IsRequired();

                /* Comment model has one author
                 * but author can have many comments
                 */
                entity.HasOne(a => a.Author)
                    .WithMany(c => c.Comments)
                    .HasForeignKey(aId => aId.AuthorId);

                /* Comment model has one post
                 * but post can have many comments
                 */
                entity.HasOne(p => p.Post)
                    .WithMany(c => c.Comments)
                    .HasForeignKey(pId => pId.PostId);
            });


            base.OnModelCreating(builder);
        }
    }
}
