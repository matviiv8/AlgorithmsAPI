using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace AlgorithmsAPI.Controllers
{
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

        [HttpPost("buble", Name = nameof(BubbleSort))]
        public async Task<IActionResult> BubbleSort([FromBody]string numbers)
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("quick", Name = nameof(QuickSort))]
        public async Task<IActionResult> QuickSort([FromBody]string numbers)
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("selection", Name = nameof(SelectionSort))]
        public async Task<IActionResult> SelectionSort([FromBody]string numbers)
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("insertion", Name = nameof(InsertionSort))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("cycle", Name = nameof(CycleSort))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("counting", Name = nameof(CountingSort))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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


        [HttpPost("comb", Name = nameof(CombSort))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("shell", Name = nameof(ShellSort))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("heap", Name = nameof(HeapSort))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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

        [HttpPost("merge", Name = nameof(MergeSort))]
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
                    NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
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
