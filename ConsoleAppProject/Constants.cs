namespace ConsoleAppProject
{
    public static class Constants
    {
        /// <summary>
        /// This class keeps all constants of Distance Converter program
        /// </summary>
        public static class DistanceConverter
        {
            /// <summary>
            /// The name of this app
            /// </summary>
            public const string PROGRAM_NAME = "Distance Converter";
            /// <summary>
            ///  Print out this message when the user input is not valid in a given context
            /// </summary>
            public const string INVALID_INPUT_MSG = "\n\rInvalid input!";
            /// <summary>
            /// Print out this message when the user should choose 
            /// </summary>
            public const string INPUT_CHOICE_MSG = "Please enter your choice > ";
            /// <summary>
            /// Print out this message when the user choice is invalid
            /// </summary>
            public const string INVALID_CHOICE_MSG = "\n\rInvalid choice!";
            /// <summary>
            /// Print out this message when the user select a distance unit
            /// </summary>
            public const string SELECTION_MSG = "\n\rYou have selected ";
            /// <summary>
            /// Print out this message when the distance is negative number
            /// </summary>
            public const string NEGATIVE_DISTANCE_MSG = "\n\rDistance cannot be less than zero!";
            /// <summary>
            /// User choice for feet
            /// </summary>
            public const int FEET = 1;
            /// <summary>
            /// User choice for metres
            /// </summary>
            public const int METRES = 2;
            /// <summary>
            /// User choice for miles
            /// </summary>
            public const int MILES = 3;
            /// <summary>
            /// 1 mile is 5280 feet
            /// </summary>
            public const double MILE_IN_FEET = 5280;
            /// <summary>
            /// 1 foot is 0.3048 metres
            /// </summary>
            public const double FEET_IN_METRES = 0.3048;
            /// <summary>
            /// 1 foot is 0.000189394 miles
            /// </summary>
            public const double FEET_IN_MILES = 0.00018939;
            /// <summary>
            /// 1 metre is 0.000621371 miles
            /// </summary>
            public const double METRES_IN_MILES = 0.00062137;
            /// <summary>
            /// 1 metre is 3.28084 feet
            /// </summary>
            public const double METRES_IN_FEET = 3.28084;

            /// <summary>
            /// Print out this message when the user should select one of 3 options
            /// </summary>
            /// <param name="direction">Unit to convert from or to</param>
            /// <returns></returns>
            public static string SelectUnitMsg(string direction)
                => $"\n\rSelect distance unit to convert {direction} >\n\r" +
                    "\n\r1. Feet" +
                    "\n\r2. Metres" +
                    "\n\r3. Miles";
            
            /// <summary>
            /// Print out this message after two units are selected
            /// </summary>
            /// <param name="fromUnit">Convert from this unit</param>
            /// <param name="toUnit">Convert to this unit</param>
            /// <returns></returns>
            public static string ConvertMsg(string fromUnit, string toUnit)
                => $"\n\rConverting from {fromUnit} to {toUnit}";
            
            /// <summary>
            ///  Print out this message when the user should enter distance
            /// </summary>
            /// <param name="fromUnit">Distance in this unit (miles, feet or metres)</param>
            /// <returns></returns>
            public static string EnterDistMsg(string fromUnit)
                => $"\n\rPlease enter distance in {fromUnit} > ";
        }
    }
}
