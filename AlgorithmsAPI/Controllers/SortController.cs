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
    }
}
