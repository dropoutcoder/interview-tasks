using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DropoutCoder.DuplicityFinder.Core;

namespace DropoutCoder.DuplicityFinder.Benchmark
{
    [MemoryDiagnoser]
    public class DuplicityFinderBenchmark
    {
        private int[] source;

        private static IValueGenerator<int> _generator = new Int32Generator();

        private IDuplicityFinder<int> _forLoopDuplicityFinder = new ForLoopDuplicityFinder<int>();
        private IDuplicityFinder<int> _hashsetDuplicityFinder = new HashsetDuplicityFinder<int>();
        private IDuplicityFinder<int> _linqDuplicityFinder = new LinqDuplicityFinder<int>();

        [Params(1000, 10000)]
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
            _forLoopDuplicityFinder.Find(source).Consume(_consumer);
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
