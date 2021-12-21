using AutoMapper;
using BenchmarkDotNet.Running;
using BenchmarkMappers;
using BenchmarkMappers.Poco;

Console.WriteLine("Hello, World!");

//BenchmarkRunner.Run(typeof(SingleEntityCompare).Assembly);
BenchmarkRunner.Run(typeof(CollectionCompare).Assembly);
