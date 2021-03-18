namespace ConsoleAppProject.App03.Commands
{
    using System;
    using System.Linq;
    using ConsoleAppProject.Common;

    /// <summary>
    /// Calculate the mean of all students` marks
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("Calculate and print MEAN")]
    public class CalculateAndPrintMeanCommand : Command
    {
        /// <summary>
        /// Create new command as set value of a base 
        /// field that is receiver of this command
        /// </summary>
        /// <param name="studentGrades">the receiver of this command</param>
        public CalculateAndPrintMeanCommand(StudentGrades studentGrades)
            : base(studentGrades)
        {}

        public override void Execute()
        {
            var totalMarks = base._studentGrades.Students
                .Select(m => m.Mark)
                .ToList()
                .Sum();

            base._studentGrades.Mean = totalMarks / base._studentGrades.Students.Count;

            Console.WriteLine($"Mean: {base._studentGrades.Mean}\n\r" +
                $"Max: {base._studentGrades.GetMaxMark()}\n\r" +
                $"Min: {base._studentGrades.GetMinMark()}\n\r");
        }
    }
}
