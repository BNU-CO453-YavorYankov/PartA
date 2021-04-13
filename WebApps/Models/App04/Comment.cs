namespace WebApps.Models.App04
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static ModelConstants.Post;

    public class Comment
    {
        public int CommentId { get; set; }

        [MinLength(MIN_CONTENT_LENGTH), MaxLength(MAX_CONTENT_LENGTH)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int PostId { get; set; }
        //Commented post
        public Post Post { get; set; }
        
        public string AuthorId { get; set; }
        
        public User Author { get; set; }
    }
}
