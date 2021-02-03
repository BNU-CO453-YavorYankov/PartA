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
        /// 1 foot is 0.3048 metres
        /// </summary>
        private const double FEET_IN_METRES = 0.3048;
        /// <summary>
        /// 1 foot is 0.000189394 miles
        /// </summary>
        private const double FEET_IN_MILES = 0.000189394;
        /// <summary>
        /// 1 metre is 0.000621371 miles
        /// </summary>
        private const double METRES_IN_MILES = 0.000621371;
        /// <summary>
        /// 1 metre is 3.28084 feet
        /// </summary>
        private const double METRES_IN_FEET = 3.28084;

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

            ConvertDistance();

            PrintResult();
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
            Console.Write($"\n\rPlease enter distance in {this.FromUnit} > ");

            try
            {
                this.FromDistance = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                if (e.Message != NEGATIVE_DISTANCE_MSG)
                    Console.WriteLine("\n\rInvalid input!");
                else
                    Console.WriteLine(e.Message);
                SetDistance();
            }
        }

        /// <summary>
        /// Convert the distance from unit to anouther chosen unit by the user
        /// </summary>
        private void ConvertDistance()
        {
            if (this.FromUnit is DistanceUnits.Miles &&
                this.ToUnit is DistanceUnits.Feet)
            {
                this.ToDistance = this.FromDistance * MILE_IN_FEET;
            }
            else if (this.FromUnit is DistanceUnits.Miles &&
                    this.ToUnit is DistanceUnits.Metres)
            {
                this.ToDistance = this.FromDistance * MILE_IN_METRES;
            }
            else if (this.FromUnit is DistanceUnits.Feet &&
                    this.ToUnit is DistanceUnits.Miles)
            {
                this.ToDistance = this.FromDistance * FEET_IN_MILES;
            }
            else if (this.FromUnit is DistanceUnits.Feet &&
                    this.ToUnit is DistanceUnits.Metres)
            {
                this.ToDistance = this.FromDistance * FEET_IN_METRES;
            }
            else if (this.FromUnit is DistanceUnits.Metres &&
                    this.ToUnit is DistanceUnits.Miles)
            {
                this.ToDistance = this.FromDistance * METRES_IN_MILES;
            }
            else if (this.FromUnit is DistanceUnits.Metres &&
                    this.ToUnit is DistanceUnits.Feet)
            {
                this.ToDistance = this.FromDistance * METRES_IN_FEET;
            }
        }

        private void PrintResult()
        {
            Console.WriteLine(
                $"\n\r{this.FromDistance} {this.FromUnit} is {this.ToDistance:f2} {this.ToUnit}");
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
