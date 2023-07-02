using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Services.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Services.Algorithms
{
    public class SortServiceTests
    {
        private ISortService _sortService;

        [SetUp]
        public void Setup()
        {
            this._sortService = new SortService();
        }

        [Test]
        public async Task BubbleSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.BubbleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task BubbleSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.BubbleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task BubbleSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 13 };
            int[] expectedResult = new int[] { 13 };

            // Act
            int[] actualResult = await _sortService.BubbleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task BubbleSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.BubbleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task BubbleSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.BubbleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task QuickSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.QuickSort(array, 0, array.Length-1);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task QuickSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.QuickSort(array, 0, array.Length-1);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task QuickSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 7 };
            int[] expectedResult = new int[] { 7 };

            // Act
            int[] actualResult = await _sortService.QuickSort(array, 0 ,array.Length-1);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task QuickSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.QuickSort(array, 0, array.Length-1);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task QuickSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.QuickSort(array, 0, array.Length-1);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SelectionSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.SelectionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SelectionSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.SelectionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SelectionSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 8 };
            int[] expectedResult = new int[] { 8 };

            // Act
            int[] actualResult = await _sortService.SelectionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SelectionSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.SelectionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task SelectionSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.SelectionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InsertionSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.InsertionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InsertionSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.InsertionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InsertionSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 31 };
            int[] expectedResult = new int[] { 31 };

            // Act
            int[] actualResult = await _sortService.InsertionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InsertionSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.InsertionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task InsertionSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.InsertionSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CycleSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CycleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CycleSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CycleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CycleSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 4 };
            int[] expectedResult = new int[] { 4 };

            // Act
            int[] actualResult = await _sortService.CycleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CycleSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CycleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CycleSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.CycleSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CountingSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CountingSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CountingSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CountingSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CountingSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 19 };
            int[] expectedResult = new int[] { 19 };

            // Act
            int[] actualResult = await _sortService.CountingSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CountingSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CountingSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CountingSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.CountingSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CombSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CombSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CombSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CombSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CombSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 13 };
            int[] expectedResult = new int[] { 13 };

            // Act
            int[] actualResult = await _sortService.CombSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CombSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.CombSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CombSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.CombSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ShellSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.ShellSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ShellSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.ShellSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ShellSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 8 };
            int[] expectedResult = new int[] { 8 };

            // Act
            int[] actualResult = await _sortService.ShellSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ShellSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.ShellSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ShellSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.ShellSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task HeapSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.HeapSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task HeapSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.HeapSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task HeapSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 9 };
            int[] expectedResult = new int[] { 9 };

            // Act
            int[] actualResult = await _sortService.HeapSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task HeapSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.HeapSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task HeapSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.HeapSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task MergeSort_Array_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2 };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.MergeSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task MergeSort_ArrayWithDuplicateElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, 5, 2, 3, 2, 3 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.MergeSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task MergeSort_ArrayWithOneElement_ReturnsSameElement()
        {
            // Arrange
            int[] array = new int[] { 3 };
            int[] expectedResult = new int[] { 3 };

            // Act
            int[] actualResult = await _sortService.MergeSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task MergeSort_SortedArray_ReturnsSameArray()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            int[] expectedResult = new int[] { 1, 2, 2, 3, 3, 3, 4, 5 };

            // Act
            int[] actualResult = await _sortService.MergeSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task MergeSort_ArrayWithNegativeElements_ReturnsSortedArray()
        {
            // Arrange
            int[] array = new int[] { 3, 4, 1, -5, 2, -3, 2, 3 };
            int[] expectedResult = new int[] { -5, -3, 1, 2, 2, 3, 3, 4 };

            // Act
            int[] actualResult = await _sortService.MergeSort(array);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
