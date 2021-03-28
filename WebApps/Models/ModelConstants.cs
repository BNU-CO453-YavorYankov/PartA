namespace WebApps.Models
{
    /// <summary>
    /// All constants related to models
    /// </summary>
    public static class ModelConstants
    {
        public static class Post 
        {
            public const int MAX_CONTENT_LENGTH = 1000;
            public const int MIN_CONTENT_LENGTH = 5;
        }

        public class User
        {
            public const int MAX_NAME_LENGTH = 20;
            public const int MIN_NAME_LENGTH = 2;
        }
    }
}
