/*
 * This file demonstrates the usage of Optional Lamda Parameters. C# 12 allows developers to 
 * provide a default value for Lamba parameters.
 * */

namespace CSharp12CoreFeatures;

internal class OptionalLamdaParametersDemo
{
    public delegate int IncrementDelegate(int number, int increment = 1);
    public IncrementDelegate Increment = (int number, int incrementCount = 1) => number + incrementCount;
}
