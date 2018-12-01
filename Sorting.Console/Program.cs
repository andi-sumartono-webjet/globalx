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
                .AddSingleton<ISortingFactory<FullName>, SortingFactory<FullName>>()
                .AddTransient<IFullNameRepository, FullNameRepository>()
                .AddTransient<App>();            
        }

        static void Usage(string exeName) 
        {
            System.Console.WriteLine($"Usage: {exeName} file-to-process.txt [--method=Bubble|--method=Quick]");
            System.Console.WriteLine($"by default bubble sort method will be used. Method values are case sensitive :)");
        }


        static void Main(string[] args)
        {
            var currentExecutableName = args[0];
            if (args.Length < 2) 
            {
                Usage(currentExecutableName);
            }
        
            var filePath = args[1];

            var options = args.Skip(1).ToArray(); //we're skipping the first arg because it contains filename
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, options);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<App>();
            app.Run(filePath); 
        }
    }
}
