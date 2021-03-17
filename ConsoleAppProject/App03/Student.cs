namespace ConsoleAppProject.App03
{
    using System;

    using static Common.Constants.Common;
    using static Common.Constants.StudentGrades;

    /// <summary>
    /// Student class keeps student details
    /// </summary>
    /// <author>Yavor Yankov</author>
    public class Student
    {
        /// <summary>
        /// backing field of first name prop
        /// </summary>
        private string _firstName;
        /// <summary>
        /// backing field of last name prop
        /// </summary>
        private string _lastName;
        /// <summary>
        /// backing field of mark prop
        /// </summary>
        private int _mark;

        /// <summary>
        /// Create new empty student model
        /// </summary>
        public Student() { }

        /// <summary>
        /// Create new student with id, first and last name
        /// </summary>
        /// <param name="id">The id of the student</param>
        /// <param name="firstName">The first name of the student</param>
        /// <param name="lastName">The last name of the student</param>
        public Student(int id, string firstName, string lastName)
        {
            this.StudentId = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// The id of this student
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// The name of this student
        /// </summary>
        public string FirstName
        {
            get => this._firstName;
            set
            {
                if (value.Length < MIN_NAME_LENGTH)
                    throw new ArgumentException(INVALID_STUDENT_NAME_MSG);
                else if (value is null || value is "")
                    throw new NullReferenceException(NULL_OR_EMPTY_MSG);

                this._firstName = value;
            }
        }

        /// <summary>
        /// The last name of this student
        /// </summary>
        public string LastName
        {
            get => this._lastName;
            set
            {
                if (value.Length < MIN_NAME_LENGTH)
                    throw new ArgumentException(INVALID_STUDENT_NAME_MSG);
                else if (value is null || value is "")
                    throw new NullReferenceException(NULL_OR_EMPTY_MSG);
                this._lastName = value;
            }
        }

        /// <summary>
        /// The full name of this student
        /// </summary>
        public string FullName => $"{this.FirstName} {this.LastName}";

        /// <summary>
        /// The grade of this student
        /// </summary>
        public Grades Grade { get; set; }

        /// <summary>
        /// The mark in percentages of this student
        /// </summary>
        public int Mark
        {
            get => this._mark;
            set
            {
                if (value is < 0 or > 100)
                    throw new ArgumentOutOfRangeException(OUT_OF_RANGE_MARK_MSG);

                this._mark = value;
            }
        }

        public override string ToString()
            => $"{this.StudentId}. {this.FullName} - {this.Mark}%, {this.Grade}";
    }
}
