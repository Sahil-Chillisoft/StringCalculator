using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestStringCalculator
{
    [TestFixture]
    public class TestStringCalculator
    {
        private StringCalculator.StringCalculator CreateStringCalculator()
        {
            return new StringCalculator.StringCalculator();
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
        public void Add_GivenInputHas1Number_ReturnNumber()
        {
            //Arrange 
            const string input = "2";
            const int expectedOutput = 2;

            //Act 
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHas2Numbers_ReturnSum()
        {
            //Arrange 
            const string input = "2,3";
            const int expectedOutput = 5;

            //Act 
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasMultipleNumbers_ReturnSum()
        {
            //Arrange 
            const string input = "2,3,5";
            const int expectedOutput = 10;

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
        public void Add_GivenInputHasDefaultDelimiter_ReturnSum()
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
        public void Validate_GivenInputHasSingleNegativeNumber_ReturnException()
        {
            //Arrange
            const string input = "-1";
            const string expectedOutput = "Negative numbers are not allowed: -1";

            //Act
            var output = Assert.Throws<Exception>(() => CreateStringCalculator().Add(input));

            //Assert
            Assert.AreEqual(expectedOutput, output.Message);
        }

        [Test]
        public void Validate_GivenInputHasMultipleNegativeNumbers_ReturnException()
        {
            //Arrange
            const string input = "-1, 2, -3, 4, -5";
            const string expectedOutput = "Negative numbers are not allowed: -1, -3, -5";

            //Act
            var output = Assert.Throws<Exception>(() => CreateStringCalculator().Add(input));

            //Assert
            Assert.AreEqual(expectedOutput, output.Message);
        }

        [Test]
        public void Add_GivenInputHasNumbersGreaterThan1000ThenIgnoreNumber_ReturnSum()
        {
            //Arrange 
            const string input = "2, 1001";
            const int expectedOutput = 2;

            //Act 
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void Add_GivenInputHasNumbersLessThan1000_ReturnSum()
        {
            //Arrange 
            const string input = "1, 999";
            const int expectedOutput = 1000;
            
            //Act
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput,output);
        }

        [Test]
        public void Add_GivenDelimitersWithDiffLengths_ReturnSum()
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
        public void Add_GivenInputHasMultipleDelimitersWithDiffLengths_ReturnSum()
        {
            //Arrange 
            const string input = "//[***][%]\n1***2%3";
            const int expectedOutput = 6;

            //Act 
            var output = CreateStringCalculator().Add(input);

            //Assert
            Assert.AreEqual(expectedOutput, output);
        }
    }
}