﻿namespace ConsoleAppProject.App03
{
    using ConsoleAppProject.App03.Commands;
    using ConsoleAppProject.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static Common.Constants.Common;
    using static Common.Constants.StudentGrades;

    /// <summary>
    /// The invoker class is responsible for reading user input 
    /// and execute the command as well as storing all available commands.
    /// </summary>
    /// <author>Yavor Yankov</author>
    public class StudentGradesInvoker
    {
        /// <summary>
        /// All available commands
        /// <para>Key - Key value pair where the key is the name of the command
        /// but the value keeps whether  or not the command can be executed by the user.
        /// True if the command is executable and false if it is auto executable.
        /// </para>
        /// <para>Value - command class</para> 
        /// </summary>
        private Dictionary<KeyValuePair<string, bool>, Command> _commands;
        /// <summary>
        /// The reciever which student grades class
        /// </summary>
        private readonly StudentGrades _studentGrades;

        /// <summary>
        /// Initialise new student grade invoker 
        /// and make new instance of the reviecer
        /// </summary>
        public StudentGradesInvoker()
        {
            this._studentGrades = new StudentGrades();

            AddCommands();
        }

        /// <summary>
        /// If this property is true this application will be terminated 
        /// and the user will be redirected to the main menu
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        /// <summary>
        /// Run method is responsible to read user`s input and execute as a command
        /// </summary>
        public void Run()
        {
            // Print out the heading and description of Student grades app
            ExecuteCommand(
                GetCommandByName(
                    Helper.GetClassNameByAttribute(
                        typeof(PrintHeadingAndDescriptionCommand))));

            Console.WriteLine(ChooseOptionMsg(GetExecutableCommands()));

            while (IsCompleted is false)
            {
                Console.WriteLine();
                try
                {
                    Console.Write("choice > ");
                    var input = Reader.ReadInteger;

                    ExecuteCommand(
                        GetCommandByName(
                            GetCommandNameByNum(input)));
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }
        }

        private string GetCommandNameByNum(int input)
        {
            switch (input)
            {
                case 1:
                    return Helper.GetClassNameByAttribute(typeof(AddStudentCommand));
                case 2:
                    return Helper.GetClassNameByAttribute(typeof(AddStudentMarkCommand));
                case 3:
                    return Helper.GetClassNameByAttribute(typeof(AddMarkToAllStudentsCommand));
                case 4:
                    return Helper.GetClassNameByAttribute(typeof(PrintStudentsCommand));
                case 5:
                    return Helper.GetClassNameByAttribute(typeof(CalculateAndPrintMeanCommand));
                case 6:
                    return Helper.GetClassNameByAttribute(typeof(CalculateAndPrintGradeProfileCommand));
                case 7:
                    return Helper.GetClassNameByAttribute(typeof(PrintResultCommand));
                case 8:
                    return Helper.GetClassNameByAttribute(typeof(HelpCommand));
                case 9:
                    return Helper.GetClassNameByAttribute(typeof(ExitCommand));
                default:
                    Console.WriteLine(INVALID_CHOICE_MSG);
                    break;
            }
            
            return null;
        }

        /// <summary>
        /// This method get the executable commands.
        /// The way it works is filter all Dictonary keys and values of the keys which are true.
        /// Then select only the dictionary keys of their keys.
        /// Example:
        /// Dictionary -> Key = { 'Command name', true }
        /// From the above example the Command name will be inside of the filltered keys.
        /// </summary>
        /// <returns></returns>
        public List<string> GetExecutableCommands()
            => this._commands
                .Where(e => e.Key.Value == true)
                .Select(e => e.Key.Key)
                .ToList();

        /// <summary>
        /// Execute the given command
        /// </summary>
        /// <param name="command">The given command to be executed</param>
        private void ExecuteCommand(Command command)
        {
            if (command is not null)
            {
                command.Execute();
            }
        }

        /// <summary>
        /// Add all command to the dictionary
        /// </summary>
        private void AddCommands()
        {
            this._commands = new Dictionary<KeyValuePair<string, bool>, Command>();
            
            // Add 'Print heading and description' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(PrintHeadingAndDescriptionCommand)), false),
                new PrintHeadingAndDescriptionCommand(this._studentGrades));

            // Add 'Add student' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(AddStudentCommand)), true),
                new AddStudentCommand(this._studentGrades));

            // Add 'Mark student' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(AddStudentMarkCommand)), true),
                new AddStudentMarkCommand(this._studentGrades));

            // Add 'Marks to all students' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(AddMarkToAllStudentsCommand)), true),
                new AddMarkToAllStudentsCommand(this._studentGrades));

            // Add 'Print students' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(PrintStudentsCommand)), true),
                new PrintStudentsCommand(this._studentGrades));

            // Add 'Calculate and display mean' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(CalculateAndPrintMeanCommand)), true),
                new CalculateAndPrintMeanCommand(this._studentGrades));

            // Add 'Calculate and display grade profiles' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(CalculateAndPrintGradeProfileCommand)), true),
                new CalculateAndPrintGradeProfileCommand(this._studentGrades));

            // Add 'Print result' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(PrintResultCommand)), true),
                new PrintResultCommand(this._studentGrades));

            // Add 'Help' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(HelpCommand)), true),
                new HelpCommand(this));

            // Add 'Exit' command
            this._commands.Add(
                new KeyValuePair<string, bool>(
                    Helper.GetClassNameByAttribute(typeof(ExitCommand)), true),
                new ExitCommand(this));
        }

        /// <summary>
        /// Get a command by its name from the collection
        /// </summary>
        /// <param name="commandName">The name of the command</param>
        /// <returns>Return the command derived class that match with the name</returns>
        private Command GetCommandByName(string commandName)
            => this._commands
                .FirstOrDefault(k => k.Key.Key == commandName)
                .Value;
    }
}
