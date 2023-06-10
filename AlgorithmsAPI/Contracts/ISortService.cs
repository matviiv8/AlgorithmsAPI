namespace AlgorithmsAPI.Contracts
{
    public interface ISortService
    {
        Task<int[]> BubbleSort(int[] array);
        Task<int[]> QuickSort(int[] array, int left, int right);
        Task<int[]> SelectionSort(int[] array);
        Task<int[]> InsertionSort(int[] array);
        Task<int[]> CycleSort(int[] array);
        Task<int[]> CountingSort(int[] array);
        Task<int[]> CombSort(int[] array);
        Task<int[]> ShellSort(int[] array);
        Task<int[]> HeapSort(int[] array);
        Task<int[]> MergeSort(int[] array);
    }
}
