namespace ConsoleAppProject.App03.Commands
{
    using ConsoleAppProject.Common;
    using System;

    using static Common.Constants.Common;

    /// <summary>
    /// Get a student and add mark
    /// </summary>
    /// <author>Yavor Yankov</author>
    public class AddStudentMarkCommand : Command
    {
        /// <summary>
        /// The receiver of this command
        /// </summary>
        private StudentGrades _studentGrades;
        /// <summary>
        /// Student that will be marked
        /// </summary>
        private Student _student;

        /// <summary>
        /// Create new command as get the student by its name and assign a mark
        /// </summary>
        /// <param name="studentGrades"></param>
        public AddStudentMarkCommand(StudentGrades studentGrades)
            : base(studentGrades)
            => this._studentGrades = studentGrades;

        /// <summary>
        /// List all students then get one by user`s input and assign a mark.
        /// </summary>
        public override void Execute()
        {
            Console.WriteLine("Please select a student as type its id:\n\r");

            PrintStudents();

            ChooseStudent();

            EvaluateStudent();

            this._studentGrades.UpdateStudentMark(this._student);
        }

        /// <summary>
        /// Read user`s input and add mark to the chosen student if the mark is valid.
        /// </summary>
        private void EvaluateStudent()
        {
            while (this._student.Mark == default)
            {
                try
                {
                    Console.WriteLine($"You are going to assign mark of {this._student.FullName}");
                    Console.Write("mark > ");
                    this._student.Mark = Reader.ReadInteger;
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(FormatException))
                    {
                        Console.WriteLine(INVALID_INPUT_MSG);
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Choose a student to be marked
        /// </summary>
        private void ChooseStudent()
        {
            while (this._student is null)
            {
                try
                {
                    Console.Write("student id > ");
                    this._student = this._studentGrades
                        .GetStudentById(Reader.ReadInteger);

                    if (this._student is null)
                    {
                        Console.WriteLine(INVALID_CHOICE_MSG);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }
        }

        /// <summary>
        /// Print students
        /// </summary>
        private void PrintStudents()
        {
            foreach (var student in this._studentGrades.Students)
            {
                Console.WriteLine($"    {student}");
            }
            Console.WriteLine();
        }
    }
}
