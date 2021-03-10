namespace ConsoleAppProject.App01
{
    using System;
    using System.ComponentModel;
    using ConsoleAppProject.Common;

    using static Common.Constants.Common;
    using static Common.Constants.DistanceConverter;

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
    public class DistanceConverter : IApplication
    {
        /// <summary>
        /// Backing field for setting and retrieving the property value
        /// </summary>
        private double _fromDistance;
        
        [DisplayName("From Distance")]
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

        [DisplayName("From Unit")]
        /// <summary>
        /// The unit that will be convered from 
        /// Its default value is no unit
        /// </summary>
        public DistanceUnits FromUnit { get; set; } = DistanceUnits.NoUnit;

        /// <summary>
        /// Backing field for setting and retrieving the property value
        /// </summary>
        private double _toDistance;
        
        [DefaultValue(0.00d), DisplayName("To Distance")]
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

        [DisplayName("To Unit")]
        /// <summary>
        /// The unit that will be convered to
        /// Its default value is no unit
        /// </summary>
        public DistanceUnits ToUnit { get; set; } = DistanceUnits.NoUnit;

        /// <summary>
        /// The result as a string.
        /// It is passed to PrintResult helper method
        /// </summary>
        public string Result
            => $"\n\r{this.FromDistance} {this.FromUnit} is {this.ToDistance:f2} {this.ToUnit}";

        /// <summary>
        /// This method runs the app
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Helper.PrintHeading(PROGRAM_NAME, null);

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

                Helper.PrintResult(this.Result);
            }
        }

        /// <summary>
        /// This method allows the user to select a distance unit
        /// </summary>
        public DistanceUnits SelectUnit()
        {
            while (true)
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
                }
            }
        }

        /// <summary>
        /// This method allows the user to input the distance to convert from
        /// </summary>
        public void SetDistance()
        {
            try
            {
                Console.Write(EnterDistMsg(this.FromUnit.ToString()));
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

        //This method is not used for this application
        public void Validation()
        {
            throw new NotImplementedException();
        }
    }
}
