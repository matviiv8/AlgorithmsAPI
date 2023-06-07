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
    }
}
