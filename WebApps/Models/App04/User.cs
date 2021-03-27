namespace WebApps.Models.App04
{
    using System;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The user model keeps the user`s details as well as its posts
    /// </summary>
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
    
    public enum Gender
    {
        male = 0,
        female = 1
    }
}
