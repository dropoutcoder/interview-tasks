﻿using BenchmarkDotNet.Attributes;
using DropoutCoder.SmartGuideTdd.FindMultiples.Abstraction;

namespace DropoutCoder.SmartGuideTdd.FindMultiples.Benchmarks
{
    [MinColumn, MaxColumn, MemoryDiagnoser]
    public class DivisibleValueFinderBenchmarks
    {
        private readonly IDivisibleValueFinder forLoop = new ForLoopDivisibleValueFinder();
        private readonly IDivisibleValueFinder linqAggregate = new LinqAggregateDivisibleValueFinder();

        [Params(1, 3, 7)]
        public uint Base { get; set; }

        [Params(21, 278, 1321)]
        public uint Limit { get; set; }

        [Benchmark]
        public List<uint> ForLoop() => forLoop.Find(Base, Limit).ToList();

        [Benchmark]
        public List<uint> LinqAggregate() => linqAggregate.Find(Base, Limit).ToList();
    }
}
