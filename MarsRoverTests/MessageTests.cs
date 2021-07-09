using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            // I need to check when message object is instantiated and no name parameter is passed, the proper exception message is thrown
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Name of message required.", ex.Message);
            }
        }

        [TestMethod]
        public void ConstrutorSetsName()
        {
            // Check to see if constructor is properly setting the name property
            Message test = new Message("Ground control to Major Tom", commands);
            Assert.AreEqual("Ground control to Major Tom", test.Name);
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            // check to see if constructor sets commands property
            Message test = new Message("Ground control to Major Tom", commands);
            Assert.AreEqual(commands, test.Commands);
        }
    }
}
