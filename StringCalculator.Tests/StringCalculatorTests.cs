using System;
using NUnit;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }

        [Test]
        public void Add_GivenInputIsEmpty_Return0()
        {
            //Arrange 
            const string input = "";
            const int expectedOutput = 0;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasSingleNumber_ReturnNumber()
        {
            //Arrange 
            const string input = "1";
            const int expectedOutput = 1;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHas2Numbers_ReturnSum()
        {
            //Arrange 
            const string input = "1,2";
            const int expectedOutput = 3;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasMultiple_ReturnSum()
        {
            //Arrange 
            const string input = "1,2,3";
            const int expectedOutput = 6;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasNewLineDelimiter_ReturnSum()
        {
            //Arrange 
            const string input = "1\n2,3";
            const int expectedOutput = 6;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasCustomDelimiter_ReturnSum()
        {
            //Arrange 
            const string input = "//[;]\n1;2";
            const int expectedOutput = 3;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Validate_WhenInputHasSingleNegativeNumber_ReturnException()
        {
            //Arrange 
            const string input = "-1";
            const string expectedOutput = "Negatives not allowed: -1";

            //Act             
            var output = Assert.Throws<Exception>(() => CreateStringCalculator().Add(input));

            //Assert
            Assert.AreEqual(expectedOutput, output.Message);
        }

        [Test]
        public void Validate_WhenInputHasMultipleNegativeNumber_ReturnException()
        {
            //Arrange 
            const string input = "-1,2,-3,4,-5";
            const string expectedOutput = "Negatives not allowed: -1,-3,-5";

            //Act             
            var output = Assert.Throws<Exception>(() => CreateStringCalculator().Add(input));

            //Assert
            Assert.AreEqual(expectedOutput, output.Message);
        }

        [Test]
        public void Add_GivenInputHasNumberGreaterThen1000ThenIgnoreNumber_ReturnSum()
        {
            //Arrange 
            const string input = "2,1001";
            const int expectedOutput = 2;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasMultipleNumbersGreaterThen1000ThenIgnoreNumbers_ReturnSum()
        {
            //Arrange 
            const string input = "2,1001,3,1002";
            const int expectedOutput = 5;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasNumbersLessThan1000_ReturnSum()
        {
            //Arrange 
            const string input = "2,999";
            const int expectedOutput = 1001;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputCustomDelimiterWithDiffLength_ReturnSum()
        {
            //Arrange 
            const string input = "//[***]\n1***2***3";
            const int expectedOutput = 6;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasCustomDelimiters_ReturnSum()
        {
            //Arrange 
            const string input = "//[*][%]\n1*2%3";
            const int expectedOutput = 6;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }


        [Test]
        public void Add_GivenInputHasCustomDelimitersWithDiffLengths_ReturnSum()
        {
            //Arrange 
            const string input = "//[***][%%]\n1***2%%3";
            const int expectedOutput = 6;

            //Act             
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

    }
}
