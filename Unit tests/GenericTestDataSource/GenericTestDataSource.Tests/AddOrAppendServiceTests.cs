using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GenericTestDataSource.Tests;
public class AddOrAppendServiceTests
{
    [Theory]
    [ClassData(typeof(TestCaseData))]
    public void AddOrAppendService_Execute_Test(IServiceTestRunner tester)
    {
       tester.ExecuteTests();
    }
}

public interface IServiceTestRunner
{
    void ExecuteTests();
}

public class ServiceTestRunner<T> : IServiceTestRunner 
{
    public IAddOrAppendService<T> SUT { get; set; }
    public T First { get; set; }
    public T Second { get; set; }
    public T ExpectedResult { get; set; }
    public void ExecuteTests()
    {
        var actualResult = SUT.Execute(First,Second);
        Assert.Equal(ExpectedResult, actualResult);
    }
}
public class TestCaseData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
             new ServiceTestRunner<string> { SUT = new StringAddOrAppendService(), First = "First", Second = "Second", ExpectedResult = "FirstSecond" }
        };

        yield return new object[]
        {
             new ServiceTestRunner<int> { SUT = new IntAddOrAppendService(), First = 1, Second = 2, ExpectedResult = 3}
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
