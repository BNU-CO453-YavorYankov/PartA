namespace WebApps.Models.App04
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using static ModelConstants.Post;

    /// <summary>
    /// Post model that keeps info for
    /// its description, created on date and author
    /// </summary>
    public class Post
    {
        public int PostId { get; set; }

        [MinLength(MIN_CONTENT_LENGTH), MaxLength(MAX_CONTENT_LENGTH)]
        public string Content { get; set; }

        /// <summary>
        /// Name of the photo/image of this posts with extension
        /// Example: image-name.jpeg
        /// </summary>
        public string PhotoName { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
        
        /// <summary>
        /// Collection of users that liked this post
        /// </summary>
        public ICollection<UserLikePost> UsersLikes { get; set; }
    }
}
