using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting.Domain.Models;
using Sorting.Domain.Repositories.Interface;
using Sorting.Domain.Services.Interface;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sorting.Infrastructure.Services.Interface;

namespace Sorting.Console.Tests
{
    [TestClass]
    public class AppTests
    {
        private Mock<ISortingFactory<FullName>> _sortingFactory;
        private Mock<IFullNameRepository> _fullNameRepository;
        private Mock<IOptions<Configuration>> _configuration;
        private Mock<ILogger<App>> _logger;
        private Mock<IFileService> _fileService;
        private Mock<ISort<FullName>> _sort;
        private App _app;
        private FullName[] _getAllFake = new [] {new FullName("a")};
        private FullName[] _sortReturnFake = new [] {new FullName("a")};
        private Configuration _fakeConfiguration = new Configuration();

        [TestInitialize]
        public void Initializer()
        {
            _sortingFactory = new Mock<ISortingFactory<FullName>>();
            _fullNameRepository = new Mock<IFullNameRepository>();
            _configuration = new Mock<IOptions<Configuration>>();
            _logger = new Mock<ILogger<App>>();
            _fileService = new Mock<IFileService>();
            _sort = new Mock<ISort<FullName>>();

            _app = new App(
                _sortingFactory.Object, 
                _fullNameRepository.Object, 
                _configuration.Object, 
                _fileService.Object,
                _logger.Object
            ); 
                        
            _configuration
                .Setup( x => x.Value )
                .Returns(_fakeConfiguration);

            _fullNameRepository
                .Setup( x => x.SetInputFilePath(It.IsAny<string>()))
                .Returns(_fullNameRepository.Object);
            
            _fullNameRepository
                .Setup( x => x.GetAll())
                .Returns(_getAllFake);

            _fullNameRepository
                .Setup( x => x.SetOutputFilePath(It.IsAny<string>()))
                .Returns(_fullNameRepository.Object);
            
            _sortingFactory
                .Setup( x => x.GetSortingMethod(It.IsAny<SortingMethodEnum>()))
                .Returns(_sort.Object);
            
            _sort
                .Setup( x => x.Sort(It.IsAny<FullName[]>()))
                .Returns(_sortReturnFake);

            _fileService
                .Setup ( x => x.GetCurrentWorkingDirectory() )
                .Returns(string.Empty);

        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Run_Given_NullParameter_Should_ThrowArgumentNullException()
        {
            //act
            _app.Run(null);

            //assert - will throw argument null exception
        }

        [TestMethod]
        public void Run_Given_NoParameter_Should_UseBubbleSortAsTheSortingMethod()
        {
            //arrange            
            SortingMethodEnum sortingMethodEnum = default(SortingMethodEnum);
            
            _sortingFactory
                .Setup( x => x.GetSortingMethod(It.IsAny<SortingMethodEnum>()))
                .Callback<SortingMethodEnum>((x) => { sortingMethodEnum = x; })
                .Returns(_sort.Object);

            
            //act
            _app.Run("blah.txt");

            //assert
            Assert.AreEqual(SortingMethodEnum.Bubble, sortingMethodEnum);
        }

        [TestMethod]
        public void Run_Given_MethodParameterIsSet_Should_UseMethodParametersSortingMethod()
        {
            //arrange
            _fakeConfiguration = new Configuration { method = "Quick" };
            _configuration
                .Setup( x => x.Value )
                .Returns(_fakeConfiguration);

            SortingMethodEnum sortingMethodEnum = SortingMethodEnum.Bubble;
            
            _sortingFactory
                .Setup( x => x.GetSortingMethod(It.IsAny<SortingMethodEnum>()))
                .Callback<SortingMethodEnum>((x) => { sortingMethodEnum = x; })
                .Returns(_sort.Object);

            
            //act
            _app.Run("blah.txt");

            //assert
            Assert.AreEqual(SortingMethodEnum.Quick, sortingMethodEnum);
        }

        [TestMethod]
        public void Run_Given_MethodParameterIsNotSet_Should_UseDefaultFileAsOutput()
        {
            //arrange
            string outputFile = null;
            
            _fullNameRepository
                .Setup( x => x.SetOutputFilePath(It.IsAny<string>()))
                .Callback<string>((x) => { outputFile = x; })
                .Returns(_fullNameRepository.Object);
            
            //act
            _app.Run("blah.txt");

            //assert
            Assert.AreEqual("sorted-names-list.txt", outputFile);
        }

        [TestMethod]
        public void Run_Given_MethodParameterOutputFileIsSet_Should_UseOutputFileNameAsDefinedInParameter()
        {
            //arrange
            _fakeConfiguration = new Configuration { output = "xxx.txt" };
            _configuration
                .Setup( x => x.Value )
                .Returns(_fakeConfiguration);

            string outputFile = null;
            
            _fullNameRepository
                .Setup( x => x.SetOutputFilePath(It.IsAny<string>()))
                .Callback<string>((x) => { outputFile = x; })
                .Returns(_fullNameRepository.Object);
            
            //act
            _app.Run("blah.txt");

            //assert
            Assert.AreEqual("xxx.txt", outputFile);
        }

    }
}
