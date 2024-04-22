/*
 * This file demonstrates the usage of Collection Expression in C# 12. Collection Expression was introduced 
 * in C# 12, .Net 8 and is used to create inline collections.
 * */

namespace CSharp12CoreFeatures;

internal class CollectionExpressionsDemo
{
    // Creating collection Property using Collection Expression
    public IEnumerable<string> OfficeLocatons => ["India", "Germany"];

    public int EmployeeHeadCount(IEnumerable<int> employeesPerLocation) => employeesPerLocation.Sum();

    public void PrintEmployeeCount()
    {
        // Pass collection expression in parameter
        var headCount = EmployeeHeadCount([10, 12, 12]);
        Console.WriteLine($"Head Count {headCount}");
    }

    public string[] DirectorsInIndia => ["John Doe", "Jane Doe"];

    public string[] DirectorsInGermany => ["Jacob Doe", "Joseph Doe"];


    // Inlining collection into other variables using Spread Operator
    public string[] DirectorsWorldWide => [..DirectorsInIndia, ..DirectorsInGermany];
}
