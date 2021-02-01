using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App version allows the user to convert distances measured in 
    /// miles into feet and feet into miles, 
    /// for example it will convert a distance measured in miles 
    /// into the same distance measured in feet.
    /// </summary>
    /// <author>
    /// Yavor Yankov version 0.2
    /// </author>
    public class DistanceConverter
    {
        /// <summary>
        /// 1 mile is 5280 feet
        /// </summary>
        private const double MILE_IN_FEET = 5280;
        /// <summary>
        /// 1 mile is 1609.34 metres
        /// </summary>
        private const double MILE_IN_METRES = 1609.34;

        /// <summary>
        /// Feet in miles
        /// </summary>
        private double miles = 0.00d;
        /// <summary>
        /// Inputed miles by the user
        /// </summary>
        private double inputedMiles = 0.00d;
        /// <summary>
        /// Miles in feet 
        /// </summary>
        private double feet = 0.00d;
        /// <summary>
        /// Inputed feet by the user
        /// </summary>
        private double inputedFeet = 0.00d;
        /// <summary>
        /// Miles in metres
        /// </summary>
        private double metres = 0.00d;

        /// <summary>
        /// The constructor of this distance converter 
        /// that invoke the run method.
        /// </summary>
        public DistanceConverter()
        {
            Run();
        }

        /// <summary>
        /// This method runs the app
        /// </summary>
        public void Run()
        {
            PrintHeading();

            InputMiles();
            CalculateFeet();
            PrintFeet();
            
            InputFeet();
            CalculateMiles();
            PrintMiles();

            InputMiles();
            CalculateMetres();
            PrintMetres();
        }

        /// <summary>
        /// Read and convert the user input in miles unit.
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
        /// Read and convert the user input.
        /// </summary>
        private void InputFeet()
        {
            try
            {
                Console.Write("Input feet: ");
                SetFeet(double.Parse(Console.ReadLine()));
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
        /// <param name="miles">Inputed miles by the user</param>
        private void SetMiles(double miles)
        {
            if(miles < 0)
            {
                Console.WriteLine("Miles cannot be less than zero!");
            }
            else
            {
                this.inputedMiles = miles;
            }
        }

        /// <summary>
        /// Check is the user input less than zero if true print out error msg,
        /// if false set it to feet field.
        /// </summary>
        /// <param name="feet">Inputed feet by the user</param>
        private void SetFeet(double feet)
        {
            if (feet < 0)
            {
                Console.WriteLine("Feet cannot be less than zero!");
            }
            else
            {
                this.inputedFeet = feet;
            }
        }

        /// <summary>
        /// Calculate miles into feets
        /// Formula: 1 mile = 5280 feet.
        /// </summary>
        private void CalculateFeet()
            => this.feet = this.inputedMiles * MILE_IN_FEET;

        /// <summary>
        /// Calculate feet into miles
        /// Formula: 5280 feet = 1 mile.
        /// </summary>
        private void CalculateMiles()
            => this.miles = this.inputedFeet / MILE_IN_FEET;

        /// <summary>
        /// Calculate miles into metres
        /// Formula: 1 mile = 1609.34 metres
        /// </summary>
        private void CalculateMetres()
            => this.metres = this.inputedMiles * MILE_IN_METRES;

        /// <summary>
        /// Print out the miles into feet.
        /// </summary>
        private void PrintFeet()
        {
            Console.WriteLine($"{this.inputedMiles} miles is {this.feet} feet");
        }

        /// <summary>
        /// Print out the feet into miles.
        /// </summary>
        private void PrintMiles()
        {
            Console.WriteLine($"{this.inputedFeet} feet is {this.miles} miles");
        }

        /// <summary>
        /// Print out the miles into metres.
        /// </summary>
        private void PrintMetres()
        {
            Console.WriteLine($"{this.inputedMiles} miles is {this.metres} metres");
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
