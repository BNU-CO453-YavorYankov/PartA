namespace ConsoleAppProject.App03.Commands
{
    using System; 
    using ConsoleAppProject.Common;

    using static Common.Constants.StudentGrades;

    /// <summary>
    /// Calculate the percentage of students btaining each grade
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("6. Calculate and print grade profile")]
    public class CalculateAndPrintGradeProfileCommand : Command
    {
        /// <summary>
        /// Create new command as set value of a base 
        /// field that is receiver of this command
        /// </summary>
        /// <param name="studentGrades">the receiver of this command</param>
        public CalculateAndPrintGradeProfileCommand(StudentGrades studentGrades)
            : base(studentGrades)
        {}

        /// <summary>
        /// Execute this command
        /// </summary>
        public override void Execute()
        {
            base._studentGrades.GradeProfiles = new double[6];

            foreach (var student in base._studentGrades.Students)
            {
                try
                {
                    if (student.Grade == Grades.F)
                        base._studentGrades.GradeProfiles[0]++;
                    else if (student.Grade == Grades.D)
                        base._studentGrades.GradeProfiles[1]++;
                    else if (student.Grade == Grades.C)
                        base._studentGrades.GradeProfiles[2]++;
                    else if (student.Grade == Grades.B)
                        base._studentGrades.GradeProfiles[3]++;
                    else if (student.Grade == Grades.A)
                        base._studentGrades.GradeProfiles[4]++;
                }
                catch (Exception)
                {
                    //Students that are without mark
                    base._studentGrades.GradeProfiles[5]++;
                }
            }

            var numberOfStudents = base._studentGrades.Students.Count;

            for (int i = 0; i < base._studentGrades.GradeProfiles.Length; i++)
            {
                var currentProfile = base._studentGrades.GradeProfiles[i];

                base._studentGrades.GradeProfiles[i] = currentProfile * (100 / numberOfStudents);
            }

            PrintGradeProfiles(base._studentGrades.GradeProfiles);
        }

        /// <summary>
        /// Print out the grade profiles table in percents and classes
        /// </summary>
        /// <param name="gradeProfiles">Grade profiles in percents</param>
        private void PrintGradeProfiles(double[] gradeProfiles)
            => Console.WriteLine(GradeProfilesMsg(gradeProfiles));
    }
}
