﻿namespace ConsoleApp.Tests
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
    }
}
