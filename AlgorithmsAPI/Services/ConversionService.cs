using AlgorithmsAPI.Contracts;
using System.Runtime.CompilerServices;

namespace AlgorithmsAPI.Services
{
    public class ConversionService : IConversionService
    {
        public async Task<int[]> GetArrayNumbersFromString(string numbers)
        {
            return numbers.Split(' ').Select(int.Parse).ToArray();
        }

        public async Task<string> GetStringFromArrayNumbers(int[] array)
        {
            return string.Join(" ", array);
        }
    }
}
