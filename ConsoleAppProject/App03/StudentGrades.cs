namespace ConsoleAppProject.App03
{
    using ConsoleAppProject.Common;

    using static ConsoleAppProject.Common.Constants.StudentMarks;

    /// <summary>
    /// allow a tutor to enter a single mark of each of a list 
    /// of students and it will convert that mark into a grade. 
    /// The application will then be able to calculate simple statistics 
    /// and also calculate and display a student grade profile.
    /// </summary>
    /// <author>Yavor Yankov version 1.0</author>
    public class StudentGrades : IApplication
    {
        public string Result => throw new System.NotImplementedException();

        /// <summary>
        /// Create new instance of this class
        /// </summary>
        public StudentGrades() 
        {

        }


        public void Run()
        {
            Helper.PrintHeading(PROGRAM_NAME, DESCRIPTION);
        }

        public void Validation()
        {
            throw new System.NotImplementedException();
        }
    }
}
