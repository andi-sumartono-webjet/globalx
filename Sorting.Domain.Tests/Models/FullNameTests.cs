using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting.Domain.Models;

namespace Sorting.Domain.Tests.Models 
{ 
    [TestClass]
    public class FullNameTests 
    {
        [DataTestMethod]
        [DataRow("Apple", null, 1)]
        [DataRow(null, "Apple", -1)]
        [DataRow("Apple", "", 1)]
        [DataRow("", "Apple", -1)]
        public void CompareTo_Given_AFullNameWithThatContainASingleWord_ComparedWithFullNameWithNullOrEmptyString_ShouldReturn_TheRightValue(
            string value, 
            string stringToTest, 
            int expectedResult
        )
        {
            //arrange
            var fullNameToTest = new FullName(stringToTest);
            var fullName = new FullName(value);

            //act
            var result = fullName.CompareTo(fullNameToTest);
            
            //assert
            Assert.AreEqual(expectedResult, result, $"{value} {stringToTest}");
        }

        [DataTestMethod]
        [DataRow("Apple","Apple", 0)]
        [DataRow("Apple","Orange", -1)]
        [DataRow("Orange","Apple", 1)]
        public void CompareTo_Given_AFullNameWithThatContainASingleWord_ComparedWithFullNameWithTheSameSingleWord_ShouldReturn_TheRightValue(
            string value, 
            string stringToTest, 
            int expectedResult
        )
        {
            //arrange
            var fullNameToTest = new FullName(stringToTest);
            var fullName = new FullName(value);

            //act
            var result = fullName.CompareTo(fullNameToTest);
            
            //assert
            Assert.AreEqual(expectedResult, result, $"{value} {stringToTest}");
        }

        [DataTestMethod]
        [DataRow("Apple Orange","Apple Orange", 0)]
        [DataRow("Apple Orange","Orange Apple", 1)]
        [DataRow("Orange Apple","Apple Orange", -1)]
        public void CompareTo_Given_AFullNameWithThatContainATwoWords_ComparedWithFullNameWithTwoWords_ShouldReturn_TheRightValueBasedOnSecondWordFirst(
            string value, 
            string stringToTest, 
            int expectedResult
        )
        {
            //arrange
            var fullNameToTest = new FullName(stringToTest);
            var fullName = new FullName(value);

            //act
            var result = fullName.CompareTo(fullNameToTest);
            
            //assert
            Assert.AreEqual(expectedResult, result, $"{value} {stringToTest}");
        }



    }
}