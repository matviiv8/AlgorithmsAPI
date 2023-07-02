using AlgorithmsAPI.Contracts.Algorithms;
using System.Text;
using System.Text.RegularExpressions;

namespace AlgorithmsAPI.Services.Algorithms
{
    public class CipherService : ICipherService
    {
        public async Task<string> CaesarCipher(string text, int key, bool mode)
        {
            var encrypted = string.Empty;
            key = mode ? key : -key;

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    var encryptedChar = (char)(symbol + key);
                    if (!char.IsLetter(encryptedChar))
                    {
                        encryptedChar = (char)(encryptedChar - 26);
                    }
                    encrypted += encryptedChar;
                }
                else
                {
                    encrypted += symbol;
                }
            }

            return encrypted;
        }

        public async Task<string> VigenereCipher(string text, string key, bool mode)
        {
            key = key.ToUpper();

            var result = new StringBuilder();
            var keyIndex = 0;
            var modifier = mode ? 1 : -1;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    var charIndex = char.ToUpper(c) - 'A';
                    var keyCharIndex = char.ToUpper(key[keyIndex % key.Length]) - 'A';
                    var shiftedIndex = (charIndex + modifier * keyCharIndex + 26) % 26;
                    var shiftedChar = (char)('A' + shiftedIndex);

                    result.Append(char.IsLower(c) ? char.ToLower(shiftedChar) : shiftedChar);

                    keyIndex++;
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public async Task<string> ScytaleCipher(string text, int key, bool mode)
        {
            if (mode)
            {
                var paddingLength = text.Length % key;
                if (paddingLength > 0)
                {
                    text += new string(' ', key - paddingLength);
                }

                var numColumns = text.Length / key;
                var result = string.Empty;

                for (int i = 0; i < numColumns; i++)
                {
                    for (int j = 0; j < key; j++)
                    {
                        result += text[i + numColumns * j].ToString();
                    }
                }

                return result;
            }
            else
            {
                var numColumns = text.Length / key;
                var symbols = new char[text.Length];
                var index = 0;
                for (int i = 0; i < numColumns; i++)
                {
                    for (int j = 0; j < key; j++)
                    {
                        symbols[i + numColumns * j] = text[index];
                        index++;
                    }
                }

                return new string(symbols).TrimEnd();
            }
        }

        public async Task<string> AtbashCipher(string text, bool mode)
        {
            var result = new StringBuilder();

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    char transformedChar;
                    if (mode)
                    {
                        transformedChar = (char)('Z' - (char.ToUpper(symbol) - 'A'));
                    }
                    else
                    {
                        transformedChar = (char)('A' + ('Z' - char.ToUpper(symbol)));
                    }

                    result.Append(char.IsUpper(symbol) ? char.ToUpper(transformedChar) : char.ToLower(transformedChar));
                }
                else
                {
                    result.Append(symbol);
                }
            }

            return result.ToString();
        }

        public async Task<string> Rot13Cipher(string text, bool mode)
        {
            var result = new StringBuilder();
            var modifier = mode ? 13 : -13;

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    var baseChar = char.IsUpper(symbol) ? 'A' : 'a';
                    var transformedChar = (char)(((symbol - baseChar + modifier + 26) % 26) + baseChar);

                    result.Append(transformedChar);
                }
                else
                {
                    result.Append(symbol);
                }
            }

            return result.ToString();
        }

        public async Task<string> A1Z26Cipher(string text, bool mode)
        {
            var result = new StringBuilder();

            if (mode)
            {
                foreach (char symbol in text.ToUpper())
                {
                    if (char.IsLetter(symbol))
                    {
                        var numericValue = symbol - 'A' + 1;
                        result.Append(numericValue);
                        result.Append("-");
                    }
                    else if (char.IsWhiteSpace(symbol) || char.IsPunctuation(symbol))
                    {
                        if (result.Length > 0 && result[result.Length - 1] == '-')
                        {
                            result.Length--;
                        }

                        result.Append(symbol);
                    }
                }
            }
            else
            {
                var tokens = Regex.Split(text, @"(?<!-)\b(?![ -])");

                foreach (string token in tokens)
                {
                    var parts = token.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string part in parts)
                    {
                        if (int.TryParse(part, out int numericValue))
                        {
                            var letter = (char)('A' + numericValue - 1);
                            result.Append(char.ToLower(letter));
                        }

                        foreach (char symbol in part)
                        {
                            if (char.IsPunctuation(symbol) && Convert.ToChar(symbol) != '-')
                            {
                                var lastIndex = result.Length - 1;
                                if (lastIndex >= 0 && result[lastIndex] == ' ')
                                {
                                    result.Length--;
                                }

                                result.Append(symbol);
                            }
                        }
                    }

                    result.Append(' ');
                }
            }

            return result.ToString().Trim().TrimEnd('-');
        }
    }
}
