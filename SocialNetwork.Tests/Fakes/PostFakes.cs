namespace SocialNetwork.Tests.Fakes
{
    using Bogus;
    using System.Collections.Generic;
    using System.Linq;
    using WebApps.Models.App04;

    public static class PostFakes
    {
        /// <summary>
        /// This post is without author and comments
        /// </summary>
        public static Post GetPost()
        => new Faker<Post>().CustomInstantiator(f => new Post
        {
            Content = f.Lorem.Random.AlphaNumeric(5),
            CreatedOn = f.Date.Recent(),
            PhotoName = f.Image.PlaceImgUrl(),
        }).Generate();

        /// <summary>
        /// Return many posts
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<Post> GetPosts(int count = 3)
        => Enumerable
            .Range(1, count)
            .Select(i => GetPost())
            .ToList();
    }
}
