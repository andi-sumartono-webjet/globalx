using Sorting.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Sorting.Domain.Models;
using System.Linq;
using System;

[TestClass]
public class BubbleSortTests 
{
    private BubbleSort<FullName> _bubbleSort;

    [TestInitialize]
    public void Initializer()
    {
        _bubbleSort = new BubbleSort<FullName>();

    }

    [TestMethod]
    public void Sort_GivenAnEmptyFullNameArray_ShouldReturn_EmptyArray() 
    {
        //arrange
        
        //act
        var result = _bubbleSort.Sort(new List<FullName>());

        //assert
        Assert.IsNotNull(result, "result should not be null");
        Assert.AreEqual(result.Count, 0);
        
    }

    [TestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    public void Sort_GivenASimpleFullNameArray_ShouldReturn_SortedArray(string[] input, string[] expectedOutput)
    {
        //arrange
        var inputArray = input
                            .Select(x=>new FullName(x))
                            .ToList();

        //act
        var result = _bubbleSort.Sort(inputArray);

        //assert
        var arrayResult = result.Select(x=>x.ToString()).ToArray(); 
        
        Assert.IsTrue(expectedOutput.SequenceEqual(arrayResult));
    }

    private static IEnumerable<object[]> GetData()
    {        
        yield return new object[] { 
            new []
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            }, 
            new[]
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder"   
            } 
        };

    }
}