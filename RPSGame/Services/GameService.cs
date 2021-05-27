namespace RPSGame.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameService
    {
        private Random _random;

        /// <summary>
        /// Initialize new GameService with random instance
        /// </summary>
        public GameService()
        {
            this._random = new();
            this.WinnersByRounds = new();
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
        public Winners RoundWinner { get; set; }

        /// <summary>
        /// The last round number
        /// </summary>
        public int CurrentRound { get; set; } = 0;

        /// <summary>
        /// <key>key - round number</key>
        /// <br/>
        /// <value>value - who won the round</value>
        /// </summary>
        public Dictionary<int, Winners> WinnersByRounds{ get; set; }

        /// <summary>
        /// <key>key - who won the game</key>
        /// <br/>
        /// <value>value - rounds won</value>
        /// </summary>
        public KeyValuePair<Winners,int> GameWinner { get; set; }

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
        public void SetRoundWinner()
        {
            if (this.PlayerChoice == Choices.Papper && this.RobotChoice == Choices.Papper ||
                this.PlayerChoice == Choices.Rock && this.RobotChoice == Choices.Rock ||
                this.PlayerChoice == Choices.Scissors && this.RobotChoice == Choices.Scissors)
            {
                this.RoundWinner = Winners.Draw;
            }
            else if (this.PlayerChoice == Choices.Rock && this.RobotChoice == Choices.Papper)
            {
                this.RoundWinner = Winners.Robot;
            }
            else if (this.PlayerChoice == Choices.Papper && this.RobotChoice == Choices.Rock)
            {
                this.RoundWinner = Winners.Player;
            }
            else if (this.PlayerChoice == Choices.Scissors && this.RobotChoice == Choices.Rock)
            {
                this.RoundWinner = Winners.Robot;
            }
            else if (this.PlayerChoice == Choices.Rock && this.RobotChoice == Choices.Scissors)
            {
                this.RoundWinner = Winners.Player;
            }
            else if (this.PlayerChoice == Choices.Papper && this.RobotChoice == Choices.Scissors)
            {
                this.RoundWinner = Winners.Robot;
            }
            else if (this.PlayerChoice == Choices.Scissors && this.RobotChoice == Choices.Papper)
            {
                this.RoundWinner = Winners.Player;
            }

            this.WinnersByRounds.Add(this.CurrentRound+1, this.RoundWinner);
        }

        public void UpdateRoundsStat() 
        {
            this.Rounds--;
            this.CurrentRound++;

            if (this.Rounds is 0)
            {
                CalculateGameWinner();
            }
        }
        
        /// <summary>
        /// Reset most of the props to their default values.
        /// This method is used when the user wants to play again.
        /// </summary>
        public void ResetStat() 
        {
            this.CurrentRound = 0;
            this.WinnersByRounds = new();
            this.GameWinner = default;
        }

        private void CalculateGameWinner()
        {
            var robotRoundsWon = GetWonRoundsByRobot(); 
            var playerRoundsWon = GetWonRoundsByPlayer();

            if (robotRoundsWon > playerRoundsWon)
            {
                this.GameWinner = new(Winners.Robot,robotRoundsWon);
            }
            else if (robotRoundsWon < playerRoundsWon)
            {
                this.GameWinner = new(Winners.Player, playerRoundsWon);
            }
            else if (robotRoundsWon == playerRoundsWon)
            {
                this.GameWinner = new(Winners.Draw, 0);
            }
        }

        private int GetWonRoundsByRobot()
            => this.WinnersByRounds.Values
                .Where(w => w == Winners.Robot)
                .Count();

        private int GetWonRoundsByPlayer()
            => this.WinnersByRounds.Values
                .Where(w => w == Winners.Player)
                .Count();
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
