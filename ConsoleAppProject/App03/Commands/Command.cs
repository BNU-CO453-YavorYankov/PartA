namespace ConsoleAppProject.App03.Commands
{
    /// <summary>
    /// Command abstarct class which is inherited by each concrete command class
    /// </summary>
    /// <author>Yavor Yankov</author>
    public abstract class Command
    {
        // The hashtag nullable enable is used to enable nullable types 
        #nullable enable
        /// <summary>
        /// The receiver of the Command Design Pattern.
        /// StudentGrades class will perform the action from the command
        /// </summary>
        protected StudentGrades? _studentGrades;
        /// <summary>
        /// In some commands the invoker is required to be used as a receiver as well
        /// </summary>
        protected StudentGradesInvoker? _invoker;
        #nullable restore
        /// <summary>
        /// The constructor that initialises this command
        /// and recieve the 'reciever'
        /// </summary>
        /// <param name="studentGrades">Reciever of the command</param>
        public Command(StudentGrades studentGrades)
            => this._studentGrades = studentGrades;

        /// <summary>
        /// the constructor that initialises this command
        /// and recieve the 'reciever' which is the invoker of the Command Design Pattern
        /// </summary>
        /// <param name="invoker"></param>
        public Command(StudentGradesInvoker invoker)
            => this._invoker = invoker;

        /// <summary>
        /// Abstract method to be overriden which executes this command
        /// </summary>
        public abstract void Execute();
    }
}
