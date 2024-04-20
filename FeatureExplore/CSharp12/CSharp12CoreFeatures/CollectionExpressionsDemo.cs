using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
