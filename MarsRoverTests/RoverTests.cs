using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover roger = new Rover(10);
            Assert.AreEqual(roger.Position, 10);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover roger = new Rover();
            Assert.AreEqual(roger.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover roger = new Rover();
            Assert.AreEqual(roger.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover roger = new Rover();
            Command[] modeTest = { new Command("MODE_CHANGE", "LOW_POWER") };
            Message testMessage = new Message("Change Mode!", modeTest);
            roger.ReceiveMessage(testMessage);
            Assert.AreEqual(roger.Mode, "LOW_POWER");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void DoesNotMoveInLowPower()
        {
            Rover roger = new Rover();
            Command[] modeTest = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 200) };
            Message testMessage = new Message("MOVE!", modeTest);
            roger.ReceiveMessage(testMessage);
            //Assert.ThrowsException<ArgumentOutOfRangeException>
            // Assert.AreEqual(roger.Position, 200);
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover roger = new Rover();
            Command[] test = { new Command ("MOVE", 250) };
            Message testMessage = new Message("Huh", test);
            roger.ReceiveMessage(testMessage);
            Assert.AreEqual(roger.Position, 250);
        }

    }
}
