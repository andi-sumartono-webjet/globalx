using System.Collections.Generic;
using System.Linq;
using Sorting.Domain.Models.Interface;
using Sorting.Domain.Services.Interface;

namespace Sorting.Domain.Services
{
    public class QuickSort<T> : ISort<T> where T : IComparable<T>
    {

        private void StartSort(T[] arr, int left, int right) 
        {
            int i=left, j=right; 
            T pivot = arr[(left+right)/2];

            while (i <= j) 
            {
                while (arr[i].CompareTo(pivot) < 0) 
                    i++;

                while (arr[j].CompareTo(pivot) > 0)
                    j--;

                if (i <= j)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    i++;
                    j--;
                }
            }

            if (left < j)
                StartSort(arr, left, j);
            
            if (i < right)
                StartSort(arr, i, right);
        } 


        public IList<T> Sort(IList<T> source)
        {
            var arrSource = source.ToArray();
            StartSort(arrSource, 0, source.Count-1);
            return arrSource.ToList();
        }
    }
}