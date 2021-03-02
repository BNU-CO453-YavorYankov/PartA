namespace ConsoleAppProject.App02
{
    using static ConsoleAppProject.Constants.BMICalculator;

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
        /// This method runs the app
        /// </summary>
        public void Run()
        {
            Helper.PrintHeading(PROGRAM_NAME, DESCRIPTION);


        }
    }
}
