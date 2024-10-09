using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using FluentAssertions;
using KC.UnitTestInterview.Enums;

namespace KC.UnitTestInterview.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;
        private Mock<INumberStringHandler> _mockStringHandler;

        [SetUp]
        public void Setup()
        {
            _mockStringHandler = new Mock<INumberStringHandler>();
            _calculator = new Calculator(_mockStringHandler.Object);
        }

        [Test]
        public void ProcessNumbers_WithValidInput_AddsNumbers()
        {
            // Arrange
            var input = "1,2,3";
            var operation = NumberOperation.Add;
            _mockStringHandler.Setup(handler => handler.GetNumbersFromString(input)).Returns(new List<int> { 1, 2, 3 });

            // Act
            var result = _calculator.ProcessNumbers(input, operation);

            // Assert
            result.Should().Be(6);
        }

        [Test]
        public void ProcessNumbers_WithValidInput_SubtractsNumbers()
        {
            // Arrange
            var input = "5,2,1";
            var operation = NumberOperation.Subtract;
            _mockStringHandler.Setup(handler => handler.GetNumbersFromString(input)).Returns(new List<int> { 5, 2, 1 });

            // Act
            var result = _calculator.ProcessNumbers(input, operation);

            // Assert
            result.Should().Be(-8);
        }

        [Test]
        public void ProcessNumbers_WithNullOrEmptyString_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;
            var operation = NumberOperation.Add;

            // Act
            Action act = () => _calculator.ProcessNumbers(input, operation);

            // Assert
            act.Should().Throw<ArgumentNullException>()
               .And.ParamName.Should().Be("numbersToProcess");
        }

        [Test]
        public void GetPercentageDifferenceBetweenNumbers_WithValidInput_CalculatesDifference()
        {
            // Arrange
            int numberOne = 10;
            int numberTwo = 20;

            // Act
            var result = _calculator.GetPercentageDifferenceBetweenNumbers(numberOne, numberTwo);

            // Assert
            result.Should().Be(67);
        }

        [Test]
        public void CalculateTotalMinutesForTime_WithValidInput_ReturnsTotalMinutes()
        {
            // Arrange
            string timeString = "1:30"; // 1 hour and 30 minutes
            _mockStringHandler.Setup(handler => handler.GetHoursAndMinutesFromTimeString(timeString)).Returns((1, 30));

            // Act
            var result = _calculator.CalculateTotalMinutesForTime(timeString);

            // Assert
            result.Should().Be(90); // 1 hour * 60 + 30 minutes = 90 minutes
        }

        [Test]
        public void CalculateTotalMinutesForTime_WithNullOrEmptyString_ReturnsZero()
        {
            // Arrange
            string timeString = "";

            // Act
            var result = _calculator.CalculateTotalMinutesForTime(timeString);

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void GetLargestEvenNumber_WithValidInput_ReturnsLargestEvenNumber()
        {
            // Arrange
            var input = "1,2,3,4,5,6";
            _mockStringHandler.Setup(handler => handler.GetNumbersFromString(input)).Returns(new List<int> { 1, 2, 3, 4, 5, 6 });

            // Act
            var result = _calculator.GetLargestEvenNumber(input);

            // Assert
            result.Should().Be(6);
        }

        [Test]
        public void GetLargestEvenNumber_WithNoEvenNumbers_ReturnsZero()
        {
            // Arrange
            var input = "1,3,5,7";
            _mockStringHandler.Setup(handler => handler.GetNumbersFromString(input)).Returns(new List<int> { 1, 3, 5, 7 });

            // Act
            var result = _calculator.GetLargestEvenNumber(input);

            // Assert
            result.Should().Be(0);
        }
    }
}
