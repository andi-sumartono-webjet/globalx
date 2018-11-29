using System.Collections.Generic;
using Sorting.Domain.Models.Interface;
using Sorting.Domain.Services.Interface;

namespace Sorting.Domain.Services 
{
    public class BubbleSort<T> : ISort<T> where T: IComparable<T>
    {

        public BubbleSort()
        {
        }

        public IList<T> Sort(IList<T> source)
        {
            return new List<T>();
        }
    }
}