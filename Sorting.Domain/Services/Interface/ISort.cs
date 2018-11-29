using System.Collections.Generic;

namespace Sorting.Domain.Services.Interface
{
    public interface ISort<T> where T: IComparable<T>, new() 
    {
        IList<T> Sort(IList<T> source);
    }
}