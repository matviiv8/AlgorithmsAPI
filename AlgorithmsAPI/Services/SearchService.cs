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
    }
}
