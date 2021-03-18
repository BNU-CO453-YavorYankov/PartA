namespace ConsoleAppProject.App03.Commands
{
    using ConsoleAppProject.Common;
    
    /// <summary>
    /// Exit to the main menu
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("9. Exit")]
    public class ExitCommand : Command
    {
        /// <summary>
        /// Create new command and assign invoker as a reciever 
        /// of the newly created command
        /// </summary>
        /// <param name="invoker">The reciever of this command</param>
        public ExitCommand(StudentGradesInvoker invoker)
            : base(invoker)
        { }

        /// <summary>
        /// Execute the command as set is completed prop to true
        /// </summary>
        public override void Execute()
            => base._invoker.IsCompleted = true;
    }
}
