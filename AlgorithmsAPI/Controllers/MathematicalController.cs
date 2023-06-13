using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
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
        private readonly ILogger<MathematicalController> _logger;
        private Stopwatch _stopwatch;

        public MathematicalController(IConversionService conversionService, IMathematicalService mathematicalService, ILogger<MathematicalController> logger)
        {
            this._conversionService = conversionService;
            this._mathematicalService = mathematicalService;
            this._stopwatch = new Stopwatch();
            this._logger = logger;
        }

        [HttpPost("factorial", Name = nameof(Factorial))]
        public async Task<IActionResult> Factorial([FromQuery]string number)
        {
            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return BadRequest();
                }

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
            catch (Exception error)
            {
                _logger.LogError($"Error in MathematicalController.Factorial(number): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPost("fibonacci", Name = nameof(Fibonacci))]
        public async Task<IActionResult> Fibonacci([FromQuery] string number)
        {
            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return BadRequest();
                }

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
            catch (Exception error)
            {
                _logger.LogError($"Error in MathematicalController.Fibonacci(number): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPost("iterativeGCD", Name = nameof(IterativeGCD))]
        public async Task<IActionResult> IterativeGCD([FromQuery] string firstNumber, [FromQuery] string secondNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(firstNumber) || string.IsNullOrEmpty(secondNumber))
                {
                    return BadRequest();
                }

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
            catch (Exception error)
            {
                _logger.LogError($"Error in MathematicalController.IterativeGCD(firstNumber, secondNumber): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPost("recursiveGCD", Name = nameof(RecursiveGCD))]
        public async Task<IActionResult> RecursiveGCD([FromQuery] string firstNumber, [FromQuery] string secondNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(firstNumber) || string.IsNullOrEmpty(secondNumber))
                {
                    return BadRequest();
                }

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
            catch (Exception error)
            {
                _logger.LogError($"Error in MathematicalController.RecursiveGCD(firstNumber, secondNumber): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPost("isprime", Name = nameof(IsPrime))]
        public async Task<IActionResult> IsPrime([FromQuery] string number)
        {
            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return BadRequest();
                }

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
            catch (Exception error)
            {
                _logger.LogError($"Error in MathematicalController.IsPrime(number): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
