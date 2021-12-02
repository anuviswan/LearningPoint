using BenchmarkDotNet.Running;
using BenchmarkForEach;

var summary = BenchmarkRunner.Run<LoopTest>();
