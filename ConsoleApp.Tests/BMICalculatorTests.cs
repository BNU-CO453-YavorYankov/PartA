namespace ConsoleApp.Tests
{
    using NUnit.Framework;
    using ConsoleAppProject.App02;

    using static ConsoleAppProject.Common.Constants.BMICalculator;
    using System;

    public class BMICalculatorTests
    {
        private BMICalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new BMICalculator();
        }
        
        [Test]
        public void BMIInImperialUnits() 
        {
            //Arrange
            calculator.UnitType = UnitTypes.Imperial;

            calculator.WeightInStones = 5;
            calculator.WeightInPounds = 6;

            calculator.HeightInFeet = 7;
            calculator.HeightInInches = 8;

            //Act
            calculator.CalculateBMI();

            //Assert
            Assert.That(calculator.BodyMassIndex, Is.EqualTo(6.31));
        }

        [Test]
        public void BMIInMetricUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Metric;

            calculator.WeightInKg = 50;
            calculator.HeightInMetres = 1.5;

            //Act
            calculator.CalculateBMI();

            //Assert
            Assert.That(calculator.BodyMassIndex, Is.EqualTo(22.22));
        }

        [Test]
        public void UnderweightWeightStatusInImperialUnits() 
        {
            //Arrange
            calculator.UnitType = UnitTypes.Imperial;

            calculator.WeightInStones = 5;
            calculator.WeightInPounds = 0;
            calculator.HeightInFeet = 5;
            calculator.HeightInInches = 0;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(UNDERWEIGHT));
        }

        [Test]
        public void NormalWeightStatusInImperialUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Imperial;

            calculator.WeightInStones = 10;
            calculator.WeightInPounds = 0;
            calculator.HeightInFeet = 6;
            calculator.HeightInInches = 0;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(NORMAL));
        }

        [Test]
        public void OverweightWeightStatusInImperialUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Imperial;

            calculator.WeightInStones = 14;
            calculator.WeightInPounds = 0;
            calculator.HeightInFeet = 6;
            calculator.HeightInInches = 0;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OVERWEIGHT));
        }

        [Test]
        public void ObeseClassIWeightStatusInImperialUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Imperial;

            calculator.WeightInStones = 18;
            calculator.WeightInPounds = 0;
            calculator.HeightInFeet = 6;
            calculator.HeightInInches = 0;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OBESE_CLASS_I));
        }

        [Test]
        public void ObeseClassIIWeightStatusInImperialUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Imperial;

            calculator.WeightInStones = 20;
            calculator.WeightInPounds = 0;
            calculator.HeightInFeet = 6;
            calculator.HeightInInches = 0;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OBESE_CLASS_II));
        }

        [Test]
        public void ObeseClassIIIWeightStatusInImperialUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Imperial;

            calculator.WeightInStones = 22;
            calculator.WeightInPounds = 0;
            calculator.HeightInFeet = 6;
            calculator.HeightInInches = 0;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OBESE_CLASS_III));
        }

        [Test]
        public void UnderweightWeightStatusInMetricUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Metric;

            calculator.WeightInKg = 50;
            calculator.HeightInMetres = 1.9;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(UNDERWEIGHT));
        }

        [Test]
        public void NormalWeightStatusInMetricUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Metric;

            calculator.WeightInKg = 80;
            calculator.HeightInMetres = 1.9;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(NORMAL));
        }

        [Test]
        public void OverweightWeightStatusInMetricUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Metric;

            calculator.WeightInKg = 70;
            calculator.HeightInMetres = 1.6;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OVERWEIGHT));
        }

        [Test]
        public void ObeseClassIWeightStatusInMetricUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Metric;

            calculator.WeightInKg = 90;
            calculator.HeightInMetres = 1.7;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OBESE_CLASS_I));
        }

        [Test]
        public void ObeseClassIIWeightStatusInMetricUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Metric;

            calculator.WeightInKg = 90;
            calculator.HeightInMetres = 1.56;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OBESE_CLASS_II));
        }

        [Test]
        public void ObeseClassIIIWeightStatusInMetricUnits()
        {
            //Arrange
            calculator.UnitType = UnitTypes.Metric;

            calculator.WeightInKg = 150;
            calculator.HeightInMetres = 1.9;

            //Act
            calculator.CalculateBMI();
            calculator.SetWeightStatus();

            //Assert
            Assert.That(calculator.WeightStatus, Is.EqualTo(OBESE_CLASS_III));
        }

        [Test]
        public void DefaultValueUnitTypeShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                calculator.CalculateBMI();
            }, UNIT_TYPE_DEFAULT_VALUE_ERROR);
        }

        [Test]
        public void NegativeWeightInStonesShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ///Arrange
                calculator.UnitType = UnitTypes.Imperial;

                calculator.WeightInStones = -2;
                calculator.WeightInPounds = 0;
                calculator.HeightInFeet = 6;
                calculator.HeightInInches = 0;

                //Act
                calculator.CalculateBMI();
            }, NEGATIVE_WEIGHT_MSG);
        }

        [Test]
        public void NegativeWeightInPoundsShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ///Arrange
                calculator.UnitType = UnitTypes.Imperial;

                calculator.WeightInStones = 10;
                calculator.WeightInPounds = -1;
                calculator.HeightInFeet = 6;
                calculator.HeightInInches = 0;

                //Act
                calculator.CalculateBMI();
            }, NEGATIVE_WEIGHT_MSG);
        }

        [Test]
        public void NegativeWeightInKgShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ///Arrange
                calculator.UnitType = UnitTypes.Metric;

                calculator.WeightInKg = -10;
                calculator.HeightInMetres = 0;
                
                //Act
                calculator.CalculateBMI();
            }, NEGATIVE_WEIGHT_MSG);
        }

        [Test]
        public void NegativeHeightInFeetShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ///Arrange
                calculator.UnitType = UnitTypes.Imperial;

                calculator.WeightInStones = 10;
                calculator.WeightInPounds = 15;
                calculator.HeightInFeet = -6;
                calculator.HeightInInches = 0;

                //Act
                calculator.CalculateBMI();
            }, NEGATIVE_HEIGHT_MSG);
        }

        [Test]
        public void NegativeHeightInInchesShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ///Arrange
                calculator.UnitType = UnitTypes.Imperial;

                calculator.WeightInStones = 10;
                calculator.WeightInPounds = 15;
                calculator.HeightInFeet = 7;
                calculator.HeightInInches = -2;

                //Act
                calculator.CalculateBMI();
            }, NEGATIVE_HEIGHT_MSG);
        }

        [Test]
        public void NegativeHeightInMetresShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ///Arrange
                calculator.UnitType = UnitTypes.Metric;

                calculator.WeightInKg = 10;
                calculator.HeightInMetres = -5;

                //Act
                calculator.CalculateBMI();
            }, NEGATIVE_HEIGHT_MSG);
        }
    }
}
