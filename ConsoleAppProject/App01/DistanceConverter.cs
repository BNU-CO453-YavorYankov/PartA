﻿namespace ConsoleAppProject.App01
{
    using System;
    using static ConsoleAppProject.App01.Constants;

    /// <summary>
    /// This App version allows the user to convert distances measured in 
    /// miles into feet and feet into miles,
    /// miles into metres and metres into miles,
    /// feet into metres and metres into feet,
    /// for example it will convert a distance measured in miles 
    /// into the same distance measured in feet.
    /// </summary>
    /// <author>
    /// Yavor Yankov version 0.3.3
    /// </author>
    public class DistanceConverter
    {
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
        /// Backing field for setting and retrieving the property value
        /// </summary>
        private double _toDistance;
        /// <summary>
        /// The converted distance to chosen unit
        /// </summary>
        public double ToDistance
        {
            get { return this._toDistance; }
            set
            {
                this._toDistance = Math.Round(value, 2);
            }
        }

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

            Console.WriteLine(SelectUnitMsg("from"));
            this.FromUnit = SelectUnit();

            Console.WriteLine(SelectUnitMsg("to"));
            this.ToUnit = SelectUnit();

            Console.WriteLine(
                ConvertMsg(
                    this.FromUnit.ToString(),
                    this.ToUnit.ToString()));

            SetDistance();

            ConvertDistance();

            PrintResult();
        }

        /// <summary>
        /// This method allows the user to select a distance unit
        /// </summary>
        public DistanceUnits SelectUnit()
        {
            try
            {
                Console.Write(INPUT_CHOICE_MSG);
                var userChoice = Reader.ReadInteger;

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
            catch (Exception)
            {
                Console.WriteLine(INVALID_INPUT_MSG);
                SelectUnit();
            }
            return DistanceUnits.NoUnit;
        }

        /// <summary>
        /// This method allows the user to input the distance to convert from
        /// </summary>
        public void SetDistance()
        {
            Console.Write(EnterDistMsg(this.FromUnit.ToString()));

            try
            {
                this.FromDistance = Reader.ReadDouble;
            }
            catch (Exception e)
            {
                if (e.Message != NEGATIVE_DISTANCE_MSG)
                    Console.WriteLine(INVALID_INPUT_MSG);
                else
                    Console.WriteLine(e.Message);

                SetDistance();
            }
        }

        /// <summary>
        /// Convert the distance from unit to anouther chosen unit by the user
        /// </summary>
        public void ConvertDistance()
        {
            if (this.FromUnit is DistanceUnits.Miles &&
                this.ToUnit is DistanceUnits.Feet)
            {
                this.ToDistance = this.FromDistance * MILE_IN_FEET;
            }
            else if (this.FromUnit is DistanceUnits.Miles &&
                    this.ToUnit is DistanceUnits.Metres)
            {
                this.ToDistance = this.FromDistance / METRES_IN_MILES;
            }
            else if (this.FromUnit is DistanceUnits.Feet &&
                    this.ToUnit is DistanceUnits.Miles)
            {
                this.ToDistance = this.FromDistance * FEET_IN_MILES;
            }
            else if (this.FromUnit is DistanceUnits.Feet &&
                    this.ToUnit is DistanceUnits.Metres)
            {
                this.ToDistance = this.FromDistance / METRES_IN_FEET;
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

        /// <summary>
        /// Print out the converted distance
        /// </summary>
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
