using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GenericTestDataSource.Tests;

public class AddOrAppendServiceTests
{
    [Theory]
    [ClassData(typeof(GenericTestCaseData))]
    public void AddOrAppendService_Execute_Test1<T>(IAddOrAppendService<T> addOrAppendService,T first,T second, T expected)
    {
        var result = addOrAppendService.Execute(first, second);
        Assert.Equal(expected, result);
    }
}

public class GenericTestCaseData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new StringAddOrAppendService(),
            "First",
            "Second",
            "FirstSecond"
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
