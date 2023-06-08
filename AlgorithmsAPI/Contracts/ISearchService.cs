namespace AlgorithmsAPI.Contracts
{
    public interface ISearchService
    {
        Task<int?> BinarySearch(int[] array, int item);
        Task<int?> LinearSearch(int[] array, int item);
        Task<int?> InterpolationSearch(int[] array, int item);
        Task<int?> TernarySearch(int[] array, int item);
        Task<int?> FibonacciSearch(int[] array, int item);
        Task<int?> SentinelSearch(int[] array, int item);
        Task<int?> JumpSearch(int[] array, int item);
    }
}
