using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlgorithmsAPI.Controllers
{
    /// <summary>
    /// Controller for cryptographic cipher algorithms.
    /// </summary>
    [ApiController]
    [Route("cipher")]
    public class CipherController : Controller
    {
        private readonly ICipherService _cipherService;
        private readonly ILogger<CipherController> _logger;
        private Stopwatch _stopwatch;

        public CipherController(ICipherService cipherService, ILogger<CipherController> logger)
        {
            this._cipherService = cipherService;
            this._logger = logger;
            this._stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Encodes or decodes the text using the Caesar cipher algorithm with the specified key.
        /// </summary>
        /// <param name="text">The text to be encoded or decoded.</param>
        /// <param name="key">The key used to shift the characters in the text.</param>
        /// <param name="mode">The cipher mode (Encrypt or Decrypt).</param>
        /// <returns>The encoded or decoded text.</returns>
        /// <remarks>
        /// The Caesar cipher is a simple substitution cipher that shifts the letters of the alphabet by a certain number of positions.
        /// For encryption, each letter in the text is shifted forward in the alphabet by the key. For decryption, the letters are shifted
        /// backward by the key to retrieve the original text.
        ///
        /// The time complexity of the Caesar cipher algorithm is O(n), where n is the length of the text. This is because each character
        /// in the text needs to be processed individually to perform the encryption or decryption operation.
        ///
        /// The space complexity of the Caesar cipher algorithm is also O(n), where n is the length of the text. This is because the algorithm
        /// requires additional space to store the encoded or decoded text, which can be of the same length as the input text.
        /// </remarks>
        [HttpPost("caesar")]
        public async Task<IActionResult> Caesar([FromQuery] string text, [FromQuery] int key, [FromQuery] CipherMode mode)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                if (key < 0 || key > 25)
                {
                    return BadRequest("Invalid key value. Valid range: 0-25");
                }

                _stopwatch.Start();
                var result = mode switch
                {
                    CipherMode.Encrypt => await _cipherService.CaesarCipher(text, key, true),
                    CipherMode.Decrypt => await _cipherService.CaesarCipher(text, key, false),
                    _ => throw new ArgumentException("Invalid parameter value mode")
                };
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new CipherResult
                {
                    NameOfAlgorithm = "Caesar",
                    ElapsedTime = elapsedTime,
                    TextToTransform = text,
                    ResultText = result,
                    SelectedMode = mode,
                    Key = key.ToString()
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in CipherController.Caesar(text,key,mode): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Encodes or decodes the text using the Vigenere cipher algorithm with the specified key.
        /// </summary>
        /// <param name="text">The text to be encoded or decoded.</param>
        /// <param name="key">The key used for the Vigenere cipher.</param>
        /// <param name="mode">The cipher mode (Encrypt or Decrypt).</param>
        /// <returns>The encoded or decoded text.</returns>
        /// <remarks>
        /// The Vigenere cipher is a polyalphabetic substitution cipher that uses a series of Caesar ciphers based on the letters of a keyword.
        /// Each letter in the keyword determines the amount of shifting for the corresponding letters in the plaintext. The keyword is repeated
        /// to match the length of the plaintext or ciphertext.
        ///
        /// The time complexity of the Vigenere cipher algorithm is O(n), where n is the length of the text. This is because each character
        /// in the text needs to be processed individually to perform the encryption or decryption operation.
        ///
        /// The space complexity of the Vigenere cipher algorithm is also O(n), where n is the length of the text. This is because the algorithm
        /// requires additional space to store the encoded or decoded text, which can be of the same length as the input text.
        /// </remarks>
        [HttpPost("vigenere")]
        public async Task<IActionResult> Vigenere([FromQuery] string text, [FromQuery] string key, [FromQuery] CipherMode mode)
        {
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = mode switch
                {
                    CipherMode.Encrypt => await _cipherService.VigenereCipher(text, key, true),
                    CipherMode.Decrypt => await _cipherService.VigenereCipher(text, key, false),
                    _ => throw new ArgumentException("Invalid parameter value mode")
                };
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new CipherResult
                {
                    NameOfAlgorithm = "Vigenere",
                    ElapsedTime = elapsedTime,
                    TextToTransform = text,
                    ResultText = result,
                    SelectedMode = mode,
                    Key = key.ToString().ToUpper()
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in CipherController.Vigenere(text,key,mode): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Encodes or decodes the text using the Scytale cipher algorithm with the specified key.
        /// </summary>
        /// <param name="text">The text to be encoded or decoded.</param>
        /// <param name="key">The key used for the Scytale cipher. Must be a positive integer.</param>
        /// <param name="mode">The cipher mode (Encrypt or Decrypt).</param>
        /// <returns>The encoded or decoded text.</returns>
        /// <remarks>
        /// The Scytale cipher is a transposition cipher that involves wrapping the plaintext or ciphertext around a cylinder or rod of a specific diameter.
        /// The key represents the diameter of the rod, and the text is written along the length of the rod. To encrypt, the text is read off in a
        /// zigzag pattern along the length of the rod. To decrypt, the text is rearranged by columns based on the diameter of the rod.
        ///
        /// The time complexity of the Scytale cipher algorithm is O(n), where n is the length of the text. This is because each character
        /// in the text needs to be processed individually to perform the encryption or decryption operation.
        ///
        /// The space complexity of the Scytale cipher algorithm is also O(n), where n is the length of the text. This is because the algorithm
        /// requires additional space to store the encoded or decoded text, which can be of the same length as the input text.
        /// </remarks>
        [HttpPost("scytale")]
        public async Task<IActionResult> Scytale([FromQuery] string text, [FromQuery] int key, [FromQuery] CipherMode mode)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                if (key <= 0)
                {
                    return BadRequest("Key must be a positive integer.");
                }

                _stopwatch.Start();
                var result = mode switch
                {
                    CipherMode.Encrypt => await _cipherService.ScytaleCipher(text, key, true),
                    CipherMode.Decrypt => await _cipherService.ScytaleCipher(text, key, false),
                    _ => throw new ArgumentException("Invalid parameter value mode")
                };
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new CipherResult
                {
                    NameOfAlgorithm = "Scytale",
                    ElapsedTime = elapsedTime,
                    TextToTransform = text,
                    ResultText = result,
                    SelectedMode = mode,
                    Key = key.ToString()
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in CipherController.Scytale(text,key,mode): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Encodes or decodes the text using the Atbash cipher algorithm with the specified mode.
        /// </summary>
        /// <param name="text">The text to be encoded or decoded.</param>
        /// <param name="mode">The cipher mode (Encrypt or Decrypt).</param>
        /// <returns>The encoded or decoded text.</returns>
        /// <remarks>
        /// The Atbash cipher is a substitution cipher that replaces each letter in the text with its corresponding letter in the reversed alphabet.
        /// For encryption, each letter in the text is replaced with the letter that is at the same position in the reversed alphabet. For decryption,
        /// the process is the same as encryption because reversing the alphabet twice brings it back to the original order.
        ///
        /// The time complexity of the Atbash cipher algorithm is O(n), where n is the length of the text. This is because each character in the text
        /// needs to be processed individually to perform the encryption or decryption operation.
        ///
        /// The space complexity of the Atbash cipher algorithm is O(n), where n is the length of the text. This is because the algorithm requires
        /// additional space to store the encoded or decoded text, which can be of the same length as the input text.
        /// </remarks>
        [HttpPost("atbash")]
        public async Task<IActionResult> Atbash([FromQuery] string text, [FromQuery] CipherMode mode)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = mode switch
                {
                    CipherMode.Encrypt => await _cipherService.AtbashCipher(text, true),
                    CipherMode.Decrypt => await _cipherService.AtbashCipher(text, false),
                    _ => throw new ArgumentException("Invalid parameter value mode")
                };
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new CipherResult
                {
                    NameOfAlgorithm = "Atbash",
                    ElapsedTime = elapsedTime,
                    TextToTransform = text,
                    ResultText = result,
                    SelectedMode = mode,
                    Key = "Not needed"
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in CipherController.Atbash(text,mode): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Encodes or decodes the text using the ROT13 cipher algorithm.
        /// </summary>
        /// <param name="text">The text to be encoded or decoded.</param>
        /// <param name="mode">The cipher mode (Encrypt or Decrypt).</param>
        /// <returns>The encoded or decoded text.</returns>
        /// <remarks>
        /// The ROT13 cipher is a simple letter substitution cipher that replaces each letter
        /// with the letter 13 positions ahead or behind it in the alphabet. It is a special case
        /// of the Caesar cipher, where the key is fixed at 13.
        ///
        /// For encryption, each letter in the text is shifted forward in the alphabet by 13 positions.
        /// For decryption, the letters are shifted backward by 13 positions to retrieve the original text.
        ///
        /// The ROT13 cipher operates only on alphabetical characters, preserving the case of each letter.
        /// Non-alphabetical characters are left unchanged.
        ///
        /// The time complexity of the ROT13 cipher algorithm is O(n), where n is the length of the text.
        /// This is because each character in the text needs to be processed individually to perform
        /// the encryption or decryption operation.
        ///
        /// The space complexity of the ROT13 cipher algorithm is also O(n), where n is the length of the text.
        /// This is because the algorithm requires additional space to store the encoded or decoded text,
        /// which can be of the same length as the input text.
        /// </remarks>
        [HttpPost("rot13")]
        public async Task<IActionResult> Rot13([FromQuery] string text, [FromQuery] CipherMode mode)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = mode switch
                {
                    CipherMode.Encrypt => await _cipherService.Rot13Cipher(text, true),
                    CipherMode.Decrypt => await _cipherService.Rot13Cipher(text, false),
                    _ => throw new ArgumentException("Invalid parameter value mode")
                };
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new CipherResult
                {
                    NameOfAlgorithm = "Rot13",
                    ElapsedTime = elapsedTime,
                    TextToTransform = text,
                    ResultText = result,
                    SelectedMode = mode,
                    Key = "Not needed"
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in CipherController.Rot13(text,mode): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        /// <summary>
        /// Encodes or decodes the text using the A1Z26 cipher algorithm.
        /// </summary>
        /// <param name="text">The text to be encrypted or decrypted.</param>
        /// <param name="mode">The cipher mode (Encrypt or Decrypt).</param>
        /// <returns>The encrypted or decrypted text.</returns>
        /// <remarks>
        /// The A1Z26 cipher is a simple substitution cipher that replaces each letter with its corresponding
        /// position in the alphabet (e.g., A=1, B=2, C=3, etc.). This cipher can be used for both encryption
        /// and decryption by specifying the appropriate mode.
        ///
        /// For encryption, each letter in the text is replaced with its corresponding position in the alphabet.
        /// For decryption, the positions are converted back to letters to retrieve the original text.
        ///
        /// The A1Z26 cipher operates only on alphabetical characters, preserving the case of each letter.
        /// Non-alphabetical characters are left unchanged.
        ///
        /// The time complexity of the A1Z26 cipher algorithm is O(n), where n is the length of the text.
        /// This is because each character in the text needs to be processed individually to perform
        /// the encryption or decryption operation.
        ///
        /// The space complexity of the A1Z26 cipher algorithm is O(n), where n is the length of the text.
        /// This is because the algorithm requires additional space to store the encrypted or decrypted text,
        /// which can be of the same length as the input text.
        /// </remarks>
        [HttpPost("a1z26")]
        public async Task<IActionResult> A1Z26([FromQuery] string text, [FromQuery] CipherMode mode)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return BadRequest();
                }

                _stopwatch.Start();
                var result = mode switch
                {
                    CipherMode.Encrypt => await _cipherService.A1Z26Cipher(text, true),
                    CipherMode.Decrypt => await _cipherService.A1Z26Cipher(text, false),
                    _ => throw new ArgumentException("Invalid parameter value mode")
                };
                _stopwatch.Stop();
                var elapsedTime = _stopwatch.Elapsed;

                return Ok(new CipherResult
                {
                    NameOfAlgorithm = "A1Z26",
                    ElapsedTime = elapsedTime,
                    TextToTransform = text,
                    ResultText = result,
                    SelectedMode = mode,
                    Key = "Not needed"
                });
            }
            catch (Exception error)
            {
                _logger.LogError($"Error in CipherController.A1Z26(text,mode): {error.Message}");
                _logger.LogError($"Inner exception:\n{error.InnerException}");
                _logger.LogTrace(error.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
