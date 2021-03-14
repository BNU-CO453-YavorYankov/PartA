namespace ConsoleAppProject.App03
{
    using ConsoleAppProject.App03.Commands;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The invoker class is responsible for reading user input 
    /// and execute the command as well as storing all available commands.
    /// </summary>
    /// <author>Yavor Yankov</author>
    public class StudentGradesInvoker
    {
        /// <summary>
        /// All available commands
        /// @Key - name of the command
        /// @Value - command class
        /// </summary>
        private Dictionary<string, Command> _commands;
        /// <summary>
        /// The reciever which student grades class
        /// </summary>
        private readonly StudentGrades _studentGrades;

        /// <summary>
        /// If this property is true this application will be terminated 
        /// and the user will be redirected to the main menu
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        /// <summary>
        /// Initialise new student grade invoker 
        /// and make new instance of the reviecer
        /// </summary>
        public StudentGradesInvoker()
        {
            this._studentGrades = new StudentGrades();

            AddCommands();

            // Print out the heading and description of Student grades app
            ExecuteCommand(this._commands
                .FirstOrDefault(k => k.Key == nameof(PrintHeadingAndDescriptionCommand))
                .Value);
        }

        /// <summary>
        /// Execute the given command
        /// </summary>
        /// <param name="command">The given command to be executed</param>
        private void ExecuteCommand(Command command)
            => command.Execute();

        /// <summary>
        /// Add all command to the dictionary
        /// </summary>
        private void AddCommands()
            => this._commands = new Dictionary<string, Command>()
            {
                { nameof(PrintHeadingAndDescriptionCommand), new PrintHeadingAndDescriptionCommand(this._studentGrades)}
            };

        /// <summary>
        /// Set the is completed to true and the while loop will be broken
        /// </summary>
        private void ExitApp()
            => this.IsCompleted = true;
    }
}
