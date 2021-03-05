namespace ConsoleAppProject
{
    using ConsoleAppProject.App01;
    using ConsoleAppProject.App02;
    using System;

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
        private static DistanceConverter converter;
        /// <summary>
        /// Instance of BMI calculator class
        /// </summary>
        private static BMICalculator calculator;
        private static 

        /// <summary>
        /// Starting point of all sub-projects.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.Beep();

            //RunApp1();
            RunApp2();
         }

        /// <summary>
        /// Initialise the distance converter and invoke the run method.
        /// </summary>
        private static void RunApp1()
        {
            converter = new DistanceConverter();
            converter.Run();
        }

        /// <summary>
        /// Initialise the BMI calculator and invoke the run method.
        /// </summary>
        private static void RunApp2()
        {
            calculator = new BMICalculator();
            calculator.Run();
        }
    }
}
