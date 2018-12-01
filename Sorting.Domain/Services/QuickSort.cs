using System.Collections.Generic;
using System.Linq;
using Sorting.Domain.Models.Interface;
using Sorting.Domain.Services.Interface;

namespace Sorting.Domain.Services
{
    public class QuickSort<T> : ISort<T> where T : IComparable<T>
    {

        private int GetPartition(T[] arr, int left, int right) 
        {
            T pivot = arr[left];
            while (true) 
            {
                while (arr[left].CompareTo(pivot) == -1)  
                    left++;

                while (arr[right].CompareTo(pivot) == 1)
                    right--;

                if (left < right)
                {
                    if (arr[left].CompareTo(arr[right]) == 0) return right;
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                }
                else 
                {
                    return right;
                }
            }
        } 

        private void StartSort(T[] arr, int left, int right) 
        {
            if (left > right) return;
            int pivot = GetPartition(arr, left, right);

            if (pivot > 1) {
                GetPartition(arr, left, pivot - 1);
            }
            if (pivot + 1 < right) {
                GetPartition(arr, pivot + 1, right);
            }
        }

        public IList<T> Sort(IList<T> source)
        {
            var arrSource = source.ToArray();
            StartSort(arrSource, 0, source.Count);
            return arrSource.ToList();
        }
    }
}