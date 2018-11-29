using System.Collections.Generic;
using Sorting.Domain.Models.Interface;

namespace Sorting.Domain.Services.Interface
{
    public interface ISort<T> where T: IComparable<T>
    {
        IList<T> Sort(IList<T> source);
    }
}
