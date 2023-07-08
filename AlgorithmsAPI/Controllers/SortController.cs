using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace AlgorithmsAPI.Controllers
{
    /// <summary>
    /// Controller for sorting algorithms.
    /// </summary>
    [ApiController]
    [Route("sort")]
    public class SortController : Controller
    {
        private readonly IConversionService _conversionService;
        private readonly ISortService _sortService;
        private Stopwatch _stopwatch;
        private readonly ILogger<SortController> _logger;

        public SortController(ISortService sortService, IConversionService conversionService, ILogger<SortController> logger)
        {
            this._sortService = sortService;
            this._conversionService = conversionService;
            this._stopwatch = new Stopwatch();
            this._logger = logger;
        }

        /// <summary>
        /// Performs bubble sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Bubble sort is a simple sorting algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.
        /// 
        /// The time complexity of the bubble sort algorithm is O(n^2), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(1) because it only requires a constant amount of additional space to perform the sorting.
        /// </remarks>
        [HttpPost("bubble")]
        public async Task<IActionResult> BubbleSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.BubbleSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "BubbleSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.BubbleSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs quick sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Quick sort is a divide-and-conquer sorting algorithm that divides the input array into smaller subarrays, and recursively sorts those subarrays.
        /// 
        /// The time complexity of the quick sort algorithm is O(n log n), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(log n) on average, and O(n) in the worst case, due to the recursive nature of the algorithm.
        /// </remarks>
        [HttpPost("quick")]
        public async Task<IActionResult> QuickSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.QuickSort(initialArray, 0, initialArray.Length - 1);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "QuickSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.QuickSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs selection sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Selection sort is a simple sorting algorithm that repeatedly finds the minimum element from the unsorted part of the array and swaps it with the first unsorted element.
        /// 
        /// The time complexity of the selection sort algorithm is O(n^2), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(1) because it only requires a constant amount of additional space to perform the sorting.
        /// </remarks>
        [HttpPost("selection")]
        public async Task<IActionResult> SelectionSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.SelectionSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "SelectionSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.SelectionSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs insertion sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Insertion sort is a simple sorting algorithm that builds the final sorted array one item at a time.
        /// It iterates through the array, comparing each element with the previous elements and inserting it into its correct position.
        /// 
        /// The time complexity of the insertion sort algorithm is O(n^2), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(1) because it only requires a constant amount of additional space to perform the sorting.
        /// </remarks>
        [HttpPost("insertion")]
        public async Task<IActionResult> InsertionSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.InsertionSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "InsertionSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.InsertionSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs cycle sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Cycle sort is an in-place, unstable sorting algorithm that minimizes the number of writes to memory.
        /// It achieves this by cyclically rotating the elements within groups until each element is in its correct position.
        /// 
        /// The time complexity of the cycle sort algorithm is O(n^2), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(1) because it only requires a constant amount of additional space to perform the sorting.
        /// </remarks>
        [HttpPost("cycle")]
        public async Task<IActionResult> CycleSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.CycleSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "CycleSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.CycleSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs counting sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Counting sort is a linear-time, integer sorting algorithm that sorts elements based on their counts.
        /// It counts the number of occurrences of each element and uses that information to determine the correct position of each element in the sorted array.
        /// 
        /// The time complexity of the counting sort algorithm is O(n + k), where n is the number of elements in the array and k is the range of input values.
        /// 
        /// The space complexity of the algorithm is O(n + k) because it requires additional space for the count array and the sorted array.
        /// </remarks>
        [HttpPost("counting")]
        public async Task<IActionResult> CountingSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.CountingSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "CountingSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.CountingSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }


        /// <summary>
        /// Performs comb sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Comb sort is a variation of bubble sort that improves the bubble sort algorithm by using a larger gap to compare and swap elements.
        /// It starts with a large gap between elements and gradually reduces the gap until it becomes 1, which is equivalent to a bubble sort pass.
        /// 
        /// The time complexity of the comb sort algorithm is O(n^2), but it can be improved by using a shrink factor to reduce the gap.
        /// 
        /// The space complexity of the algorithm is O(1) because it performs the sorting in-place without requiring additional space.
        /// </remarks>
        [HttpPost("comb")]
        public async Task<IActionResult> CombSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.CombSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "CombSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.CombSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs shell sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Shell sort is an in-place comparison sorting algorithm that generalizes insertion sort.
        /// It starts by sorting pairs of elements far apart from each other, then progressively reduces the gap between elements to be compared until the gap is 1.
        /// 
        /// The time complexity of the shell sort algorithm depends on the chosen gap sequence, but it can be considered between O(n log n) and O(n^2), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(1) because it performs the sorting in-place without requiring additional space.
        /// </remarks>
        [HttpPost("shell")]
        public async Task<IActionResult> ShellSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.ShellSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "ShellSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.ShellSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs heap sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Heap sort is a comparison-based sorting algorithm that uses a binary heap data structure to sort elements.
        /// It first builds a max-heap from the input array and then repeatedly extracts the maximum element from the heap, resulting in a sorted array.
        /// 
        /// The time complexity of the heap sort algorithm is O(n log n), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(1) because it performs the sorting in-place without requiring additional space.
        /// </remarks>
        [HttpPost("heap")]
        public async Task<IActionResult> HeapSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.HeapSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "HeapSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.HeapSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs merge sort on an array of numbers.
        /// </summary>
        /// <param name="numbers">The numbers to be sorted, provided as a string.</param>
        /// <returns>The sorted array of numbers.</returns>
        /// <remarks>
        /// Merge sort is a divide-and-conquer sorting algorithm that divides the input array into smaller subarrays, sorts them independently, and then merges them to obtain a sorted array.
        /// 
        /// The time complexity of the merge sort algorithm is O(n log n), where n is the number of elements in the array.
        /// 
        /// The space complexity of the algorithm is O(n) because it requires additional space for merging the subarrays.
        /// </remarks>
        [HttpPost("merge")]
        public async Task<IActionResult> MergeSort([FromBody] string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var initialArray = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var sortedArray = await _sortService.MergeSort(initialArray);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SortResult
                {
                    NameOfAlgorithm = "MergeSort",
                    InitialArray = numbers,
                    ElapsedTime = elapsedTime,
                    SortedArray = _conversionService.GetStringFromArrayNumbers(sortedArray)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SortController.MergeSort(numbers): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
