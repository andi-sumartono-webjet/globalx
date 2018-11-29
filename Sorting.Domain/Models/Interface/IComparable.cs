namespace Sorting.Domain.Models.Interface
{
    public interface IComparable<T>
    {
        int CompareTo(T obj);
    }
}