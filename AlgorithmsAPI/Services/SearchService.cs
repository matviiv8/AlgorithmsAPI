using AlgorithmsAPI.Contracts;

namespace AlgorithmsAPI.Services
{
    public class SearchService : ISearchService
    {
        public async Task<int?> BinarySearch(int[] array, int item)
        {
            var low = 0;
            var high = array.Length - 1;

            while(low <= high)
            {
                var mid = low + (high - low) / 2;

                if (array[mid] == item)
                {
                    return mid;
                }

                if (array[mid] > item)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return null;
        }

        public async Task<int?> LinearSearch(int[] array, int item)
        {
            int? result = null;

            for(int i = 0;i<array.Length; i++)
            {
                if (array[i] == item)
                {
                    result = i;
                }
            }

            return result;
        }

        public async Task<int?> InterpolationSearch(int[] array, int item)
        {
            var low = 0;
            var high = array.Length - 1;

            while (!(array[high] == array[low] || item < array[low] || array[high] < item))
            {
                var mid = low + (item - array[low]) * ((high - low) / (array[high] - array[low]));

                if (array[mid] < item)
                {
                    low = mid + 1;
                }
                else if (item < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if(item == array[low])
            {
                return low;
            }

            return null;
        }

        public async Task<int?> TernarySearch(int[] array, int item)
        {
            var low = 0;
            var high = array.Length - 1;

            while (high >= low)
            {
                var firstMid = low + (high - low) / 3;
                var secondMid = high - (high - low) / 3;

                if (array[firstMid] == item)
                {
                    return firstMid;
                }
                if (array[secondMid] == item)
                {
                    return secondMid;
                }

                if(item < array[firstMid])
                {
                    high = firstMid - 1;
                }
                else if (item > array[secondMid])
                {
                    low = secondMid + 1;
                }
                else
                {
                    low = firstMid + 1;
                    high = secondMid - 1;
                }
            }

            return null;
        }

        public async Task<int?> FibonacciSearch(int[] array, int item)
        {
            var prevPrevFibonacci = 0;
            var prevFibonacci = 1;
            var currentFibonacci = prevPrevFibonacci + prevFibonacci; 

            while (currentFibonacci < array.Length)
            {
                prevPrevFibonacci = prevFibonacci;
                prevFibonacci = currentFibonacci;
                currentFibonacci = prevPrevFibonacci + prevFibonacci;
            }

            var offset = -1;

            while (currentFibonacci > 1)
            {
                var index = Math.Min(offset + prevPrevFibonacci, array.Length - 1);

                if (array[index] < item)
                {
                    currentFibonacci = prevFibonacci;
                    prevFibonacci = prevPrevFibonacci;
                    prevPrevFibonacci = currentFibonacci - prevFibonacci;
                    offset = index;
                }

                else if (array[index] > item)
                {
                    currentFibonacci = prevPrevFibonacci;
                    prevFibonacci = prevFibonacci - prevPrevFibonacci;
                    prevPrevFibonacci = currentFibonacci - prevFibonacci;
                }

                else
                {
                    return index;
                }
            }

            if (prevFibonacci != 0 && array[offset + 1] == item)
            {
                return offset + 1;
            }

            return null;
        }

        public async Task<int?> SentinelSearch(int[] array, int item)
        {
            var last = array[array.Length - 1];
            array[array.Length - 1] = item;
            int index = 0;

            while (array[index] != item)
            {
                index++;
            }
            array[array.Length - 1] = last;

            if ((index < array.Length - 1) || (array[array.Length - 1] == item))
            {
                return index;
            }
            else
            {
                return null;
            }
        }

        public async Task<int?> JumpSearch(int[] array, int item)
        {
            var step = (int)Math.Sqrt(array.Length);
            var prev = 0;

            for(int minStep = Math.Min(step, array.Length) - 1; array[minStep]<item; minStep = Math.Min(step, array.Length) - 1)
            {
                prev = step;
                step += (int)Math.Sqrt(array.Length);
                if (prev >= array.Length)
                {
                    return null;
                }
            }

            while (array[prev] < item)
            {
                prev++;

                if (prev == Math.Min(step, array.Length))
                {
                    return null;
                }
            }

            if (array[prev] == item)
            {
                return prev;
            }

            return null;
        }
    }
}
