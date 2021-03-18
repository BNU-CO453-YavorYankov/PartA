namespace ConsoleAppProject.App03.Commands
{
    using System.Text;
    using ConsoleAppProject.Common;
    
    using static Common.Constants.StudentGrades;

    /// <summary>
    /// Print out on the console 
    /// all students, mean and grade profiles
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("7. Print result")]
    public class PrintResultCommand : Command
    {
        /// <summary>
        /// Create new command and specify which 
        /// base-class constructor should be called 
        /// when creating instances of this derived class.
        /// </summary>
        /// <param name="studentGrades">The reciever that will 
        /// perform the action from this command</param>
        public PrintResultCommand(StudentGrades studentGrades)
            : base(studentGrades)
        { }

        /// <summary>
        /// Execute this command as set the result of this app and print it out
        /// </summary>
        public override void Execute()
        {
            var stringBuilder = new StringBuilder();
            
            foreach (var student in this._studentGrades.Students)
            {
                stringBuilder.Append($"{student}\n\r");
            }
            
            stringBuilder.Append($"\n\rMean: {base._studentGrades.Mean}\n\r" +
                $"Max: {base._studentGrades.GetMaxMark()}\n\r" +
                $"Min: {base._studentGrades.GetMinMark()}\n\r");

            stringBuilder.Append($"\n\r{GradeProfilesMsg(base._studentGrades.GradeProfiles)}");

            base._studentGrades.Result = stringBuilder.ToString();

            System.Console.WriteLine(base._studentGrades.Result);
        }
    }
}
