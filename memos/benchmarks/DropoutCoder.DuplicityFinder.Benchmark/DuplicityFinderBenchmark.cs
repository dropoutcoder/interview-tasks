using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using DropoutCoder.DuplicityFinder.Core;
using DropoutCoder.DuplicityFinder.Core;

namespace DropoutCoder.DuplicityFinder.Benchmark
{
    [MemoryDiagnoser]
    public class DuplicityFinderBenchmark
    {
        private int[] source;

        private static IValueGenerator<int> _generator = new Int32Generator();
        private IDuplicityFinder<int> _hashsetDuplicityFinder = new HashsetDuplicityFinder<int>();
        private IDuplicityFinder<int> _linqDuplicityFinder = new LinqDuplicityFinder<int>();

        [Params(1_000, 10_000, 100_000, 1_000_000)]
        public uint Count;

        private Consumer _consumer = new Consumer();

        [GlobalSetup]
        public void Setup()
        {
            var initializer = new ArrayInitializer<int>(_generator);

            source = initializer.Initialize(Count);
        }

        [Benchmark]
        public void ForLoop()
        {
            _hashsetDuplicityFinder.Find(source).Consume(_consumer);
        }

        [Benchmark]
        public void Hashset()
        {
            _hashsetDuplicityFinder.Find(source).Consume(_consumer);
        }

        [Benchmark]
        public void Linq()
        {
            _linqDuplicityFinder.Find(source).Consume(_consumer);
        }
    }
}
