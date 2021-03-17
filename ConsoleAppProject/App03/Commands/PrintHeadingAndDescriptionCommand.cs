namespace ConsoleAppProject.App03.Commands
{
    using ConsoleAppProject.Common;
    using static Common.Constants.StudentGrades;

    /// <summary>
    /// This command print the heading and description of the student grades app.
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("Print heading and description")]
    public class PrintHeadingAndDescriptionCommand : Command
    {
        /// <summary>
        /// Create new command and specify which 
        /// base-class constructor should be called 
        /// when creating instances of this derived class.
        /// </summary>
        /// <param name="studentGrades">The reciever that will 
        /// perform the action from this command</param>
        public PrintHeadingAndDescriptionCommand(StudentGrades studentGrades)
            : base(studentGrades)
        {
        }

        /// <summary>
        /// Execute this command as print out the heading 
        /// and description of this application
        /// </summary>
        public override void Execute()
            => Helper.PrintHeading(PROGRAM_NAME, DESCRIPTION);
    }
}
