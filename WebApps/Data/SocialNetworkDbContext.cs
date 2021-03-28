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

            base.OnModelCreating(builder);
        }
    }
}
