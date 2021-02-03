using ConsoleAppProject.App01;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Yavor Yankov 01/02/2021
    /// </summary>
    public static class Program
    {
        private static DistanceConverter converter;

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine("Developed by Yavor Yankov");
            Console.WriteLine();
            Console.Beep();

            RunApp1();
        }

        private static void RunApp1()
        {
            converter = new DistanceConverter();
            converter.Run();
        }
    }
}
