using Sorting.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Sorting.Domain.Models;
using System.Linq;

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
    public void Sort_GivenASimpleFullNameArray_ShouldReturn_SortedArray()
    {
        //arrange
        var inputArray = new List<string> {"A", "B", "C"}
                            .Select(x=>new FullName(x))
                            .ToList();

        var expectedArray = new string[]{"A", "B", "C"};

        //act
        var result = _bubbleSort.Sort(inputArray);

        //assert 
        Assert.IsTrue(expectedArray.SequenceEqual(result.Select(x=>x.ToString()).ToArray()));
    }

}