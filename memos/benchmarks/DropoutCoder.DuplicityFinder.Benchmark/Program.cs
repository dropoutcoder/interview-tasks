using System;
using BenchmarkDotNet.Running;

namespace DropoutCoder.CodingFun.Benchmark
{
    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DuplicityFinderBenchmark>();
            Console.ReadLine();
        }
    }
}
