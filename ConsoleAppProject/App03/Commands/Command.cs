namespace ConsoleAppProject.App03.Commands
{
    /// <summary>
    /// Command abstarct class which is inherited by each concrete command class
    /// </summary>
    /// <author>Yavor Yankov</author>
    public abstract class Command
    {
        /// <summary>
        /// The receiver of the Command Design Pattern.
        /// StudentGrades class will perform the action from the command
        /// </summary>
        protected StudentGrades studentGrades;

        /// <summary>
        /// The constructor that initialises this command
        /// and recieve the 'reciever'
        /// </summary>
        /// <param name="studentGrades">Reciever of the command</param>
        public Command(StudentGrades studentGrades)
            => this.studentGrades = studentGrades;
        
        /// <summary>
        /// Abstract method to be overriden which executes this command
        /// </summary>
        public abstract void Execute();
    }
}
