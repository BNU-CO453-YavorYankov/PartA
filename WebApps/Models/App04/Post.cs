namespace WebApps.Models.App04
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants.Post;

    /// <summary>
    /// Post model that keeps info for
    /// its description, created on date and author
    /// </summary>
    public class Post
    {
        public Post() => this.CreatedOn = DateTime.Now.Date;

        public int PostId { get; set; }

        [MinLength(MIN_CONTENT_LENGTH), MaxLength(MAX_CONTENT_LENGTH)]
        public string Content { get; set; }
        
        public string PhotoUrl { get; set; }
        
        public DateTime CreatedOn { get; private set; }
        
        public string AuthorId { get; set; }
        
        public User Author { get; set; }
    }
}
