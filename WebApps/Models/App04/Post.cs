namespace WebApps.Models.App04
{
    using System;
    
    /// <summary>
    /// Post model that keeps info for
    /// its description, created on date and author
    /// </summary>
    public class Post
    {
        public Post() => this.CreatedOn = DateTime.Now.Date;

        public int PostId { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreatedOn { get; private set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}
