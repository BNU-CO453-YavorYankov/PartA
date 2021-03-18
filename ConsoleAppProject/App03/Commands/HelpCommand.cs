namespace ConsoleAppProject.App03.Commands
{
    using System;
    using ConsoleAppProject.Common;

    /// <summary>
    /// This command print all other commands when it is executed
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName(" Help")]
    public class HelpCommand : Command
    {
        /// <summary>
        /// The invoker that is responsible for reading and executing all commands
        /// </summary>
        private new StudentGradesInvoker _invoker;

        public HelpCommand(StudentGradesInvoker invoker)
            : base(invoker)
        {
            this._invoker = invoker;
        }

        /// <summary>
        /// Execute this command as get and print out all 
        /// executable commands of this application
        /// </summary>
        public override void Execute()
            => Console.WriteLine(String.Join('\n',this._invoker.GetExecutableCommands()));
    }
}
