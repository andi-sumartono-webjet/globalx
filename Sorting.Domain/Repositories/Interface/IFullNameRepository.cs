using Sorting.Domain.Models;

namespace Sorting.Domain.Repositories.Interface
{
    public interface IFullNameRepository : IRepository<FullName>
    {
        IFullNameRepository SetInputFilePath(string filePath); 
        IFullNameRepository SetOutputFilePath(string filePath);       
    }
}