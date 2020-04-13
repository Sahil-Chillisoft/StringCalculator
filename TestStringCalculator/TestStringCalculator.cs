using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class TestStringCalculator
    {
        readonly StringCalculator _stringCalculator = new StringCalculator();
        
        [Test]
        public void Add_WhenEmptyString_Return0()
        {
            //Arrange 
            const string input = "";
            const int expectedOutput = 0;
            int output;

            //Act 
            output = _stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expectedOutput,output);
        }

        [Test]
        public void Add_WhenInputHas1Number_ReturnInput()
        {
            //Arrange 
            const string input = "2";
            const int expectedOutput = 2;
            int output;

            //Act 
            output = _stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_WhenInputHas2Numbers_ReturnSum()
        {
            //Arrange
            const string input = "2,3";
            const int expectedOutput = 5;
            int output;

            //Act
            output = _stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_WhenInputHasMultipleNumbers_ReturnSum()
        {
            //Arrange
            const string input = "2,3,5";
            const int expectedOutput = 10;
            int output;
            
            //Act
            output = _stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_WhenInputHasNewLineDelimiter_ReturnSum()
        {
            //Arrange
            const string input = "1\n2,3";
            const int expectedOutput = 6;
            int output;

            //Act
            output = _stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

    }
}
