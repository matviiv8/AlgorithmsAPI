using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Controllers;
using AlgorithmsAPI.Models;
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
    public class StringsControllerTests
    {
        private StringsController _stringsController;
        private Mock<IStringsService> _stringsServiceMock;
        private Mock<ILogger<StringsController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            this._stringsServiceMock = new Mock<IStringsService>();
            this._loggerMock = new Mock<ILogger<StringsController>>();

            this._stringsController = new StringsController(_stringsServiceMock.Object, _loggerMock.Object);
        }


        [Test]
        public async Task IsPalindrom_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";

            // Act
            var actualResult = await _stringsController.IsPalindrom(text);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task IsPalindrom_CorrectString_ReturnsOkWithResult()
        {
            // Arrange
            string text = "Wow";
            bool isPalindromResult = true;
            var expectedResult = new StringsResult
            {
                NameOfAlgorithm = "IsPalindrom",
                ElapsedTime = It.IsAny<TimeSpan>(),
                StringInput = text,
                StringResult = isPalindromResult.ToString()
            };

            _stringsServiceMock.Setup(service => service.IsStringPalindrom(It.IsAny<string>()))
                .ReturnsAsync(isPalindromResult);

            // Act
            var actualResult = await _stringsController.IsPalindrom(text);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((StringsResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.StringInput, ((StringsResult)okResult.Value).StringInput);
            Assert.AreEqual(expectedResult.StringResult, ((StringsResult)okResult.Value).StringResult);
        }

        [Test]
        public async Task IsPalindrom_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "Wow";
            var exception = new Exception("Some error message");

            _stringsServiceMock.Setup(service => service.IsStringPalindrom(It.IsAny<string>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _stringsController.IsPalindrom(text);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task Reverse_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";

            // Act
            var actualResult = await _stringsController.Reverse(text);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Reverse_CorrectString_ReturnsOkWithResult()
        {
            // Arrange
            string text = "abc";
            string reverseResult = "cba";
            var expectedResult = new StringsResult
            {
                NameOfAlgorithm = "Reverse",
                ElapsedTime = It.IsAny<TimeSpan>(),
                StringInput = text,
                StringResult = reverseResult.ToString()
            };

            _stringsServiceMock.Setup(service => service.ReverseString(It.IsAny<string>()))
                .ReturnsAsync(reverseResult);

            // Act
            var actualResult = await _stringsController.Reverse(text);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((StringsResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.StringInput, ((StringsResult)okResult.Value).StringInput);
            Assert.AreEqual(expectedResult.StringResult, ((StringsResult)okResult.Value).StringResult);
        }

        [Test]
        public async Task Reverse_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "abc";
            var exception = new Exception("Some error message");

            _stringsServiceMock.Setup(service => service.ReverseString(It.IsAny<string>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _stringsController.Reverse(text);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task UniquePermutation_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";

            // Act
            var actualResult = await _stringsController.UniquePermutation(text);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task UniquePermutation_CorrectString_ReturnsOkWithResult()
        {
            // Arrange
            string text = "abc";
            List<string> uniquePermutationResult = new List<string> { "abc", "acb", "bac", "bca", "cab", "cba" };
            var expectedResult = new StringsResult
            {
                NameOfAlgorithm = "UniquePermutation",
                ElapsedTime = It.IsAny<TimeSpan>(),
                StringInput = text,
                StringResult = string.Join(" ", uniquePermutationResult)
            };

            _stringsServiceMock.Setup(service => service.GetEveryUniquePermutation(It.IsAny<string>()))
                .ReturnsAsync(uniquePermutationResult);

            // Act
            var actualResult = await _stringsController.UniquePermutation(text);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((StringsResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.StringInput, ((StringsResult)okResult.Value).StringInput);
            Assert.AreEqual(expectedResult.StringResult, ((StringsResult)okResult.Value).StringResult);
        }

        [Test]
        public async Task UniquePermutation_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "abc";
            var exception = new Exception("Some error message");

            _stringsServiceMock.Setup(service => service.GetEveryUniquePermutation(It.IsAny<string>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _stringsController.UniquePermutation(text);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task FindSubstring_OneEmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            string substring = "apples";

            // Act
            var actualResult = await _stringsController.FindSubstring(text, substring);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task FindSubstring_TwoEmptyStrings_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            string substring = "";

            // Act
            var actualResult = await _stringsController.FindSubstring(text, substring);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task FindSubstring_CorrectStrings_ReturnsOkWithResult()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            string substring = "apples";
            List<int> findSubstringResult = new List<int> { 7, 40 };
            var expectedResult = new StringsResult
            {
                NameOfAlgorithm = "FindSubstring",
                ElapsedTime = It.IsAny<TimeSpan>(),
                StringInput = text,
                StringResult = string.Join(" ", findSubstringResult)
            };

            _stringsServiceMock.Setup(service => service.FindSubstring(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(findSubstringResult);

            // Act
            var actualResult = await _stringsController.FindSubstring(text, substring);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((StringsResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.StringInput, ((StringsResult)okResult.Value).StringInput);
            Assert.AreEqual(expectedResult.StringResult, ((StringsResult)okResult.Value).StringResult);
        }

        [Test]
        public async Task FindSubstring_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            string substring = "apples";
            var exception = new Exception("Some error message");

            _stringsServiceMock.Setup(service => service.FindSubstring(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _stringsController.FindSubstring(text, substring);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task ReplaceSubstring_OneEmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            string substring = "pears";
            string replacement = "bilberry";

            // Act
            var actualResult = await _stringsController.ReplaceSubstring(text, substring, replacement);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task ReplaceSubstring_TwoEmptyStrings_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            string substring = "";
            string replacement = "bilberry";

            // Act
            var actualResult = await _stringsController.ReplaceSubstring(text, substring, replacement);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task ReplaceSubstring_ThreeEmptyStrings_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            string substring = "";
            string replacement = "";

            // Act
            var actualResult = await _stringsController.ReplaceSubstring(text, substring, replacement);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task ReplaceSubstring_CorrectStrings_ReturnsOkWithResult()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            string substring = "pears";
            string replacement = "bilberry";
            string replaceSubstringResult = "I like apples and oranges, but I prefer apples.";
            var expectedResult = new StringsResult
            {
                NameOfAlgorithm = "ReplaceSubstring",
                ElapsedTime = It.IsAny<TimeSpan>(),
                StringInput = text,
                StringResult = replaceSubstringResult.ToString()
            };

            _stringsServiceMock.Setup(service => service.ReplaceSubstring(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(replaceSubstringResult);

            // Act
            var actualResult = await _stringsController.ReplaceSubstring(text, substring, replacement);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((StringsResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.StringInput, ((StringsResult)okResult.Value).StringInput);
            Assert.AreEqual(expectedResult.StringResult, ((StringsResult)okResult.Value).StringResult);
        }

        [Test]
        public async Task ReplaceSubstring_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            string substring = "pears";
            string replacement = "bilberry";
            var exception = new Exception("Some error message");

            _stringsServiceMock.Setup(service => service.ReplaceSubstring(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _stringsController.ReplaceSubstring(text, substring, replacement);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }
    }
}
