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
    /// Yavor Yankov version 0.3.2
    /// </author>
    public class DistanceConverter
    {
        /// <summary>
        /// Print out this message when the user should select one of 3 options
        /// </summary>
        private const string SELECT_DIST_FROM_MSG = 
            "\n\rSelect distance unit to convert from >\n\r\n\r" +
            "1. Feet\n\r2. Metres\n\r3. Miles\n\r\n\r";
        /// <summary>
        /// Print out this message when the user should select one of 3 options
        /// </summary>
        private const string SELECT_DIST_TO_MSG =
            "\n\rSelect distance unit to convert to >\n\r\n\r" +
            "1. Feet\n\r2. Metres\n\r3. Miles\n\r\n\r";
        /// <summary>
        /// Print out this message when the user should choose 
        /// </summary>
        private const string INPUT_CHOICE_MSG = "Please enter your choice > ";
        /// <summary>
        /// Print out this message when the user choice is invalid
        /// </summary>
        private const string INVALID_CHOICE_MSG = "\n\rInvalid choice!";
        /// <summary>
        /// Print out this message when the user select a distance unit
        /// </summary>
        private const string SELECTION_MSG = "\n\rYou have selected ";
        /// <summary>
        /// Print out this message when the distance is negative number
        /// </summary>
        private const string NEGATIVE_DISTANCE_MSG = "\n\rDistance cannot be less than zero!";
        /// <summary>
        /// User choice for feet
        /// </summary>
        private const int FEET = 1;
        /// <summary>
        /// User choice for metres
        /// </summary>
        private const int METRES = 2;
        /// <summary>
        /// User choice for miles
        /// </summary>
        private const int MILES = 3;
        /// <summary>
        /// 1 mile is 5280 feet
        /// </summary>
        private const double MILE_IN_FEET = 5280;
        /// <summary>
        /// 1 mile is 1609.34 metres
        /// </summary>
        private const double MILE_IN_METRES = 1609.34;

        /// <summary>
        /// The constructor of this distance converter 
        /// that invoke the run method.
        /// </summary>
        public DistanceConverter()
        {
            Run();
        }

        /// <summary>
        /// Backing field for setting and retrieving the property value
        /// </summary>
        private double _fromDistance;
        /// <summary>
        /// The amount of distance that will be converted
        /// </summary>
        public double FromDistance 
        {
            get { return this._fromDistance; }
            set 
            {
                
                if (value < 0)
                {
                    throw new ArgumentException(NEGATIVE_DISTANCE_MSG);
                }
                _fromDistance = value;
            } 
        }

        /// <summary>
        /// The unit that will be convered from 
        /// Its default value is no unit
        /// </summary>
        public DistanceUnits FromUnit { get; set; } = DistanceUnits.NoUnit;

        /// <summary>
        /// The converted distance to chosen unit
        /// </summary>
        public double ToDistance { get; set; }

        /// <summary>
        /// The unit that will be convered to
        /// Its default value is no unit
        /// </summary>
        public DistanceUnits ToUnit { get; set; } = DistanceUnits.NoUnit;

        /// <summary>
        /// This method runs the app
        /// </summary>
        public void Run()
        {
            PrintHeading();
            
            Console.WriteLine(SELECT_DIST_FROM_MSG);
            this.FromUnit = SelectUnit();
            
            Console.WriteLine(SELECT_DIST_TO_MSG);
            this.ToUnit = SelectUnit();

            Console.WriteLine($"\n\rConverting from {this.FromUnit} to {this.ToUnit}");

            SetDistance();

            //CalculateDistance();
        }

        /// <summary>
        /// This method allows the user to select a distance unit
        /// </summary>
        private DistanceUnits SelectUnit()
        {
            var userChoice = 0;

            while (true)
            {
                Console.Write(INPUT_CHOICE_MSG);
                var success = int.TryParse(
                    Console.ReadLine(),
                    out userChoice);

                if (success)
                {
                    switch (userChoice)
                    {
                        case FEET:
                            Console.WriteLine($"{SELECTION_MSG} Feet");
                            return DistanceUnits.Feet;
                        case METRES:
                            Console.WriteLine($"{SELECTION_MSG} Metres");
                            return DistanceUnits.Metres;
                        case MILES:
                            Console.WriteLine($"{SELECTION_MSG} Miles");
                            return DistanceUnits.Miles;
                        default:
                            Console.WriteLine(INVALID_CHOICE_MSG);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(INVALID_CHOICE_MSG);
                }
            }
        }

        /// <summary>
        /// This method allows the user to input the distance to convert from
        /// </summary>
        private void SetDistance() 
        {
            Console.Write($"Please enter distance in {this.FromUnit} > ");
           
            try
            {
                this.FromDistance = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                if(e.Message != NEGATIVE_DISTANCE_MSG) 
                    Console.WriteLine("\n\rInvalid input!");
                else 
                    Console.WriteLine(e.Message);
                SetDistance();
            }
        }

        ///// <summary>
        ///// Check is the user input less than zero if true print out error msg,
        ///// if false set it to miles field.
        ///// </summary>
        ///// <param name="miles">Inputed miles by the user</param>
        //private void SetMiles(double miles)
        //{
        //    if (miles < 0)
        //    {
        //        Console.WriteLine("Miles cannot be less than zero!");
        //    }
        //    else
        //    {
        //        this.inputedMiles = miles;
        //    }
        //}

        ///// <summary>
        ///// Check is the user input less than zero if true print out error msg,
        ///// if false set it to feet field.
        ///// </summary>
        ///// <param name="feet">Inputed feet by the user</param>
        //private void SetFeet(double feet)
        //{
        //    if (feet < 0)
        //    {
        //        Console.WriteLine("Feet cannot be less than zero!");
        //    }
        //    else
        //    {
        //        this.inputedFeet = feet;
        //    }
        //}

        ///// <summary>
        ///// Calculate miles into feets
        ///// Formula: 1 mile = 5280 feet.
        ///// </summary>
        //private void CalculateFeet()
        //    => this.feet = this.inputedMiles * MILE_IN_FEET;

        ///// <summary>
        ///// Calculate feet into miles
        ///// Formula: 5280 feet = 1 mile.
        ///// </summary>
        //private void CalculateMiles()
        //    => this.miles = this.inputedFeet / MILE_IN_FEET;

        ///// <summary>
        ///// Calculate miles into metres
        ///// Formula: 1 mile = 1609.34 metres
        ///// </summary>
        //private void CalculateMetres()
        //    => this.metres = this.inputedMiles * MILE_IN_METRES;

        ///// <summary>
        ///// Print out the miles into feet.
        ///// </summary>
        //private void PrintFeet()
        //{
        //    Console.WriteLine($"{this.inputedMiles} miles is {this.feet} feet");
        //}

        ///// <summary>
        ///// Print out the feet into miles.
        ///// </summary>
        //private void PrintMiles()
        //{
        //    Console.WriteLine($"{this.inputedFeet} feet is {this.miles} miles");
        //}

        ///// <summary>
        ///// Print out the miles into metres.
        ///// </summary>
        //private void PrintMetres()
        //{
        //    Console.WriteLine($"{this.inputedMiles} miles is {this.metres} metres");
        //}

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
