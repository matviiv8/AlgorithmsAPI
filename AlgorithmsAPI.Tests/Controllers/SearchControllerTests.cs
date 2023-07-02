using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Controllers;
using AlgorithmsAPI.Models;
using AlgorithmsAPI.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Controllers
{
    public class SearchControllerTests
    {
        private SearchController _searchController;
        private Mock<ISearchService> _searchServiceMock;
        private IConversionService _conversionService;
        private Mock<ILogger<SearchController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            this._searchServiceMock = new Mock<ISearchService>();
            this._conversionService = new ConversionService();
            this._loggerMock = new Mock<ILogger<SearchController>>();

            this._searchController = new SearchController(_searchServiceMock.Object, _conversionService, _loggerMock.Object);
        }

        [Test]
        public async Task BinarySearch_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";
            int item = 13;

            // Act
            var actualResult = await _searchController.BinarySearch(numbers, item);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task BinarySearch_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            int binarySearchResult = 0;
            var expectedResult = new SearchResult
            {
                NameOfAlgorithm = "BinarySearch",
                ElapsedTime = It.IsAny<TimeSpan>(),
                SearchArray = numbers,
                SearchedVariable = item,
                LastMatchingResult = binarySearchResult == null ? "Item is missing" : binarySearchResult.ToString()
            };

            _searchServiceMock.Setup(service => service.BinarySearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ReturnsAsync(binarySearchResult);

            // Act
            var actualResult = await _searchController.BinarySearch(numbers, item);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SearchResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.SearchArray, ((SearchResult)okResult.Value).SearchArray);
            Assert.AreEqual(expectedResult.SearchedVariable, ((SearchResult)okResult.Value).SearchedVariable);
            Assert.AreEqual(expectedResult.LastMatchingResult, ((SearchResult)okResult.Value).LastMatchingResult);
        }

        [Test]
        public async Task BinarySearch_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            var exception = new Exception("Some error message");

            _searchServiceMock.Setup(service => service.BinarySearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _searchController.BinarySearch(numbers, item);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task LinearSearch_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";
            int item = 13;

            // Act
            var actualResult = await _searchController.LinearSearch(numbers, item);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task LinearSearch_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            int linearSearchResult = 0;
            var expectedResult = new SearchResult
            {
                NameOfAlgorithm = "LinearSearch",
                ElapsedTime = It.IsAny<TimeSpan>(),
                SearchArray = numbers,
                SearchedVariable = item,
                LastMatchingResult = linearSearchResult == null ? "Item is missing" : linearSearchResult.ToString()
            };

            _searchServiceMock.Setup(service => service.LinearSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ReturnsAsync(linearSearchResult);

            // Act
            var actualResult = await _searchController.LinearSearch(numbers, item);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SearchResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.SearchArray, ((SearchResult)okResult.Value).SearchArray);
            Assert.AreEqual(expectedResult.SearchedVariable, ((SearchResult)okResult.Value).SearchedVariable);
            Assert.AreEqual(expectedResult.LastMatchingResult, ((SearchResult)okResult.Value).LastMatchingResult);
        }

        [Test]
        public async Task LinearSearch_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            var exception = new Exception("Some error message");

            _searchServiceMock.Setup(service => service.LinearSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _searchController.LinearSearch(numbers, item);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task InterpolationSearch_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";
            int item = 13;

            // Act
            var actualResult = await _searchController.InterpolationSearch(numbers, item);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task InterpolationSearch_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            int interpolationSearchResult = 0;
            var expectedResult = new SearchResult
            {
                NameOfAlgorithm = "InterpolationSearch",
                ElapsedTime = It.IsAny<TimeSpan>(),
                SearchArray = numbers,
                SearchedVariable = item,
                LastMatchingResult = interpolationSearchResult == null ? "Item is missing" : interpolationSearchResult.ToString()
            };

            _searchServiceMock.Setup(service => service.InterpolationSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ReturnsAsync(interpolationSearchResult);

            // Act
            var actualResult = await _searchController.InterpolationSearch(numbers, item);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SearchResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.SearchArray, ((SearchResult)okResult.Value).SearchArray);
            Assert.AreEqual(expectedResult.SearchedVariable, ((SearchResult)okResult.Value).SearchedVariable);
            Assert.AreEqual(expectedResult.LastMatchingResult, ((SearchResult)okResult.Value).LastMatchingResult);
        }

        [Test]
        public async Task InterpolationSearch_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            var exception = new Exception("Some error message");

            _searchServiceMock.Setup(service => service.InterpolationSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _searchController.InterpolationSearch(numbers, item);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task TernarySearch_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";
            int item = 13;

            // Act
            var actualResult = await _searchController.TernarySearch(numbers, item);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task TernarySearch_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            int ternarySearchResult = 0;
            var expectedResult = new SearchResult
            {
                NameOfAlgorithm = "TernarySearch",
                ElapsedTime = It.IsAny<TimeSpan>(),
                SearchArray = numbers,
                SearchedVariable = item,
                LastMatchingResult = ternarySearchResult == null ? "Item is missing" : ternarySearchResult.ToString()
            };

            _searchServiceMock.Setup(service => service.TernarySearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ReturnsAsync(ternarySearchResult);

            // Act
            var actualResult = await _searchController.TernarySearch(numbers, item);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SearchResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.SearchArray, ((SearchResult)okResult.Value).SearchArray);
            Assert.AreEqual(expectedResult.SearchedVariable, ((SearchResult)okResult.Value).SearchedVariable);
            Assert.AreEqual(expectedResult.LastMatchingResult, ((SearchResult)okResult.Value).LastMatchingResult);
        }

        [Test]
        public async Task TernarySearch_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            var exception = new Exception("Some error message");

            _searchServiceMock.Setup(service => service.TernarySearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _searchController.TernarySearch(numbers, item);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task FibonacciSearch_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";
            int item = 13;

            // Act
            var actualResult = await _searchController.FibonacciSearch(numbers, item);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task FibonacciSearch_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            int fibonacciSearchResult = 0;
            var expectedResult = new SearchResult
            {
                NameOfAlgorithm = "FibonacciSearch",
                ElapsedTime = It.IsAny<TimeSpan>(),
                SearchArray = numbers,
                SearchedVariable = item,
                LastMatchingResult = fibonacciSearchResult == null ? "Item is missing" : fibonacciSearchResult.ToString()
            };

            _searchServiceMock.Setup(service => service.FibonacciSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ReturnsAsync(fibonacciSearchResult);

            // Act
            var actualResult = await _searchController.FibonacciSearch(numbers, item);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SearchResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.SearchArray, ((SearchResult)okResult.Value).SearchArray);
            Assert.AreEqual(expectedResult.SearchedVariable, ((SearchResult)okResult.Value).SearchedVariable);
            Assert.AreEqual(expectedResult.LastMatchingResult, ((SearchResult)okResult.Value).LastMatchingResult);
        }

        [Test]
        public async Task FibonacciSearch_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            var exception = new Exception("Some error message");

            _searchServiceMock.Setup(service => service.FibonacciSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _searchController.FibonacciSearch(numbers, item);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task SentinelSearch_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";
            int item = 13;

            // Act
            var actualResult = await _searchController.SentinelSearch(numbers, item);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task SentinelSearch_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            int sentinelSearchResult = 0;
            var expectedResult = new SearchResult
            {
                NameOfAlgorithm = "SentinelSearch",
                ElapsedTime = It.IsAny<TimeSpan>(),
                SearchArray = numbers,
                SearchedVariable = item,
                LastMatchingResult = sentinelSearchResult == null ? "Item is missing" : sentinelSearchResult.ToString()
            };

            _searchServiceMock.Setup(service => service.SentinelSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ReturnsAsync(sentinelSearchResult);

            // Act
            var actualResult = await _searchController.SentinelSearch(numbers, item);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SearchResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.SearchArray, ((SearchResult)okResult.Value).SearchArray);
            Assert.AreEqual(expectedResult.SearchedVariable, ((SearchResult)okResult.Value).SearchedVariable);
            Assert.AreEqual(expectedResult.LastMatchingResult, ((SearchResult)okResult.Value).LastMatchingResult);
        }

        [Test]
        public async Task SentinelSearch_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            var exception = new Exception("Some error message");

            _searchServiceMock.Setup(service => service.SentinelSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _searchController.SentinelSearch(numbers, item);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task JumpSearch_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";
            int item = 13;

            // Act
            var actualResult = await _searchController.JumpSearch(numbers, item);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task JumpSearch_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            int jumpSearchResult = 0;
            var expectedResult = new SearchResult
            {
                NameOfAlgorithm = "JumpSearch",
                ElapsedTime = It.IsAny<TimeSpan>(),
                SearchArray = numbers,
                SearchedVariable = item,
                LastMatchingResult = jumpSearchResult == null ? "Item is missing" : jumpSearchResult.ToString()
            };

            _searchServiceMock.Setup(service => service.JumpSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ReturnsAsync(jumpSearchResult);

            // Act
            var actualResult = await _searchController.JumpSearch(numbers, item);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SearchResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.SearchArray, ((SearchResult)okResult.Value).SearchArray);
            Assert.AreEqual(expectedResult.SearchedVariable, ((SearchResult)okResult.Value).SearchedVariable);
            Assert.AreEqual(expectedResult.LastMatchingResult, ((SearchResult)okResult.Value).LastMatchingResult);
        }

        [Test]
        public async Task JumpSearch_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "1 2 3 4 5 6 7 8 9";
            int item = 1;
            var exception = new Exception("Some error message");

            _searchServiceMock.Setup(service => service.JumpSearch(It.IsAny<int[]>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _searchController.JumpSearch(numbers, item);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }
    }
}
