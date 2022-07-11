using System;
using BenchmarkDotNet.Running;
using MongoDB.Driver.Core.Compression;
using CompressionTesting.CompressionBenchmarks;

Console.WriteLine("Benchmark to run: ");
var benchmark = Console.ReadLine();

if (benchmark == "ironsnappy")
{
    var summary1 = BenchmarkRunner.Run<IronSnappyBenchmarks>();
}
else if (benchmark == "snappier") 
{
    var summary2 = BenchmarkRunner.Run<SnappierBenchmarks>();
}
else if (benchmark == "zstdsharp")
{
    var summary3 = BenchmarkRunner.Run<ZstdSharpBenchmarks>();
}
else 
{
    Console.WriteLine("Unknown benchmark");
}