using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using Sorting.Domain.Models;
using Sorting.Domain.Repositories.Interface;
using Sorting.Domain.Services.Interface;

namespace Sorting.Console
{
    public class App 
    {
        private readonly IOptions<Configuration> config;
        private readonly ISortingFactory<FullName> sortingFactory;
        private readonly IFullNameRepository repository;

        
        public App(
            IOptions<Configuration> config, 
            ISortingFactory<FullName> sortingFactory, 
            IFullNameRepository repository)
        {
            this.config = config;
            this.sortingFactory = sortingFactory;
            this.repository = repository;
        }
        
        public void Run(string filePath)
        {
            SortingMethodEnum sortingMethod;
            
            if (!Enum.TryParse<SortingMethodEnum>(config.Value.method, true, out sortingMethod)) {
                sortingMethod = default(SortingMethodEnum);
            }
            
            var allNames = this.repository
                            .SetInputFilePath(filePath)
                            .GetAll();
            
            var result = this
                        .sortingFactory
                        .GetSortingMethod(sortingMethod)
                        .Sort(allNames)
                        .ToArray();

            var outputFilePath = Path.Combine(
                                    Directory.GetCurrentDirectory(), 
                                    config.Value.output ?? "sorted-names-list.txt"
                                );

            this.repository
                    .SetOutputFilePath(filePath)
                    .Save(result);            
        }
    }
}