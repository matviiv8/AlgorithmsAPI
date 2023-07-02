using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Services.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Services.Algorithms
{
    public class SearchServiceTests
    {
        private ISearchService _searchService;

        [SetUp]
        public void Setup()
        {
            _searchService = new SearchService();
        }

        [Test]
        public async Task BinarySearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.BinarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task BinarySearch_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 4;

            // Act
            int? actualResult = await _searchService.BinarySearch(array, element);

            // Assert
            Assert.IsNull(actualResult);
        }

        [Test]
        public async Task BinarySearch_ArrayWithDuplicateElements_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 5;
            int expectedResult = 3;

            // Act
            int? actualResult = await _searchService.BinarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task BinarySearch_ElementIsAtFirstIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 1;
            int expectedResult = 0;

            // Act
            int? actualResult = await _searchService.BinarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task BinarySearch_ElementIsAtLastIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 9;
            int expectedResult = array.Length-1;

            // Act
            int? actualResult = await _searchService.BinarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task LinearSearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.LinearSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task LinearSearch_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 4;

            // Act
            int? actualResult = await _searchService.LinearSearch(array, element);

            // Assert
            Assert.IsNull(actualResult);
        }

        [Test]
        public async Task LinearSearch_ArrayWithDuplicateElements_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 6, 7, 9 };
            int element = 6;
            int expectedResult = 4;

            // Act
            int? actualResult = await _searchService.LinearSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task LinearSearch_ElementIsAtFirstIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 1;
            int expectedResult = 0;

            // Act
            int? actualResult = await _searchService.LinearSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task LinearSearch_ElementIsAtLastIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 9;
            int expectedResult = array.Length - 1;

            // Act
            int? actualResult = await _searchService.LinearSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InterpolationSearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.InterpolationSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InterpolationSearch_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 4;

            // Act
            int? actualResult = await _searchService.InterpolationSearch(array, element);

            // Assert
            Assert.IsNull(actualResult);
        }

        [Test]
        public async Task InterpolationSearch_ArrayWithDuplicateElements_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 3, 5, 6, 7, 9 };
            int element = 3;
            int expectedResult = 2;

            // Act
            int? actualResult = await _searchService.InterpolationSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InterpolationSearch_ElementIsAtFirstIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 1;
            int expectedResult = 0;

            // Act
            int? actualResult = await _searchService.InterpolationSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InterpolationSearch_ElementIsAtLastIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 9;
            int expectedResult = array.Length - 1;

            // Act
            int? actualResult = await _searchService.InterpolationSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task TernarySearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.TernarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task TernarySearch_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 4;

            // Act
            int? actualResult = await _searchService.TernarySearch(array, element);

            // Assert
            Assert.IsNull(actualResult);
        }

        [Test]
        public async Task TernarySearch_ArrayWithDuplicateElements_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.TernarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task TernarySearch_ElementIsAtFirstIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 1;
            int expectedResult = 0;

            // Act
            int? actualResult = await _searchService.TernarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task TernarySearch_ElementIsAtLastIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 9;
            int expectedResult = array.Length - 1;

            // Act
            int? actualResult = await _searchService.TernarySearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task FibonacciSearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.FibonacciSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task FibonacciSearch_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 4;

            // Act
            int? actualResult = await _searchService.FibonacciSearch(array, element);

            // Assert
            Assert.IsNull(actualResult);
        }

        [Test]
        public async Task FibonacciSearch_ArrayWithDuplicateElements_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 2, 3, 5, 6, 7, 9 };
            int element = 2;
            int expectedResult = 2;

            // Act
            int? actualResult = await _searchService.FibonacciSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task FibonacciSearch_ElementIsAtFirstIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 1;
            int expectedResult = 0;

            // Act
            int? actualResult = await _searchService.FibonacciSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task FibonacciSearch_ElementIsAtLastIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 9;
            int expectedResult = array.Length - 1;

            // Act
            int? actualResult = await _searchService.FibonacciSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SentinelSearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.SentinelSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SentinelSearch_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 4;

            // Act
            int? actualResult = await _searchService.SentinelSearch(array, element);

            // Assert
            Assert.IsNull(actualResult);
        }

        [Test]
        public async Task SentinelSearch_ArrayWithDuplicateElements_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 5;
            int expectedResult = 3;

            // Act
            int? actualResult = await _searchService.SentinelSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SentinelSearch_ElementIsAtFirstIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 1;
            int expectedResult = 0;

            // Act
            int? actualResult = await _searchService.SentinelSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SentinelSearch_ElementIsAtLastIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 9;
            int expectedResult = array.Length - 1;

            // Act
            int? actualResult = await _searchService.SentinelSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task JumpSearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 7;
            int expectedResult = 5;

            // Act
            int? actualResult = await _searchService.JumpSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task JumpSearch_ElementDoesNotExist_ReturnsNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 6, 7, 9 };
            int element = 4;

            // Act
            int? actualResult = await _searchService.JumpSearch(array, element);

            // Assert
            Assert.IsNull(actualResult);
        }

        [Test]
        public async Task JumpSearch_ArrayWithDuplicateElements_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 5;
            int expectedResult = 3;

            // Act
            int? actualResult = await _searchService.JumpSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task JumpSearch_ElementIsAtFirstIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 1;
            int expectedResult = 0;

            // Act
            int? actualResult = await _searchService.JumpSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task JumpSearch_ElementIsAtLastIndex_ReturnsCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 2, 3, 5, 5, 6, 7, 9 };
            int element = 9;
            int expectedResult = array.Length - 1;

            // Act
            int? actualResult = await _searchService.JumpSearch(array, element);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
