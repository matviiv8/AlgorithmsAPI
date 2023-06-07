using System.Runtime.CompilerServices;

namespace AlgorithmsAPI.Contracts
{
    public interface IConversionService
    {
        Task<int[]> GetArrayNumbersFromString(string numbers);
        Task<string> GetStringFromArrayNumbers(int[] array);
    }
}
