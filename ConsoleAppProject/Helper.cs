using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// Helper class is responsible for keeping methods 
    /// that are used in more than one App
    /// </summary>
    /// <author>Yavor Yankov</author>
    /// <version>1.0</version>
    public static class Helper
    {
        /// <summary>
        /// Print out the heading of an App and its brief description
        /// </summary>
        /// <param name="appDescription">The description of an application</param>
        public static void PrintHeading(string appName, string appDescription)
        {

            Console.WriteLine("--------------------------------------\n\r" +
                              $"           {appName}                 \n\r" +
                              "            by Yavor Yankov           \n\r" +
                              "--------------------------------------\n\r" +
                              "\n\r" +
                              $"{appDescription}");
        }
    }
}
