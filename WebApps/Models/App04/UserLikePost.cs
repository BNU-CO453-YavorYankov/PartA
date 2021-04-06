namespace WebApps.Models.App04
{
    /// <summary>
    /// This model keeps the userId of the user that liked particular post.
    /// It is a mapping table between user and post.
    /// </summary>
    public class UserLikePost
    {
        public string UserId { get; set; }
        
        public User User { get; set; }

        public int PostId { get; set; }
        
        public Post Post { get; set; }
    }
}
