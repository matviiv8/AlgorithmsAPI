using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlgorithmsAPI.Controllers
{
    /// <summary>
    /// Controller for string manipulation algorithms.
    /// </summary>
    public class StringsController : Controller
    {
        private readonly IStringsService _stringsService;
        private readonly ILogger<StringsController> _logger;
        private Stopwatch _stopwatch;

        public StringsController(IStringsService stringsService, ILogger<StringsController> logger)
        {
            this._stringsService = stringsService;
            this._logger = logger;
            this._stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Determines whether a given text is a palindrome.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns>True if the text is a palindrome; otherwise, false.</returns>
        /// <remarks>
        /// A palindrome is a word, phrase, number, or other sequence of characters that reads the same forward and backward.
        /// 
        /// The time complexity of the palindrome checking algorithm is O(n), where n is the length of the input text.
        /// 
        /// The space complexity of the algorithm is O(1) because it uses a constant amount of additional space regardless of the input size.
        /// </remarks>
        [HttpPost("ispalindrom")]
        public async Task<IActionResult> IsPalindrom([FromQuery] string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = await _stringsService.IsStringPalindrom(text);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new StringsResult
                {
                    NameOfAlgorithm = "IsPalindrom",
                    ElapsedTime = elapsedTime,
                    StringResult = result.ToString(),
                    StringInput = text
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in StringsController.IsPalindrom(text): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Generates all unique permutations of a given word.
        /// </summary>
        /// <param name="word">The word to generate permutations from.</param>
        /// <returns>A list of unique permutations of the word.</returns>
        /// <remarks>
        /// This method uses a recursive algorithm to generate all unique permutations of the characters in the input word.
        /// 
        /// The time complexity of the unique permutations generation algorithm depends on the length of the word and the number of unique permutations. In the worst case, where all characters in the word are unique, the time complexity is O(n!), where n is the length of the word.
        /// 
        /// The space complexity of the algorithm depends on the number of unique permutations. The method uses a HashSet to store the unique permutations, so the space complexity is proportional to the number of unique permutations generated.
        /// </remarks>
        [HttpPost("uniquepermutation")]
        public async Task<IActionResult> UniquePermutation([FromQuery] string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = await _stringsService.GetEveryUniquePermutation(text);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new StringsResult
                {
                    NameOfAlgorithm = "UniquePermutation",
                    ElapsedTime = elapsedTime,
                    StringResult = string.Join(" ", result),
                    StringInput = text
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in StringsController.UniquePermutation(text): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Finds the occurrences of a substring in a text.
        /// </summary>
        /// <param name="text">The text to search in.</param>
        /// <param name="substring">The substring to find.</param>
        /// <returns>A list of indices where the substring is found in the text.</returns>
        /// <remarks>
        /// This method searches for occurrences of the specified substring in the given text.
        /// It returns a list of indices indicating the starting positions of the found substrings in the text.
        /// If either the text or the substring is null or empty, an empty list is returned.
        /// 
        /// The algorithm used in this method has a time complexity of O((n - m + 1) * m), where n is the length of the text
        /// and m is the length of the substring. It iterates through the text and compares each character
        /// with the corresponding character in the substring.
        /// 
        /// The space complexity of this algorithm is O(k), where k is the number of occurrences of the substring found in the text.
        /// The method uses additional memory to store the list of indices, which depends on the number of occurrences,
        /// but it does not depend on the size of the input text or substring.
        /// </remarks>
        [HttpPost("findsubstring")]
        public async Task<IActionResult> FindSubstring([FromQuery] string text, [FromQuery] string substring)
        {
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(substring))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = await _stringsService.FindSubstring(text, substring);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new StringsResult
                {
                    NameOfAlgorithm = "FindSubstring",
                    ElapsedTime = elapsedTime,
                    StringResult = string.Join(" ", result),
                    StringInput = text
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in StringsController.FindSubstring(text,substring): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Reverses a given string.
        /// </summary>
        /// <param name="text">The string to be reversed.</param>
        /// <returns>The reversed string.</returns>
        /// <remarks>
        /// This method reverses the characters in the given string and returns the reversed string.
        /// If the input string is null or empty, an empty string is returned.
        /// 
        /// The algorithm used in this method has a time complexity of O(n), where n is the length of the string.
        /// It iterates through the string and swaps the characters from both ends until the middle is reached.
        /// 
        /// The space complexity of this algorithm is O(n), where n is the length of the string.
        /// It creates a character array to store the reversed string, which requires additional memory.
        /// </remarks>
        [HttpPost("reverse")]
        public async Task<IActionResult> Reverse([FromQuery] string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = await _stringsService.ReverseString(text);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new StringsResult
                {
                    NameOfAlgorithm = "Reverse",
                    ElapsedTime = elapsedTime,
                    StringResult = string.Join(" ", result),
                    StringInput = text
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in StringsController.Reverse(text): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Replaces all occurrences of a substring with a new string in a given text.
        /// </summary>
        /// <param name="text">The text where the substring should be replaced.</param>
        /// <param name="substring">The substring to be replaced.</param>
        /// <param name="replacement">The string to replace the substring with.</param>
        /// <returns>The text with the replaced substrings.</returns>
        /// <remarks>
        /// This method replaces all occurrences of the specified substring with the replacement string in the given text.
        /// If either the text, substring, or replacement string is null or empty, the original text is returned without any replacements.
        /// 
        /// The algorithm used in this method has a time complexity of O(n), where n is the length of the text.
        /// It iterates through the text and checks for occurrences of the substring using string comparison.
        /// For each occurrence found, it replaces the substring with the replacement string using string concatenation.
        /// 
        /// The space complexity of this algorithm is O(n + m), where n is the length of the text and m is the length of the replacement string.
        /// It creates a new string to store the result, which may require additional memory.
        /// </remarks>
        [HttpPost("replacesubstring")]
        public async Task<IActionResult> ReplaceSubstring([FromQuery] string text, [FromQuery] string substring, [FromQuery] string replacement)
        {
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(substring) || string.IsNullOrEmpty(replacement))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = await _stringsService.ReplaceSubstring(text, substring, replacement);
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new StringsResult
                {
                    NameOfAlgorithm = "ReplaceSubstring",
                    ElapsedTime = elapsedTime,
                    StringResult = string.Join(" ", result),
                    StringInput = text
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in StringsController.ReplaceSubstring(text,substring,replacement): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
