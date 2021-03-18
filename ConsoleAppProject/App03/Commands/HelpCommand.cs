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
        /// Create new command and assign invoker as a reciever 
        /// of the newly created command
        /// </summary>
        /// <param name="invoker">The reciever of this command</param>
        public HelpCommand(StudentGradesInvoker invoker)
            : base(invoker)
        {}

        /// <summary>
        /// Execute this command as get and print out all 
        /// executable commands of this application
        /// </summary>
        public override void Execute()
            => Console.WriteLine(String.Join('\n',base._invoker.GetExecutableCommands()));
    }
}
