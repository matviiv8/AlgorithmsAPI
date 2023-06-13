using AlgorithmsAPI.Contracts.Algorithms;

namespace AlgorithmsAPI.Services.Algorithms
{
    public class SortService : ISortService
    {
        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

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
                        Swap(ref array[j - 1], ref array[j]);
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
                        Swap(ref array[i], ref array[j]);
                    }
                    j++;
                }

                var pivotIndex = i + 1;
                Swap(ref array[pivotIndex], ref array[right]);

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

                Swap(ref array[minIndex], ref array[i]);
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
                    Swap(ref item, ref array[position]);
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
                        Swap(ref item, ref array[position]);
                    }
                }
            }

            return array;
        }

        public async Task<int[]> CountingSort(int[] array)
        {
            var min = array.Min();
            var max = array.Max();
            var count = new int[max - min + 1];

            for(int i = 0; i < array.Length; i++)
            {
                count[array[i]-min]++;
            }

            var index = 0;

            for(int i = min; i <= max; i++)
            {
                while (count[i - min] > 0)
                {
                    array[index++] = i;
                    count[i - min]--;
                }
            }

            return array;
        }

        public async Task<int[]> CombSort(int[] array)
        {
            var gap = array.Length;
            bool swapped = true;

            while(gap != 1 || swapped == true)
            {
                gap = getNextGap(gap);
                swapped = false;

                for (int i = 0; i < array.Length - gap; i++)
                {
                    if (array[i] > array[i + gap])
                    {
                        Swap(ref array[i], ref array[i + gap]);

                        swapped = true;
                    }
                }
            }
            return array;
        }

        private int getNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            return gap < 1 ? 1 : gap;
        }

        public async Task<int[]> ShellSort(int[] array)
        {
            for (int gap = array.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    var temp = array[i];

                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }

                    array[j] = temp;
                }
            }
            
            return array;
        }

        public async Task<int[]> HeapSort(int[] array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, array.Length, i);
            }

            for (int i = array.Length - 1; i > 0; i--)
            {
                Swap(ref array[0], ref array[i]);

                Heapify(array, i, 0);
            }

            return array;
        }

        private static void Heapify(int[] array, int n, int i)
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(ref array[i], ref array[largest]);

                Heapify(array, n, largest);
            }
        }

        public async Task<int[]> MergeSort(int[] array)
        {
            var tempArray = new int[array.Length];
            Sort(array, tempArray, 0, array.Length - 1);

            return array;
        }

        private static void Sort(int[] array, int[] tempArray, int left, int right)
        {
            if (left < right)
            {
                var mid = (left + right) / 2;
                Sort(array, tempArray, left, mid);
                Sort(array, tempArray, mid + 1, right);
                Merge(array, tempArray, left, mid, right);
            }
        }

        private static void Merge(int[] array, int[] tempArray, int left, int mid, int right)
        {
            Array.Copy(array, left, tempArray, left, right - left + 1);

            var leftIndex = left;
            var rightIndex = mid + 1;
            var currentIndex = left;

            while (leftIndex <= mid && rightIndex <= right)
            {
                if (tempArray[leftIndex] <= tempArray[rightIndex])
                {
                    array[currentIndex] = tempArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[currentIndex] = tempArray[rightIndex];
                    rightIndex++;
                }
                currentIndex++;
            }

            while (leftIndex <= mid)
            {
                array[currentIndex] = tempArray[leftIndex];
                leftIndex++;
                currentIndex++;
            }

            while (rightIndex <= right)
            {
                array[currentIndex] = tempArray[rightIndex];
                rightIndex++;
                currentIndex++;
            }
        }
    }
}