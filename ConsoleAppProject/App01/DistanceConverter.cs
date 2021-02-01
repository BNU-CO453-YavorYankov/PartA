using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App allows the user to convert distances measured in 
    /// one unit of distance into another unit of distance, 
    /// for example it will convert a distance measured in miles 
    /// into the same distance measured in feet.
    /// </summary>
    /// <author>
    /// Yavor Yankov version 0.1
    /// </author>
    public class DistanceConverter
    {
        /// <summary>
        /// 1 mile is 5280 feet
        /// </summary>
        private const double MILE_IN_FEET = 5280;

        /// <summary>
        /// Inputed miles by the user
        /// </summary>
        private double miles = 0.00d;
        /// <summary>
        /// Converted miles into feet
        /// </summary>
        private double feet;

        /// <summary>
        /// The constructor of this distance converter 
        /// that invoke the run method.
        /// </summary>
        public DistanceConverter()
        {
            Run();
        }

        /// <summary>
        /// Print app heading and invoke input miles,
        /// calculate feet and print feet methods.
        /// If miles field is equal to its default value, 
        /// it araises recursion.
        /// </summary>
        public void Run()
        {
            PrintHeading();
            InputMiles();
            
            if(this.miles == 0)
            {
                Run();
            }

            CalculateFeet();
            PrintFeet();
        }

        /// <summary>
        /// Read and convert the user input.
        /// </summary>
        private void InputMiles()
        {
            try
            {
                Console.Write("Input miles: ");
                SetMiles(double.Parse(Console.ReadLine()));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }

        /// <summary>
        /// Check is the user input less than zero if true print out error msg,
        /// if false set it to miles field.
        /// </summary>
        /// <param name="miles"></param>
        private void SetMiles(double miles)
        {
            if(miles < 0)
            {
                Console.WriteLine("Miles cannot be less than zero!");
            }
            else
            {
                this.miles = miles;
            }
        }

        /// <summary>
        /// Calculate miles into feets
        /// Formula: 1 mile = 5280 feet.
        /// </summary>
        private void CalculateFeet()
            => this.feet = this.miles * MILE_IN_FEET;

        /// <summary>
        /// Print out the miles into feet.
        /// </summary>
        private void PrintFeet()
        {
            Console.WriteLine($"{this.miles:f2} miles is {this.feet:f2} feet");
        }

        /// <summary>
        /// Print out the heading of this App
        /// </summary>
        private void PrintHeading() 
        {
            Console.WriteLine("--------------------------------------\n\r" +
                              "           Distance Converter         \n\r" +
                              "            by Yavor Yankov           \n\r" +
                              "--------------------------------------\n\r");
        }
    }
}
