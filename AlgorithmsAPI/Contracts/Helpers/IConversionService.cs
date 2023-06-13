using System.Runtime.CompilerServices;

namespace AlgorithmsAPI.Contracts.Helpers
{
    public interface IConversionService
    {
        int[] GetArrayNumbersFromString(string numbers);
        string GetStringFromArrayNumbers(int[] array);
    }
}
