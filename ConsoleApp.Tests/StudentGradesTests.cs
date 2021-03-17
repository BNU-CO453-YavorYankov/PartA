namespace ConsoleApp.Tests
{
    using NUnit.Framework;
    using ConsoleAppProject.App03;
    using ConsoleAppProject.App03.Commands;

    using static ConsoleAppProject.Common.Constants.StudentGrades;

    public class StudentGradesTests
    {
        private StudentGrades _studentGrades;
        private StudentGradesInvoker _invoker;

        [SetUp]
        public void Setup()
        {
            this._studentGrades = new StudentGrades(); 
            this._invoker = new StudentGradesInvoker();
        }

        [Test]
        public void AddStudentCommandShouldAddStudent() 
        {
            var addStudentCommand = new AddStudentCommand(this._studentGrades);
            addStudentCommand.Execute();

            Assert.That(this._studentGrades.Students.Count, Is.EqualTo(11));
        }
    }
}
