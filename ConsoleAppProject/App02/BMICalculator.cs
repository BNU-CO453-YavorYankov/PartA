namespace ConsoleAppProject.App02
{
    using System;
    using System.ComponentModel;
    using ConsoleAppProject.Common;

    using static Common.Constants.Common;
    using static Common.Constants.BMICalculator;

    /// <summary>
    /// Body Mass Index, is a measure of the weight compared to the height of one person.
    /// BMI gives an estimate of the weight-related health risks.
    /// 
    /// The BMI calculator allows the user to choose between imperial and metric units.
    /// After, he should input its weight and height. Then the app will calculate and
    /// print out the BMI of the user. Also, prints out the World Health Organisation 
    /// weight status as well as explanation to BAME groups of extra risks.
    /// </summary>
    /// <author>
    /// Yavor Yankov 
    /// </author>
    /// <version>1.0</version>
    public class BMICalculator : IApplication
    {
        /// <summary>
        /// The unit that would be imperial or metric.
        /// </summary>
        public UnitTypes UnitType { get; set; } = default;

        /// <summary>
        /// Converted stones into pounds plus if there are additional ones
        /// </summary>
        public double TotalWeightInPounds
            => (this.WeightInStones * STONE_TO_POUNDS) + this.WeightInPounds;

        [DisplayName("Stones")]
        /// <summary>
        /// weight of the user in stones
        /// </summary>
        public double WeightInStones { get; set; } = -1;

        [DisplayName("Pounds")]
        /// <summary>
        /// weight of the user in pounds
        /// </summary>
        public double WeightInPounds { get; set; } = -1;

        [DisplayName("Kg")]
        /// <summary>
        /// weight of the user in Kg
        /// </summary>
        public double WeightInKg { get; set; } = -1;

        /// <summary>
        /// Converted feet into inches plus if there are additional ones
        /// </summary>
        public double TotalHeightInInches
            => (this.HeightInFeet * FOOT_TO_INCHES) + this.HeightInInches;

        [DisplayName("Feet")]
        /// <summary>
        /// height of the user in feet
        /// </summary> 
        public double HeightInFeet { get; set; } = -1;

        [DisplayName("Inches")]
        /// <summary>
        /// height of the user in inches
        /// </summary>
        public double HeightInInches { get; set; } = -1;

        [DisplayName("Metres")]
        /// <summary>
        /// height of the user in metres
        /// </summary>
        public double HeightInMetres { get; set; } = -1;

        [DisplayName("body mass index (BMI)")]
        /// <summary>
        /// body mass index of the user
        /// </summary>
        public double BodyMassIndex { get; set; } = -1;

        [DisplayName("weight status")]
        /// <summary>
        /// the weight status of the user according to
        /// World Health Organisation
        /// </summary>
        public string WeightStatus { get; set; }

        //The definition of result prop comes from IApplication!
        public string Result
         => $"\n\rBMI: {this.BodyMassIndex:f2}\n\r" +
            $"Weight status: {this.WeightStatus}\n\r\n\r" +
            "If you are Black, Asian or other ethnic groups,\n\r" +
            "you have a higher risk.\n\r\n\r" +
            "Adults 23 or more are at increased risk\n\r" +
            "Adults 27.5 or more are at high risk\n\r\n\r" +
            $"{WEIGHT_STATUS_TABLE}";

        /// <summary>
        /// This method runs the app
        /// </summary>
        public void Run()
        {
            Helper.PrintHeading(PROGRAM_NAME, DESCRIPTION);

            SelectUnit();

            if (this.UnitType == UnitTypes.Imperial)
            {
                InputWeightInImperialUnits();
                InputHeightInImperialUnits();
            }
            else
            {
                InputWeightInMetricUnits();
                InputHeightInMetricUnits();
            }

            CalculateBMI();

            SetWeightStatus();

            Helper.PrintResult(this.Result);
        }
        
        /// <summary>
        /// Sets the weight status based on BMI value. 
        /// The weight status is according to the World Health Organisation
        /// </summary>
        private void SetWeightStatus()
        {
            if (this.BodyMassIndex < 18.5)
            {
                this.WeightStatus = UNDERWEIGHT;
            }
            else if (this.BodyMassIndex >= 18.5 && this.BodyMassIndex <= 24.9)
            {
                this.WeightStatus = NORMAL;
            }
            else if (this.BodyMassIndex >= 25 && this.BodyMassIndex <= 29.9)
            {
                this.WeightStatus = OVERWEIGHT;
            }
            else if (this.BodyMassIndex >= 30 && this.BodyMassIndex <= 34.9)
            {
                this.WeightStatus = OBESE_CLASS_I;
            }
            else if (this.BodyMassIndex >= 35 && this.BodyMassIndex <= 39.9)
            {
                this.WeightStatus = OBESE_CLASS_II;
            }
            else if (this.BodyMassIndex >= 40)
            {
                this.WeightStatus = OBESE_CLASS_III;
            }
        }

        /// <summary>
        /// User should input 1 or 2 in order to choose unit type
        /// </summary>
        public void SelectUnit()
        {
            Console.WriteLine(SELECT_UNIT_MSG);

            while (this.UnitType == default)
            {
                try
                {
                    Console.Write(INPUT_CHOICE_MSG);
                    var userChoice = Reader.ReadInteger;

                    switch (userChoice)
                    {
                        case 1:
                            this.UnitType = UnitTypes.Imperial;
                            break;
                        case 2:
                            this.UnitType = UnitTypes.Metric;
                            break;
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
            Console.WriteLine(SelectedUnitMsg(this.UnitType.ToString()));
        }

        /// <summary>
        /// Calculates the body mass index and store the result in BodyMassIndex prop.
        /// </summary>
        public void CalculateBMI()
        {
            // This exception will never be thrown to the user.
            if (this.UnitType == default)
            {
                throw new ArgumentException("The UnitType property is not set!");
            }

            switch (this.UnitType)
            {
                case UnitTypes.Imperial:
                    this.BodyMassIndex = (this.TotalWeightInPounds * 703) / Math.Pow(this.TotalHeightInInches, 2);
                    break;
                case UnitTypes.Metric:
                    this.BodyMassIndex = this.WeightInKg / Math.Pow(this.HeightInMetres, 2);
                    break;
            }
        }

        /// <summary>
        /// This method reads the user input 
        /// and store it in the WeightInStones and WeightInPounds props.
        /// </summary>
        private void InputWeightInImperialUnits()
        {
            double userWeight = default;

            while (this.WeightInStones == -1)
            {
                try
                {
                    Console.Write($"{INPUT_WEIGHT_MSG}stones > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight < 0)
                    {
                        Console.WriteLine(NEGATIVE_WEIGHT_MSG);
                    }
                    else
                    {
                        this.WeightInStones = userWeight;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }

            userWeight = default;

            while (this.WeightInPounds == -1)
            {
                try
                {
                    Console.Write($"{INPUT_WEIGHT_MSG}pounds > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight < 0)
                    {
                        Console.WriteLine(NEGATIVE_WEIGHT_MSG);
                    }
                    else
                    {
                        this.WeightInPounds = userWeight;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }
        }

        /// <summary>
        /// This method reads the user input 
        /// and store it in the HeightInFeet and HeightInInches props.
        /// </summary>
        private void InputHeightInImperialUnits()
        {
            double userWeight = default;

            while (this.HeightInFeet == -1)
            {
                try
                {
                    Console.Write($"{INPUT_HEIGHT_MSG}feet > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight < 0)
                    {
                        Console.WriteLine(NEGATIVE_HEIGHT_MSG);
                    }
                    else
                    {
                        this.HeightInFeet = userWeight;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }

            userWeight = default;

            while (this.HeightInInches == -1)
            {
                try
                {
                    Console.Write($"{INPUT_HEIGHT_MSG}inches > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight < 0)
                    {
                        Console.WriteLine(NEGATIVE_HEIGHT_MSG);
                    }
                    else
                    {
                        this.HeightInInches = userWeight;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }
        }

        /// <summary>
        /// This method reads the user input and store it in the WeightInKg prop.
        /// </summary>
        private void InputWeightInMetricUnits()
        {
            while (this.WeightInKg == -1)
            {
                try
                {
                    Console.Write(INPUT_WEIGHT_MSG);

                    var userWeight = Reader.ReadDouble;

                    if (userWeight < 0)
                    {
                        Console.WriteLine(NEGATIVE_WEIGHT_MSG);
                    }
                    else
                    {
                        this.WeightInKg = userWeight;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }
        }

        /// <summary>
        /// This method reads the user input and store it in the HeightInMetres prop.
        /// </summary>
        private void InputHeightInMetricUnits()
        {
            while (this.HeightInMetres == -1)
            {
                try
                {
                    Console.Write(INPUT_HEIGHT_MSG);
                    var userHeight = Reader.ReadDouble;

                    if (userHeight < 0)
                    {
                        Console.WriteLine(NEGATIVE_HEIGHT_MSG);
                    }
                    else
                    {
                        this.HeightInMetres = userHeight;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }
        }
    }
}
