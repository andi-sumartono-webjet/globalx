using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sorting.Domain.Models;
using Sorting.Domain.Repositories.Interface;
using Sorting.Domain.Services.Interface;
using Sorting.Infrastructure.Services.Interface;

namespace Sorting.Console
{
    public class App 
    {
        private readonly IOptions<Configuration> config;
        private readonly IFileService fileService;
        private readonly ILogger<App> logger;
        private readonly ISortingFactory<FullName> sortingFactory;
        private readonly IFullNameRepository repository;

        
        public App(
            ISortingFactory<FullName> sortingFactory, 
            IFullNameRepository repository,
            IOptions<Configuration> config, 
            IFileService fileService,
            ILogger<App> logger
        )
        {
            this.config = config;
            this.fileService = fileService;
            this.logger = logger;
            this.sortingFactory = sortingFactory;
            this.repository = repository;
        }
        
        public void Run(string filePath)
        {
            SortingMethodEnum sortingMethod;

            if (string.IsNullOrEmpty(filePath))
            {
                throw new System.ArgumentNullException("Missing filePath");
            }
            
            if (!Enum.TryParse<SortingMethodEnum>(config.Value.method, true, out sortingMethod)) {
                sortingMethod = default(SortingMethodEnum);
            }
            
            try 
            {
                var allNames = this.repository
                                .SetInputFilePath(filePath)
                                .GetAll();
                
                var result = this
                            .sortingFactory
                            .GetSortingMethod(sortingMethod)
                            .Sort(allNames)
                            .ToArray();

                var outputFilePath = Path.Combine(
                                        fileService.GetCurrentWorkingDirectory(), 
                                        config.Value.output ?? "sorted-names-list.txt"
                                    );

                this.repository
                        .SetOutputFilePath(outputFilePath)
                        .Save(result);            

            } 
            catch (Exception ex) 
            {
                this.logger.LogError(ex, $"Error while processing file {filePath}");
                throw;
            }
        }
    }
}