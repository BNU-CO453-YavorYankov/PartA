﻿namespace ConsoleAppProject.App03
{
    using System;
    using ConsoleAppProject.Common;
    using System.Collections.Generic;

    using static Common.Constants.StudentGrades;
    using System.Linq;

    /// <summary>
    /// allow a tutor to enter a single mark of each of a list 
    /// of students and it will convert that mark into a grade. 
    /// The application will then be able to calculate simple statistics 
    /// and also calculate and display a student grade profile.
    /// </summary>
    /// <author>Yavor Yankov</author>
    public class StudentGrades : IApplication
    {
        /// <summary>
        /// List with all students in this app instance 
        /// </summary>
        public List<Student> Students { get; private set; }

        /// <summary>
        /// The result of this application
        /// </summary>
        public string Result => throw new System.NotImplementedException();

        /// <summary>
        /// Create new instance of this class
        /// </summary>
        public StudentGrades()
        {
            SeedStudentsCollection();
        }

        /// <summary>
        /// Update a student mark
        /// </summary>
        /// <param name="student">The student model with mark</param>
        public void UpdateStudentMark(Student student)
            => this.Students
            .FirstOrDefault(s => s.StudentId == student.StudentId).Mark = student.Mark;

        /// <summary>
        /// Add a student if it is not exists in the students collection
        /// </summary>
        /// <param name="student">The new student to be added</param>
        public void AddStudent(Student student) 
        {
            try
            {
                ValidateStudent(student);

                student.StudentId = SetStudentId();
                this.Students.Add(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <param name="id">student id</param>
        /// <returns>Returns the student with the given id</returns>
        public Student GetStudentById(int id)
            => this.Students.FirstOrDefault(i =>i.StudentId == id);

        /// <summary>
        /// Get the last student`s id and add 1 
        /// </summary>
        /// <returns>Return the student`s id</returns>
        private int SetStudentId() => this.Students.Last().StudentId + 1;

        /// <summary>
        /// Validate is the new student already added to the student collection
        /// </summary>
        /// <param name="student">The student to be checked</param>
        private void ValidateStudent(Student student)
        {
            if (this.Students.Any(f =>f.FullName == student.FullName))
                throw new ArgumentException($"Student {student.FullName} already exists.");
        }

        /// <summary>
        /// Create and add 10 students in the students collection
        /// </summary>
        private void SeedStudentsCollection()
            => this.Students = new()
            {
                new() { StudentId = 1, FirstName = "Finn", LastName = "Warner" },
                new() { StudentId = 2, FirstName = "Bryn", LastName = "Colon" },
                new() { StudentId = 3, FirstName = "Jorgie", LastName = "Bowers" },
                new() { StudentId = 4, FirstName = "Tia", LastName = "Cole" },
                new() { StudentId = 5, FirstName = "Alissia", LastName = "Joyce" },
                new() { StudentId = 6, FirstName = "Ami", LastName = "Richmond" },
                new() { StudentId = 7, FirstName = "Stanislaw", LastName = "Burch" },
                new() { StudentId = 8, FirstName = "Gabrielle", LastName = "Malone" },
                new() { StudentId = 9, FirstName = "Ruby", LastName = "Leigh" },
                new() { StudentId = 10, FirstName = "Winston", LastName = "Rudd" },
            };

        #region Not implemented methods from IApplication interface
        
        public void Run() => throw new System.NotImplementedException("This method is not used in this application");
        public void Validation() => throw new System.NotImplementedException("This method is not used in this application");

        
        #endregion
    }
}
