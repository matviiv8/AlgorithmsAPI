using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Controllers;
using AlgorithmsAPI.Models;
using AlgorithmsAPI.Services.Algorithms;
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
    public class SortControllerTests
    {
        private SortController _sortController;
        private Mock<ISortService> _sortServiceMock;
        private IConversionService _conversionService;
        private Mock<ILogger<SortController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            this._sortServiceMock = new Mock<ISortService>();
            this._conversionService = new ConversionService();
            this._loggerMock = new Mock<ILogger<SortController>>();

            this._sortController = new SortController(_sortServiceMock.Object, _conversionService, _loggerMock.Object);
        }

        [Test]
        public async Task BubbleSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.BubbleSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task BubbleSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int [] bubbleSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "BubbleSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(bubbleSortResult)
            };

            _sortServiceMock.Setup(service => service.BubbleSort(It.IsAny<int[]>()))
                .ReturnsAsync(bubbleSortResult);

            // Act
            var actualResult = await _sortController.BubbleSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task BubbleSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.BubbleSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.BubbleSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task QuickSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.QuickSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task QuickSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] quickSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "QuickSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(quickSortResult)
            };

            _sortServiceMock.Setup(service => service.QuickSort(It.IsAny<int[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(quickSortResult);

            // Act
            var actualResult = await _sortController.QuickSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task QuickSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.QuickSort(It.IsAny<int[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.QuickSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task SelectionSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.SelectionSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task SelectionSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] selectionSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "SelectionSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(selectionSortResult)
            };

            _sortServiceMock.Setup(service => service.SelectionSort(It.IsAny<int[]>()))
                .ReturnsAsync(selectionSortResult);

            // Act
            var actualResult = await _sortController.SelectionSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task SelectionSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.SelectionSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.SelectionSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task InsertionSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.InsertionSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task InsertionSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] insertionSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "InsertionSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(insertionSortResult)
            };

            _sortServiceMock.Setup(service => service.InsertionSort(It.IsAny<int[]>()))
                .ReturnsAsync(insertionSortResult);

            // Act
            var actualResult = await _sortController.InsertionSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task InsertionSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.InsertionSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.InsertionSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task CycleSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.CycleSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task CycleSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] cycleSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "CycleSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(cycleSortResult)
            };

            _sortServiceMock.Setup(service => service.CycleSort(It.IsAny<int[]>()))
                .ReturnsAsync(cycleSortResult);

            // Act
            var actualResult = await _sortController.CycleSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task CycleSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.CycleSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.CycleSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task CountingSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.CountingSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task CountingSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] countingSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "CountingSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(countingSortResult)
            };

            _sortServiceMock.Setup(service => service.CountingSort(It.IsAny<int[]>()))
                .ReturnsAsync(countingSortResult);

            // Act
            var actualResult = await _sortController.CountingSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task CountingSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.CountingSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.CountingSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task CombSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.CombSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task CombSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] combSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "CombSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(combSortResult)
            };

            _sortServiceMock.Setup(service => service.CombSort(It.IsAny<int[]>()))
                .ReturnsAsync(combSortResult);

            // Act
            var actualResult = await _sortController.CombSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task CombSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.CombSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.CombSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task ShellSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.ShellSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task ShellSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] shellSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "ShellSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(shellSortResult)
            };

            _sortServiceMock.Setup(service => service.ShellSort(It.IsAny<int[]>()))
                .ReturnsAsync(shellSortResult);

            // Act
            var actualResult = await _sortController.ShellSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task ShellSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.ShellSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.ShellSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task HeapSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.HeapSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task HeapSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] heapSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "HeapSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(heapSortResult)
            };

            _sortServiceMock.Setup(service => service.HeapSort(It.IsAny<int[]>()))
                .ReturnsAsync(heapSortResult);

            // Act
            var actualResult = await _sortController.HeapSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task HeapSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.HeapSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.HeapSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task MergeSort_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string numbers = "";

            // Act
            var actualResult = await _sortController.MergeSort(numbers);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task MergeSort_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            int[] mergeSortResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };
            var expectedResult = new SortResult
            {
                NameOfAlgorithm = "MergeSort",
                ElapsedTime = It.IsAny<TimeSpan>(),
                InitialArray = numbers,
                SortedArray = _conversionService.GetStringFromArrayNumbers(mergeSortResult)
            };

            _sortServiceMock.Setup(service => service.MergeSort(It.IsAny<int[]>()))
                .ReturnsAsync(mergeSortResult);

            // Act
            var actualResult = await _sortController.MergeSort(numbers);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((SortResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.InitialArray, ((SortResult)okResult.Value).InitialArray);
            Assert.AreEqual(expectedResult.SortedArray, ((SortResult)okResult.Value).SortedArray);
        }

        [Test]
        public async Task MergeSort_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string numbers = "3 4 1 -5 2 -3 2 3";
            var exception = new Exception("Some error message");

            _sortServiceMock.Setup(service => service.MergeSort(It.IsAny<int[]>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _sortController.MergeSort(numbers);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }
    }
}
