namespace AlgorithmsAPI.Contracts
{
    public interface ISortService
    {
        Task<int[]> BubbleSort(int[] array);
        Task<int[]> QuickSort(int[] array, int left, int right);
        Task<int[]> SelectionSort(int[] array);
    }
}
