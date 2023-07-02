using AlgorithmsAPI.Contracts.Algorithms;
using System.Text;

namespace AlgorithmsAPI.Services.Algorithms
{
    public class StringsService : IStringsService
    {
        public async Task<bool> IsStringPalindrom(string text)
        {
            for(int i= 0; i < text.Length / 2; i++)
            {
                if (char.ToUpper(text[i]) != char.ToUpper(text[text.Length - i - 1]))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<List<string>> GetEveryUniquePermutation(string text)
        {
            if (text.Length < 2)
            {
                return new List<string>
                {
                    text,
                };
            }

            var result = new HashSet<string>();

            for (var i = 0; i < text.Length; i++)
            {
                var temp = await GetEveryUniquePermutation(text.Remove(i, 1));

                result.UnionWith(temp.Select(subPerm => text[i] + subPerm));
            }

            return result.ToList();
        }

        public async Task<List<int>> FindSubstring(string text, string substring)
        {
            var indices = new List<int>();
            var textLength = text.Length;
            var substringLength = substring.Length;

            for (int i = 0; i <= textLength - substringLength; i++)
            {
                var match = true;

                for (int j = 0; j < substringLength; j++)
                {
                    if (text[i + j] != substring[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    indices.Add(i);
                }
            }

            return indices;
        }

        public async Task<string> ReverseString(string text)
        {
            var chars = text.ToCharArray();
            var left = 0;
            var right = chars.Length - 1;

            while (left < right)
            {
                var temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;

                left++;
                right--;
            }

            return new string(chars);
        }

        public async Task<string> ReplaceSubstring(string text, string substring, string replacement)
        {
            var result = new StringBuilder();
            var startIndex = 0;
            var index = text.IndexOf(substring, startIndex);

            while (index != -1)
            {
                result.Append(text.Substring(startIndex, index - startIndex));
                result.Append(replacement);

                startIndex = index + substring.Length;
                index = text.IndexOf(substring, startIndex);
            }

            result.Append(text.Substring(startIndex));

            return result.ToString();
        }
    }
}
