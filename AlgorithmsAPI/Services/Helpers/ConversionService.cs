using AlgorithmsAPI.Contracts.Helpers;
using System.Runtime.CompilerServices;

namespace AlgorithmsAPI.Services.Helpers
{
    public class ConversionService : IConversionService
    {
        public int[] GetArrayNumbersFromString(string numbers)
        {
            return numbers.Split(' ').Select(int.Parse).ToArray();
        }

        public string GetStringFromArrayNumbers(int[] array)
        {
            return string.Join(" ", array);
        }
    }
}
