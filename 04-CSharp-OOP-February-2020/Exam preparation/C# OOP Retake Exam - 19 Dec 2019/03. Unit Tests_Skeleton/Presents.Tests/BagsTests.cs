using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presents.Tests
{

    [TestFixture]
    public class BagsTests
    {
        private Bag bag;
        private Present present;
        private string pName = "toy";
        private double pMagic = 10;

        [SetUp]
        public void Setup()
        {
            this.bag = new Bag();
            this.present = new Present(pName, pMagic);
        }

        //Arange
        //Act
        //Assert

        [Test]
        public void CreateIfNull()
        {
            //Arange
            Present failPresent = null;
           
            //Assert
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    //Act
                    bag.Create(failPresent);
                }
                , "Present is null"
            );
        }
        [Test]
        public void CreateSuccessfully()
        {
            //Arange
            string expected = $"Successfully added present {present.Name}.";
            //Act
           string actual= bag.Create(present);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateIfExist()
        {
            //Arange
            bag.Create(present);
            
            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    bag.Create(present);
                }
                , "This present already exists!"
            );
        }

        [Test]
        public void RemoveExisted()
        {
            bag.Create(present);
            bool isTrue = bag.Remove(present);

            Assert.AreEqual(true, isTrue);
        }

        [Test]
        public void RemoveNotExisted()
        {
            bool isTrue = bag.Remove(present);

            Assert.AreEqual(false, isTrue);
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            bag.Create(present);
            bag.Create(new Present("poni2", 3));
            bag.Create(new Present("poni",8));

            double expected = 3;
            double actual = bag.GetPresentWithLeastMagic().Magic;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentWithName()
        {
            bag.Create(present);
            bag.Create(new Present("poni2", 3));
            bag.Create(new Present("poni3", 8));

            string expected = "poni3";
            string actual = bag.GetPresent("poni3").Name;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentsCollection()
        {
            Present present2 = new Present("poni2", 3);
            Present present3 = new Present("poni3", 8);
            List<Present> presents = new List<Present>();
            presents.Add(present);
            presents.Add(present2);
            presents.Add(present3);
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);
            CollectionAssert.AreEqual(presents.AsReadOnly(), bag.GetPresents());
        }

    }
}
