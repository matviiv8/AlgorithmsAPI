namespace AlgorithmsAPI.Contracts
{
    public interface ISearchService
    {
        Task<int?> BinarySearch(int[] array, int item);
        Task<int?> LinearSearch(int[] array, int item);
        Task<int?> InterpolationSearch(int[] array, int item);
    }
}
