using BenchmarkDotNet.Running;

namespace DropoutCoder.SmartGuideTdd.GameOfLife.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner
                .Run<GameOfLifeBenchmark>();
        }
    }
}