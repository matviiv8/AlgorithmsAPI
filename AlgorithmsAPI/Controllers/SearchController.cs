using AlgorithmsAPI.Contracts;
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
        private Stopwatch _stopwatch;

        public SearchController(ISearchService searchService, IConversionService conversionService)
        {
            this._searchService = searchService;
            this._conversionService = conversionService;
            this._stopwatch = new Stopwatch();
        }

        [HttpPost("binary", Name = nameof(BinarySearch))]
        public async Task<IActionResult> BinarySearch([FromBody]string numbers, [FromQuery]int item)
        {
            var array = await _conversionService.GetArrayNumbersFromString(numbers);
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
                SearchArray = await _conversionService.GetStringFromArrayNumbers(array)
            });
        }

        [HttpPost("linear", Name = nameof(LinearSearch))]
        public async Task<IActionResult> LinearSearch([FromBody]string numbers, [FromQuery]int item)
        {
            var array = await _conversionService.GetArrayNumbersFromString(numbers);

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
                SearchArray = await _conversionService.GetStringFromArrayNumbers(array)
            });
        }

        [HttpPost("interpolation", Name = nameof(InterpolationSearch))]
        public async Task<IActionResult> InterpolationSearch([FromBody]string numbers, [FromQuery]int item)
        {
            var array = await _conversionService.GetArrayNumbersFromString(numbers);
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
                SearchArray = await _conversionService.GetStringFromArrayNumbers(array)
            });
        }


        [HttpPost("ternary", Name = nameof(TernarySearch))]
        public async Task<IActionResult> TernarySearch([FromBody] string numbers, [FromQuery] int item)
        {
            var array = await _conversionService.GetArrayNumbersFromString(numbers);
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
                SearchArray = await _conversionService.GetStringFromArrayNumbers(array)
            });
        }
    }
}
