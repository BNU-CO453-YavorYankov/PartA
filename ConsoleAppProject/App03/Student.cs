using ConsoleAppProject.App03;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App02
{
    public class Student
    {

        /// <summary>
        /// The first name of this student
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of this student
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The grade of this student
        /// </summary>
        public Grades Grade { get; set; }
        /// <summary>
        /// The mark of this student
        /// </summary>
        public int Mark { get; set; }
    }
}
