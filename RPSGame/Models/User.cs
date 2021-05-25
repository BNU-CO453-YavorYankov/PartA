namespace RPSGame.Models
{
    using System.ComponentModel.DataAnnotations;
  
    /// <summary>
    /// This user model keep information about 
    /// user`s name and number of rounds
    /// </summary>
    public class User
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        [MinLength(2, ErrorMessage = "Name cannot be less than 3 symbols long.")]
        public string Name { get; set; }
        [Range(1, 20, ErrorMessage = "Number of rounds cannot be less than 1 or more than 20.")]
        public int Rounds { get; set; }
    }
}
