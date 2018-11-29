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
            Assert.AreEqual(expectedResult, result, $"Failed when comparing '{value}' and '{stringToTest}'");
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
            Assert.AreEqual(expectedResult, result, $"Failed when comparing '{value}' and '{stringToTest}'");
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
            Assert.AreEqual(expectedResult, result, $"Failed when comparing '{value}' and '{stringToTest}'");
        }

        [DataTestMethod]
        [DataRow("Apple           Orange","  Apple      Orange", 0)]
        [DataRow("Apple     Orange","    Orange                Apple    ", 1)]
        [DataRow("Orange                            Apple","     Apple Orange", -1)]
        public void CompareTo_Given_AFullNameWithThatContainATwoWordsWithMultipleSpaces_ComparedWithFullNameWithTwoWordsWithMultipleSpaces_ShouldReturn_TheRightValue(
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
            Assert.AreEqual(expectedResult, result, $"Failed when comparing '{value}' and '{stringToTest}'");
        }

        [DataTestMethod]
        [DataRow("Apple Orange Pinnaple","Apple Orange Pinnaple", 0)]
        [DataRow("Apple Pinnaple Orange","Apple Pinnaple Apple", 1)]
        [DataRow("Apple Pinnaple Apple","Apple Pinnaple Orange", -1)]
        [DataRow("Apple Orange Pinnaple","Apple Apple Pinnaple", 1)]
        [DataRow("Apple Apple Pinnaple","Apple Orange Pinnaple", -1)]
        [DataRow("Orange Pinnaple Orange","Apple Pinnaple Orange", 1)]
        [DataRow("Apple Pinnaple Orange","Orange Pinnaple Orange", -1)]
        public void CompareTo_Given_AFullNameWithThatContainAThreeWords_ComparedWithFullNameWithThreeWords_ShouldReturn_TheRightValue(
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
            Assert.AreEqual(expectedResult, result, $"Failed when comparing '{value}' and '{stringToTest}'");
        }

        [DataTestMethod]
        [DataRow("Janet Parsons","Marin Alvarez", 1)]
        [DataRow("Vaughn Lewis","Adonis Julius Archer", 1)]
        [DataRow("Adonis Julius Archer","Beau Tristan Bentley", -1)]
        [DataRow("Shelby Nathan Yoder","Hunter Uriah Mathew Clarke", 1)]
        [DataRow("Marin Alvarez","Hunter Uriah Mathew Clarke", -1)]
        public void CompareTo_Given_AFullNameWithThatContainRandomNames_ComparedWithFullNameWithRandomNames_ShouldReturn_TheRightValue(
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
            Assert.AreEqual(expectedResult, result, $"Failed when comparing '{value}' and '{stringToTest}'");
        }

    }
}