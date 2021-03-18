namespace ConsoleAppProject.App03.Commands
{
    using System;
    using ConsoleAppProject.Common;
    
    /// <summary>
    /// The add student command that create and adds a new student in the system database
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("1. Add student")]
    public class AddStudentCommand : Command
    {
        /// <summary>
        /// Student that will be added to the students collection
        /// </summary>
        private Student _student;

        /// <summary>
        /// Create a new add student command as set the receiver
        /// </summary>
        public AddStudentCommand(StudentGrades studentGrades)
            : base(studentGrades)
        { }

        /// <summary>
        /// Execute this command as create a new student model and 
        /// pass it to the add student method of the StudentGrades class.
        /// </summary>
        public override void Execute()
        {
            CreateStudent();

            base._studentGrades.AddStudent(this._student);

            Console.WriteLine($"{this._student.FullName} was added\n\r");
        }

        /// <summary>
        /// Create a new student
        /// </summary>
        private void CreateStudent()
        {
            this._student = new Student();
            while (this._student.FirstName != default &&
                this._student.LastName != default)
            {
                try
                {
                    Console.WriteLine("Add a new student");

                    Console.Write("first name: ");
                    this._student.FirstName = Console.ReadLine();

                    Console.Write("last name : ");
                    this._student.LastName = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
