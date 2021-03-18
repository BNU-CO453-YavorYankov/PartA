namespace ConsoleAppProject.App03.Commands
{
    using ConsoleAppProject.Common;
    using System;

    using static Common.Constants.Common;
    using static Common.Constants.StudentGrades;

    /// <summary>
    /// This command add mark to all available students.
    /// Read the user`s input and add assign it to the mark prop of the given student.
    /// </summary>
    /// <author>Yavor Yankov</author>
    [ClassName("3. Add mark to all students")]
    public class AddMarkToAllStudentsCommand : Command
    {
        /// <summary>
        /// Create new command and assign studentGrades as a reciever 
        /// of the newly created command
        /// </summary>
        /// <param name="studentGrades">The reciever of this command</param>
        public AddMarkToAllStudentsCommand(StudentGrades studentGrades)
            : base(studentGrades)
        { }

        /// <summary>
        /// Execute this command.
        /// It get all available students.
        /// Ask the user to input a mark for the particular student.
        /// If the mark not valid print out error message on the console
        /// and ask the user to try again.
        /// </summary>
        public override void Execute()
        {
            Console.WriteLine("You are going to assign mark to all available students:");
            foreach (var student in base._studentGrades.Students)
            {
                while (student.Mark == default)
                {
                    try
                    {
                        Console.Write($"{student.StudentId}. {student.FullName}, mark = ");
                        student.Mark = Reader.ReadInteger;
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
                Console.WriteLine(UpdateStudentMarkMsg(student.FullName, student.Mark));
            }

            Console.WriteLine($"{base._studentGrades.Students.Count} students recieved a mark\n\r");
        }
    }
}
