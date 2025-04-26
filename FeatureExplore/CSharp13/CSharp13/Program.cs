/*
 * This Project demonstrates/explore C# 13 Language Features
 *  1. params Collection
 */

using CSharp13;

Console.WriteLine("Hello C# 13");

var paramsCollection = new ParamsCollection();


//paramsCollection.AddRange(new List<string> { "Red", "Blue", "Green" }); // Before C# 13
//paramsCollection.AddRange(["Red", "Blue", "Green"]);   // Before C# 13

paramsCollection.AddRange("Red", "Blue", "Green"); //Using C# 13, paramsCollection
paramsCollection.Print();
