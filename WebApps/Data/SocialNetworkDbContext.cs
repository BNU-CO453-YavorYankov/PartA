namespace WebApps.Data
{
    using WebApps.Models.App04;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class SocialNetworkDbContext : IdentityDbContext<User>
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options)
            : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
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
                    .HasForeignKey(up => up.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                /* Establish connection between the mapping table`s Post prop 
                 * with Post entity`s collection users likes and 
                 * set foreign key to be PostId prop from mapping table.
                 */
                entity.HasOne(up => up.Post)
                    .WithMany(p => p.UsersLikes)
                    .HasForeignKey(up => up.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(builder);
        }
    }
}
