namespace ConsoleAppProject.App03
{
    using System;
    using ConsoleAppProject.Common;
    using System.Collections.Generic;

    using static Common.Constants.StudentGrades;

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

        public void Run() => throw new System.NotImplementedException("This method is not used in this application");

        public void Validation() => throw new System.NotImplementedException("This method is not used in this application");
    }
}
