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
                        int firstTemp = array[i];
                        array[i] = array[j];
                        array[j] = firstTemp;
                    }
                    j++;
                }

                var pivotIndex = i + 1;
                var secondTemp = array[pivotIndex];
                array[pivotIndex] = array[right];
                array[right] = secondTemp;

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

        public async Task<int[]> InsertionSort(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var j = i - 1;

                for(; j >= 0 && array[j] > key; j--)
                {
                    array[j + 1] = array[j];
                }
                array[j + 1] = key;
            }

            return array;
        }

        public async Task<int[]> CycleSort(int[] array)
        {
            for(int cycleStart=0;cycleStart < array.Length; cycleStart++)
            {
                var item = array[cycleStart];
                var position = cycleStart;

                for(int i = cycleStart + 1; i < array.Length; i++)
                {
                    if (array[i] < item)
                    { 
                        position++; 
                    }
                }

                if (position == cycleStart)
                {
                    continue;
                }
                
                while(item == array[position])
                {
                    position++;
                }

                if(position != cycleStart)
                {
                    var temp = item;
                    item = array[position];
                    array[position] = temp;
                }

                while(position != cycleStart)
                {
                    position = cycleStart;

                    for(int i = cycleStart + 1; i < array.Length; i++)
                    {
                        if (array[i] < item)
                        {
                            position++;
                        }
                    }

                    while (item == array[position])
                    {
                        position++;
                    }

                    if (position != array[position])
                    {
                        var temp = item;
                        item = array[position];
                        array[position] = temp;
                    }
                }
            }

            return array;
        }
    }
}