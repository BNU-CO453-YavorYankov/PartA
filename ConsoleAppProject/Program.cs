namespace ConsoleAppProject
{
    using ConsoleApp.Menu;
    using ConsoleAppProject.App03;
    using ConsoleAppProject.App03.Commands;
    using ConsoleAppProject.Common;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Yavor Yankov 12/02/2021
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Instance of distance converter class
        /// </summary>
        private static App01.DistanceConverter converter;
        /// <summary>
        /// Instance of BMI calculator class
        /// </summary>
        private static App02.BMICalculator calculator;
        /// <summary>
        /// Instance of Student grades invoker class
        /// </summary>
        private static StudentGradesInvoker studentGradesInvoker;

        /// <summary>
        /// Starting point of all sub-projects.
        /// Make new instance of the menu class.
        /// Subscribe to the launch application event 
        /// and run the menu.
        /// </summary>
        public static void Main(string[] args)
        {
            //while (true)
            //{
            //    Console.Beep();

            //    var menu = new Menu(new List<string>()
            //    {
            //        Constants.DistanceConverter.PROGRAM_NAME,
            //        Constants.BMICalculator.PROGRAM_NAME,
            //        Constants.StudentGrades.PROGRAM_NAME
            //    });
            //    menu.LaunchApplicationEvent += LaunchApplication;

            //    menu.Run();
            //}

            var marks = new HelpCommand(new StudentGradesInvoker());
            marks.Execute();
        }

        /// <summary>
        /// This method define what actions to take when the event is raised.
        /// In this case depending on the appName parameter`s 
        /// value will be launched an application.
        /// </summary>
        /// <param name="sender">The sender also known as publisher of the event</param>
        /// <param name="appName">The application name to be launched</param>
        public static void LaunchApplication(object sender, string appName)
        {
            if (appName == Constants.DistanceConverter.PROGRAM_NAME)
            {
                converter = new App01.DistanceConverter();
                converter.Run();
            }
            else if (appName == Constants.BMICalculator.PROGRAM_NAME)
            {
                calculator = new App02.BMICalculator();
                calculator.Run();
            }
            else if (appName == Constants.StudentGrades.PROGRAM_NAME)
            {
                studentGradesInvoker = new StudentGradesInvoker();
                studentGradesInvoker.Run();
            }
        }
    }
}
