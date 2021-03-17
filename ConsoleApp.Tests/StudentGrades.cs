namespace ConsoleApp.Tests
{
    using NUnit.Framework;
    using ConsoleAppProject.App03;

    using static ConsoleAppProject.Common.Constants.StudentGrades;
    
    public class StudentGrades
    {
        private StudentGrades _studentGrades;
        private StudentGradesInvoker _invoker;

        [SetUp]
        public void Setup()
        {
            this._studentGrades = new StudentGrades(); 
            this._invoker = new StudentGradesInvoker();
        }
    }
}
