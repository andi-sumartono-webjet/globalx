using System.Collections.Generic;

namespace Sorting.Domain.Services.Interface
{
    public interface ISort<T> where T: IComparable<T>, new() 
    {
        IEnumerable<T> Sort(IEnumerable<T> source);
    }
}