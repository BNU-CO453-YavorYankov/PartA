namespace WebApps.Models.App04
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using static ModelConstants.Post;

    /// <summary>
    /// Post model that keeps info for
    /// its description, created on date and author
    /// </summary>
    public class Post
    {
        public Post() => this.CreatedOn = DateTime.Now;

        public int PostId { get; set; }

        [MinLength(MIN_CONTENT_LENGTH), MaxLength(MAX_CONTENT_LENGTH)]
        public string Content { get; set; }

        public string PhotoName { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public DateTime CreatedOn { get; private set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
