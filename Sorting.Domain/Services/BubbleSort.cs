using System.Collections.Generic;
using Sorting.Domain.Services.Interface;

namespace Sorting.Domain.Services 
{
    public class BubbleSort<T> : ISort<T> where T : IComparable<T>, new()
    {
        public IEnumerable<T> Sort(IEnumerable<T> source)
        {
            return new List<T>();
        }
    }
}