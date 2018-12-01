using System.IO;
using Sorting.Infrastructure.Services.Interface;

namespace Sorting.Infrastructure.Services 
{
    public class FileService : IFileService
    {
        public string GetCurrentWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public bool IsFileExists(string path)
        {
            return File.Exists(path); 
        }

        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public void WriteAllLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}