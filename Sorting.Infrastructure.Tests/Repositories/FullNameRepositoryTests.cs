using Moq;
using Sorting.Infrastructure.Exceptions;
using Sorting.Infrastructure.Repositories;
using Sorting.Infrastructure.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;

namespace Sorting.Infrastructure.Tests.Repository 
{
    [TestClass]
    public class FullNameRepositoryTests 
    {
        private Mock<IFileService> _fileService;
        private FullNameRepository _fullnameRepository;

        [TestInitialize]
        public void Initialize() 
        {
            _fileService = new Mock<IFileService>();
            _fullnameRepository = new FullNameRepository(_fileService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(PathNeedToBeSetException))]
        public void GetAll_Given_PathNotBeenSet_Should_ThrowPathNeedToBeSetException() 
        {
            //arrange

            //act
            _fullnameRepository.GetAll();

            //assert (will throw exception)

        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void GetAll_Given_FileNotExists_Should_ThrowFileNotFoundException() 
        {
            //arrange
            var filePath = "path";
            _fullnameRepository.SetFilePath(filePath);
            _fileService.Setup( x => x.IsFileExists(filePath) ).Returns(false);

            //act
            _fullnameRepository.GetAll();

            //assert (will throw exception)

        }

        [TestMethod]
        public void GetAll_Given_FileExists_Should_ReturnFileNameObjectArray() 
        {
            //arrange
            var filePath = "path";
            var fileContent = new string[] 
            {
                "Content1",
                "Content2"
            };

            _fullnameRepository.SetFilePath(filePath);
            _fileService.Setup( x => x.IsFileExists(filePath) ).Returns(true);
            _fileService.Setup( x => x.ReadAllLines(filePath) ).Returns(fileContent);

            //act
            var result = _fullnameRepository.GetAll();

            //assert (will throw exception)
            var resultArray = result.Select(x=>x.ToString()).ToArray();
            Assert.AreEqual(JsonConvert.SerializeObject(fileContent), JsonConvert.SerializeObject(resultArray));

        }

    }
}