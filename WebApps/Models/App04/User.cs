namespace WebApps.Models.App04
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    using static ModelConstants.User;

    /// <summary>
    /// The user model keeps the user`s details as well as its posts
    /// </summary>
    public class User : IdentityUser
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
        }

        [MinLength(MIN_NAME_LENGTH), MaxLength(MAX_NAME_LENGTH)]
        public string FirstName { get; set; }
        
        [MinLength(MIN_NAME_LENGTH), MaxLength(MAX_NAME_LENGTH)]
        public string LastName { get; set; }
        
        public string FullName => $"{this.FirstName} {this.LastName}";
        
        public DateTime? DateOfBirth { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        
        public ICollection<Post> Posts{ get; set; }
     
        public ICollection<UserLikePost> LikedPosts{ get; set; }
    }
    
    public enum Gender
    {
        preferNotToSay = 0,
        male = 1,
        female = 2
    }
}
