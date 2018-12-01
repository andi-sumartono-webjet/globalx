namespace Sorting.Domain.Repositories.Interface
{
    public interface IRepository<T>
    {
        T[] GetAll();
        void Save(T[] items);
    }
}