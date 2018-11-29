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
            for(int i=0; i<source.Count-1; i++) 
            {
                for(int j=i+1; j<source.Count; j++) 
                {
                    if (source[i].CompareTo(source[j]) == 1) 
                    {
                        //swap i and j content;
                        (source[j], source[i]) = (source[i], source[j]);
                    }
                }
            }
            return source;
        }
    }
}