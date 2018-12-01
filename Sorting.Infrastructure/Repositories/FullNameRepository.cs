using Sorting.Domain.Models;
using Sorting.Domain.Repositories.Interface;
using Sorting.Infrastructure.Services.Interface;
using Sorting.Infrastructure.Exceptions;
using System.Linq;

namespace Sorting.Infrastructure.Repositories 
{
    public class FullNameRepository : IFullNameRepository 
    {
        private readonly IFileService fileService;
        private string filePath;

        public FullNameRepository(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public IFullNameRepository SetFilePath(string filePath) 
        {
            this.filePath = filePath;
            return this;
        }        

        public FullName[] GetAll() 
        {           
            if (string.IsNullOrEmpty(this.filePath)) 
            {
                throw new PathNeedToBeSetException("Path need to be set first. Call SetFilePath()");
            }

            if (!this.fileService.IsFileExists(this.filePath))
            {
                throw new System.IO.FileNotFoundException($"File {this.filePath} Not Exists");
            }

            return this
                        .fileService
                        .ReadAllLines(this.filePath)
                        .Select(x=>new FullName(x))
                        .ToArray<FullName>();
        }
    }
}