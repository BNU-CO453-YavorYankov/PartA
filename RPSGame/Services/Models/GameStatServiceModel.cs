namespace RPSGame.Services.Models
{
    /// <summary>
    /// This model pass player`s name and the result of a given game.
    /// It is used between GameService and XMLService.
    /// </summary>
    public class GameStatServiceModel
    {
        public string PlayerName { get; set; }
        public string Result { get; set; }
    }
}
