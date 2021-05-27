namespace RPSGame.Services
{
    using System;

    public class GameService
    {
        private Random _random;

        /// <summary>
        /// Initialize new GameService with random instance
        /// </summary>
        public GameService()
        {
            this._random = new();
        }

        /// <summary>
        /// User`s name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of rounds making one game
        /// </summary>
        public int Rounds { get; set; }

        /// <summary>
        /// Player`s choice
        /// </summary>
        public Choices PlayerChoice { get; set; }

        /// <summary>
        /// The choice of the robot
        /// </summary>
        public Choices RobotChoice { get; private set; }

        /// <summary>
        /// Winner of the game
        /// </summary>
        public Winners Winner { get; set; }

        /// <summary>
        /// If true the game is finished
        /// </summary>
        public bool IsGameFinished { get; private set; } = false;

        /// <summary>
        /// Set robot choice as invoke next method 
        /// with min value 1 and max value 3
        /// </summary>
        public void SetRobotChoice()
        {
            var choice = this._random.Next(1, 3);

            this.RobotChoice = (Choices)choice;
        }

        /// <summary>
        /// Set winner as check for possible combinations,
        /// if there is a match set the winner.
        /// </summary>
        public void SetWinner()
        {
            if (this.PlayerChoice == Choices.Papper && this.RobotChoice == Choices.Papper ||
                this.PlayerChoice == Choices.Rock && this.RobotChoice == Choices.Rock ||
                this.PlayerChoice == Choices.Scissors && this.RobotChoice == Choices.Scissors)
            {
                this.Winner = Winners.Draw;
            }
            else if (this.PlayerChoice == Choices.Rock && this.RobotChoice == Choices.Papper)
            {
                this.Winner = Winners.Robot;
            }
            else if (this.PlayerChoice == Choices.Papper && this.RobotChoice == Choices.Rock)
            {
                this.Winner = Winners.Player;
            }
            else if (this.PlayerChoice == Choices.Scissors && this.RobotChoice == Choices.Rock)
            {
                this.Winner = Winners.Robot;
            }
            else if (this.PlayerChoice == Choices.Rock && this.RobotChoice == Choices.Scissors)
            {
                this.Winner = Winners.Player;
            }
            else if (this.PlayerChoice == Choices.Papper && this.RobotChoice == Choices.Scissors)
            {
                this.Winner = Winners.Robot;
            }
            else if (this.PlayerChoice == Choices.Scissors && this.RobotChoice == Choices.Papper)
            {
                this.Winner = Winners.Player;
            }
        }

        public void UpdateRoundsStat() 
        {
            this.Rounds--;
            if (this.Rounds is 0)
            {
                this.IsGameFinished = true;
            }
        }
    }

    public enum Choices
    {
        Rock = 1,
        Papper = 2,
        Scissors = 3
    }

    public enum Winners 
    {
        Player = 1,
        Robot = 2,
        Draw = 3
    }
}
