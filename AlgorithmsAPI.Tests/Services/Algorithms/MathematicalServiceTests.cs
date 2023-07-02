using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Services.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Services.Algorithms
{
    public class MathematicalServiceTests
    {
        private IMathematicalService _mathematicalService;

        [SetUp]
        public void Setup()
        {
            this._mathematicalService = new MathematicalService();
        }

        [Test]
        public async Task Factorial_Zero_ReturnsOne()
        {
            // Arrange
            int number = 0;
            int expectedResult = 1;

            // Act
            int actualResult = await _mathematicalService.Factorial(number);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Factorial_PositiveNumber_ReturnsCorrectResult()
        {
            // Arrange
            int number = 5;
            int expectedResult = 120;

            // Act
            int actualResult = await _mathematicalService.Factorial(number);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Factorial_NegativeNumber_ReturnsThrowException()
        {
            // Arrange
            int number = -5;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _mathematicalService.Factorial(number));
        }

        [Test]
        public async Task Fibonacci_Zero_ReturnsZero()
        {
            // Arrange
            int number = 0;
            int expectedResult = 0;

            // Act
            int actualResult = await _mathematicalService.Fibonacci(number);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Fibonacci_PositiveNumber_ReturnsCorrectResult()
        {
            // Arrange
            int number = 7;
            int expectedResult = 13;

            // Act
            int actualResult = await _mathematicalService.Fibonacci(number);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Fibonacci_NegativeNumber_ReturnsThrowException()
        {
            // Arrange
            int number = -7;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _mathematicalService.Fibonacci(number));
        }

        [Test]
        public async Task IterativeGCD_PositiveNumbers_ReturnsCorrectResult()
        {
            // Arrange
            int firstNumber = 18;
            int secondNumber = 24;
            int expectedResult = 6;

            // Act
            int actualResult = await _mathematicalService.IterativeGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task IterativeGCD_NegativeNumbers_ReturnsCorrectResult()
        {
            // Arrange
            int firstNumber = -36;
            int secondNumber = -48;
            int expectedResult = 12;

            // Act
            int actualResult = await _mathematicalService.IterativeGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task IterativeGCD_BothNumbersZero_ReturnsZero()
        {
            // Arrange
            int firstNumber = 0;
            int secondNumber = 0;
            int expectedResult = 0;

            // Act
            int actualResult = await _mathematicalService.IterativeGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task IterativeGCD_OneNumberZero_ReturnsOtherNumberAsGCD()
        {
            // Arrange
            int firstNumber = 0;
            int secondNumber = 13;
            int expectedResult = 13;

            // Act
            int actualResult = await _mathematicalService.IterativeGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task RecursiveGCD_BothNumbersZero_ReturnsZero()
        {
            // Arrange
            int firstNumber = 0;
            int secondNumber = 0;
            int expectedResult = 0;

            // Act
            int actualResult = await _mathematicalService.RecursiveGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task RecursiveGCD_PositiveNumbers_ReturnsCorrectResult()
        {
            // Arrange
            int firstNumber = 18;
            int secondNumber = 24;
            int expectedResult = 6;

            // Act
            int actualResult = await _mathematicalService.RecursiveGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task RecursiveGCD_NegativeNumbers_ReturnsCorrectResult()
        {
            // Arrange
            int firstNumber = -36;
            int secondNumber = -48;
            int expectedResult = 12;

            // Act
            int actualResult = await _mathematicalService.RecursiveGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task RecursiveGCD_OneNumberZero_ReturnsOtherNumberAsGCD()
        {
            // Arrange
            int firstNumber = 0;
            int secondNumber = 13;
            int expectedResult = 13;

            // Act
            int actualResult = await _mathematicalService.RecursiveGCD(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task IsPrime_Zero_ReturnsFalse()
        {
            // Arrange
            int number = 0;

            // Act
            bool actualResult = await _mathematicalService.IsPrime(number);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public async Task IsPrime_PrimeNumber_ReturnsTrue()
        {
            // Arrange
            int number = 13;

            // Act
            bool actualResult = await _mathematicalService.IsPrime(number);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public async Task IsPrime_NonPrimeNumber_ReturnsFalse()
        {
            // Arrange
            int number = 8;

            // Act
            bool actualResult = await _mathematicalService.IsPrime(number);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public async Task IsPrime_NegativeNumber_ReturnsFalse()
        {
            // Arrange
            int number = -13;

            // Act
            bool actualResult = await _mathematicalService.IsPrime(number);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public async Task SieveOfEratosthenes_Zero_ReturnsEmptyArray()
        {
            // Arrange
            int threshold = 0;
            int[] expectedResult = { };

            // Act
            int[] actualResult = await _mathematicalService.SieveOfEratosthenes(threshold);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SieveOfEratosthenes_PositiveNumber_ReturnsCorrectResult()
        {
            // Arrange
            int threshold = 8;
            int[] expectedResult = new int[] { 2, 3, 5, 7};

            // Act
            int[] actualResult = await _mathematicalService.SieveOfEratosthenes(threshold);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SieveOfEratosthenes_NegativeNumber_ReturnsThrowException()
        {
            // Arrange
            int threshold = -8;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _mathematicalService.SieveOfEratosthenes(threshold));
        }
    }
}
