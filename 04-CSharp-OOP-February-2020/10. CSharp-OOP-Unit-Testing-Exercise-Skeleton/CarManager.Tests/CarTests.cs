using CarManager;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.IO;

namespace Tests
{
    public class CarTests
    {
        private Car testCar;
        private string make = "BMW";
        private string model = "E46";
        private double fuelConsumption = 10;
        private double fuelCapacity = 100;
        [SetUp]
        public void Setup()
        {
            this.testCar = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void TestConstructorWithoutParameters()
        {
            //Arrange
            //Act
            double expectedFuelAmount = 0;
            double actualFuelAmount = testCar.FuelAmount;
            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }


        [Test]
        public void TestMakeWithCorrectData()
        {
            //Arrange
            //Act
            string expectedMake = make;
            string actualMake = testCar.Make;

            //Assert
            Assert.AreEqual(expectedMake,actualMake);
        }

        [Test]
        public void TestMakeWithInCorrectNullData()
        {
            //Arrange    
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                testCar = new Car(null, model, fuelConsumption, fuelCapacity);
            });
        }
        [Test]
        public void TestMakeWithInCorrectStringEmptyData()
        {
            //Arrange
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                testCar = new Car(string.Empty, model, fuelConsumption, fuelCapacity);
            });
        }


        [Test]
        public void TestModelWithCorrectData()
        {
            //Arrange

            //Act
            string expectedModel = this.model;
            string actualModel = this.testCar.Model;
            //Assert
            Assert.AreEqual(expectedModel,actualModel);
        }

        [Test]
        public void TestModelWithInCorrectNullData()
        {
            //Arrange
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                testCar = new Car(make, null, fuelConsumption, fuelCapacity);
            });
        }
        [Test]
        public void TestModelWithInCorrectStringEmptyData()
        {
            //Arrange
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                testCar = new Car(make, string.Empty, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void TestFuelConsumtionWithCorrectData()
        {
            //Arrange

            //Act
            double expectedFuelConsumption = fuelConsumption;
            double actualFuelConsumption = this.testCar.FuelConsumption ;
            //Assert
            Assert.AreEqual(expectedFuelConsumption,actualFuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-200)]
        public void TestFuelConsumtionWithIncorrectData(double param)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(()=>
            {
                //Act
                testCar = new Car(make, model, param, fuelCapacity);
            });
        }

        [Test]
        public void TestFuelCapacityWithCorrectData()
        {
            //Arrange

            //Act
            double expectedFuelCapacity = this.fuelCapacity;
            double actualFuelCapacity = this.testCar.FuelCapacity;
            //Assert
            Assert.AreEqual(expectedFuelCapacity,actualFuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-200)]
        public void TestFuelCapacityWithIncorrectData(double param)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                testCar = new Car(make, model, fuelConsumption, param);
            });
        }

        [TestCase(15)]
        [TestCase(1)]
        public void TestRefuelWithCorrectData(double param)
        {
            //Arrange
            double refuelQuantity = param;

            //Act
            this.testCar.Refuel(refuelQuantity);
            double expectedFuel = refuelQuantity;
            double actualFuel = this.testCar.FuelAmount;
            //Assert
            Assert.AreEqual(expectedFuel,actualFuel);
        }

        [TestCase(150)]
        [TestCase(250)]
        public void TestRefuelWithToManyFuel(double param)
        {
            //Arrange
            double refuelQuantity = param;

            //Act
            this.testCar.Refuel(refuelQuantity);
            double expectedFuel = this.testCar.FuelCapacity;
            double actualFuel = this.testCar.FuelAmount;
            //Assert
            Assert.AreEqual(expectedFuel, actualFuel);
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void TestRefuelWithZeroOrNegativeFuel(double param)
        {
            //Arrange
            double refuelQuantity = param;

            //Act
            
            //Assert
            Assert.Throws<ArgumentException>(()=>
            {
                this.testCar.Refuel(refuelQuantity);
            });
        }


        [Test]
        public void TestDriveWithCorrectData()
        {
            //Arrange
            double refuelValue = 10;
            double driveDistance = 10;
            this.testCar.Refuel(refuelValue);
            //Act
            this.testCar.Drive(driveDistance);
            double expectedFuelAmount = 9;
            double actualFuelAmount = this.testCar.FuelAmount;
            //Assert
            Assert.AreEqual(expectedFuelAmount,actualFuelAmount);
        }

        [Test]
        public void TestDriveWithoutFuel()
        {
            //Arrange
            double driveDistance = 10;

            //Assert
            Assert.Throws<InvalidOperationException>(()=>
            {
                //Act
                this.testCar.Drive(driveDistance);
            });
        }

        [Test]
        public void NewTest()
        {
            //Arrange

            //Act

            //Assert
            Assert.Pass();
        }
    }
}