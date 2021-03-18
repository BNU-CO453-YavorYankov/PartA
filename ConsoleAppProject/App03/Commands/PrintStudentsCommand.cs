namespace ConsoleAppProject.App03.Commands
{
    using System;
    using ConsoleAppProject.Common;
    
    /// <summary>
    /// Print all students
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("Print students")]
    public class PrintStudentsCommand : Command
    {
        /// <summary>
        /// The receiver of this command
        /// </summary>
        private StudentGrades _studentGrades;

        /// <summary>
        /// Create new command as assign receiver of the newly created command
        /// </summary>
        /// <param name="studentGrades">The receiver of this command</param>
        public PrintStudentsCommand(StudentGrades studentGrades)
            : base(studentGrades)
            => this._studentGrades = studentGrades;

        /// <summary>
        /// Execute this command as print all students
        /// </summary>
        public override void Execute()
            => this._studentGrades.Students
                .ForEach(s => Console.WriteLine(s.ToString()));
    }
}
