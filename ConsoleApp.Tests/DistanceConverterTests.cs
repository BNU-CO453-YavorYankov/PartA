namespace ConsoleApp.Tests
{
    using System;
    using NUnit.Framework;
    using ConsoleAppProject.App01;

    using static ConsoleAppProject.Common.Constants.DistanceConverter;

    public class DistanceConverterTests
    {
        private DistanceConverter converter;

        [SetUp]
        public void Setup()
        {
            converter = new DistanceConverter();
        }

        [Test]
        public void ConvertMilesToFeet()
        {
            //Arrange
            converter.FromUnit = DistanceUnits.Miles;
            converter.ToUnit = DistanceUnits.Feet;
            converter.FromDistance = 5;

            //Act
            converter.ConvertDistance();

            //Assert
            Assert.That(converter.ToDistance, Is.EqualTo(26400));
        }

        [Test]
        public void ConvertMilesToMetres()
        {
            //Arrange
            converter.FromUnit = DistanceUnits.Miles;
            converter.ToUnit = DistanceUnits.Metres;
            converter.FromDistance = 2;

            //Act
            converter.ConvertDistance();

            //Assert
            Assert.That(converter.ToDistance, Is.EqualTo(3218.69));
        }

        [Test]
        public void ConvertFeetToMiles()
        {
            //Arrange
            converter.FromUnit = DistanceUnits.Feet;
            converter.ToUnit = DistanceUnits.Miles;
            converter.FromDistance = 12345;

            //Act
            converter.ConvertDistance();

            //Assert
            Assert.That(converter.ToDistance, Is.EqualTo(2.34));
        }

        [Test]
        public void ConvertFeetToMetres()
        {
            //Arrange
            converter.FromUnit = DistanceUnits.Feet;
            converter.ToUnit = DistanceUnits.Metres;
            converter.FromDistance = 258;

            //Act
            converter.ConvertDistance();

            //Assert
            Assert.That(converter.ToDistance, Is.EqualTo(78.64));
        }

        [Test]
        public void ConvertMetresToMiles()
        {
            //Arrange
            converter.FromUnit = DistanceUnits.Metres;
            converter.ToUnit = DistanceUnits.Miles;
            converter.FromDistance = 1695.15;

            //Act
            converter.ConvertDistance();

            //Assert
            Assert.That(converter.ToDistance, Is.EqualTo(1.05));
        }

        [Test]
        public void ConvertMetresToFeet()
        {
            //Arrange
            converter.FromUnit = DistanceUnits.Metres;
            converter.ToUnit = DistanceUnits.Feet;
            converter.FromDistance = 1000;

            //Act
            converter.ConvertDistance();

            //Assert
            Assert.That(converter.ToDistance, Is.EqualTo(3280.84));
        }

        [Test]
        public void InvalidDistanceValueShouldThrowException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                converter.FromDistance = -24.54;
            }, NEGATIVE_DISTANCE_MSG);
        }
    }
}