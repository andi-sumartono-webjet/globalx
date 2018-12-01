using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using Sorting.Domain.Models;
using Sorting.Domain.Services.Interface;
using Sorting.Domain.Services;
using Sorting.Domain.Repositories.Interface;
using Sorting.Infrastructure.Repositories;
using Sorting.Infrastructure.Services;
using Sorting.Infrastructure.Services.Interface;

namespace Sorting.Console
{
    class Program
    {
        private static void ConfigureServices(IServiceCollection serviceCollection, string[] args) 
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args) 
                .Build();

            var serviceProvider = serviceCollection
                .AddOptions()
                .AddLogging()   
                .Configure<Configuration>(configuration)
                .AddSingleton<ISortingFactory<FullName>, SortingFactory<FullName>>()
                .AddSingleton<IFileService, FileService>()
                .AddTransient<IFullNameRepository, FullNameRepository>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<App>();            
        }

        static void PrintUsageInstruction() 
        {
            var currentExecutableName = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            System.Console.WriteLine($"Usage: {currentExecutableName} file-to-process.txt [--method=Bubble|--method=Quick]");
            System.Console.WriteLine($"by default bubble sort method will be used :)");
        }


        static void Main(string[] args)
        {
            if (args.Length == 0) 
            {
                PrintUsageInstruction();
            }
        
            var filePath = args[0];

            var options = args.Skip(1).ToArray(); //we're skipping the first arg because it contains filename
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, options);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<App>();
            
            try 
            {
                app.Run(filePath); 
            } 
            catch(Exception ex) 
            {
                System.Console.WriteLine($"Error when processing {filePath}");
                System.Console.WriteLine($"Message: {ex.Message}");
            }
        }
    }
}
