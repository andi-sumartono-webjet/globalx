using Sorting.Domain.Models;
using Sorting.Domain.Models.Interface;

namespace Sorting.Domain.Services.Interface
{
    public interface ISortingFactory<T> where T : IComparable<T>
    {
        ISort<T> GetSortingMethod(SortingMethodEnum method); 
    }
}
