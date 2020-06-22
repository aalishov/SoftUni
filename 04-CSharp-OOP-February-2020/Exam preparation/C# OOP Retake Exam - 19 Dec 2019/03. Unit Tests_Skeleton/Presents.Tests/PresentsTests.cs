namespace Presents.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private string name = "toy";
        private double magic = 10;

        [SetUp]
        public void SetUp()
        {
            this.present = new Present(name, magic);
        }

        //Arrange

        //Act
        //Assert

        [Test]
        public void NameGetter()
        {
            //Assert
            Assert.AreEqual(name, present.Name);
        }

        [Test]
        public void NameSetter()
        {
            //Arrange
            string newName = "toy2";
            //Act
            this.present.Name = newName;
            //Assert
            Assert.AreEqual(newName, present.Name);
        }

        [Test]
        public void MagicGetter()
        {
            //Assert
            Assert.AreEqual(magic, present.Magic);
        }

        [Test]
        public void MagicSetter()
        {
            //Arrange
            double newMagic = 12;
            //Act
            this.present.Magic = newMagic;
            //Assert
            Assert.AreEqual(newMagic, present.Magic);
        }
    }
}
