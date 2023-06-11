using AlgorithmsAPI.Contracts;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace AlgorithmsAPI.Controllers
{
    [ApiController]
    [Route("math")]
    public class MathematicalController : Controller
    {
        private readonly IConversionService _conversionService;
        private readonly IMathematicalService _mathematicalService;
        private Stopwatch _stopwatch;

        public MathematicalController(IConversionService conversionService, IMathematicalService mathematicalService)
        {
            this._conversionService = conversionService;
            this._mathematicalService = mathematicalService;
            this._stopwatch = new Stopwatch();
        }

        [HttpPost("factorial", Name = nameof(Factorial))]
        public async Task<IActionResult> Factorial([FromQuery]string number)
        {
            _stopwatch.Start();
            var result = await _mathematicalService.Factorial(Convert.ToInt32(number));
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new MathematicalResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                ElapsedTime = elapsedTime,
                InputData = number,
                OutputData = result.ToString()
            });
        }

        [HttpPost("fibonacci", Name = nameof(Fibonacci))]
        public async Task<IActionResult> Fibonacci([FromQuery] string number)
        {
            _stopwatch.Start();
            var result = await _mathematicalService.Fibonacci(Convert.ToInt32(number));
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new MathematicalResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                ElapsedTime = elapsedTime,
                InputData = number,
                OutputData = result.ToString()
            });
        }

        [HttpPost("iterativeGCD", Name = nameof(IterativeGCD))]
        public async Task<IActionResult> IterativeGCD([FromQuery] string firstNumber, [FromQuery] string secondNumber)
        {
            _stopwatch.Start();
            var result = await _mathematicalService.IterativeGCD(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new MathematicalResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                ElapsedTime = elapsedTime,
                InputData = firstNumber + " " + secondNumber,
                OutputData = result.ToString()
            });
        }

        [HttpPost("recursiveGCD", Name = nameof(RecursiveGCD))]
        public async Task<IActionResult> RecursiveGCD([FromQuery] string firstNumber, [FromQuery] string secondNumber)
        {
            _stopwatch.Start();
            var result = await _mathematicalService.RecursiveGCD(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new MathematicalResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                ElapsedTime = elapsedTime,
                InputData = firstNumber + " " + secondNumber,
                OutputData = result.ToString()
            });
        }

        [HttpPost("isprime", Name = nameof(IsPrime))]
        public async Task<IActionResult> IsPrime([FromQuery] string number)
        {
            _stopwatch.Start();
            var result = await _mathematicalService.IsPrime(Convert.ToInt32(number));
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.Elapsed;

            return Ok(new MathematicalResult
            {
                NameOfAlgorithm = RouteData.Values["action"]?.ToString(),
                ElapsedTime = elapsedTime,
                InputData = number,
                OutputData = result.ToString()
            });
        }
    }
}
