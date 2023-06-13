using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace AlgorithmsAPI.Controllers
{
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

        [HttpPost("binary", Name = nameof(BinarySearch))]
        public async Task<IActionResult> BinarySearch([FromBody]string numbers, [FromQuery]int item)
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("linear", Name = nameof(LinearSearch))]
        public async Task<IActionResult> LinearSearch([FromBody]string numbers, [FromQuery]int item)
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("interpolation", Name = nameof(InterpolationSearch))]
        public async Task<IActionResult> InterpolationSearch([FromBody]string numbers, [FromQuery]int item)
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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


        [HttpPost("ternary", Name = nameof(TernarySearch))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("fibonacci", Name = nameof(FibonacciSearch))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("sentinel", Name = nameof(SentinelSearch))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("jump", Name = nameof(JumpSearch))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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
