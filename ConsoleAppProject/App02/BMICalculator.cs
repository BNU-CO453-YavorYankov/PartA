namespace ConsoleAppProject.App02
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
        /// weight of the user
        /// </summary>
        public double Weight { get; set; } = default;

        /// <summary>
        /// height of the user
        /// </summary>
        public double Height { get; set; } = default;

        /// <summary>
        /// This method runs the app
        /// </summary>
        public void Run()
        {
            Helper.PrintHeading(PROGRAM_NAME, DESCRIPTION);

            SelectUnit();

            InputWeight();
            InputHeight();
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
        /// This method reads the user input and store it in the weight prop.
        /// </summary>
        private void InputWeight() 
        {
            while (this.Weight == default)
            {
                try
                {
                    Console.Write(InputWeightMsg(this.UnitType.ToString()));
                    var userWeight = Reader.ReadDouble;

                    if (userWeight<=0)
                    {
                        Console.WriteLine(NEGATIVE_WEIGHT_MSG);
                    }
                    else
                    {
                        this.Weight = userWeight;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(INVALID_INPUT_MSG);
                }
            }
        }

        private void InputHeight()
        {
            throw new NotImplementedException();
        }
    }
}
