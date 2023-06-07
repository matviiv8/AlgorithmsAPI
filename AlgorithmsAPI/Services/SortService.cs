using AlgorithmsAPI.Contracts;

namespace AlgorithmsAPI.Services
{
    public class SortService : ISortService
    {
        public async Task<int[]> BubbleSort(int[] array)
        {
            bool swapped = true;
            int i = 0;

            while (swapped)
            {
                swapped = false;
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        swapped = true;
                    }
                }
                i++;
            }
            return array;
        }

        public async Task<int[]> QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                var pivot = array[right];
                var i = left - 1;
                var j = left;

                while (j < right)
                {
                    if (array[j] <= pivot)
                    {
                        i++;
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                    j++;
                }

                var pivotIndex = i + 1;
                var temp2 = array[pivotIndex];
                array[pivotIndex] = array[right];
                array[right] = temp2;

                await QuickSort(array, left, pivotIndex - 1);
                await QuickSort(array, pivotIndex + 1, right);
            }

            return array;
        }

        public async Task<int[]> SelectionSort(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                var minIndex = i;

                for(int j=i+1;j<array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex= j;
                    }
                }

                var temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
            return array;
        }
    }
}