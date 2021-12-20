using AutoMapper;
using BenchmarkDotNet.Running;
using BenchmarkMappers;
using BenchmarkMappers.Poco;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run(typeof(SimpleObjectSource).Assembly);
