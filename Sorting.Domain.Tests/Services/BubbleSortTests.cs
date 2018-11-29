using Sorting.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Sorting.Domain.Models;

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
    public void Sort_GivenAnEmptyArray_ShouldReturn_EmptyArray() 
    {
        //arrange
        
        //act
        var result = _bubbleSort.Sort(new List<FullName>());

        //assert
        Assert.IsNotNull(result, "result should not be null");
        Assert.AreEqual(result.Count, 0);
        
    }
}