using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace AlgorithmsAPI.Controllers
{
    /// <summary>
    /// Controller for mathematical algorithms.
    /// </summary>
    [ApiController]
    [Route("math")]
    public class MathematicalController : Controller
    {
        private readonly IMathematicalService _mathematicalService;
        private readonly ILogger<MathematicalController> _logger;
        private Stopwatch _stopwatch;

        public MathematicalController(IMathematicalService mathematicalService, ILogger<MathematicalController> logger)
        {
            this._mathematicalService = mathematicalService;
            this._stopwatch = new Stopwatch();
            this._logger = logger;
        }
        
        /// <summary>
        /// Calculates the factorial of a given number.
        /// </summary>
        /// <param name="number">The number for which to calculate the factorial.</param>
        /// <returns>The factorial of the input number.</returns>
        /// <remarks>
        /// The factorial of a non-negative integer n, denoted by n!, is the product of all positive integers less than or equal to n.
        /// 
        /// The time complexity of the factorial calculation algorithm is O(n), where n is the input number. This is because the algorithm
        /// iterates from 1 to n, multiplying each number in the range, resulting in a linear time complexity proportional to the input number.
        ///
        /// The space complexity of the factorial calculation algorithm is O(1), which means it requires a constant amount of additional
        /// space regardless of the input number. The algorithm does not use any data structures or recursion that would consume additional space.
        /// </remarks>
        [HttpPost("factorial")]
        public async Task<IActionResult> Factorial([FromQuery] string number)
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
                    NameOfAlgorithm = "Factorial",
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

        /// <summary>
        /// Calculates the Fibonacci number at the specified position.
        /// </summary>
        /// <param name="number">The position of the Fibonacci number to calculate.</param>
        /// <returns>The Fibonacci number at the specified position.</returns>
        /// <remarks>
        /// The Fibonacci sequence is a series of numbers in which each number (Fibonacci number) is the sum of the two preceding ones.
        /// 
        /// The time complexity of the Fibonacci calculation algorithm is O(2^n), where n is the input position. This algorithm uses recursion
        /// and has exponential time complexity, which makes it inefficient for large values of n. 
        /// 
        /// The space complexity of the Fibonacci calculation algorithm is O(n), where n is the input position. This is because the recursive
        /// algorithm requires storing intermediate results on the call stack, leading to a space complexity proportional to the input position.
        /// </remarks>
        [HttpPost("fibonacci")]
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
                    NameOfAlgorithm = "Fibonacci",
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

        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two numbers using the iterative method.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The GCD of the two numbers.</returns>
        /// <remarks>
        /// The iterative method for calculating the GCD repeatedly applies the Euclidean algorithm
        /// until the remainder becomes zero. It is an efficient method for finding the GCD of two numbers.
        /// 
        /// Time complexity: O(log(min(a, b))), where a and b are the two input numbers.
        /// 
        /// Space complexity: O(1).
        /// </remarks>
        [HttpPost("iterativeGCD")]
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
                    NameOfAlgorithm = "IterativeGCD",
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

        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two numbers using a recursive algorithm.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The greatest common divisor (GCD) of the two input numbers.</returns>
        /// <remarks>
        /// The greatest common divisor (GCD) of two numbers is the largest positive integer that divides both numbers without leaving a remainder.
        /// 
        /// The time complexity of the recursive GCD algorithm depends on the values of the input numbers. In the worst case, when the two numbers
        /// are consecutive Fibonacci numbers, the time complexity is O(log n), where n is the larger of the two numbers. However, in most cases,
        /// the algorithm has a lower time complexity due to the recursive nature of the calculation.
        ///
        /// The space complexity of the recursive GCD algorithm is O(log n), where n is the larger of the two numbers. This is because the algorithm
        /// uses a recursive function call stack, and the maximum depth of the stack is proportional to the logarithm of the input numbers.
        /// </remarks>
        [HttpPost("recursiveGCD")]
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
                    NameOfAlgorithm = "RecursiveGCD",
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

        /// <summary>
        /// Checks if a given number is a prime number.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the input number is prime; otherwise, false.</returns>
        /// <remarks>
        /// A prime number is a natural number greater than 1 that is not divisible by any positive integer other than 1 and itself.
        /// 
        /// The time complexity of the algorithm to check if a number is prime is O(sqrt(n)), where n is the input number. This is because
        /// the algorithm iterates up to the square root of the input number to check for divisibility.
        ///
        /// The space complexity of the algorithm is O(1) as it does not require additional space that grows with the input size.
        /// </remarks>
        [HttpPost("isprime")]
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
                    NameOfAlgorithm = "IsPrime",
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

        /// <summary>
        /// Generates an array of prime numbers up to the specified threshold using the Sieve of Eratosthenes algorithm.
        /// </summary>
        /// <param name="threshold">The upper limit or threshold.</param>
        /// <returns>An array of prime numbers up to the specified threshold.</returns>
        /// <remarks>
        /// The Sieve of Eratosthenes algorithm is an efficient method for generating prime numbers up to a given threshold.
        /// 
        /// The time complexity of this algorithm is O(n log log n), where n is the specified threshold. It is much more efficient
        /// than checking each number individually for primality.
        ///
        /// The space complexity of the algorithm is O(n), where n is the specified threshold. The algorithm uses a boolean array
        /// to mark composite numbers, requiring additional space proportional to the threshold.
        /// </remarks>
        [HttpPost("sieveoferatosthenes")]
        public async Task<IActionResult> SieveOfEratosthenes([FromQuery] string threshold)
        {
            try
            {
                if (string.IsNullOrEmpty(threshold))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = await _mathematicalService.SieveOfEratosthenes(Convert.ToInt32(threshold));
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new MathematicalResult
                {
                    NameOfAlgorithm = "SieveOfEratosthenes",
                    ElapsedTime = elapsedTime,
                    InputData = threshold,
                    OutputData = string.Join(" ", result)
            });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in MathematicalController.SieveOfEratosthenes(threshold): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
