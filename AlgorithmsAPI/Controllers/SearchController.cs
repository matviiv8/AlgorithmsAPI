using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Web.Http.Results;

namespace AlgorithmsAPI.Controllers
{
    /// <summary>
    /// Controller for search functionality.
    /// </summary>
    [ApiController]
    [Route("search")]
    public class SearchController : Controller
    {
        private readonly IConversionService _conversionService;
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;
        private Stopwatch _stopwatch;

        public SearchController(ISearchService searchService, IConversionService conversionService, ILogger<SearchController> logger)
        {
            this._searchService = searchService;
            this._conversionService = conversionService;
            this._stopwatch = new Stopwatch();
            this._logger = logger;
        }

        /// <summary>
        /// Performs a binary search on a given array of numbers to find a specific item.
        /// </summary>
        /// <param name="numbers">A string representation of the array of numbers.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>An IActionResult representing the result of the binary search.</returns>
        /// <remarks>
        /// The binary search algorithm works on a sorted array by repeatedly dividing the search space in half until the item is found or the
        /// search space is empty. It compares the target item with the middle element of the current search space and determines whether to
        /// continue the search in the left or right half.
        ///
        /// The time complexity of the binary search algorithm is O(log n), where n is the size of the array. In each iteration, the algorithm
        /// divides the search space in half, resulting in a halving of the remaining elements to search. Therefore, the number of comparisons
        /// decreases logarithmically with the size of the array.
        ///
        /// The space complexity of the binary search algorithm is O(1), as it only requires a constant amount of additional space to store
        /// variables and perform the search. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("binary")]
        public async Task<IActionResult> BinarySearch([FromBody] string numbers, [FromQuery] int item)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var array = _conversionService.GetArrayNumbersFromString(numbers);
                array = array.OrderBy(number => number).ToArray();

                _stopwatch.Start();
                var result = await _searchService.BinarySearch(array, item);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SearchResult
                {
                    NameOfAlgorithm = "BinarySearch",
                    ElapsedTime = elapsedTime,
                    SearchedVariable = item,
                    LastMatchingResult = result == null ? "Item is missing" : result.ToString(),
                    SearchArray = _conversionService.GetStringFromArrayNumbers(array)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SearchController.BinarySearch(numbers, item): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs a linear search on a given array of numbers to find a specific item.
        /// </summary>
        /// <param name="numbers">A string representation of the array of numbers.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>An IActionResult representing the result of the linear search.</returns>
        /// <remarks>
        /// The linear search algorithm, also known as sequential search, works by iterating through the array one element at a time and comparing
        /// each element with the search item until a match is found or the end of the array is reached.
        ///
        /// The time complexity of the linear search algorithm is O(n), where n is the size of the array. In the worst case scenario, the search
        /// item may be located at the end of the array, requiring the algorithm to iterate through all elements. Therefore, the time complexity is
        /// directly proportional to the size of the array.
        ///
        /// The space complexity of the linear search algorithm is O(1), as it only requires a constant amount of additional space to store
        /// variables and perform the search. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("linear")]
        public async Task<IActionResult> LinearSearch([FromBody] string numbers, [FromQuery] int item)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }
                var array = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var result = await _searchService.LinearSearch(array, item);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SearchResult
                {
                    NameOfAlgorithm = "LinearSearch",
                    ElapsedTime = elapsedTime,
                    SearchedVariable = item,
                    LastMatchingResult = result == null ? "Item is missing" : result.ToString(),
                    SearchArray = _conversionService.GetStringFromArrayNumbers(array)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SearchController.LinearSearch(numbers, item): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs an interpolation search on a given array of numbers to find a specific item.
        /// </summary>
        /// <param name="numbers">A string representation of the array of numbers.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>An IActionResult representing the result of the interpolation search.</returns>
        /// <remarks>
        /// The interpolation search algorithm is an improved variant of binary search that works on uniformly distributed sorted arrays. It uses
        /// interpolation formulae to estimate the position of the search item within the array.
        ///
        /// The time complexity of the interpolation search algorithm is O(log log n), where n is the size of the array. In each iteration, the
        /// algorithm computes the position of the mid element using interpolation, which provides a closer estimate of the item's position compared
        /// to binary search. Therefore, the number of comparisons decreases faster than in binary search, resulting in a logarithmic logarithmic time complexity.
        ///
        /// The space complexity of the interpolation search algorithm is O(1), as it only requires a constant amount of additional space to store
        /// variables and perform the search. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("interpolation")]
        public async Task<IActionResult> InterpolationSearch([FromBody] string numbers, [FromQuery] int item)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var array = _conversionService.GetArrayNumbersFromString(numbers);
                array = array.OrderBy(number => number).ToArray();

                _stopwatch.Start();
                var result = await _searchService.InterpolationSearch(array, item);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SearchResult
                {
                    NameOfAlgorithm = "InterpolationSearch",
                    ElapsedTime = elapsedTime,
                    SearchedVariable = item,
                    LastMatchingResult = result == null ? "Item is missing" : result.ToString(),
                    SearchArray = _conversionService.GetStringFromArrayNumbers(array)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SearchController.InterpolationSearch(numbers, item): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs a ternary search on a given array of numbers to find a specific item.
        /// </summary>
        /// <param name="numbers">A string representation of the array of numbers.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>An IActionResult representing the result of the ternary search.</returns>
        /// <remarks>
        /// The ternary search algorithm is a divide-and-conquer search algorithm that works on a sorted array. It divides the array into three parts
        /// and determines if the search item is in the first, second, or third part based on comparisons with the mid1 and mid2 elements.
        ///
        /// The time complexity of the ternary search algorithm is O(log n), where n is the size of the array. In each iteration, the algorithm
        /// reduces the search space by dividing it into three parts. Therefore, the number of comparisons decreases exponentially as the size of
        /// the search space decreases, resulting in a logarithmic time complexity.
        ///
        /// The space complexity of the ternary search algorithm is O(1), as it only requires a constant amount of additional space to store
        /// variables and perform the search. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("ternary")]
        public async Task<IActionResult> TernarySearch([FromBody] string numbers, [FromQuery] int item)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var array = _conversionService.GetArrayNumbersFromString(numbers);
                array = array.OrderBy(number => number).ToArray();

                _stopwatch.Start();
                var result = await _searchService.TernarySearch(array, item);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SearchResult
                {
                    NameOfAlgorithm = "TernarySearch",
                    ElapsedTime = elapsedTime,
                    SearchedVariable = item,
                    LastMatchingResult = result == null ? "Item is missing" : result.ToString(),
                    SearchArray = _conversionService.GetStringFromArrayNumbers(array)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SearchController.TernarySearch(numbers, item): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs a Fibonacci search on a given array of numbers to find a specific item.
        /// </summary>
        /// <param name="numbers">A string representation of the array of numbers.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>An IActionResult representing the result of the Fibonacci search.</returns>
        /// <remarks>
        /// The Fibonacci search algorithm is an efficient searching algorithm that utilizes the Fibonacci sequence to divide the array into
        /// smaller subarrays and perform comparisons based on the Fibonacci numbers.
        ///
        /// The time complexity of the Fibonacci search algorithm is O(log n), where n is the size of the array. This is because the algorithm
        /// divides the array into smaller subarrays using Fibonacci numbers and performs comparisons to determine the next subarray to search.
        /// As the size of the subarrays decreases exponentially, the time complexity is logarithmic.
        ///
        /// The space complexity of the Fibonacci search algorithm is O(1), as it only requires a constant amount of additional space to store
        /// variables and perform the search. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("fibonacci")]
        public async Task<IActionResult> FibonacciSearch([FromBody] string numbers, [FromQuery] int item)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }
                var array = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var result = await _searchService.FibonacciSearch(array, item);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SearchResult
                {
                    NameOfAlgorithm = "FibonacciSearch",
                    ElapsedTime = elapsedTime,
                    SearchedVariable = item,
                    LastMatchingResult = result == null ? "Item is missing" : result.ToString(),
                    SearchArray = _conversionService.GetStringFromArrayNumbers(array)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SearchController.FibonacciSearch(numbers, item): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }


        /// <summary>
        /// Performs a sentinel search on a given array of numbers to find a specific item.
        /// </summary>
        /// <param name="numbers">A string representation of the array of numbers.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>An IActionResult representing the result of the sentinel search.</returns>
        /// <remarks>
        /// The sentinel search algorithm is an improvement over linear search that uses a sentinel value to optimize the search process.
        /// It works by placing a sentinel value at the end of the array and comparing the search item with each element in the array.
        /// If the search item is found before reaching the sentinel, the algorithm terminates. This avoids the need for an additional
        /// boundary check in each iteration of the linear search.
        ///
        /// The time complexity of the sentinel search algorithm is O(n), where n is the size of the array. In the worst case scenario,
        /// the algorithm will perform a linear search through the entire array until it either finds the item or reaches the sentinel.
        /// Therefore, the time complexity is proportional to the size of the array.
        ///
        /// The space complexity of the sentinel search algorithm is O(1), as it only requires a constant amount of additional space to
        /// store variables and perform the search. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("sentinel")]
        public async Task<IActionResult> SentinelSearch([FromBody] string numbers, [FromQuery] int item)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var array = _conversionService.GetArrayNumbersFromString(numbers);

                _stopwatch.Start();
                var result = await _searchService.SentinelSearch(array, item);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SearchResult
                {
                    NameOfAlgorithm = "SentinelSearch",
                    ElapsedTime = elapsedTime,
                    SearchedVariable = item,
                    LastMatchingResult = result == null ? "Item is missing" : result.ToString(),
                    SearchArray = _conversionService.GetStringFromArrayNumbers(array)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SearchController.SentinelSearch(numbers, item): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Performs a jump search on a given array of numbers to find a specific item.
        /// </summary>
        /// <param name="numbers">A string representation of the array of numbers.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>An IActionResult representing the result of the jump search.</returns>
        /// <remarks>
        /// The jump search algorithm is an efficient searching algorithm for sorted arrays. It works by jumping ahead by a fixed number of steps,
        /// and if the desired element is not found, it jumps again. This process continues until the desired element is found or it exceeds the array bounds.
        ///
        /// The time complexity of the jump search algorithm is O(√n), where n is the size of the array. This is because the algorithm performs
        /// a linear search in each block of size √n, and there can be a maximum of √n blocks. Therefore, the time complexity is proportional to the
        /// square root of the array size.
        ///
        /// The space complexity of the jump search algorithm is O(1), as it only requires a constant amount of additional space to store variables
        /// and perform the search. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("jump")]
        public async Task<IActionResult> JumpSearch([FromBody] string numbers, [FromQuery] int item)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                {
                    return BadRequest();
                }

                var array = _conversionService.GetArrayNumbersFromString(numbers);
                array = array.OrderBy(number => number).ToArray();

                _stopwatch.Start();
                var result = await _searchService.JumpSearch(array, item);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new SearchResult
                {
                    NameOfAlgorithm = "JumpSearch",
                    ElapsedTime = elapsedTime,
                    SearchedVariable = item,
                    LastMatchingResult = result == null ? "Item is missing" : result.ToString(),
                    SearchArray = _conversionService.GetStringFromArrayNumbers(array)
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in SearchController.JumpSearch(numbers, item): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
