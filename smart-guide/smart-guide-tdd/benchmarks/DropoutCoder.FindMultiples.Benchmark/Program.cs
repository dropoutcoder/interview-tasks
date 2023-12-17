using BenchmarkDotNet.Running;

namespace DropoutCoder.SmartGuideTdd.FindMultiples.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner
                .Run<DivisibleValueFinderBenchmarks>();
        }
    }
}