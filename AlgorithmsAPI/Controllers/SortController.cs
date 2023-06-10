using AlgorithmsAPI.Contracts;
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

        public SortController(ISortService sortService, IConversionService conversionService)
        {
            this._sortService = sortService;
            this._conversionService = conversionService;
            this._stopwatch = new Stopwatch();
        }

        [HttpPost("buble", Name = nameof(BubbleSort))]
        public async Task<IActionResult> BubbleSort([FromBody]string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.BubbleSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult 
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime, 
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray) 
            });
        }

        [HttpPost("quick", Name = nameof(QuickSort))]
        public async Task<IActionResult> QuickSort([FromBody]string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.QuickSort(initialArray,0,initialArray.Length-1);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }

        [HttpPost("selection", Name = nameof(SelectionSort))]
        public async Task<IActionResult> SelectionSort([FromBody]string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.SelectionSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }

        [HttpPost("insertion", Name = nameof(InsertionSort))]
        public async Task<IActionResult> InsertionSort([FromBody] string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.InsertionSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }

        [HttpPost("cycle", Name = nameof(CycleSort))]
        public async Task<IActionResult> CycleSort([FromBody] string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.CycleSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }

        [HttpPost("counting", Name = nameof(CountingSort))]
        public async Task<IActionResult> CountingSort([FromBody] string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.CountingSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }


        [HttpPost("comb", Name = nameof(CombSort))]
        public async Task<IActionResult> CombSort([FromBody] string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.CombSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }

        [HttpPost("shell", Name = nameof(ShellSort))]
        public async Task<IActionResult> ShellSort([FromBody] string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.ShellSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }

        [HttpPost("heap", Name = nameof(HeapSort))]
        public async Task<IActionResult> HeapSort([FromBody] string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.HeapSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }

        [HttpPost("merge", Name = nameof(MergeSort))]
        public async Task<IActionResult> MergeSort([FromBody] string numbers)
        {
            var initialArray = await _conversionService.GetArrayNumbersFromString(numbers);

            _stopwatch.Start();
            var sortedArray = await _sortService.MergeSort(initialArray);
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new SortResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                InitialArray = numbers,
                ElapsedTime = elapsedTime,
                SortedArray = await _conversionService.GetStringFromArrayNumbers(sortedArray)
            });
        }
    }
}
