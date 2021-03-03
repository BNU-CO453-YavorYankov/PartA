﻿namespace ConsoleAppProject.App02
{
    using System;

    using static Constants.Common;
    using static Constants.BMICalculator;

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
    public class BMICalculator
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

        /// <summary>
        /// weight of the user in stones
        /// </summary>
        public double WeightInStones { get; set; } = default;

        /// <summary>
        /// weight of the user in pounds
        /// </summary>
        public double WeightInPounds { get; set; } = default;

        /// <summary>
        /// weight of the user in Kg
        /// </summary>
        public double WeightInKg { get; set; } = default;

        /// <summary>
        /// Converted feet into inches plus if there are additional ones
        /// </summary>
        public double TotalHeightInInches
            => (this.HeightInFeet * FOOT_TO_INCHES) + this.HeightInInches;

        /// <summary>
        /// height of the user in feet
        /// </summary> 
        public double HeightInFeet { get; set; } = default;

        /// <summary>
        /// height of the user in inches
        /// </summary>
        public double HeightInInches { get; set; } = default;

        /// <summary>
        /// height of the user in metres
        /// </summary>
        public double HeightInMetres { get; set; } = default;

        /// <summary>
        /// body mass index of the user
        /// </summary>
        public double BodyMassIndex { get; set; } = default;

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

            while (this.WeightInStones == default)
            {
                try
                {
                    Console.Write($"{INPUT_WEIGHT_MSG}stones > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight <= 0)
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

            while (this.WeightInPounds == default)
            {
                try
                {
                    Console.Write($"{INPUT_WEIGHT_MSG}pounds > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight <= 0)
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
            
            while (this.HeightInFeet == default)
            {
                try
                {
                    Console.Write($"{INPUT_HEIGHT_MSG}feet > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight <= 0)
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
            
            while (this.HeightInInches == default)
            {
                try
                {
                    Console.Write($"{INPUT_HEIGHT_MSG}inches > ");

                    userWeight = Reader.ReadDouble;

                    if (userWeight <= 0)
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
            while (this.WeightInKg == default)
            {
                try
                {
                    Console.Write(INPUT_WEIGHT_MSG);

                    var userWeight = Reader.ReadDouble;

                    if (userWeight <= 0)
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
            while (this.HeightInMetres == default)
            {
                try
                {
                    Console.Write(INPUT_HEIGHT_MSG);
                    var userHeight = Reader.ReadDouble;

                    if (userHeight <= 0)
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
