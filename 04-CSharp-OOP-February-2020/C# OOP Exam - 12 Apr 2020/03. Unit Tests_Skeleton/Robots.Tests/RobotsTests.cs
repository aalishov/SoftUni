namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {

        private RobotManager testManger;
        [Test]
        public void TestConstructorSetCapacity()
        {
            int expectedCapacity = 10;
            RobotManager manager = new RobotManager(expectedCapacity);

            Assert.AreEqual(expectedCapacity, manager.Capacity);
        }

        [Test]
        public void TestCapacityException()
        {
            int expectedCapacity = -10;

            Assert.Throws<ArgumentException>(
                () =>
                { testManger = new RobotManager(expectedCapacity); }, "Invalid capacity!"
             );
        }

        [Test]
        public void TestCount()
        {
            int expectedCout = 0;
            RobotManager manager = new RobotManager(10);
            int actualCount = manager.Count;
            Assert.AreEqual(expectedCout, actualCount);
        }

        [Test]
        public void TestCountWithRobots()
        {
            int expectedCout = 2;
            RobotManager manager = new RobotManager(10);
            manager.Add(new Robot("Test1",25));
            manager.Add(new Robot("Test2", 25));
            int actualCount = manager.Count;
            Assert.AreEqual(expectedCout, actualCount);
        }

        [Test]
        public void TestAddRobotWithSameRobotName()
        {
            
            RobotManager manager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    manager.Add(new Robot("Test1", 25));
                    manager.Add(new Robot("Test1", 25));
                }, $"There is already a robot with name Test1!"
                );
        }

        [Test]
        public void TestAddRobotWithNotEnaughCapacity()
        {

            RobotManager manager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    manager.Add(new Robot("Test1", 25));
                    manager.Add(new Robot("Test2", 25));
                }, $"Not enough capacity!"
                );
        }

        [Test]
        public void TestRemoveRobotWithUnexistingName()
        {

            RobotManager manager = new RobotManager(4);
            manager.Add(new Robot("Test1", 25));
            manager.Add(new Robot("Test2", 25));

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    manager.Remove("Test3");
                }, $"Robot with the name Test3 doesn't exist!"
                );
        }

        [Test]
        public void TestRemoveRobot()
        {
            RobotManager manager = new RobotManager(4);
            manager.Add(new Robot("Test1", 25));
            manager.Add(new Robot("Test2", 25));
            manager.Remove("Test2");

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void TestWorkWithUnixistingRobot()
        {
            RobotManager manager = new RobotManager(4);
            manager.Add(new Robot("Test1", 25));
            manager.Add(new Robot("Test2", 25));

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    manager.Work("Test3","work",1);
                }, $"Robot with the name Test3 doesn't exist!"
                );
        }

        [Test]
        public void TestWorkWithoutBattery()
        {
            RobotManager manager = new RobotManager(4);
            manager.Add(new Robot("Test1", 25));
            manager.Add(new Robot("Test2", 25));

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    manager.Work("Test2", "work", 50);
                }, $"Test2 doesn't have enough battery!"
                );
        }

        [Test]
        public void TestWorkCorrect()
        {
            RobotManager manager = new RobotManager(4);
            Robot r1 = new Robot("Test2", 25);
            manager.Add(new Robot("Test1", 25));
            manager.Add(r1);

            manager.Work("Test2", "work", 10);
            Assert.AreEqual(15,r1.Battery);
        }


        [Test]
        public void TestChargeWithUnixistingRobot()
        {
            RobotManager manager = new RobotManager(4);
            manager.Add(new Robot("Test1", 25));
            manager.Add(new Robot("Test2", 25));

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    manager.Charge("Test3");
                }, $"Robot with the name Test3 doesn't exist!"
                );
        }

        [Test]
        public void TestChargeCorrect()
        {
            RobotManager manager = new RobotManager(4);
            Robot r1 = new Robot("Test2", 25);
            manager.Add(new Robot("Test1", 25));
            manager.Add(r1);

            manager.Work("Test2", "work", 10);
            manager.Charge("Test2");
            Assert.AreEqual(25, r1.Battery);
        }


    }
}
