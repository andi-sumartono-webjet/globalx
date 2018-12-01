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
        private string inputFilePath, outputFilePath;

        public FullNameRepository(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public IFullNameRepository SetInputFilePath(string filePath) 
        {
            this.inputFilePath = filePath;
            return this;
        }        

        public IFullNameRepository SetOutputFilePath(string filePath)
        {
            this.outputFilePath = filePath;
            return this;
        }

        public void Save(FullName[] fullnames) 
        {
            if (string.IsNullOrEmpty(this.outputFilePath)) 
            {
                throw new PathNeedToBeSetException("Output file path need to be set first. Call SetOutputFilePath()");
            }

            this.fileService
                .WriteAllLines(this.outputFilePath, fullnames.Select(x=>x.ToString()).ToArray());
        }

        public FullName[] GetAll() 
        {           
            if (string.IsNullOrEmpty(this.inputFilePath)) 
            {
                throw new PathNeedToBeSetException("Input file path need to be set first. Call SetInputFilePath()");
            }

            if (!this.fileService.IsFileExists(this.inputFilePath))
            {
                throw new System.IO.FileNotFoundException($"File {this.inputFilePath} Not Exists");
            }

            return this
                        .fileService
                        .ReadAllLines(this.inputFilePath)
                        .Select(x=>new FullName(x))
                        .ToArray<FullName>();
        }
    }
}