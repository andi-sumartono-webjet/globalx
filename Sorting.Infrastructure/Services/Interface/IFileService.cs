namespace Sorting.Infrastructure.Services.Interface
{
    public interface IFileService
    {
        bool IsFileExists(string path);
        string[] ReadAllLines(string path);
        void WriteAllLines(string path, string[] lines);       

        string GetCurrentWorkingDirectory(); 
    }
}