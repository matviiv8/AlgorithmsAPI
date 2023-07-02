using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Controllers;
using AlgorithmsAPI.Models;
using AlgorithmsAPI.Services.Algorithms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Controllers
{
    public class MathematicalControllerTests
    {
        private MathematicalController _mathematicalController;
        private Mock<IMathematicalService> _mathematicalServiceMock;
        private Mock<ILogger<MathematicalController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            this._mathematicalServiceMock = new Mock<IMathematicalService>();
            this._loggerMock = new Mock<ILogger<MathematicalController>>();

            this._mathematicalController = new MathematicalController(_mathematicalServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task Factorial_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string number = "";

            // Act
            var actualResult = await _mathematicalController.Factorial(number);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Factorial_CorrectNumber_ReturnsOkWithResult()
        {
            // Arrange
            string number = "5";
            int factorialResult = 120;
            var expectedResult = new MathematicalResult
            {
                NameOfAlgorithm = "Factorial",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InputData = number,
                OutputData = factorialResult.ToString()
            };

            _mathematicalServiceMock.Setup(service => service.Factorial(It.IsAny<int>()))
                .ReturnsAsync(factorialResult);

            // Act
            var actualResult = await _mathematicalController.Factorial(number);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((MathematicalResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InputData, ((MathematicalResult)okResult.Value).InputData);
            Assert.AreEqual(expectedResult.OutputData, ((MathematicalResult)okResult.Value).OutputData);
        }

        [Test]
        public async Task Factorial_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string number = "5";
            var exception = new Exception("Some error message");

            _mathematicalServiceMock.Setup(service => service.Factorial(It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _mathematicalController.Factorial(number);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task Fibonacci_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string number = "";

            // Act
            var actualResult = await _mathematicalController.Fibonacci(number);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Fibonacci_CorrectNumber_ReturnsOkWithResult()
        {
            // Arrange
            string number = "8";
            int fibonacciResult = 21;
            var expectedResult = new MathematicalResult
            {
                NameOfAlgorithm = "Fibonacci",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InputData = number,
                OutputData = fibonacciResult.ToString()
            };

            _mathematicalServiceMock.Setup(service => service.Fibonacci(It.IsAny<int>()))
                .ReturnsAsync(fibonacciResult);

            // Act
            var actualResult = await _mathematicalController.Fibonacci(number);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((MathematicalResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InputData, ((MathematicalResult)okResult.Value).InputData);
            Assert.AreEqual(expectedResult.OutputData, ((MathematicalResult)okResult.Value).OutputData);
        }

        [Test]
        public async Task Fibonacci_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string number = "8";
            var exception = new Exception("Some error message");

            _mathematicalServiceMock.Setup(service => service.Fibonacci(It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _mathematicalController.Fibonacci(number);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task IterativeGCD_TwoEmptyStrings_ReturnsBadRequest()
        {
            // Arrange
            string firstNumber = "";
            string secondNumber = "";

            // Act
            var actualResult = await _mathematicalController.IterativeGCD(firstNumber, secondNumber);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task IterativeGCD_OneEmptyString_ReturnsBadRequest()
        {
            // Arrange
            string firstNumber = "8";
            string secondNumber = "";

            // Act
            var actualResult = await _mathematicalController.IterativeGCD(firstNumber, secondNumber);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task IterativeGCD_CorrectNumber_ReturnsOkWithResult()
        {
            // Arrange
            string firstNumber = "8";
            string secondNumber = "13";
            int iterativeGCDResult = 1;
            var expectedResult = new MathematicalResult
            {
                NameOfAlgorithm = "IterativeGCD",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InputData = firstNumber + " " + secondNumber,
                OutputData = iterativeGCDResult.ToString()
            };

            _mathematicalServiceMock.Setup(service => service.IterativeGCD(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(iterativeGCDResult);

            // Act
            var actualResult = await _mathematicalController.IterativeGCD(firstNumber, secondNumber);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((MathematicalResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InputData, ((MathematicalResult)okResult.Value).InputData);
            Assert.AreEqual(expectedResult.OutputData, ((MathematicalResult)okResult.Value).OutputData);
        }

        [Test]
        public async Task IterativeGCD_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string firstNumber = "8";
            string secondNumber = "13";
            var exception = new Exception("Some error message");

            _mathematicalServiceMock.Setup(service => service.IterativeGCD(It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _mathematicalController.IterativeGCD(firstNumber, secondNumber);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task RecursiveGCD_TwoEmptyStrings_ReturnsBadRequest()
        {
            // Arrange
            string firstNumber = "";
            string secondNumber = "";

            // Act
            var actualResult = await _mathematicalController.RecursiveGCD(firstNumber, secondNumber);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task RecursiveGCD_OneEmptyString_ReturnsBadRequest()
        {
            // Arrange
            string firstNumber = "8";
            string secondNumber = "";

            // Act
            var actualResult = await _mathematicalController.RecursiveGCD(firstNumber, secondNumber);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task RecursiveGCD_CorrectNumber_ReturnsOkWithResult()
        {
            // Arrange
            string firstNumber = "8";
            string secondNumber = "13";
            int recursiveGCDResult = 1;
            var expectedResult = new MathematicalResult
            {
                NameOfAlgorithm = "RecursiveGCD",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InputData = firstNumber + " " + secondNumber,
                OutputData = recursiveGCDResult.ToString()
            };

            _mathematicalServiceMock.Setup(service => service.RecursiveGCD(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(recursiveGCDResult);

            // Act
            var actualResult = await _mathematicalController.RecursiveGCD(firstNumber, secondNumber);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((MathematicalResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InputData, ((MathematicalResult)okResult.Value).InputData);
            Assert.AreEqual(expectedResult.OutputData, ((MathematicalResult)okResult.Value).OutputData);
        }

        [Test]
        public async Task RecursiveGCD_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string firstNumber = "8";
            string secondNumber = "13";
            var exception = new Exception("Some error message");

            _mathematicalServiceMock.Setup(service => service.RecursiveGCD(It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _mathematicalController.RecursiveGCD(firstNumber, secondNumber);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task IsPrime_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string number = "";

            // Act
            var actualResult = await _mathematicalController.IsPrime(number);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task IsPrime_CorrectNumber_ReturnsOkWithResult()
        {
            // Arrange
            string number = "13";
            bool isPrimeResult = true;
            var expectedResult = new MathematicalResult
            {
                NameOfAlgorithm = "IsPrime",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InputData = number,
                OutputData = isPrimeResult.ToString()
            };

            _mathematicalServiceMock.Setup(service => service.IsPrime(It.IsAny<int>()))
                .ReturnsAsync(isPrimeResult);

            // Act
            var actualResult = await _mathematicalController.IsPrime(number);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((MathematicalResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InputData, ((MathematicalResult)okResult.Value).InputData);
            Assert.AreEqual(expectedResult.OutputData, ((MathematicalResult)okResult.Value).OutputData);
        }

        [Test]
        public async Task IsPrime_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string number = "13";
            var exception = new Exception("Some error message");

            _mathematicalServiceMock.Setup(service => service.IsPrime(It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _mathematicalController.IsPrime(number);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task SieveOfEratosthenes_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string number = "";

            // Act
            var actualResult = await _mathematicalController.SieveOfEratosthenes(number);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task SieveOfEratosthenes_CorrectNumber_ReturnsOkWithResult()
        {
            // Arrange
            string number = "13";
            int[] sieveOfEratosthenesResult = new int[] { 2, 3, 5, 7, 11, 13 };
            var expectedResult = new MathematicalResult
            {
                NameOfAlgorithm = "SieveOfEratosthenes",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InputData = number,
                OutputData = string.Join(" ", sieveOfEratosthenesResult)
            };

            _mathematicalServiceMock.Setup(service => service.SieveOfEratosthenes(It.IsAny<int>()))
                .ReturnsAsync(sieveOfEratosthenesResult);

            // Act
            var actualResult = await _mathematicalController.SieveOfEratosthenes(number);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((MathematicalResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InputData, ((MathematicalResult)okResult.Value).InputData);
            Assert.AreEqual(expectedResult.OutputData, ((MathematicalResult)okResult.Value).OutputData);
        }

        [Test]
        public async Task SieveOfEratosthenes_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string number = "13";
            var exception = new Exception("Some error message");

            _mathematicalServiceMock.Setup(service => service.SieveOfEratosthenes(It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _mathematicalController.SieveOfEratosthenes(number);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }
    }
}
