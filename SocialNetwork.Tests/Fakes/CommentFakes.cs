namespace SocialNetwork.Tests.Fakes
{
    using Bogus;
    using WebApps.Models.App04;

    public class CommentFakes
    {
        /// <summary> 
        /// This comment is without author and post 
        /// </summary>
        public static Comment GetComment()
        => new Faker<Comment>().CustomInstantiator(f => new Comment
        {
            Content = f.Lorem.Random.AlphaNumeric(5),
            CreatedOn = f.Date.Recent(),
        }).Generate();
    }
}
