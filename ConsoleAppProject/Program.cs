﻿namespace ConsoleAppProject
{
    using ConsoleApp.Menu;
    using ConsoleAppProject.App01;
    using ConsoleAppProject.App02;
    using ConsoleAppProject.App03;
    using ConsoleAppProject.Common;
    using System;
    using System.Collections.Generic;
    using static Common.Constants;

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
        /// Instance of Student marks class
        /// </summary>
        private static App03.StudentMarks studentMarks;

        /// <summary>
        /// Starting point of all sub-projects.
        /// Make new instance of the menu class.
        /// Subscribe to the launch application event 
        /// and run the menu.
        /// </summary>
        public static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;

            //Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            //Console.WriteLine();
            //Console.Beep();

            ////RunApp1();
            ////RunApp2();
            //RunApp3();

            var menu = new Menu(new List<string>
            {
                Constants.DistanceConverter.PROGRAM_NAME,
                Constants.BMICalculator.PROGRAM_NAME,
                Constants.StudentMarks.PROGRAM_NAME
            });
            menu.LaunchApplicationEvent += LaunchApplication;

            menu.Run();
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
            else if(appName == Constants.BMICalculator.PROGRAM_NAME)
            {
                calculator = new App02.BMICalculator();
                calculator.Run();
            }
            else if (appName == Constants.StudentMarks.PROGRAM_NAME)
            {
                studentMarks = new App03.StudentMarks();
                studentMarks.Run();
            }
        }
    }
}
