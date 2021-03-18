namespace ConsoleApp.Tests
{
    using NUnit.Framework;
    using ConsoleAppProject.App03;
    using ConsoleAppProject.App03.Commands;

    using static ConsoleAppProject.Common.Constants.StudentGrades;
    using System;

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

        [Test]
        public void CreateStudentWithInvalidNameShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var student = new Student(1, "n", "wrong name");

            }, INVALID_STUDENT_NAME_MSG);
        }

        [Test]
        public void AssignNegativeMarkOfStudentShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var student = new Student(1, "Test", "Student");
                student.Mark = -1;

            }, OUT_OF_RANGE_MARK_MSG);
        }

        [Test]
        public void AssignMoreThanMaxMarkOfStudentShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var student = new Student(1, "Test", "Student");
                student.Mark = 150;

            }, OUT_OF_RANGE_MARK_MSG);
        }

        [Test]
        public void GetStudentByIdShouldReturnValidStudent()
        {
            var student = this._studentGrades.GetStudentById(1);

            var actualStudent = new Student(1, "Finn", "Warner");

            Assert.That(student.FullName, Is.EqualTo(actualStudent.FullName));
        }

        [Test]
        public void GetStudentByIdShouldReturnNull()
        {
            var student = this._studentGrades.GetStudentById(40);

            Assert.That(student, Is.Null);
        }

        [Test]
        public void AssignMarkOfStudentShouldUpdateStudent()
        {
            var student = new Student { StudentId = 1, FirstName = "Finn", LastName = "Warner", Mark = 60 };

            this._studentGrades.UpdateStudentMark(student);

            var updatedStudent = this._studentGrades
                .GetStudentById(1);

            Assert.That(updatedStudent.Mark, Is.EqualTo(student.Mark));
        }

        [Test]
        public void AssignMarkOfInvalidStudentShouldNotUpdateStudent()
        {
            var student = new Student { StudentId = 1, FirstName = "Wrong", LastName = "Student", Mark = 90 };

            Assert.Throws<NullReferenceException>(() =>
            {
                this._studentGrades.UpdateStudentMark(student);

            }, $"{student.FullName} cannot be found.");
        }

        [Test]
        public void GetMinMarkShouldReturnMark()
        {
            var minMark = this._studentGrades.GetMinMark();

            Assert.That(minMark, Is.EqualTo(0));
        }

        [Test]
        public void GetMaxMarkShouldReturnMark()
        {
            var student = new Student { StudentId = 11, FirstName = "The best", LastName = "student", Mark = 100 };

            this._studentGrades.AddStudent(student);

            var maxMark = this._studentGrades.GetMaxMark();

            Assert.That(maxMark, Is.EqualTo(100));
        }

        [Test]
        public void CalculateMeanCommandShouldSetMean()
        {
            this._studentGrades.Students = new()
            {
                new() { StudentId = 1, FirstName = "Finn", LastName = "Warner", Mark = 10 },
                new() { StudentId = 2, FirstName = "Bryn", LastName = "Colon", Mark = 20 },
                new() { StudentId = 3, FirstName = "Jorgie", LastName = "Bowers", Mark = 30 },
                new() { StudentId = 4, FirstName = "Tia", LastName = "Cole", Mark = 40 },
                new() { StudentId = 5, FirstName = "Alissia", LastName = "Joyce", Mark = 50 },
                new() { StudentId = 6, FirstName = "Ami", LastName = "Richmond", Mark = 60 },
                new() { StudentId = 7, FirstName = "Stanislaw", LastName = "Burch", Mark = 70 },
                new() { StudentId = 8, FirstName = "Gabrielle", LastName = "Malone", Mark = 80 },
                new() { StudentId = 9, FirstName = "Ruby", LastName = "Leigh", Mark = 90 },
                new() { StudentId = 10, FirstName = "Winston", LastName = "Rudd", Mark = 100 },
            };

            var command = new CalculateAndPrintMeanCommand(this._studentGrades);
            command.Execute();

            Assert.That(this._studentGrades.Mean, Is.EqualTo(55));
        }

        [Test]
        public void CalculateGradeProfilesCommandShouldSetAllProfiles()
        {
            this._studentGrades.Students = new()
            {
                new() { StudentId = 1, FirstName = "Finn", LastName = "Warner", Mark = 10 },
                new() { StudentId = 2, FirstName = "Bryn", LastName = "Colon", Mark = 20 },
                new() { StudentId = 3, FirstName = "Jorgie", LastName = "Bowers", Mark = 30 },
                new() { StudentId = 4, FirstName = "Tia", LastName = "Cole", Mark = 40 },
                new() { StudentId = 5, FirstName = "Alissia", LastName = "Joyce", Mark = 50 },
                new() { StudentId = 6, FirstName = "Ami", LastName = "Richmond", Mark = 60 },
                new() { StudentId = 7, FirstName = "Stanislaw", LastName = "Burch", Mark = 70 },
                new() { StudentId = 8, FirstName = "Gabrielle", LastName = "Malone", Mark = 80 },
                new() { StudentId = 9, FirstName = "Ruby", LastName = "Leigh", Mark = 90 },
                new() { StudentId = 10, FirstName = "Winston", LastName = "Rudd", Mark = 100 },
            };

            var command = new CalculateAndPrintGradeProfileCommand(this._studentGrades);
            command.Execute();

            var expectedResult = new double[]
            {
                40, 10, 10, 10, 30, 0
            };

            Assert.AreEqual(expectedResult, this._studentGrades.GradeProfiles);
        }
    }
}
